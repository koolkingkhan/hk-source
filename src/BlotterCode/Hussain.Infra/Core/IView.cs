using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hussain.Infra.Core
{
    public interface IView
    {
        IViewModel ViewModel { get; set; }
    }
}
