using System;

namespace LR_4.Entities
{
    public class Passenger: IComparable
    {
        public string FName { get; set; }
        public string SName { get; set; }
        public string Citizenship { get; set; }
        public string Gender { get; set; }
        public string PassportNum { get; set; }
        public float TotalSum { get; set; }
        
        public Passenger()
        {
            FName = "";
            SName = "";
            Citizenship = "";
            Gender = "";
            PassportNum = "";
            TotalSum = 0;
        }
        
        public int CompareTo(object obj)
        {
            Passenger temp = obj as Passenger;
            if (temp.PassportNum == this.PassportNum)
                return 0;
            return 1;
        }
    }
}