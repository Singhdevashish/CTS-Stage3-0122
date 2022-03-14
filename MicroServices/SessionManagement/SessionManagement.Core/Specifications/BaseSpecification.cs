using SessionManagement.Core.Entitites;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace SessionManagement.Core.Specifications
{
    public abstract class BaseSpecification<T> where T : BaseEntity
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
