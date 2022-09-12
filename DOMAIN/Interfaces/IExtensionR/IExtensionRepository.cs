using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOMAIN.Interfaces.IExtensionR
{
    public interface IExtensionRepository<T>
    {
        public T ExtensionR { set; get; }
    }
}
