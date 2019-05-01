namespace GoF.Behavioral.Command {
    public interface ICommand {
        Display Execute();
        Display UnExecute();
    }
}