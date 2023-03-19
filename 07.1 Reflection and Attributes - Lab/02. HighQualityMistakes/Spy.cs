using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization.Formatters;
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

        public string AnalyzeAccessModifiers(string className)
        {
            StringBuilder sb=new StringBuilder();

            Type type = Type.GetType(className);

            FieldInfo[] fieldsInfo = type.GetFields(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);


            foreach (var field in fieldsInfo) 
            { 
                if(!field.IsPrivate)
                {
                    sb.AppendLine($"{field.Name} must be private!");
                }
            }

            MethodInfo[] publicMethodsInfo = type.GetMethods(BindingFlags.Instance | BindingFlags.Public);
            MethodInfo[] nonPublicMethodsInfo = type.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

            foreach (var method in publicMethodsInfo.Where(x => x.Name.StartsWith("set")))
            {
                sb.AppendLine($"{method.Name} have to be private!");
            }
            foreach (var method in nonPublicMethodsInfo.Where(x => x.Name.StartsWith("get")))
            {
                sb.AppendLine($"{method.Name} have to be public!");
            }
            return sb.ToString().Trim();
        }
    }
}
