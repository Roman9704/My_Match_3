namespace Test
{
    static class Program
    {
        static void Main()
        {
            Initializer.initialization();

            Initializer.GameLoop.Update();
        }
    }
}
