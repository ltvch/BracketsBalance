using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckBrackets
{
    class Program
    {   

        static void Main(string[] args)
        {
            Brackets brakes = new Brackets();
            string text = "[{}()<Test Me!!>[[{{}}]]]";//true
            text = "))( ][(";///false
            text = "([]())(";///false
            text = "{}([])";
            text = "([}])";
            text = "([])";
            text = "()[]{}[][]";

            /// Console.WriteLine(prog.IsBalancedBrackets(text));
            Console.WriteLine(brakes.IsBalansedBrackets(text));
            Console.ReadKey();
        }
    }
}
