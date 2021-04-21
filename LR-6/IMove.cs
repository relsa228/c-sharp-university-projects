namespace LR_6
{
    public interface IMove
    {
        public void Breaking(int speed, int time) {}
        
        public void SetAcceleration(int acc) {}

        public void Overclocking(int time) {}

        public void Move(int time) {}
    }
}