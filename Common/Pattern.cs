using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace devLap.Common
{
    public abstract class Singleton<T> where T : class, new()
    {
        private static T _instance;

        public static T Instance
        {
            get
            {
                if(null == _instance)
                {
                    _instance = new T();
                }

                return _instance;
            }
        }

    }
}
