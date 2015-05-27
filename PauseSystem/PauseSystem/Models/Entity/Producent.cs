using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace PauseSystem.Models.Entity
{
    public partial class Producent : BaseEntity
    {
        private readonly BindingList<Produkt> _produkts = new BindingList<Produkt>();
        public string Navn { get; set; }
        public int CompareTo(Producent other)
        {
            if (other == null)
                return 1;
            return String.Compare(Navn, other.Navn, StringComparison.Ordinal);
        }
        public virtual BindingList<Produkt> Produkts
        {
            get { return _produkts; }
        }
        public override int GetHashCode()
        {
            return Id;
        }
    }
}
