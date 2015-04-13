using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PauseSystem.Models.Entity;

namespace PauseSystem.Models
{
    public static class RepositoryExtentions
    {
        public static IList<CustomerDelivery> GetDeliveries(this IRepository<LeveringsProdukt> repository, int? kundeId, DateTime? startDate, DateTime? endDate)
        {
            var query = repository.AsQuerable();
            if (startDate.HasValue)
                query = query.Where(x => x.TurLevering.Ture.Dato.Value > startDate);
            return query.Take(20).Select(x => new CustomerDelivery
            {
                Antal = x.Antal,
                VareNr = x.ProduktNr,
                Beskrivelse = x.Produkt.Navn.ToString(), //.Navn,
                Pris = x.SalgsPris,
                SampletPris = x.SalgsPris
            }).ToList();

        }

    }
}