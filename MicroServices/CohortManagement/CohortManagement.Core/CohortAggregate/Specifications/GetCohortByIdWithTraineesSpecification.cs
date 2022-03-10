using CohortManagement.Core.Specifications;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace CohortManagement.Core.CohortAggregate.Specifications
{
    public class GetCohortByIdWithTraineesSpecification : BaseSpecification<Cohort>
    {
        long id;
        public GetCohortByIdWithTraineesSpecification(long id)
        {
            this.id = id;
            base.AddInclude("Trainees");
        }
        public override Expression<Func<Cohort, bool>> ToExpression()
        {
            return obj => obj.Id == id;
        }
    }
}
