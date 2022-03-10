using CohortManagement.Core.Specifications;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace CohortManagement.Core.CohortAggregate.Specifications
{
    public class GetCohortByIdSpecification : BaseSpecification<Cohort>
    {
        int id;
        public GetCohortByIdSpecification(int id)
        {
            this.id = id;
        }
        public override Expression<Func<Cohort, bool>> ToExpression()
        {
            return obj => obj.Id == id;
        }
    }
}
