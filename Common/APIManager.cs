using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Threading;
using devLap.Models;

namespace devLap.Common
{
    public class APIManager : Singleton<APIManager>
    {
        private ManualResetEvent Wait = new ManualResetEvent(true);

        // 국가별 기본 GMT 시간
        private Dictionary<string, string> APIList;
        // 서버 GMT 시간
        public bool Initialize()
        {
            try
            {
                if (false == Load())
                {
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                Logger.Instance.Fatal("[APIManager]SystemLog Exception {0}: " + ex.Message);
                return false;
            }
        }

        public bool Load()
        {
            try
            {
                Wait.Reset();
                _InitializeAPI();

                return true;
            }
            catch (Exception ex)
            {
                Logger.Instance.Fatal("[APIManager]SystemLog Exception {0}: " + ex.Message);
                return false;
            }
            finally
            {
                Wait.Set();
            }
        }


        // 기본 GMT 검색
        public string FindAPI(string name)
        {
            Wait.WaitOne(5000);

            string api;
            
            if (false == APIList.TryGetValue(name, out api))
            {
                //에러로그???                
                return null;
            }

            string ip = ServerInfo.Instance.api_ipAddress;
            string port = ServerInfo.Instance.api_port;
            string version = ServerInfo.Instance.api_version;
            string url = "https://"+ip+":"+port+"/"+version+"/"+api;

            return url;
        }

        // 기본 GMT 정보 초기화
        private void _InitializeAPI()
        {         
            APIList = new Dictionary<string, string>()
			{
				{ "Login", "login" },	
                { "RegisterItem", "item/register" },	
                { "Unregisteritem", "item/unregister" },	
                { "RequestItemList", "item/list" },	
                { "Purchase Item", "item/purchase" },	
			};
        }


    }
}