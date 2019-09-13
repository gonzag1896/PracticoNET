using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Exception
{
    public class TypeException : SystemException
    {
        public TypeException()
          : base("El usuario ingresado es PartTime")
        {

        }
    }
}
