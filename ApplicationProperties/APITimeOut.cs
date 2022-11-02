using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ApplicationPropertiesSettings.Properties;

namespace ApplicationPropertiesSettings
{
    public static class APITimeOut
    {
        static public int GetAPITimeout()
        {
            return int.Parse(Resources.ResourceManager.GetString("APITimeoutExpiresSeconds"));
        }
    }
}
