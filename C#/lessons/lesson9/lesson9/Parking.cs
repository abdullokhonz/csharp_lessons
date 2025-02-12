namespace lesson9
{
    public class Parking
    {
        private uint counter = 0;
        public string[,] parking = new string[10, 5];
        string[] lineNames =
        {
            "Марка",
            "Модель",
            "Цвет",
            "Номер",
            "Время прибытия"
        };

        public Parking()
        {
            Console.WriteLine("Создан новый объект Parking\n");
        }

        public void AddCar(string[] car)
        {
            if (counter != 10)
            {
                Console.WriteLine($"Машина под номером {car[3]} припарковался\n");
                for (int i = 0; i < car.Length; i++)
                {
                    parking[counter, i] = car[i];
                }
                counter++;
            }
            else
                Console.WriteLine("В парковке нет свободных мест\n");
        }

        public void DeleteCar(string number)
        {
            for (int i = 0; i < counter; i++)
            {
                if (number == parking[i, 3])
                {
                    for (int j = 0; j < parking.GetLength(1); j++)
                    {
                        parking[i, j] = string.Empty;
                    }

                    for (int k = i; k < parking.GetLength(0) - 1; k++)
                    {
                        for (int l = 0; l < parking.GetLength(1); l++)
                        {
                            parking[k, l] = parking[k + 1, l];
                        }
                    }

                    counter--;

                    Console.WriteLine($"Машина под номером {number} освободил стоянку, свободных мест теперь {10 - counter}\n");

                    break;
                }
            }
        }

        public void ParkingInfo()
        {
            Console.WriteLine("Информация о парковке");
            for (int i = 0; i < counter; i++)
            {
                Console.WriteLine("Стоянка №" + (i + 1));
                for (int j = 0; j < parking.GetLength(1); j++)
                {
                    Console.WriteLine($"\t{lineNames[j]}: {parking[i, j]}");
                }
            }
            Console.WriteLine("Свободных мест осталось " + (10 - counter) + "\n");
        }
    }
}
