using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Yous_Api.Models
{
    public class RequestJson
    {
        public object parameters { get; set; }
        public string foreEndType { get; set; }
        public string code { get; set; }
    }
}