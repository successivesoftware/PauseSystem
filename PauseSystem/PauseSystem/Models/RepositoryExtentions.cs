using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PauseSystem.Models.Entity;

namespace PauseSystem.Models
{
    public static class RepositoryExtentions
    {
        public static IList<TurLevering> GetDeliveries(this IRepository<TurLevering> repository)
        {
            return repository.AsQuerable().Take(10).ToList();

            
            //return repository
            //    .FindById(customerId)
            //    .Orders.SelectMany(o => o.OrderDetails)
            //    .Select(o => o.Quantity * o.UnitPrice).Sum();
        }

    }
}