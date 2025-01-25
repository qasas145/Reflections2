using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflections2
{
    public  static class ObjectExtension
    {
        public static dynamic Exposed(this Type type)
        {
            return new ExposedObject(type);
        }
    }
}
