using CohortManagement.Core.Specifications;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace CohortManagement.Core.CohortAggregate.Specifications
{
    public class GetAllCohortsSpecification : BaseSpecification<Cohort>
    {
        public override Expression<Func<Cohort, bool>> ToExpression() 
        {
            return obj => true;
        }
    }
}
