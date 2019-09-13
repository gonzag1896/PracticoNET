using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Exception
{
    public class ExistException : SystemException
    {
        public ExistException()
          : base("No existe empleado con el identificador ingresado")
        {

        }
    }
}
