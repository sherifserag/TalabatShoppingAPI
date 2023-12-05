using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TalabatG02.Core.Entities;

namespace TalabatG02.Core.Specifications
{
    public interface ISpecification<T> where T:BaseEntity
    {
        public Expression<Func<T, bool>> Criteria { get; set; }// Signature for Prop
        public List<Expression<Func<T,object>>> Includes { get; set; }  

        public Expression<Func<T,object>> OrderBy { get; set; }

        public Expression<Func<T, object>> OrderByDesc { get; set; }

        public int Take { get;set; }

        public int Skip { get;set; }    

        public bool IsPagenationEnabled { get; set; }   

    }
}
