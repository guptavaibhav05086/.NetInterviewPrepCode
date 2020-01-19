using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionsLibrary
{
    
    public class ReflectionsDemo
    {
        public int AddMethod(int val1,int val2)
        {
            Console.WriteLine("Sum is: " + (val1 + val2));
            return (val1 + val2);
        }
    }
}
