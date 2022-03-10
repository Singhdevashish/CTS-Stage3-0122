using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;
namespace CohortManagement.Core.Specifications
{
    public abstract class BaseSpecification<T> where T: BaseEntity, IAggregateRoot
    {
        Expression<Func<T, bool>> criteria;
        public List<string> Includes { get; } = new List<string>();
        public abstract Expression<Func<T, bool>> ToExpression();
        protected virtual void AddInclude(string include)
        {
            Includes.Add(include);
        }
    }
}
