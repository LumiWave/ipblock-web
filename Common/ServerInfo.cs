using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Xml;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Microsoft.Extensions.Logging;

namespace devLap.Common
{
    public class ServerInfo : Singleton<ServerInfo>
    {
        private JObject xmlFileText = null;

        public string api_ipAddress = "";

        public string api_port = "";

        public string api_version = "";

        public bool Initialize(string path)
        {
            try
            {
                XmlDocument ServerConfigDoc = XMLReader.ReadXml(path);
                string jsonText = JsonConvert.SerializeXmlNode(ServerConfigDoc);
                xmlFileText = JObject.Parse(jsonText);

                if (null == xmlFileText[Define.ServerInfo])
                {
                    return false;
                }

                xmlFileText = (JObject)xmlFileText[Define.ServerInfo];      
                
                //api base info setting...
                JObject API = (JObject)xmlFileText[Define.API];                     
                api_ipAddress = (string)API[Define.IPAddress];            
                api_port = (string)API[Define.Port];  
                api_version = (string)API[Define.Version];              
            }
            catch(System.Exception ex)
            {                   
                Logger.Instance.Fatal("[ServerInfo]SystemLog Exception {0}: " + ex.Message);
                return false;
            }

            return true;
        }
    }
}
