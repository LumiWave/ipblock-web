using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;

using log4net;
using log4net.Config;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace devLap.Common
{
        // 서버에서만 사용 하는 부분을 이동 시킴
    public class Logger : Singleton<Logger>
    {
        public log4net.ILog log = null;

        public bool Initialize(string strXmlFilePath)
        {
            // Log4net Config 정보 불러오기
            XmlConfigurator.Configure(new System.IO.FileInfo(strXmlFilePath));
            if (null == log)
            {
                log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            }

            Logger.Instance.log.Info("succeed Logger Initialize");

            return true;
        }

#region log4net 을 한번 래핑 시킴
        public void Debug(object message)                                                           {   log.Debug(message);                         }
        public void Debug(object message, Exception exception)                                      {   log.Debug(message, exception);              }
        public void DebugFormat(string format, object arg0)                                         {   log.DebugFormat(format, arg0);              }
        public void DebugFormat(string format, params object[] args)                                {   log.DebugFormat(format, args);              }
        public void DebugFormat(IFormatProvider provider, string format, params object[] args)      {   log.DebugFormat(provider, format, args);    }
        public void DebugFormat(string format, object arg0, object arg1)                            {   log.DebugFormat(format, arg0, arg1);        }
        public void DebugFormat(string format, object arg0, object arg1, object arg2)               {   log.DebugFormat(format, arg0, arg1, arg2);  }
        public void Error(object message)                                                           {   log.Error(message);                         }
        public void Error(object message, Exception exception)                                      {   log.Error(message, exception);              }
        public void ErrorFormat(string format, object arg0)                                         {   log.ErrorFormat(format, arg0);              }
        public void ErrorFormat(string format, params object[] args)                                {   log.ErrorFormat(format, args);              }
        public void ErrorFormat(IFormatProvider provider, string format, params object[] args)      {   log.ErrorFormat(provider, format, args);    }
        public void ErrorFormat(string format, object arg0, object arg1)                            {   log.ErrorFormat(format, arg0, arg1);        }
        public void ErrorFormat(string format, object arg0, object arg1, object arg2)               {   log.ErrorFormat(format, arg0, arg1, arg2);  }
        public void Fatal(object message)                                                           {   log.Fatal(message);                         }
        public void Fatal(object message, Exception exception)                                      {   log.Fatal(message, exception);              }
        public void FatalFormat(string format, object arg0)                                         {   log.FatalFormat(format, arg0);              }
        public void FatalFormat(string format, params object[] args)                                {   log.FatalFormat(format, args);              }
        public void FatalFormat(IFormatProvider provider, string format, params object[] args)      {   log.FatalFormat(provider, format, args);    }
        public void FatalFormat(string format, object arg0, object arg1)                            {   log.FatalFormat(format, arg0, arg1);        }
        public void FatalFormat(string format, object arg0, object arg1, object arg2)               {   log.FatalFormat(format, arg0, arg1, arg2);  }
        public void Info(object message)                                                            {   log.Info(message);                          }
        public void Info(object message, Exception exception)                                       {   log.Info(message, exception);               }
        public void InfoFormat(string format, object arg0)                                          {   log.InfoFormat(format, arg0);               }
        public void InfoFormat(string format, params object[] args)                                 {   log.InfoFormat(format, args);               }
        public void InfoFormat(IFormatProvider provider, string format, params object[] args)       {   log.InfoFormat(provider, format, args);     }
        public void InfoFormat(string format, object arg0, object arg1)                             {   log.InfoFormat(format, arg0, arg1);         }
        public void InfoFormat(string format, object arg0, object arg1, object arg2)                {   log.InfoFormat(format, arg0, arg1, arg2);   }
        public void Warn(object message)                                                            {   log.Warn(message);                          }
        public void Warn(object message, Exception exception)                                       {   log.Warn(message, exception);               }
        public void WarnFormat(string format, object arg0)                                          {   log.WarnFormat(format, arg0);               }
        public void WarnFormat(string format, params object[] args)                                 {   log.WarnFormat(format, args);               }
        public void WarnFormat(IFormatProvider provider, string format, params object[] args)       {   log.WarnFormat(provider, format, args);     }
        public void WarnFormat(string format, object arg0, object arg1)                             {   log.WarnFormat(format, arg0, arg1);         }
        public void WarnFormat(string format, object arg0, object arg1, object arg2)                {   log.WarnFormat(format, arg0, arg1, arg2);   }
#endregion


    }
}