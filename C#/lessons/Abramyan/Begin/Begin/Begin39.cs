namespace Begin
{
    public class Begin39
    {
        public static (double, double) Begin(double A, double B, double C)
        {
            // Вычисление дискриминанта / Calculate the discriminant
            double D = B * B - 4 * A * C;

            // Находим квадратный корень дискриминанта / Calculate the square root of the discriminant
            double sqrtD = Math.Sqrt(D);

            // Находим корни уравнения / Calculate the roots of the equation
            double x1 = (-B - sqrtD) / (2 * A);
            double x2 = (-B + sqrtD) / (2 * A);

            // Возвращаем корни в порядке возрастания / Return the roots in ascending order
            return x1 < x2 ? (x1, x2) : (x2, x1);
        }
    }
}
