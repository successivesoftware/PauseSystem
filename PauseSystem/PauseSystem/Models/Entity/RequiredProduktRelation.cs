using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SubusiDbEf.BaseClass;

namespace SubusiDbEf.Models
{
    [Serializable]
    public class RequiredProduktRelation : BindableObject
    {
        private int _id, _ratio;
        private Produkt _fromProdukt, _toProdukt;

        public int Id
        {
            get { return _id; }
            set
            {
                RaisePropertyChanging(() => Id);
                _id = value;
                RaisePropertyChanged(() => Id);
            }
        }

        public int FromProduktId { get; set; }
        public int ToProduktId { get; set; }

        public int Ratio
        {
            get { return _ratio; }
            set
            {
                RaisePropertyChanging(() => Ratio);
                _ratio = value;
                RaisePropertyChanged(() => Ratio);
            }
        }

        public virtual Produkt FromProdukt
        {
            get
            {
                return _fromProdukt;

            }
            set
            {
                RaisePropertyChanging(() => FromProdukt);
                _fromProdukt = value;
                RaisePropertyChanged(() => FromProdukt);
            }
        }

        public virtual Produkt ToProdukt
        {
            get { return _toProdukt; }
            set
            {
                RaisePropertyChanging(()=>ToProdukt);
                _toProdukt = value;
                RaisePropertyChanged(()=>ToProdukt);
            }
        }

    }
}
