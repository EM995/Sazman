namespace Sazman.DataModels.Models
{
    public class FarzandEntity : BaseEntity
    {
        public string? Nam { get; set; }
        public string? NameXanevadegi { get; set; }
        public DateTime? TarixTavallod { get; set; }

        public PersonnelEntity? Personnel { get; set; }
        public Guid? PersonnelId { get; set; }
    }
}
