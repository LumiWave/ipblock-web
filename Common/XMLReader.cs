using System;
using System.Collections.Generic;
using System.Text;

using System.Security.Cryptography;
using System.IO;
using System.Xml;

namespace devLap.Common
{ 
        public class XMLReader
    {
        public static XmlDocument ReadXml(string strXtsFilePath)
        {
            FileStream fsInput = new FileStream(strXtsFilePath, FileMode.Open, FileAccess.Read);
            byte[] xts = new byte[fsInput.Length];
            fsInput.Read(xts, 0, xts.Length);
            fsInput.Close();
            String strXml = System.Text.Encoding.UTF8.GetString(xts);

            XmlDocument ServerConfigDoc = new XmlDocument();
            ServerConfigDoc.LoadXml(strXml);

            return ServerConfigDoc;
        }
    }
}











