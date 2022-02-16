using CommandPattern.Core.Contracts;

namespace CommandPattern.Commands
{
    public class HelloCommand : ICommand
    {
        public string Execute(string[] args)
        {
            return $"Hallo, {args[0]}";
        }
    }
}
