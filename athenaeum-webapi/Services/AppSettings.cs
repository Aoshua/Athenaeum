using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace athenaeum_webapi.Services
{
    public class AppSettings
    {
        public string Secret { get; set; }
        public static JsonSerializerSettings JsonSettings => new JsonSerializerSettings()
        {
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
        };
    }
}
