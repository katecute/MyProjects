using System;
using System.Collections.Generic;
using System.Linq;

namespace Hierarchy
{
    class Program
    {   
        static void Main(string[] args)
        {
            // Task: to convert the Dictionary collection "elements" 
            //to List with keeping hierarchy of elements
            Dictionary<string, string> elements = new Dictionary<string, string>()
            {
                {"Tissue", "Organ"},
                {"Cell", "Cells"},
                {"System", "Body"},
                {"Cells", "Tissue"},
                {"Organ", "System"},
            };

            List<string> hierarchy = new List<string>();

            string first = elements.Keys.First(el => !elements.ContainsValue(el));
            hierarchy.Add(first);

            while (elements.ContainsKey(hierarchy.Last()))
                hierarchy.Add(elements[hierarchy.Last()]);                

            foreach (var item in hierarchy)
                Console.WriteLine(item);

            Console.ReadKey();
        }
    }
}
