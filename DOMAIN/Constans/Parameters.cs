using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DOMAIN.Constans
{
    public static class Parameters
    {
        public static string xmlDomain = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    }
}
