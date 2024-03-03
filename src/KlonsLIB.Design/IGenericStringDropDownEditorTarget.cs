using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KlonsLIB.Design
{
    public interface IGenericStringDropDownEditorTarget
    {
        string[] GetValues(string propertyname);
    }
}
