using LSP.Interfaces;

namespace LSP.Classes
{
    public class Sparrow : Bird, IFlyingBird
    {
        public void Fly()
        {
            Console.WriteLine("Sparrow is flying...");
        }
    }
}
