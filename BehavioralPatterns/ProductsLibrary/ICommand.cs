using System;
using System.Collections.Generic;
using System.Text;

namespace ProductsLibrary
{
    public interface ICommand
    {
        void Execute();
        void Undo();
    }

    public class CommandsInvoker
    {
        private readonly Stack<ICommand> commands;
        public CommandsInvoker()
        {
            commands = new Stack<ICommand>();
        }
        public void Invoke(ICommand command)
        {
            commands.Push(command);
            command.Execute();
        }
        public void Undo()
        {
            var command = commands.Pop();
            command.Undo();
        }
    }
}
