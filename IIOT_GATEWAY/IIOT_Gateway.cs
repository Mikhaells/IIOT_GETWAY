using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using MQTTnet;
using MQTTnet.Client;
using static System.Runtime.InteropServices.JavaScript.JSType;
using IIOT_GATEWAY;

namespace IIOT_GATEWAY
{
    public partial class IIOT_Gateway : Form
    {
        private static readonly HttpClient client = new HttpClient();
        
        private IMqttClient mqttClient;
        public Controller cnt = new Controller();    
        public IIOT_Gateway()
        {
            client.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            client.DefaultRequestHeaders.Add("Custom-Header", "HeaderValue");

            InitializeComponent();
            btSearch.Click += BtSearch_Click;
            trDeviceList.AfterSelect += TrDeviceList_AfterSelect;
        }

        private void TrDeviceList_AfterSelect(object? sender, TreeViewEventArgs e)
        {
            if (e.Node.Text == "WLAN")
            {
                
                PublishTopicAsync(cnt.CreateJsonString("GetIpAddress","wlan0"));
            }
            if (e.Node.Text == "Ethernet")
            {
                PublishTopicAsync(cnt.CreateJsonString("GetIpAddress", "eth0"));
            }
            if (e.Node.Text == "Get Data")
            {
                pnlHome.Controls.Clear();
                GetDataForm Getdata = new GetDataForm(this);
                Getdata.Dock = DockStyle.Fill;
                pnlHome.Controls.Add(Getdata); 
            }
            if (e.Node.Text == "Set Data")
            {
                pnlHome.Controls.Clear();
                SetDataForm Setdata = new SetDataForm(this);
                Setdata.Dock = DockStyle.Fill;
                pnlHome.Controls.Add(Setdata);
            }
        }

        private void BtSearch_Click(object? sender, EventArgs e)
        {
            GetDeviceAPIAsync();
            createTreeView();
            ConnectMQTTAsync();
        }

        public async Task GetDeviceAPIAsync()
        {
            string antaresUrl = "https://platform.antares.id:8443/~/antares-cse/antares-id/IIOT_GATEWAY/Raspberry_PI";
            string apiKey = "2c8489c626d81199:3aa45962c7db0414"; 

            try
            {
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add("X-M2M-Origin", apiKey);
                client.DefaultRequestHeaders.Add("Accept", "application/json");

                HttpResponseMessage response = await client.GetAsync(antaresUrl);
                response.EnsureSuccessStatusCode();
                 


                // Baca data respons
                string responseBody = await response.Content.ReadAsStringAsync();  
                JObject parsedData = JObject.Parse(responseBody);
                string rnValue = (string)parsedData["m2m:cnt"]?["rn"]; 
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "API Error");
            }
        }


        private void createTreeView()
        {
            trDeviceList.Nodes.Clear();
            pnlHome.Controls.Clear();

            TreeNode rootNode = new TreeNode("Raspberry PI"); 
            
            TreeNode childNode1 = new TreeNode("Connection");
            TreeNode childNode2 = new TreeNode("Get Data");
            TreeNode childNode3 = new TreeNode("Set Data");

            TreeNode ConChildNode1 = new TreeNode("WLAN");
            TreeNode ConChildNode2 = new TreeNode("Ethernet");


            childNode1.Nodes.Add(ConChildNode1);
            childNode1.Nodes.Add(ConChildNode2);



            rootNode.Nodes.Add(childNode1);
            rootNode.Nodes.Add(childNode2);
            rootNode.Nodes.Add(childNode3);

            trDeviceList.Nodes.Add(rootNode);
        }


        public async Task ConnectMQTTAsync()
        {
            var factory = new MqttFactory();
            mqttClient = factory.CreateMqttClient();

            var options = new MqttClientOptionsBuilder()
                .WithTcpServer("mqtt.antares.id", 1883)
                .WithCredentials("", "") 
                .WithCleanSession()
                .Build();

            mqttClient.ConnectedAsync += async args =>
            {
                Invoke(new Action(() =>
                {
                    lblInfo.Text = "Connected to Antares MQTT Server!";
                    lblInfo.ForeColor = Color.Green;
                }));
                SubscribeTopicAsync();

            };

            
            mqttClient.DisconnectedAsync += async args =>
            {
                Invoke(new Action(() =>
                {
                    lblInfo.Text = "Disconnected from Antares MQTT Server.";
                    lblInfo.ForeColor = Color.Red;
                   
                }));
            };

           
            try
            {
                await mqttClient.ConnectAsync(options);
            }
            catch (Exception ex)
            {
                lblInfo.Text = $"Failed to connect: {ex.Message}";
                lblInfo.ForeColor = Color.Red;
            }


        }

        private async Task SubscribeTopicAsync()
        {
            string topic = "/oneM2M/resp/antares-cse/2c8489c626d81199:3aa45962c7db0414/json"; 
            try
            {
                await mqttClient.SubscribeAsync(new MqttTopicFilterBuilder().WithTopic(topic).Build()); 
            }
            catch (Exception ex)
            {
                lblInfo.Text = $"Failed to connect: {ex.Message}";
                lblInfo.ForeColor = Color.Red;
            }

            
            mqttClient.ApplicationMessageReceivedAsync += async args =>
            {
                string receivedMessage = Encoding.UTF8.GetString(args.ApplicationMessage.Payload);
                Invoke(new Action(() =>
                {

                    var jsonObject = JObject.Parse(receivedMessage); 
                    string cnf = jsonObject["m2m:rsp"]?["pc"]?["m2m:cin"]?["cnf"]?.ToString();
                    string con = jsonObject["m2m:rsp"]?["pc"]?["m2m:cin"]?["con"]?.ToString();

                    if (cnf == "IP Address")
                    {
                        pnlHome.Controls.Clear();
                        IPInfoForm ip = new IPInfoForm();
                        ip.Dock = DockStyle.Fill;
                        pnlHome.Controls.Add(ip);
                        ip.TextBoxValue = con;
                    }


                    //MessageBox.Show($"[{args.ApplicationMessage.Topic}] {receivedMessage}"); 
                }));
            }; 
        }

        public async Task PublishTopicAsync(string json)
        {
            if (mqttClient == null || !mqttClient.IsConnected)
            {
                MessageBox.Show("Please connect to the MQTT server first.");
                return;
            }

            string topic = "/oneM2M/req/2c8489c626d81199:3aa45962c7db0414/antares-cse/json"; 
            string payload = json; 

            try
            {
                var message = new MqttApplicationMessageBuilder()
                    .WithTopic(topic)
                    .WithPayload(payload)
                    .WithQualityOfServiceLevel(MQTTnet.Protocol.MqttQualityOfServiceLevel.AtMostOnce) 
                    .Build();

                await mqttClient.PublishAsync(message);
                //MessageBox.Show($"Message published to topic: {topic}");
            }
            catch (Exception ex)
            {
                lblInfo.Text = $"Failed to publish message: {ex.Message}";
                lblInfo.ForeColor = Color.Red;
            }
        }

       

    }
}
