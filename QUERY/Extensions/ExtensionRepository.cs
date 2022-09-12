using DOMAIN.Interfaces.IExtensionR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QUERY.Extensions
{
    public class ExtensionRepository<T>: IExtensionRepository<T>
    {
        public T ExtensionR { set; get; }

        public ExtensionRepository(T extensionR)
        {
            ExtensionR = extensionR;
        }
    }
}
