using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LB8._2
{
    public class SuitcaseOverflowException: Exception
    {
        public SuitcaseOverflowException() : base("Валіза переповнена неможливо додати більше речей!")
        {
        }

        public SuitcaseOverflowException(string message) : base(message)
        {
        }
    }

    
    
}
