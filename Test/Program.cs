namespace Pulse
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
