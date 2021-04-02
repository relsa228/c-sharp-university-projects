using System;

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
                Console.WriteLine("Shift the transmission to drive mode");
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
                Console.WriteLine("Shift the transmission to drive mode");
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
            
        }
    }
}