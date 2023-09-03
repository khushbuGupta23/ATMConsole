using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    public class Base
    {
        void Base()
        {
            Console.WriteLine("Base Const");
        }
        void ~Base()
        {
            Console.WriteLine("Base Destr");
        }
        void Test()
        {
           Console.WriteLine("Base Test")
        }
    }
    public class Derived:Base
    {
        void Derived()
        {
            Console.WriteLine("Derived Const");
        }
        void ~Derived()
        {
            Console.WriteLine("Drived Destr");
        }
        void Test()
        {
            Console.WriteLine("Drived Test")
        }
    }
}
