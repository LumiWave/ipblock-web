using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net;
using System.IO;
using System.Web;
using Microsoft.Extensions.Logging.Abstractions;
using devLap.Common;
using devLap.Models;

namespace devLap.Controllers
{
    public class TutorialsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult List()
        {            
            return View();
        }

        public JsonResult setNFT(string title, string description, string thumbnail_url)
        {
            SendController send = new SendController();

            APIRegisterItem registerItem = new APIRegisterItem();
            registerItem.title = title;
            registerItem.description = description;
            registerItem.thumbnail_url = thumbnail_url;
            
            /* 일단 고정하여 셋팅...*/
            registerItem.wallet_address = "0x9Ec7EDE9204E17dfa34e1d381ED5f49A0D578e96";
            registerItem.token_type = "onit";
            registerItem.token_price = 0.00003;                    

            DateTime expire_date = DateTime.Now.AddDays(30);
            DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            TimeSpan diff = expire_date - origin;

            registerItem.expire_date = (int)Math.Floor(diff.TotalSeconds);
            registerItem.creator = "byDevlap";

            bool isPost = true;              
            string url = APIManager.Instance.FindAPI("RegisterItem");
            string data = JsonConvert.SerializeObject(registerItem);

            JsonResult result = send.callAPI(isPost, url, data);

            return Json(JsonConvert.SerializeObject(result));
        }

        public JsonResult getNFTList(Int32 page_offset, Int32 page_size)
        {
            SendController send = new SendController();
          
            bool isPost = false;
            string url = APIManager.Instance.FindAPI("RequestItemList");
            url = url + "?page_offset="+page_offset+"&page_size="+page_size;
            string data = "";    

            JsonResult result = send.callAPI(isPost, url, data);

            return Json(JsonConvert.SerializeObject(result));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
