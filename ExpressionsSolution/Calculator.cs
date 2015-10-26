using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExpressionsSolution
{
    class Calculator
    {
        public double Calculate(string expression)
        {
            // calculates expression and all it's sub-expressions
            StringBuilder sb = new StringBuilder();
            int startIndex = -1;
            int endIndex = -1;
            string subExp = "";
            double temp;

            while ((startIndex = expression.LastIndexOf("(")) > -1)
            {
                endIndex = expression.IndexOf(")", startIndex);
                subExp = expression.Substring(startIndex + 1, endIndex - startIndex - 1);
                temp = Compute(subExp);

                for (int i = 0; i < startIndex; i++)
                    sb.Append(expression[i]);

                sb.Append(temp);

                for (++endIndex; endIndex < expression.Length; endIndex++)
                    sb.Append(expression[endIndex]);

                expression = sb.ToString();

                sb.Clear();
            }

            var result = Compute(expression);

            return result;
        }

        public double Compute(string s)
        {
            // calculates single linear expression like  10 +- 8 * 2

            List<char> signs = new List<char>() { '+', '-', '*', '/' };
            int i2 = -1;
            List<int> index = new List<int>();
            List<double> numbers = new List<double>();
            string n = "";

            for (int i = 0; i < s.Length; i++)
            {
                if ((i2 = signs.IndexOf(s[i])) != -1)
                {
                    if (n == "" && s[i] == '-')
                    {
                        n += '-';
                        continue;
                    }

                    index.Add(i2);
                    numbers.Add(Double.Parse(n));
                    n = "";
                }
                else
                {
                    n += s[i];
                }
            }

            numbers.Add(Double.Parse(n));
            int maxIndex;

            while (numbers.Count > 1)
            {
                maxIndex = index.IndexOf(index.Max());

                switch (index[maxIndex])
                {
                    case 0:
                        numbers[maxIndex] += numbers[maxIndex + 1];
                        numbers.RemoveAt(maxIndex + 1);
                        index.RemoveAt(maxIndex);
                        break;

                    case 1:
                        numbers[maxIndex] -= numbers[maxIndex + 1];
                        numbers.RemoveAt(maxIndex + 1);
                        index.RemoveAt(maxIndex);
                        break;
                    case 2:
                        numbers[maxIndex] *= numbers[maxIndex + 1];
                        numbers.RemoveAt(maxIndex + 1);
                        index.RemoveAt(maxIndex);
                        break;
                    case 3:
                        numbers[maxIndex] /= numbers[maxIndex + 1];
                        numbers.RemoveAt(maxIndex + 1);
                        index.RemoveAt(maxIndex);
                        break;
                }
            }

            return numbers[0];
        }       
    }
}
