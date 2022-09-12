using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace INFRASTRUCTURE.Constanst
{
    public static class Parameters
    {
        public static string xmlInfrastructure = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    }
}
