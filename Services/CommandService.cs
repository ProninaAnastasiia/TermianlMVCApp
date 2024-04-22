using TermianlMVCApp.Data;
using TermianlMVCApp.Models;

namespace TermianlMVCApp.Services
{
    public class CommandService : ICommandService
    {
        private readonly ApplicationDbContext _context;
        public CommandService(ApplicationDbContext context)
        {
            _context = context;
        }
        public Command AddCommand(Command command)
        {
            var newCommand = _context.Add(command).Entity;
            _context.SaveChanges();
            return newCommand;
        }

        public IEnumerable<Command> GetAllCommands()
        {
            return _context.Commands.ToList();
        }

        public Command GetCommand(int id)
        {
            return _context.Commands.FirstOrDefault(c => c.Id == id);
        }
    }
}
