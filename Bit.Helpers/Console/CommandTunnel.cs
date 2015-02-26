using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Bit.Helpers.Console
{
    internal class CommandTunnel
    {
        public string Name { get; set; }
        public ICommandInterface CommandObject { get; set; }
        public MethodInfo MethodInfo { get; set; }

        public void Execute(IEnumerable<string> arguments)
        {
            var args = arguments.Take(MethodInfo.GetParameters().Count());

            MethodInfo.Invoke(CommandObject, args.Cast<object>().ToArray());
        }

        public bool IsExecutable(IEnumerable<string> arguments)
        {
            return MethodInfo.GetParameters().Count() <= arguments.Count();
        }
    }
}