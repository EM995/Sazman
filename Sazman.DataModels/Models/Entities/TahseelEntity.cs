namespace Sazman.DataModels.Models
{
    public class TahseelEntity : BaseEntity
    {
        public DateTime? TarixFareghottahseeli { get; set; }
        public float? Moaddel { get; set; }

        public DaneshgahEntity? Daneshgah { get; set; }
        public Guid? DaneshgahId { get; set; }

        public PersonnelEntity? Personnel { get; set; }
        public Guid? PersonnelId { get; set; }
    }
}
