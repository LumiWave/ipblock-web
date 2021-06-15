using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace devLap.Models
{
    public class APIRegisterItem
    {                
        public string wallet_address;
        public string title;
        public string token_type;
        public string thumbnail_url;
        public double token_price;
        public Int64 expire_date;
        public string creator;
        public string description;


    }
}
