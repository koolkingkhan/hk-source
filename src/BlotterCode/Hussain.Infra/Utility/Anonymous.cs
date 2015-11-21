using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hussain.Infra.Utility
{
    public class Anonymous
    {
 
        public static T Cast<T>(object obj, T type)
        {
            return (T)obj;
        }
    }
}
