using System;
using System.Security.Cryptography.X509Certificates;

namespace Lab_3
{
    class Vehicle
    {
        protected int Speed;
        protected int Coordinates;
        public int Acceleration;

        public Vehicle()
        {
            Speed = 0;
            Coordinates = 0;
            Acceleration = 0;
        }
        
        public void Breaking(int speed, int time)
        {
            Speed = Speed - speed * time;
            if (Speed < 0)
                Speed = 0;
        }

        public virtual void Overclocking(int time)
        {
            Speed = Acceleration * time + Speed;
        }
        
        public virtual void Move(int time)
        {
            Coordinates = Coordinates + Speed * time;
        }
    }

    class Car : Vehicle
    {
        public int Parking;
        public Car()
        {
            Parking = 0;
        }

        public int this[string status]
        {
            set
            {
                switch (status)
                {
                    case "PStatus":
                        Parking = value;
                        break;
                    case "SStatus":
                        Speed = value;
                        break;
                    case "CStatus":
                        Coordinates = value;
                        break;
                }
            }
            get
            {
                switch (status)
                {
                    case "PStatus":
                        return Parking;
                    case "SStatus":
                        return Speed;
                    case "CStatus":
                        return Coordinates;
                    default:
                        return 0;
                }
            }
        }

        public void Revers()
        {
            Speed = Speed * (-1);
            Parking = 0;
        }

        public void Drive()
        {
            Parking = 0;
        }

        public void Park()
        {
            Parking = 1;
            Speed = 0;
        }

        public override void Move(int time)
        {
            if (Parking == 1)
            {
                Console.WriteLine("Переключите коробку в режим вождения");
            }
            else
            {
                Coordinates = Coordinates + Speed * time;
            }
        }
        
        public override void Overclocking(int time)
        {
            if (Parking == 1)
            {
                Console.WriteLine("Переключите коробку в режим вождения");
            }
            else
            {
                Speed = Acceleration * time + Speed;
            }
        }
    }
    
    class Program
    {
        static void Main()
        {
            Car car = new Car();
            Console.Write("Введите ускорение вашего автомобиля: ");   
            car.Acceleration = Convert.ToInt32(Console.ReadLine());
            for (;;)
            {
                bool globalCheck = false;
                Console.WriteLine("Список воозможных действий: ");
                Console.WriteLine("1. Разгон \n2. Движение \n3. Переключить коробку передач \n4. Торможение \n5. Выйти из машины");
                Console.Write("\nВыберите действие: ");
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.Write("Укажите желаемое время разгона: ");
                        int time1 = Convert.ToInt32(Console.ReadLine()); 
                        car.Overclocking(time1); 
                        Console.WriteLine("Разгон завершен. Текущая скорость: " + car["SStatus"] + "\n");
                        break;
                    case 2:
                         Console.Write("Укажите желаемое время движения: ");
                         int time = Convert.ToInt32(Console.ReadLine());
                         car.Move(time); 
                         Console.WriteLine("Движение завершено. Текущие координаты: " + car["CStatus"] + "\n");
                         break;
                    case 3:
                        Console.WriteLine("Доступные передачи:\n1. Drive\n2. Parking\n3. Revers");
                        Console.Write("\nВыберите передачу: ");
                        for (;;)
                        {
                            int transmis = Convert.ToInt32(Console.ReadLine());
                            bool check = false;
                            switch (transmis)
                            {
                                case 1:
                                    car.Drive();
                                    check = true;
                                    break;
                                case 2:
                                    check = true;
                                    car.Park();
                                    break;
                                case 3:
                                    check = true;
                                    car.Revers();
                                    break;
                                default:
                                    Console.WriteLine("Введите действительный номер: ");
                                    break;
                            }

                            if (check)
                                break;
                        }
                        break;
                    case 4:
                        Console.Write("Укажите желаемое время торможения: ");
                        int timeB = Convert.ToInt32(Console.ReadLine()); 
                        Console.Write("Укажите желаемую скорость торможения: ");
                        int speedB = Convert.ToInt32(Console.ReadLine()); 
                        car.Breaking(speedB, timeB); 
                        Console.WriteLine("Торможение завершено. Текущая скорость: " + car["SStatus"] + "\n");
                        break;
                    
                    case 5:
                        globalCheck = true;
                        break;
                    
                    default: 
                        Console.WriteLine("Такого действия не существует");
                        break;
                }
                if (globalCheck)
                    break;
            }
        }
    }
}