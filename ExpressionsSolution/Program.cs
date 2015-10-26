using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionsSolution
{
    class Program
    {
        static void Main(string[] args)
        {
            Calculator calcExpress = new Calculator();
            Console.WriteLine("Input some expression like 45 * (12 + 14) + 14 =\n\n");
            string s = Console.ReadLine().Replace(" ", "").Replace("=", "");

            double result = calcExpress.Calculate(s);

            Console.WriteLine(Environment.NewLine);

            Console.WriteLine(result);
        }
    }
}
