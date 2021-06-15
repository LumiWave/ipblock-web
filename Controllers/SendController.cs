using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using devLap.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net;
using System.IO;
using System.Web;
using devLap.Common;

namespace devLap.Controllers
{
    public class SendController : Controller
    {
        public JsonResult callAPI(bool isPost, string url, string data)
        {        
            APIResult result = new APIResult();
            result.code = -1;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => true;
            request.Timeout = 30 * 1000; // 30초
            request.Headers.Add("Accept", "*/*"); // 헤더 추가
            request.Headers.Add("Connection", "keep-alive"); // 헤더 추가
            request.Headers.Add("Accept-Encoding", "gzip, deflate, br"); // 헤더 추가

            if(true == isPost)
            {                
                byte[] sendData = UTF8Encoding.UTF8.GetBytes(data);
                request.Method = "POST";
                request.ContentType = "application/json";
                request.ContentLength = sendData.Length;

                Stream stream = request.GetRequestStream();
                stream.Write(sendData, 0, sendData.Length); 
                stream.Close();
            }
            else
            {
                request.Method = "GET";
            }

            string responseText = string.Empty;
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                HttpStatusCode status = response.StatusCode;
                Stream responseStream = response.GetResponseStream();
                using (StreamReader streamReader = new StreamReader(responseStream))
                {
                    responseText = streamReader.ReadToEnd();
                    JObject responseData = JObject.Parse(responseText);

                    result.code = (Int32)responseData["return"];
                    result.message = (string)responseData["message"];
                    result.value = (JObject)responseData["value"];
                }
            }

            return Json(JsonConvert.SerializeObject(result));
        }
    }
}
