using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace generic_method
{
    internal class helper2<T>
    {
        public static void swap(ref T a, ref T b)
        {
            T temp = a;
            a = b;
            b = temp;
        }
        public static T ADD(T a, T b)
        {
            dynamic x = a;
            dynamic y = b;
            return x + y;
        }
    }
}
