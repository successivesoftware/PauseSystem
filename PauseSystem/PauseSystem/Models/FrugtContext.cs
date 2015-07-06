using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using PauseSystem.Models.Mapping;
using PauseSystem.Models.Entity;

namespace PauseSystem.Models
{

    //public interface IDbContext
    //{
    //   // IDbSet<T> Set<T>() where T : class;
    //    int SaveChanges();
    //    DbEntityEntry Entry(object o);
    //    void Dispose();
    //}


    public class FrugtContext : DbContext
    {
        static FrugtContext()
        {
            Database.SetInitializer<FrugtContext>(null);
        }

        public FrugtContext()
            : base("Name=FrugtContext")
        {
                
        }

       

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }

        public DbSet<AbbonnementProduktPause> AbbonnementProduktPauses { get; set; }
        public DbSet<AbbPauser> AbbPausers { get; set; }
        public DbSet<AbonnementChange> AbonnementChanges { get; set; }
        public DbSet<Abonnementer> Abonnementers { get; set; }
        public DbSet<AbonnementOphør> AbonnementOphør { get; set; }
        public DbSet<AbonnementProdukt> AbonnementProdukts { get; set; }
        public DbSet<AbonnementProduktChange> AbonnementProduktChanges { get; set; }
        public DbSet<AbonnementRute> AbonnementRutes { get; set; }
        public DbSet<Adresser> Adressers { get; set; }
        public DbSet<BetalingBetingelser> BetalingBetingelsers { get; set; }
        public DbSet<Branche> Branches { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Change> Changes { get; set; }
        public DbSet<ClosedDate> ClosedDates { get; set; }
        public DbSet<Dekorter> Dekorters { get; set; }
        public DbSet<DriverMessage> DriverMessages { get; set; }
        public DbSet<ExternFragt> ExternFragts { get; set; }
        public DbSet<ExternFragtChauffør> ExternFragtChauffør { get; set; }
        public DbSet<Grøntkasse> Grøntkasse { get; set; }
        public DbSet<GrøntKasseLeveringer> GrøntKasseLeveringer { get; set; }
        public DbSet<Grossister> Grossisters { get; set; }
        public DbSet<Haendelse> Haendelses { get; set; }
        public DbSet<Kunde> Kundes { get; set; }
        public DbSet<Kundeold> Kundeolds { get; set; }
        public DbSet<Levering> Leverings { get; set; }
        public DbSet<LeveringsChange> LeveringsChanges { get; set; }
        public DbSet<LeveringsProdukt> LeveringsProdukts { get; set; }
        public DbSet<Login> Logins { get; set; }
        public DbSet<Medarbejdere> Medarbejderes { get; set; }
        public DbSet<MedarbejderOpgaver> MedarbejderOpgavers { get; set; }
        public DbSet<Opgave> Opgaves { get; set; }
        public DbSet<OrdreKilde> OrdreKildes { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<PostNrInterval> PostNrIntervals { get; set; }
        public DbSet<PostNrKunde> PostNrKundes { get; set; }
        public DbSet<Pri> Pris { get; set; }
        public DbSet<Priser> Prisers { get; set; }
        public DbSet<Producent> Producents { get; set; }
        public DbSet<ProductOrdre> ProductOrdres { get; set; }
        public DbSet<ProductOrdreStatu> ProductOrdreStatus { get; set; }
        public DbSet<Produkt> Produkts { get; set; }
        public DbSet<ProduktGrupper> ProduktGruppers { get; set; }
        public DbSet<ProduktOld> ProduktOlds { get; set; }
        public DbSet<ProduktUndergruppe> ProduktUndergruppes { get; set; }
        public DbSet<RuteChauffør> RuteChauffør { get; set; }
        public DbSet<SkipText> SkipTexts { get; set; }
        public DbSet<sysdiagram> sysdiagrams { get; set; }
        public DbSet<Ture> Tures { get; set; }
        public DbSet<TurLevering> TurLeverings { get; set; }
        public DbSet<UgeStatistik> UgeStatistiks { get; set; }
        public DbSet<VersionLog> VersionLogs { get; set; }
        public DbSet<Week> Weeks { get; set; }
        public DbSet<AbonnementProduktChangeLog> AbonnementProduktChangeLogs { get; set; }
        public DbSet<ComputerSetting> ComputerSettings { get; set; }
        public DbSet<DelivereyProdutDiff> DelivereyProdutDiffs { get; set; }
        public DbSet<GrøntKasseLevering> GrøntKasseLevering { get; set; }
        public DbSet<GrøntkasseLeveringsProdukt> GrøntkasseLeveringsProdukt { get; set; }
        public DbSet<LabelPrinter> LabelPrinters { get; set; }
        public DbSet<ProductCustomerSpecialPrice> ProductCustomerSpecialPrices { get; set; }
        public DbSet<SendDeliveryMailRequest> SendDeliveryMailRequests { get; set; }
        public DbSet<SkipList> SkipLists { get; set; }
        public DbSet<smov> smovs { get; set; }
        public DbSet<PreAbonnementProdukt> PreAbonnements { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AbbonnementProduktPauseMap());
            modelBuilder.Configurations.Add(new AbbPauserMap());
            modelBuilder.Configurations.Add(new AbonnementChangeMap());
            modelBuilder.Configurations.Add(new AbonnementerMap());
            modelBuilder.Configurations.Add(new AbonnementOphørMap());
            modelBuilder.Configurations.Add(new AbonnementProduktMap());
            modelBuilder.Configurations.Add(new AbonnementProduktChangeMap());
            modelBuilder.Configurations.Add(new AbonnementRuteMap());
            modelBuilder.Configurations.Add(new AdresserMap());
            modelBuilder.Configurations.Add(new BetalingBetingelserMap());
            modelBuilder.Configurations.Add(new BrancheMap());
            modelBuilder.Configurations.Add(new CarMap());
            modelBuilder.Configurations.Add(new ChangeMap());
            modelBuilder.Configurations.Add(new ClosedDateMap());
            modelBuilder.Configurations.Add(new DekorterMap());
            modelBuilder.Configurations.Add(new DriverMessageMap());
            modelBuilder.Configurations.Add(new ExternFragtMap());
            modelBuilder.Configurations.Add(new ExternFragtChaufførMap());
            modelBuilder.Configurations.Add(new GrøntkasseMap());
            modelBuilder.Configurations.Add(new GrøntKasseLeveringerMap());
            modelBuilder.Configurations.Add(new GrossisterMap());
            modelBuilder.Configurations.Add(new HaendelseMap());
            modelBuilder.Configurations.Add(new KundeMap());
            modelBuilder.Configurations.Add(new KundeoldMap());
            modelBuilder.Configurations.Add(new LeveringMap());
            modelBuilder.Configurations.Add(new LeveringsChangeMap());
            modelBuilder.Configurations.Add(new LeveringsProduktMap());
            modelBuilder.Configurations.Add(new LoginMap());
            modelBuilder.Configurations.Add(new MedarbejdereMap());
            modelBuilder.Configurations.Add(new MedarbejderOpgaverMap());
            modelBuilder.Configurations.Add(new OpgaveMap());
            modelBuilder.Configurations.Add(new OrdreKildeMap());
            modelBuilder.Configurations.Add(new PositionMap());
            modelBuilder.Configurations.Add(new PostNrIntervalMap());
            modelBuilder.Configurations.Add(new PostNrKundeMap());
            modelBuilder.Configurations.Add(new PriMap());
            modelBuilder.Configurations.Add(new PriserMap());
            modelBuilder.Configurations.Add(new ProducentMap());
            modelBuilder.Configurations.Add(new ProductOrdreMap());
            modelBuilder.Configurations.Add(new ProductOrdreStatuMap());
            modelBuilder.Configurations.Add(new ProduktMap());
            modelBuilder.Configurations.Add(new ProduktGrupperMap());
            modelBuilder.Configurations.Add(new ProduktOldMap());
            modelBuilder.Configurations.Add(new ProduktUndergruppeMap());
            modelBuilder.Configurations.Add(new RuteChaufførMap());
            modelBuilder.Configurations.Add(new SkipTextMap());
            modelBuilder.Configurations.Add(new sysdiagramMap());
            modelBuilder.Configurations.Add(new TureMap());
            modelBuilder.Configurations.Add(new TurLeveringMap());
            modelBuilder.Configurations.Add(new UgeStatistikMap());
            modelBuilder.Configurations.Add(new VersionLogMap());
            modelBuilder.Configurations.Add(new WeekMap());
            modelBuilder.Configurations.Add(new AbonnementProduktChangeLogMap());
            modelBuilder.Configurations.Add(new ComputerSettingMap());
            modelBuilder.Configurations.Add(new DelivereyProdutDiffMap());
            modelBuilder.Configurations.Add(new GrøntKasseLeveringMap());
            modelBuilder.Configurations.Add(new GrøntkasseLeveringsProduktMap());
            modelBuilder.Configurations.Add(new LabelPrinterMap());
            modelBuilder.Configurations.Add(new ProductCustomerSpecialPriceMap());
            modelBuilder.Configurations.Add(new SendDeliveryMailRequestMap());
            modelBuilder.Configurations.Add(new SkipListMap());
            modelBuilder.Configurations.Add(new smovMap());
            modelBuilder.Configurations.Add(new PreAbonnemetProduktMap());
        }
    }
}
