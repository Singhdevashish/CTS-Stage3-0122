using SessionManagement.Core.Entitites;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace SessionManagement.Core.Specifications
{
    public class GetAllSpecification<T> : BaseSpecification<T> where T : BaseEntity
    {
        public override Expression<Func<T, bool>> ToExpression()
        {
            return obj => true;
        }
    }
}
