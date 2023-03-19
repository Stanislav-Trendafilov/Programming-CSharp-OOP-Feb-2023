using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Stealer
{
    public class Spy
    {
        public string StealFieldInfo(string investigatedClass, string[]fieldsToInvestigate)
        {

            StringBuilder sb=new StringBuilder();

            sb.AppendLine($"Class under investigation: {investigatedClass}");

            Type type = Type.GetType(investigatedClass);

            var fields = type.GetFields(BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic);

            foreach (var field in fields.Where(c=>fieldsToInvestigate.Contains(c.Name)))
            {
                sb.AppendLine($"{field.Name} = {field.GetValue(Activator.CreateInstance(type))}");
            }

            return sb.ToString().TrimEnd();
            
        }
    }
}
