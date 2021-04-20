using System;

namespace LR_5
{
    class Car : Vehicle
    {
        private int _parking;
        public Car()
        {
            _parking = 0;
        }

        public int this[string status]
        {
            set
            {
                switch (status)
                {
                    case "PStatus":
                        _parking = value;
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
                        return _parking;
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
            _parking = 0;
        }

        public void Drive()
        {
            _parking = 0;
        }

        public void Park()
        {
            _parking = 1;
            Speed = 0;
        }

        public override void Move(int time)
        {
            if (_parking == 1)
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
            if (_parking == 1)
            {
                Console.WriteLine("Переключите коробку в режим вождения");
            }
            else
            {
                Speed = Acceleration * time + Speed;
            }
        }
    }
}