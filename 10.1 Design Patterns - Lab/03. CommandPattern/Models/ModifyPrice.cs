using CommandPattern.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern.Models
{
    public class ModifyPrice
    {
        private readonly List<ICommand> commands;
        private ICommand _command;

        public ModifyPrice()
        {
            commands=new List<ICommand>();
        }

        public void SetCommand(ICommand command)
        {
            _command = command;
        }
        public void Invoke()
        {
            commands.Add(_command);
            _command.Execute();
        }
        
    }
}
