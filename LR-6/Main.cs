using System;

namespace LR_6
{
    class Program
    {
        static void Main()
        {
            MkCar car = new MkCar();
            Console.Write("\nВведите ускорение вашего автомобиля: ");   
            ((IMove) car).SetAcceleration(Convert.ToInt32(Console.ReadLine()));
            car.MkChose();
            for (;;)
            {
                bool globalCheck = false;
                Console.WriteLine("Список воозможных действий: ");
                Console.WriteLine("1. Разгон\n2. Движение\n3. Переключить коробку передач\n4. Торможение\n5. Узнать марку\n6. Выйти из машины");
                Console.Write("\nВыберите действие: ");
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.Write("Укажите желаемое время разгона: ");
                        int time1 = Convert.ToInt32(Console.ReadLine()); 
                        ((IMove) car).Overclocking(time1); 
                        Console.WriteLine("Разгон завершен. Текущая скорость: " + car["SStatus"] + "\n");
                        break;
                    
                    case 2:
                         Console.Write("Укажите желаемое время движения: ");
                         int time = Convert.ToInt32(Console.ReadLine());
                         ((IMove) car).Move(time); 
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
                        ((IMove) car).Breaking(speedB, timeB); 
                        Console.WriteLine("Торможение завершено. Текущая скорость: " + car["SStatus"] + "\n");
                        break;
                    
                    case 5:
                        Console.Write("Марка вашего автомобиля: " + car.MkStatus() + "\n\n");
                        break;
                    
                    case 6:
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