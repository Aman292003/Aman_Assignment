using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace generic_method
{
    internal class Helper
    {
        public static void swap<T>(ref T a, ref T b)
        {
            T temp = a;
            a = b;
            b = temp;
        }
        public static T ADD<T>(T a, T b)
        {
            dynamic x = a;
            dynamic y = b;
            return x + y;
        }
       
    }
}
