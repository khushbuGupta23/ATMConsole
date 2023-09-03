using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    public class Base
    {
        public  Base()
        {
            Console.WriteLine("Base Const");
        }
        ~ Base()
        {
            Console.WriteLine("Base Destr");
        }
        public void Test()
        {
            Console.WriteLine("Base Test");
        }
    }
    public class Derived : Base
    {
         public Derived()
        {
            Console.WriteLine("Derived Const");
        }
        ~ Derived()
        {
            Console.WriteLine("Drived Destr");
        }
        public void Test()
        {
            Console.WriteLine("Drived Test");
        }
    }
}

