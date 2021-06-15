using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace devLap.Common
{
        // 서버에서만 사용 하는 부분을 이동 시킴
    public class Define
    {
        /* config */
        public const string ServerInfo				        = "ServerInfo";
        public const string API				                = "API";
        public const string IPAddress				        = "IPAddress";
        public const string Port				            = "Port";
        public const string Version				            = "Version";

        public const string ServerConfigFileInfo            = "ServerConfig.xml";

        public const string LogFileInfo                     = "log4net.xml";


        /* api */
        public const string Login				        = "Login";
        public const string RegisterItem				= "RegisterItem";
        public const string UnregisterItem				= "UnregisterItem";
        public const string RequestItemList				= "RequestItemList";
        public const string PurchaseItem				= "PurchaseItem";

    }
}