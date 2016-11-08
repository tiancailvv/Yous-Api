using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Yous_API.Controllers
{
    [Serializable]
    [DataContract]
    public class InParameters
    {
        [DataMember(Order = 1)]
        public String Parameters { get; set; }

        [DataMember(Order = 2)]
        public String Method { get; set; }

        [DataMember(Order = 3)]
        public int ForeEndType { get; set; }

        [DataMember(Order = 4)]
        public String Code { get; set; }
    }

    [Serializable]
    [DataContract]
    public class InParametersFlight
    {
        [DataMember(Order = 1)]
        public Newtonsoft.Json.Linq.JObject Parameters { get; set; }

        [DataMember(Order = 3)]
        public int ForeEndType { get; set; }

        [DataMember(Order = 4)]
        public String Code { get; set; }
    }
}