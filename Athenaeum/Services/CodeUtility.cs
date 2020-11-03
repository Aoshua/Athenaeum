using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Athenaeum.Services
{
    public static class CodeUtility
    {
        public static object SerializeObject<T>(T anyObject)
        {
            return (object)Newtonsoft.Json.JsonConvert.SerializeObject(anyObject);
        }
    }
}
