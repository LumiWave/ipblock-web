using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace devLap.Models
{
    public class APIResult
    {                
        public Int32 code;
        public string message;
        public JObject value;
    }
}
