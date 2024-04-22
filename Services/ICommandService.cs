using TermianlMVCApp.Models;

namespace TermianlMVCApp.Services
{
    public interface ICommandService
    {
        Command GetCommand(int id);
        IEnumerable<Command> GetAllCommands();
        Command AddCommand(Command command);
    }
}
