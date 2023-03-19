using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AuthorProblem
{
    public class Tracker
    {
        public void PrintMethodsByAuthor()
        {
            Type type = typeof(StartUp);
            foreach (var method in type.GetMethods((BindingFlags)60))
            {
                AuthorAttribute[] authorAttributes = method
                    .GetCustomAttributes<AuthorAttribute>().ToArray();
                foreach (var authorAttribute in authorAttributes)
                {
                    Console.WriteLine($"{method.Name} is written by {authorAttribute.Name}");
                }
            }
        }
    }
}