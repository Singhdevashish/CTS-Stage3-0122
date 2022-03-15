using System;
using System.Collections.Generic;
using System.Text;

namespace SessionManagement.Core.Entitites
{
    public class Cohort : BaseEntity
    {
        public string CohortCode { get; set; }
        private Cohort() { }
        public Cohort(long id, string cohortCode)
        {
            this.Id = id;
            this.CohortCode = cohortCode;
        }
    }
}
