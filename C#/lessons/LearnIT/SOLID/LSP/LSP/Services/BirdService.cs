using LSP.Interfaces;

namespace LSP.Services
{
    public class BirdService
    {
        public void MakeBirdFly(IFlyingBird bird) => bird.Fly();
    }
}
