using SessionManagement.Core.Entitites;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace SessionManagement.Core.Specifications
{
    public class GetSessionsForTrainerInGivenDurationSpecification : BaseSpecification<TrainingSession>
    {
        long trainerId;
        DateTime fromDate;
        DateTime toDate;
        public GetSessionsForTrainerInGivenDurationSpecification(long trainerId,
                                                                 DateTime fromDate,
                                                                 DateTime toDate)
        {
            this.trainerId = trainerId;
            this.fromDate = fromDate;
            this.toDate = toDate;
        }
        public override Expression<Func<TrainingSession, bool>> ToExpression()
        {
            return obj => obj.TrainerId == trainerId && 
                          obj.Dates.FromDate >= fromDate && 
                          obj.Dates.ToDate <= toDate;
        }
    }
}
