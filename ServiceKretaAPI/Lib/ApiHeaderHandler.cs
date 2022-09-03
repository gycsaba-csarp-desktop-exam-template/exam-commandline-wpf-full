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
                    int dataInHeader= 0;
                    string headerValue = String.Empty;
                    try
                    {
                        headerValue = headerData[parameter].ToString();
                    }
                    catch (Exception e)
                    {
                        return -1;
                    }
                    if (headerData != null)
                    {
                        if (int.TryParse(headerValue, out dataInHeader))
                            return dataInHeader;
                    }
                }
            }
            return -1;
        }
    }
}
