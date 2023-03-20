using CommandPattern.Core.Contracts;
using System.Reflection;

namespace CommandPattern
{
    public class CommandInterpreter:ICommandInterpreter
    { 

        public string Read(string args)
        {
            string[] arguments = args
                     .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Type type = Assembly
                .GetEntryAssembly()
                .GetTypes()
                .First(x => x.Name == $"{arguments[0]}Command");

            ICommand commandToExecute = Activator.CreateInstance(type) as ICommand;

            string result = commandToExecute.Execute(arguments.Skip(1).ToArray());

            return result;

        }
    }
}