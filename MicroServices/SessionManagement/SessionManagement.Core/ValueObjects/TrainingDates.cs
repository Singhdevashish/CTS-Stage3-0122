using System;
using System.Collections.Generic;
using System.Text;

namespace SessionManagement.Core.ValueObjects
{
    public class TrainingDates : BaseValueObject
    {
        public virtual DateTime FromDate { get; private set; }
        public virtual DateTime ToDate { get; private set; }

        private TrainingDates() { }
        public TrainingDates(DateTime from, DateTime to)
        {
            //validation
            this.FromDate = from;
            this.ToDate = to;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return FromDate;
            yield return ToDate;
        }
    }
}
