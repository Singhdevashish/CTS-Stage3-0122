using System;

namespace CalenderLib
{

    public class Months
    {
        Month[] months;
        public Months()
        {
            months = new Month[12];
            months[0] = new Month { Name = "January", No = 1 };
            months[1] = new Month { Name = "February", No = 2 };
            months[2] = new Month { Name = "March", No = 3 };
            months[3] = new Month { Name = "April", No = 4 };
            months[4] = new Month { Name = "May", No = 5 };
            months[5] = new Month { Name = "June", No = 6 };
            months[6] = new Month { Name = "July", No = 7 };
            months[7] = new Month { Name = "August", No = 8 };
            months[8] = new Month { Name = "September", No = 9 };
            months[9] = new Month { Name = "October", No = 10 };
            months[10] = new Month { Name = "November", No = 11 };
            months[11] = new Month { Name = "December", No = 12 };
        }

       

        
    }
}
