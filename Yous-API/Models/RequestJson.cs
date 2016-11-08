using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Yous_Api.Models
{
    public class RequestJson
    {
        [DataMember(Order = 1)]
        public Newtonsoft.Json.Linq.JObject Parameters { get; set; }
        [DataMember(Order = 3)]
        public string ForeEndType { get; set; }
        [DataMember(Order = 4)]
        public string Code { get; set; }
    }
}