using System;
using System.Collections.Generic;
using System.Text;

namespace SessionManagement.Core.ValueObjects
{
    public class TrainingLocation : BaseValueObject
    {
        public string Location { get; private set; }
        public bool IsVirtual { get; private set; }
        private TrainingLocation() { }
        public TrainingLocation(string location, bool isVirtual)
        {
            //validation
            Location = location;
            IsVirtual = isVirtual;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Location;
            yield return IsVirtual;
        }
    }
}
