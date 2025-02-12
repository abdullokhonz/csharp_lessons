using System.Data;

namespace lesson9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*Person person = new Person(18, "Абдулло", 170);
            Person person1 = new Person(18, "Абдулло");*/

            // Ex - 1
            /*User user = new User("Абдулло");
            User user2 = new User("Азам");
            User user3 = new User("Мансур");*/

            // Ex - 2
            Parking parking = new Parking();

            Car m8 = new Car("BMW", "M8", "Black", "2008AM02", DateTime.UtcNow);
            Car x6 = new Car("BMW", "X6", "White", "1206AG02", DateTime.UtcNow);

            parking.AddCar(m8.GetCar());
            parking.AddCar(x6.GetCar());

            parking.ParkingInfo();

            parking.DeleteCar(x6.carInfo[3]);

            parking.ParkingInfo();

            Car x7 = new Car("BMW", "X7", "Darkblue", "0101OO01", DateTime.UtcNow);

            parking.AddCar(x7.GetCar());

            parking.ParkingInfo();

            parking.DeleteCar(m8.carInfo[3]);

            parking.ParkingInfo();

            Car m5 = new Car("BMW", "M5", "Red", "0202OO02", DateTime.UtcNow);
            Car x5 = new Car("BMW", "X5", "Yellow", "0303OO03", DateTime.UtcNow);

            parking.AddCar(m5.GetCar());
            parking.AddCar(x5.GetCar());

            parking.ParkingInfo();

            parking.DeleteCar(m5.carInfo[3]);

            parking.ParkingInfo();

            parking.AddCar(m8.GetCar());

            parking.ParkingInfo();

            parking.AddCar(m8.GetCar());
            parking.AddCar(m8.GetCar());
            parking.AddCar(m8.GetCar());
            parking.AddCar(m8.GetCar());
            parking.AddCar(m8.GetCar());
            parking.AddCar(m8.GetCar());
            parking.AddCar(m8.GetCar());

            parking.ParkingInfo();

            parking.AddCar(m8.GetCar());
        }
    }
}
