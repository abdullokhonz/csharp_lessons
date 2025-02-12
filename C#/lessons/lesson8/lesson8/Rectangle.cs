namespace lesson8
{
    internal class Rectangle
    {
        public float width;
        public float height;
        public float[,] testRectangles = new float[3, 2];

        public float GetArea()
        {
            return width * height;
        }

        public float GetPerimeter()
        {
            return (width + height) / 2;
        }

        public void Main()
        {
            bool switcher = false;
            string text;
            uint counter = 0;

            for (int i = 0; i < testRectangles.GetLength(0); i++)
            {
                for (int j = 0; j < testRectangles.GetLength(1); j++)
                {
                    switcher = switcher != !switcher ? !switcher : switcher;
                    text = switcher == true ? $"Enter width of {i + 1} rectangle: " : $"Enter height of {i + 1} rectangle: ";
                    Console.Write(text);

                    testRectangles[i, j] = Convert.ToSingle(Console.ReadLine());

                    if (switcher == false) Console.WriteLine();
                }
            }

            foreach (var item in testRectangles)
            {
                if (switcher == false) counter++;

                switcher = switcher != !switcher ? !switcher : switcher;
                text = switcher == true ? $"Width of {counter} rectangle: " : $"Height of {counter} rectangle: ";
                Console.Write(text);

                Console.WriteLine(item);

                if (switcher == false) Console.WriteLine();
            }
        }
    }
}
