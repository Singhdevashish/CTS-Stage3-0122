using SessionManagement.Core.Entitites;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace SessionManagement.Core.Specifications
{
    public class GetTrainerByIdSpecification : BaseSpecification<Trainer>
    {
        long trainerId;
        public GetTrainerByIdSpecification(long trainerId)
        {
            this.trainerId = trainerId;
        }
        public override Expression<Func<Trainer, bool>> ToExpression()
        {
            return t => t.Id == trainerId;
        }
    }
}
