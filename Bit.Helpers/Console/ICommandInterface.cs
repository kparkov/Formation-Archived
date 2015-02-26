namespace Bit.Helpers.Console
{
    public interface ICommandInterface
    {
        ConsoleCommandHelpers Csl { get; set; }
        RunHelpers Run { get; set; }
        DeploymentHelpers Deployment { get; set; }
        DatabaseHelpers Database { get; set; }
    }
}
