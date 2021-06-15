using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using devLap.Common;

namespace devLap
{
    public class Program
    {   
        public static void Main(string[] args)
        {   
            string logFilePath = AppDomain.CurrentDomain.BaseDirectory + Define.LogFileInfo;

            if (false == Logger.Instance.Initialize(logFilePath))
            {
                // 로거 자체가 실패 났는데, 여기서 먼가 알려 줄수 있는 방법이 없을까!?
                return;
            }

            //서버정보읽어오기...
            string xmlFilePath = AppDomain.CurrentDomain.BaseDirectory + Define.ServerConfigFileInfo;
            if (false == ServerInfo.Instance.Initialize(xmlFilePath))
            {                
                return;
            }

            //api정보로드...
            if (false == APIManager.Instance.Initialize())
            {                
                return;
            }

            CreateHostBuilder(args).Build().Run();            
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseIISIntegration();
                    webBuilder.UseStartup<Startup>();                    
                });
    }
}
