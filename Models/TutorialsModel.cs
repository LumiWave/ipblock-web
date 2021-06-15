using System;
using System.Collections.Generic;

namespace devLap.Models
{
    public class ImgList
    {
        public Int32 result;
        public string message; 
        public Int32 page_offset;       
        public Int32 page_size;  
        public Int32 total_size;

        public Dictionary<Int64, Item> items = new Dictionary<Int64, Item>();   
    }

    public class Item
    {
        public Int64 item_id;
        public string wallet_address;
        public string title;
        public string token_type;
        public string thumbnail_url;
        public Int64 token_price;
        public Int64 expire_date;
        public Int64 register_date;
        public Int64 creator;
        public string owner_wallet_address;
        public string owner;
        public string token_id;
        public string create_hash;
        public string description;

    }

    public class AddNFT
    {
        public string wallet_address;
        public string title; 
        public string token_type; 
        public Int32 token_price;      
        public string thumbnail_url;  
        public Int64 expire_date;
        public string creator;
        public string description;

    }



}
