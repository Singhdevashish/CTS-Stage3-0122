using SessionManagement.Core.Entitites;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace SessionManagement.Core.Specifications
{
    public class GetCohortCodeFromIdSpecification : BaseSpecification<Cohort>
    {
        long cohortId;
        public GetCohortCodeFromIdSpecification(long cohortId)
        {
            this.cohortId = cohortId;
        }
        public override Expression<Func<Cohort, bool>> ToExpression()
        {
            return obj => obj.Id == cohortId;
        }
    }
}
