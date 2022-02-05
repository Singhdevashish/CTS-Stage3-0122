using System;
using System.Collections;
using System.Collections.Generic;

namespace CalenderLib
{

    public class Months : IEnumerable<Month>
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

        public Month this[int index]
        {
            get
            {
                return months[index];
            }
        }
        public int Count
        {
            get
            {
                return months.Length;
            }
        }

        public IEnumerator<Month> GetEnumerator()
        {
            foreach (var month in months)
                yield return month;
        }

        public IMonthsIterator GetIterator()
        {
            return new MonthsIterator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            foreach (var month in months)
                yield return month;
        }
    }

    public interface IMonthsIterator
    {
        Month First();
        void Next();
        bool IsDone();
        Month Current { get; }
        void Reset();
    }
    public class MonthsIterator : IMonthsIterator
    {
        Months months;
        private int currentPosition;
        public MonthsIterator(Months months)
        {
            this.months = months;
            currentPosition = 0;
        }

        public Month Current
        {
            get { return months[currentPosition]; }
        }

        public Month First()
        {
            currentPosition = 0;
            return Current;
        }

        public bool IsDone()
        {
            return currentPosition < months.Count - 1;
        }

        public void Next()
        {
            currentPosition += 1;
        }

        public void Reset()
        {
            currentPosition = 0;
        }
    }
}
