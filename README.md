# IIOT_GATEWAY - Industrial IoT Gateway

Gateway aplikasi Windows Forms untuk mengintegrasikan perangkat Industrial IoT (Raspberry Pi) dengan platform Antares menggunakan protokol MQTT dan Modbus TCP, dengan backend REST API.

## 📋 Daftar Isi

1. [Overview](#overview)
2. [Fitur Utama](#fitur-utama)
3. [Teknologi & Dependencies](#teknologi--dependencies)
4. [Instalasi & Setup](#instalasi--setup)
5. [Arsitektur Sistem](#arsitektur-sistem)
6. [Struktur Project](#struktur-project)
7. [Cara Penggunaan](#cara-penggunaan)
8. [API & Protokol](#api--protokol)
9. [Konfigurasi](#konfigurasi)
10. [Troubleshooting](#troubleshooting)

---

## Overview

**IIOT_GATEWAY** adalah aplikasi desktop yang bertindak sebagai jembatan antara:
- **Perangkat IoT** (Raspberry Pi dengan Modbus TCP)
- **Platform Cloud** (Antares M2M)
- **User Interface** (Windows Forms Application)

Aplikasi ini memungkinkan user untuk:
- Monitor status koneksi jaringan (WLAN/Ethernet)
- Mendapatkan data dari PLC/Device melalui Modbus TCP
- Mengirim perintah ke PLC/Device
- Berkomunikasi melalui protokol MQTT dengan Antares IoT Platform

## 🎯 Fitur Utama

### 1. **Device Management**
- Daftar perangkat IoT yang terhubung (Raspberry Pi)
- Navigasi hierarchical device tree
- Status koneksi real-time

### 2. **Network Information**
- Lihat informasi IP Address
- Support untuk WLAN (wlan0) dan Ethernet (eth0)
- IP information form untuk display data jaringan

### 3. **Data Acquisition**
- Get Data dari PLC/Device
- Modbus TCP client untuk membaca coil/register
- DataGridView untuk menampilkan data real-time
- Custom IP address input untuk target device

### 4. **Data Control**
- Set Data ke PLC/Device
- Write coil/register via Modbus TCP
- Input form untuk IP, coil address, dan value
- Real-time feedback

### 5. **MQTT Communication**
- Connect/disconnect ke Antares MQTT Broker
- Publish JSON message ke topic
- Subscribe ke response topic
- Async message handling dengan callback

### 6. **REST API Integration**
- GET request ke Antares API untuk device info
- X-M2M-Origin authentication
- JSON response parsing dengan Newtonsoft.Json

---

## 🛠️ Teknologi & Dependencies

### Framework & Language
- **Platform**: .NET 8.0 (Windows Forms)
- **Language**: C# 12
- **UI Framework**: Windows Forms (WinForms)
- **Target**: .NET 8.0-windows

### NuGet Dependencies

| Package | Version | Fungsi |
|---------|---------|--------|
| **MQTTnet** | 4.3.7.1207 | MQTT Client untuk komunikasi Antares |
| **Newtonsoft.Json** | 13.0.3 | JSON serialization/deserialization |

### External Services

| Service | Protocol | Host | Port |
|---------|----------|------|------|
| **Antares REST API** | HTTPS | platform.antares.id | 8443 |
| **Antares MQTT Broker** | TCP | mqtt.antares.id | 1883 |
| **PLC/Device** | Modbus TCP | Dynamic (IP input) | 502 |

---

## 📥 Instalasi & Setup

### Prerequisites

- **OS**: Windows 10/11 atau Server
- **.NET**: .NET 8.0 SDK atau Runtime
- **Network**: Internet connection untuk Antares platform
- **Credentials**: Antares API Key & Account

### Step 1: Clone/Download Project

```bash
git clone <repository-url>
cd IIOT_GATEWAY
```

### Step 2: Restore NuGet Packages

```bash
# Menggunakan Visual Studio Package Manager
dotnet restore

# Atau via Visual Studio
# Tools → NuGet Package Manager → Manage NuGet Packages for Solution
```

### Step 3: Configure Credentials

Edit `IIOT_Gateway.cs` dengan credentials Antares Anda:

```csharp
// Line 53-54 (GetDeviceAPIAsync)
string apiKey = "YOUR_API_KEY_HERE"; // Format: consumer_id:access_key

// Line 79 (ConnectMQTTAsync)
.WithCredentials("YOUR_USERNAME", "YOUR_PASSWORD")

// Line 123 (SubscribeTopicAsync) & PublishTopicAsync
// Update topic path dengan device ID Anda
string topic = "/oneM2M/resp/antares-cse/YOUR_CONSUMER_ID:YOUR_ACCESS_KEY/json";
```

### Step 4: Update Device Configuration

Edit `Controller.cs` dengan device path Antares Anda:

```csharp
// Line 18 - Update path ke device Anda
"to": "/antares-cse/antares-id/YOUR_ORGANIZATION/YOUR_DEVICE"
```

### Step 5: Build & Run

```bash
# Build project
dotnet build

# Run aplikasi
dotnet run

# Atau buka di Visual Studio
# File → Open Project/Solution → IIOT_GATEWAY.sln
```

---

## 🏗️ Arsitektur Sistem

```
┌─────────────────────────────────────────────────────────────────┐
│                    IIOT_GATEWAY Windows App                      │
├─────────────────────────────────────────────────────────────────┤
│                                                                   │
│  ┌──────────────┐      ┌──────────────┐     ┌──────────────┐   │
│  │   UI Layer   │◄────►│   Controller │◄───►│  Models      │   │
│  │ - TreeView   │      │   Logic      │     │  - Request   │   │
│  │ - Forms      │      │              │     │  - Response  │   │
│  │ - DataGrid   │      └──────────────┘     └──────────────┘   │
│  └──────────────┘             △                                  │
│                               │                                  │
│                    ┌──────────┴──────────┐                       │
│                    │                     │                       │
│          MQTT Connection         REST API Connection            │
│                    │                     │                       │
└────────────────────┼─────────────────────┼────────────────────┘
                     │                     │
          ┌──────────▼────┐      ┌────────▼─────────┐
          │ MQTT Broker   │      │  Antares REST    │
          │ mqtt.         │      │  API             │
          │ antares.id    │      │  platform.       │
          │ :1883         │      │  antares.id:8443 │
          └──────────┬────┘      └────────┬─────────┘
                     │                    │
                     └────────┬───────────┘
                              │
                    ┌─────────▼────────┐
                    │  Antares M2M     │
                    │  Container Node  │
                    └────────┬─────────┘
                             │
                    ┌────────▼────────┐
                    │  Raspberry Pi   │
                    │  - MQTT Client  │
                    │  - Modbus TCP   │
                    └────────┬────────┘
                             │
                    ┌────────▼────────┐
                    │  PLC/Device     │
                    │  - Modbus Slave │
                    │  - Coils        │
                    │  - Registers    │
                    └─────────────────┘
```

---

## 📁 Struktur Project

```
IIOT_GATEWAY/
├── IIOT_GATEWAY.sln                 # Solution file
├── IIOT_GATEWAY.csproj              # Project configuration
├── Program.cs                        # Entry point aplikasi
│
├── UI & Forms
│   ├── IIOT_Gateway.cs              # Main form
│   ├── IIOT_Gateway.Designer.cs     # Designer
│   ├── IIOT_Gateway.resx            # Resources
│   │
│   ├── GetDataForm.cs               # User control untuk GET
│   ├── GetDataForm.Designer.cs      # Designer
│   ├── GetDataForm.resx             # Resources
│   │
│   ├── SetDataForm.cs               # User control untuk SET
│   ├── SetDataForm.Designer.cs      # Designer
│   ├── SetDataForm.resx             # Resources
│   │
│   ├── IPInfoForm.cs                # User control untuk IP info
│   ├── IPInfoForm.Designer.cs       # Designer
│   └── IPInfoForm.resx              # Resources
│
├── Business Logic
│   ├── Controller.cs                # JSON builder & logic
│   └── Model.cs                     # Data models (empty)
│
├── Configuration
│   ├── IIOT_GATEWAY.csproj.user     # User-specific settings
│   ├── .vs/                         # VS cache files
│   └── bin/                         # Build output
└── obj/                             # Intermediate objects
```

---

## 💻 Cara Penggunaan

### Quick Start

1. **Launch Aplikasi**
   - Double-click `IIOT_GATEWAY.exe` atau `dotnet run`
   - Aplikasi membuka dengan tab "Home" kosong

2. **Click "Search" Button**
   - TreeView device list loading
   - Status label menampilkan connection info
   - MQTT automatically connecting ke Antares broker

3. **Expand Raspberry PI Node**
   ```
   Raspberry PI
   ├── Connection
   │   ├── WLAN
   │   └── Ethernet
   ├── Get Data
   └── Set Data
   ```

4. **Get Network Information**
   - Click "WLAN" → Mendapatkan IP WLAN0
   - Click "Ethernet" → Mendapatkan IP ETH0
   - IP ditampilkan di IPInfoForm

5. **Get Data dari PLC**
   - Click "Get Data" node
   - Input IP Address target PLC (misal: 192.168.1.100)
   - Click "Get Data" button
   - DataGridView menampilkan coils/registers

6. **Set Data ke PLC**
   - Click "Set Data" node
   - Input IP Address, Coil address, Value
   - Click "SET" button
   - Feedback di status bar

### Detail Workflow

#### 1. Network Information Flow

```
User clicks "WLAN"
       ↓
TreeView_AfterSelect event triggered
       ↓
Send JSON: {"cnf": "GetIpAddress", "con": "wlan0"}
       ↓
PublishTopicAsync → MQTT Publish
       ↓
Antares MQTT Broker → Raspberry Pi
       ↓
Raspberry Pi executes command
       ↓
Response JSON dengan IP address
       ↓
MQTT Subscribe callback menerima response
       ↓
Parse JSON & extract IP
       ↓
Create & display IPInfoForm
       ↓
User sees IP in text box
```

#### 2. Get Data Flow

```
User inputs IP & clicks "Get Data"
       ↓
BtGet_Click handler
       ↓
Validate input (IP tidak kosong)
       ↓
Build JSON: {"cnf": "GetDataPLC", "con": "192.168.1.100"}
       ↓
PublishTopicAsync
       ↓
Antares Raspberry Pi menerima request
       ↓
Execute Modbus TCP read ke PLC
       ↓
Return data dalam JSON response
       ↓
MQTT subscribe callback
       ↓
Parse response & populate DataGridView
```

#### 3. Set Data Flow

```
User inputs IP, Coil, Value & clicks "SET"
       ↓
BtSet_Click handler
       ↓
Validate all inputs
       ↓
Build string: "IpAdd=192.168.1.100,Address=0x100,Value=1"
       ↓
Build JSON: {"cnf": "SetCoil", "con": "...string..."}
       ↓
PublishTopicAsync
       ↓
Antares Raspberry Pi
       ↓
Execute Modbus TCP write ke PLC
       ↓
Return success/error response
       ↓
Status bar shows result
```

---

## 🔌 API & Protokol

### REST API - GET Device Information

**Endpoint:**
```
GET https://platform.antares.id:8443/~/antares-cse/antares-id/IIOT_GATEWAY/Raspberry_PI
```

**Headers:**
```
X-M2M-Origin: consumer_id:access_key
Accept: application/json
```

**Response Sample:**
```json
{
  "m2m:cnt": {
    "rn": "Raspberry_PI",
    "typ": 3,
    "ri": "/antares-cse/antares-id/IIOT_GATEWAY/Raspberry_PI",
    "ct": "20250108T120000Z"
  }
}
```

### MQTT Protocol

#### Publish Topic (Request)
```
Topic: /oneM2M/req/consumer_id:access_key/antares-cse/json
QoS: 0 (At Most Once)
```

**Payload Format:**
```json
{
  "m2m:rqp": {
    "fr": "consumer_id:access_key",
    "to": "/antares-cse/antares-id/IIOT_GATEWAY/Raspberry_PI",
    "op": 1,
    "rqi": 123456,
    "pc": {
      "m2m:cin": {
        "cnf": "COMMAND_TYPE",
        "con": "COMMAND_CONTENT"
      }
    },
    "ty": 4
  }
}
```

**Command Types:**
| cnf | Fungsi | con Value |
|-----|--------|-----------|
| `GetIpAddress` | Dapatkan IP device | `wlan0` atau `eth0` |
| `GetDataPLC` | Baca data dari PLC | IP address PLC |
| `SetCoil` | Tulis coil ke PLC | `IpAdd=IP,Address=ADDR,Value=VAL` |

#### Subscribe Topic (Response)
```
Topic: /oneM2M/resp/antares-cse/consumer_id:access_key/json
QoS: 0
```

**Response Payload:**
```json
{
  "m2m:rsp": {
    "pc": {
      "m2m:cin": {
        "cnf": "COMMAND_TYPE",
        "con": "RESPONSE_DATA"
      }
    }
  }
}
```

### Modbus TCP Protocol (PLC Communication)

Raspberry Pi menjalankan Modbus TCP client untuk berkomunikasi dengan PLC:

**Connection Details:**
- **Port**: 502 (standard Modbus TCP)
- **Function Codes**:
  - FC 01: Read Coils
  - FC 03: Read Holding Registers
  - FC 05: Write Single Coil
  - FC 16: Write Multiple Registers

**Communication Flow:**
```
IIOT_GATEWAY (MQTT) → Antares → Raspberry Pi (Modbus Client)
                                          ↓
                                    PLC/Device (Modbus Server)
```

---

## ⚙️ Konfigurasi

### 1. Antares Credentials

**File**: `IIOT_Gateway.cs`

```csharp
// Line 53-54 - API Key
string apiKey = "YOUR_CONSUMER_ID:YOUR_ACCESS_KEY";

// Line 75 - Device Path
string antaresUrl = "https://platform.antares.id:8443/~/antares-cse/antares-id/YOUR_ORG/YOUR_DEVICE";

// Line 79 - MQTT Credentials
.WithCredentials("YOUR_USERNAME", "YOUR_PASSWORD")

// Line 123 & 150 - Topic Paths
string topic = "/oneM2M/resp/antares-cse/YOUR_CONSUMER_ID:YOUR_ACCESS_KEY/json";
string publishTopic = "/oneM2M/req/YOUR_CONSUMER_ID:YOUR_ACCESS_KEY/antares-cse/json";
```

### 2. Device Path Configuration

**File**: `Controller.cs`

```csharp
// Line 18 - Update device CSE path
"to": "/antares-cse/antares-id/IIOT_GATEWAY/Raspberry_PI"
```

### 3. MQTT Broker Settings

**Default Antares Broker:**
```
Host: mqtt.antares.id
Port: 1883
```

Untuk custom broker, edit `ConnectMQTTAsync()`:

```csharp
var options = new MqttClientOptionsBuilder()
    .WithTcpServer("YOUR_BROKER_HOST", YOUR_PORT)
    .WithCredentials("USERNAME", "PASSWORD")
    .Build();
```

### 4. API Configuration

**Default Antares API:**
```
Base URL: https://platform.antares.id:8443
```

Untuk custom API, edit `GetDeviceAPIAsync()`:

```csharp
string antaresUrl = "https://YOUR_API_HOST/~/antares-cse/...";
```

---

## 🐛 Troubleshooting

### Issue 1: "Failed to connect" ke MQTT

**Symptom:**
```
Status: Failed to connect: Connection refused
Color: Red
```

**Cause:**
- Network unreachable
- Broker offline
- Wrong credentials
- Port blocked

**Solution:**

1. Check network connection:
   ```bash
   ping mqtt.antares.id
   ```

2. Verify credentials in `IIOT_Gateway.cs`:
   ```csharp
   .WithCredentials("YOUR_USERNAME", "YOUR_PASSWORD")
   ```

3. Check firewall port 1883:
   ```powershell
   Test-NetConnection -ComputerName mqtt.antares.id -Port 1883
   ```

4. Try alternative broker:
   ```csharp
   .WithTcpServer("mqtt.antares.id", 8883)  // TLS port
   ```

### Issue 2: API Call Failed (HttpRequestException)

**Symptom:**
```
MessageBox: "Error: The connection was reset by the peer"
```

**Cause:**
- Invalid API key
- Wrong device path
- SSL certificate issue

**Solution:**

1. Verify API key format:
   ```
   ✓ CORRECT: "consumer_id:access_key"
   ✗ WRONG: "consumer_id access_key"
   ```

2. Check device path exists:
   ```
   ✓ /antares-cse/antares-id/ORG/DEVICE
   ✗ /antares-cse/antares-id/DEVICE
   ```

3. For SSL issues, add in `GetDeviceAPIAsync()`:
   ```csharp
   client.DefaultRequestHeaders.Add("X-M2M-Origin", apiKey);
   // Or disable SSL verification (development only)
   ServicePointManager.ServerCertificateValidationCallback = 
       (sender, cert, chain, sslPolicyErrors) => true;
   ```

### Issue 3: "Please connect to MQTT server first"

**Symptom:**
```
MessageBox: "Please connect to MQTT server first."
```

**Cause:**
- Click button sebelum MQTT connected
- MQTT connection lost

**Solution:**

1. Click "Search" button dulu (trigger MQTT connect)
2. Wait untuk status "Connected to Antares MQTT Server!" (Green)
3. Baru gunakan Get Data/Set Data

### Issue 4: DataGridView Kosong (Get Data tidak menampilkan data)

**Symptom:**
```
DataGridView tidak populate dengan data PLC
```

**Cause:**
- IP address PLC salah
- PLC tidak accessible
- Modbus timeout
- Response parsing error

**Solution:**

1. Verify IP address:
   ```bash
   ping YOUR_PLC_IP
   ```

2. Check Modbus port:
   ```powershell
   Test-NetConnection -ComputerName YOUR_PLC_IP -Port 502
   ```

3. Debug response parsing di callback:
   ```csharp
   // Add di ApplicationMessageReceivedAsync
   Debug.WriteLine($"Raw Response: {receivedMessage}");
   ```

4. Check DataGridView columns initialized:
   ```csharp
   // Pastikan columns ada
   dataGridView1.Columns.Add("Column1", "Header1");
   ```

### Issue 5: "Invalid filename format" atau Build Error

**Symptom:**
```
Error CS1002: ; expected
Error: The type or namespace name 'IIOT_GATEWAY' could not be found
```

**Cause:**
- Namespace mismatch
- File encoding issue
- Missing using statements

**Solution:**

1. Check namespace di semua files:
   ```csharp
   namespace IIOT_GATEWAY { }
   ```

2. Verify project file (.csproj):
   ```xml
   <RootNamespace>IIOT_GATEWAY</RootNamespace>
   ```

3. Add missing usings:
   ```csharp
   using System.Net.Http;
   using Newtonsoft.Json.Linq;
   using MQTTnet;
   ```

4. Restore packages:
   ```bash
   dotnet clean
   dotnet restore
   dotnet build
   ```

### Issue 6: Port 502 Connection Refused

**Symptom:**
```
Modbus TCP connect timeout atau refused
```

**Cause:**
- PLC tidak running Modbus server
- Firewall block
- Wrong IP/Port

**Solution:**

1. Verify Modbus server running di PLC:
   ```bash
   # Dari Raspberry Pi
   netstat -tuln | grep 502
   ```

2. Check firewall rules:
   ```powershell
   # Windows Firewall - allow port 502
   netsh advfirewall firewall add rule name="Modbus" dir=out action=allow protocol=tcp localport=502
   ```

3. Use nmap to scan:
   ```bash
   nmap -p 502 YOUR_PLC_IP
   ```

---

## 📚 Additional Resources

### Antares Platform
- **Website**: https://www.antares.id
- **Documentation**: https://platform.antares.id/docs
- **API Reference**: https://www.antares.id/api-documentation

### MQTTnet Library
- **GitHub**: https://github.com/dotnet/MQTTnet
- **NuGet**: https://www.nuget.org/packages/MQTTnet
- **Docs**: https://github.com/dotnet/MQTTnet/wiki

### Modbus Protocol
- **Standard**: IEC 61131-3
- **Reference**: http://www.modbus.org
- **Port**: TCP 502 (standard)

### .NET 8.0 Windows Forms
- **Documentation**: https://learn.microsoft.com/en-us/dotnet/desktop/winforms
- **API Reference**: https://learn.microsoft.com/en-us/dotnet/api/system.windows.forms

---

## 🤝 Contributing

Untuk contribute ke project ini:

1. Fork repository
2. Create feature branch: `git checkout -b feature/nama-fitur`
3. Commit changes: `git commit -am 'Add feature'`
4. Push to branch: `git push origin feature/nama-fitur`
5. Submit pull request

---

## 📄 Lisensi

Project ini adalah bagian dari PBL (Project Based Learning) - Internal Use Only

---

## 👨‍💻 Author & Contributors

**Original Developer**: PBL Team
**Last Updated**: January 2025
**Version**: 1.0.0

---

## 🔐 Security Notes

⚠️ **IMPORTANT**:
- Jangan commit credentials ke repository
- Use environment variables untuk API key
- Enable SSL/TLS untuk production
- Validate user input sebelum send
- Use secure MQTT port (8883) untuk production
- Implement proper error handling untuk sensitive data

**Best Practices:**
```csharp
// ❌ WRONG - Hardcoded credentials
string apiKey = "consumer_id:access_key";

// ✅ CORRECT - Environment variable
string apiKey = Environment.GetEnvironmentVariable("ANTARES_API_KEY");

// ✅ CORRECT - Configuration file (gitignored)
IConfiguration config = new ConfigurationBuilder()
    .AddUserSecrets<Program>()
    .Build();
string apiKey = config["Antares:ApiKey"];
```

---

**Selamat menggunakan IIOT_GATEWAY! 🚀**
