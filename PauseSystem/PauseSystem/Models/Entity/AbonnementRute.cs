using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace PauseSystem.Models.Entity
{
    [Serializable]
    public class AbonnementRute 
    {


        private int _ruteid;
        private bool _addToRoute, _ophørt;
        private DayOfWeek _ugedag;
        private int _index;
        private Medarbejdere _chauffør;
        private Adresser _startAdresse, _endAdresse;

        private readonly BindingList<Abonnementer> _abonnementer = new BindingList<Abonnementer>();

        private double _km = 0;
        public AbonnementRute()
        {
          
        }

        public int Id { get; set; }
        public int RuteId { get; set; }

        public DayOfWeek Ugedag
        {
            get
            {
                return _ugedag;
            }
            set
            {
                _ugedag = value;
              
            }
        }

        public int ChaufførId { get; set; }
        public int StartAdresseId { get; set; }
        public int EndAdresseId { get; set; }

        public int Index
        {
            get
            {
                return _index;
            }
            set
            {
                _index = value;
               
            }
        }

        public string Navn { get; set; }
        public bool Printes { get; set; }
        public int BilId { get; set; }

        public bool AddToRoute
        {
            get
            {
                return _addToRoute;
            }
            set
            {
                _addToRoute = value;
               
            }
        }

        public bool Ophørt
        {
            get { return _ophørt; }
            set
            {
                _ophørt = value;
              
            }
        }

      
        public virtual Adresser EndAdresse
        {
            get
            {
                return _endAdresse;
            }
            set
            {
                _endAdresse = value;
             
            }
        }

        public virtual Adresser StartAdresse
        {
            get
            {
                return _startAdresse;
            }
            set
            {
                _startAdresse = value;
               
            }
        }

        public virtual Medarbejdere Chauffør
        {
            get
            {
                return _chauffør;
            }
            set
            {
                _chauffør = value;
               
            }
        }

        public virtual BindingList<Abonnementer> Abonnementer { get { return _abonnementer; } }

        public string RuteOfChauffør
        {
            get { return this.ToString(); }
        }
    
        public override string ToString()
        {
            if (Chauffør != null)
                return RuteId.ToString() + " " + Chauffør.Fornavn;

            return RuteId.ToString();
        }

       
    }
}
