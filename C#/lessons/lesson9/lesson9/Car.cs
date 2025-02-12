namespace lesson9
{
    public class Car
    {
        public string[] carInfo = new string[5];
        string[] lineNames =
        {
            "Марка",
            "Модель",
            "Цвет",
            "Номер",
            "Время прибытия"
        };

        public Car(string brand, string model, string color, string number, DateTime arrivalTime)
        {
            Console.WriteLine("Создан новый объект Car");

            string[] vehicleData =
            {
                brand, model, color, number, arrivalTime.ToString()
            };

            for (int i = 0; i < carInfo.Length; i++)
            {
                carInfo[i] = vehicleData[i];
            }

            for (int i = 0; i < carInfo.Length; i++)
            {
                Console.WriteLine($"\t{lineNames[i]}: {carInfo[i]}");
            }

            Console.WriteLine();
        }

        public string[] GetCar()
        {
            Console.WriteLine("Вы получили информацию о машине под номером " + carInfo[3] + "\n");
            return carInfo;
        }
    }
}
