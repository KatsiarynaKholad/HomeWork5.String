namespace HomeWork5.String
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var words = new TextFileStreams();
            words.SearchWords(@"D:\program\sample.txt");
        }
    }
}