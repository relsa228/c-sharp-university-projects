namespace LR_5
{
    class Vehicle
    {
        protected int Speed;
        protected int Coordinates;
        protected int Acceleration;

        protected Vehicle()
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

        public void SetAcceleration(int acc)
        {
            if (acc > 0)
                Acceleration = acc;
            else
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
}