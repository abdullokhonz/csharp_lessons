namespace lesson10
{
    public struct Point
    {
        public int x; public int y;

        public Point(int newX, int newY)
        {
            x = newX; y = newY;
        }

        public void DistanceTo()
        {
            Console.WriteLine($"Расстояние от точки X до точки Y: {Math.Abs(x - y)}");
        }
    }
}   
