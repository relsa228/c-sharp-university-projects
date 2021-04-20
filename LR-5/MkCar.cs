using System;

namespace LR_5
{
    class MkCar : Car
    {
        private string _mk;

        public string MkStatus()
        {
            return _mk;
        }
        
        public bool MkChose()
        {
            Console.Write("Марка автомобиля:\n1. Выбрать из существующих\n2. Создать свою");
            Console.Write("\n\nВыберите действие: ");
            int num = Convert.ToInt32(Console.ReadLine());
            while (true)
            {
                if (num == 1)
                {
                    Console.WriteLine("1. Жига\n2. Запорожец\n3. Лада\n4. ГАЗ");
                    Console.Write("\nВыберите марку: ");
                    string choice = Console.ReadLine();
                    switch (choice)
                    {
                        case "1":
                            _mk = "Жига";
                            return true;
                        case "2":
                            _mk = "Запорожец";
                            return true;
                        case "3":
                            _mk = "Лада";
                            return true;
                        case "4":
                            _mk = "ГАЗ";
                            return true;
                        default:
                            Console.Write("\nТакого действия не существует\n\n");
                            break;
                    }
                }
                else if (num == 2)
                {
                    Console.Write("Введите название: ");
                    string choice = Console.ReadLine();
                    _mk = choice;
                    Console.Write("Марка сохранена\n");
                    return true;
                }
                else
                {
                    Console.Write("Такого действия не существует");
                    Console.Write("\n\nВыберите действие: ");
                    num = Convert.ToInt32(Console.ReadLine());
                }
            }
        }
    }
}