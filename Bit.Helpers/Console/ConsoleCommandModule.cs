using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Bit.Helpers.Console
{
    public sealed class ConsoleCommandModule
    {
        public string MainCommand { get; set; }
        public IEnumerable<string> PositionalArguments { get; set; }

        internal List<CommandTunnel> AllCommands { get; set; }

        public ConsoleCommandModule(string[] args)
        {
            AllCommands = new List<CommandTunnel>();
            
            if (args.Length > 0)
            {
                MainCommand = args[0].ToLower();
            }

            PositionalArguments = (args.Length <= 1) ? new List<string>() : args.Skip(1);

            LocateCommands();
        }

        public void Engage(string command = null)
        {
            if (!string.IsNullOrEmpty(command)) MainCommand = command.ToLower();

            if (string.IsNullOrWhiteSpace(MainCommand) || AllCommands.All(x => x.Name != MainCommand))
            {
                System.Console.WriteLine("No valid command given. Available commands:\n");

                AllCommands.ForEach(x => System.Console.WriteLine(x.MethodInfo.Name));

                return;
            }

            var tunnel = AllCommands.Single(x => x.Name == MainCommand);

            if (!tunnel.IsExecutable(PositionalArguments))
            {
                System.Console.WriteLine("Not the correct number of arguments.\n\nExpected arguments are: " + string.Format("[{0}]", string.Join("] [", tunnel.MethodInfo.GetParameters().Select(x => x.Name))));
                return;
            }

            tunnel.Execute(PositionalArguments);
        }

        private void LocateCommands()
        {
            var types = Assembly.GetEntryAssembly().GetTypes().Where(x => typeof(ICommandInterface).IsAssignableFrom(x) && x.IsClass && !x.IsAbstract);

            foreach (var type in types)
            {
                var existing = AllCommands.FirstOrDefault(x => x.CommandObject.GetType() == type);

                ICommandInterface instance;

                if (existing != null)
                {
                    instance = existing.CommandObject;
                }
                else
                {
                    instance = (ICommandInterface) Activator.CreateInstance(type);
                    instance.Csl = new ConsoleCommandHelpers();
                    instance.Run = new RunHelpers();
                    instance.Deployment = new DeploymentHelpers();
                    instance.Database = new DatabaseHelpers();
                }

                var publicMethods = instance.GetType().GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly).Where(x => !x.IsSpecialName);

                foreach (var publicMethod in publicMethods)
                {
                    AllCommands.Add(new CommandTunnel() { CommandObject = instance, MethodInfo = publicMethod, Name = publicMethod.Name.ToLower() });
                }
            }
        }
    }
}
