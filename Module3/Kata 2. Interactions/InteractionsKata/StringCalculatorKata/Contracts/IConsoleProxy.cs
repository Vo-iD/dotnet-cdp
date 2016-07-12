namespace StringCalculatorKata.Contracts
{
    public interface IConsoleProxy
    {
        void WriteLine(string message);
        string Read();
    }
}
