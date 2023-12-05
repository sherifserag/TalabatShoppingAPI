using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalabatG02.Core.Entities;
using TalabatG02.Core.Specifications;

namespace TalabatG02.Repository
{
    public static class SpecificationEvalutor<TEntity> where TEntity : BaseEntity
    {
        
        public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> inputQuery,ISpecification<TEntity> spec)
        {
            var query = inputQuery;//context.Orders

            if (spec.Criteria is not null)
                query = query.Where(spec.Criteria);//P=>P.id ==id
                                                   //context.Products.where(P=>P.id==id);
                 //context.Products.Where(P=>P.ProductBrandId == brandId && true)
                 //context.Products.Where(P=>true && P.ProductTypeId == typeId)
                 //context.Products.Where(P=>true && true)
                 //context.Products.Where(P=>true && P.ProductTypeId == typeId)
                 //context.Products.Where(P=>P.ProductBrandId == brandId && true)
                 //context.Products.where(O=>O.buyerEmail==email && o.id ==OrderId);



            if(spec.OrderBy is not null)
                query =query.OrderBy(spec.OrderBy);//Asc
            //context.Products.OrderBy(P=>P.Name)
            //context.Products.Where(P=>true && P.ProductTypeId == typeId).OrderBy(P=>P.Price)
            //context.Products.Where(P=>P.ProductBrandId == brandId && true).OrderBy(P=>P.Price)
            if (spec.OrderByDesc is not null)
                query = query.OrderByDescending(spec.OrderByDesc);//Desc
            //context.Products.OrderByDescending(P=>P.Price)
                             //context.Products.where(O=>O.buyerEmail==email).OrderByDescending(O=>O.OrderDate)


            if(spec.IsPagenationEnabled)
            query = query.Skip(spec.Skip).Take(spec.Take);
            //context.Products.Where(P=>true && true).Skip(0).Take(5);
            //context.Products.Where(P=>true && P.ProductTypeId == typeId).Skip(4).Take(2);
            //context.Products.Where(P=>P.ProductBrandId == brandId && true).OrderBy(P=>P.Price).Skip(6).Take(3);


            query = spec.Includes.Aggregate(query, (currentQuery, IncludeExpression) => currentQuery.Include(IncludeExpression));
            // context.Products.where(P => P.id == id).Include(P=>P.ProductBrand).Include(P=>P.ProductType);
            //context.Products.OrderBy(P=>P.Name).Include(P=>P.ProductBrand).Include(P=>P.ProductType);
            //context.Products.OrderByDescending(P=>P.Price).Include(P=>P.ProductBrand).Include(P=>P.ProductType);
            //context.Products.Where(P=>P.ProductBrandId == brandId && true).Include(P=>P.ProductBrand).Include(P=>P.ProductType);
            //context.Products.Where(P=>true && P.ProductTypeId == typeId).OrderBy(P=>P.Price).Include(P=>P.ProductBrand).Include(P=>P.ProductType);
            //context.Products.Where(P=>true && true).Skip(0).Take(5).Include(P=>P.ProductBrand).Include(P=>P.ProductType);
            //context.Products.Where(P=>true && P.ProductTypeId == typeId).Skip(4).Take(2).Include(P=>P.ProductBrand).Include(P=>P.ProductType);
            //context.Products.Where(P=>P.ProductBrandId == brandId && true).OrderBy(P=>P.Price).Skip(6).Take(3).Include(P=>P.ProductBrand).Include(P=>P.ProductType);
            //context.Products.where(O=>O.buyerEmail==email).OrderByDescending(O=>O.OrderDate).Include(O=>O.DeliveryMethod).Include(O=>O.Items);
            //context.Products.where(O=>O.buyerEmail==email && o.id ==OrderId).Include(O=>O.DeliveryMethod).Include(O=>O.Items);
            return query;
        }

    }
}
