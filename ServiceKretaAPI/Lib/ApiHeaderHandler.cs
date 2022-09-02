using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceKretaAPI.Lib
{
    public class ApiHeaderHandler
    {
        public int GetHeaderParameter(HttpResponseMessage httpResponseMessage, string key, string parameter)
        {
            if (httpResponseMessage != null)
            {
                if (httpResponseMessage.Headers.Contains(key))
                {
                    var json = httpResponseMessage.Headers.GetValues(key).First();
                    var headerData = JsonConvert.DeserializeObject<dynamic>(json);
                    int dataInHeader;
                    string headerValue = headerData[parameter].ToString();
                    if (headerData != null)
                    {
                        if (int.TryParse(headerData[parameter].ToString(), out dataInHeader))
                            return dataInHeader;
                    }
                }
            }
            return -1;
        }
    }
}
