using System.Data;

namespace TermianlMVCApp.ViewModels
{
    public class MyViewModel
    {
        public List<CommandType> CommandTypes { get; set; }
        public CommandViewModel? CommandViewModel { get; set; }
        public MyViewModel(List<CommandType> commandTypes)
        {
            CommandTypes = commandTypes;
            // Создание объекта CommandViewModel с пустыми значениями
            CommandViewModel = new CommandViewModel
            {
                CommandId = null,
                TerminalId = null
            };
        }
    }
}
