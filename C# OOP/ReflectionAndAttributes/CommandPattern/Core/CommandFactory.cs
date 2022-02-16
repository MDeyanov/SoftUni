using System;
using System.Linq;
using System.Reflection;
using CommandPattern.Commands;
using CommandPattern.Core.Contracts;

namespace CommandPattern.Core
{
    public class CommandFactory : ICommandFactory
    {
        private const string CommandSuffix = "Command";
        public ICommand CreateCommand(string commandType)
        {
            Type type = Assembly.GetEntryAssembly()
                  .GetTypes()
                  .FirstOrDefault(t => t.Name == $"{commandType}{CommandSuffix}");

            if (type == null)
            {
                throw new ArgumentException($"{commandType} is invalid command type.");
            }
           ICommand instance = (ICommand)Activator.CreateInstance(type);

            return instance;
        }
    }
}
