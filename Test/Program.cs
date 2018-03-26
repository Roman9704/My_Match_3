namespace Test
{
    static class Program
    {
        static void Main()
        {
            Initializer.initialization();

            Initializer.gameLoop.Update();
        }
    }
}
