using System;

namespace LR_6
{
    class Car : Vehicle, IMove
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

        void IMove.Move(int time)
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
        
        void IMove.Overclocking(int time)
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
        
        void IMove.Breaking(int speed, int time)
        {
            Speed = Speed - speed * time;
            if (Speed < 0)
                Speed = 0;
        }

        void IMove.SetAcceleration(int acc)
        {
            if (acc > 0)
                Acceleration = acc;
            else
                Acceleration = 0; 
        }
    }
}