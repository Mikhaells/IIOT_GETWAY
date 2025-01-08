using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IIOT_GATEWAY
{
    public class Controller
    {
        public string CreateJsonString(string cnf, string con)
        {
            string jsonString = $@"
                                    {{
                                      ""m2m:rqp"": {{
                                        ""fr"": ""2c8489c626d81199:3aa45962c7db0414"",
                                        ""to"": ""/antares-cse/antares-id/IIOT_GATEWAY/Raspberry_PI"",
                                        ""op"": 1,
                                        ""rqi"": 123456,
                                        ""pc"": {{
                                          ""m2m:cin"": {{
                                            ""cnf"": ""{cnf}"",
                                            ""con"": ""{con}""
                                          }}
                                        }},
                                        ""ty"": 4
                                      }}
                                    }}";
            return jsonString;


        }

    }
}
