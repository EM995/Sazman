namespace Sazman.DataModels.Models
{
    public class PersonnelEntity : BaseEntity
    {
        public byte[]? Aks { get; set; }
        public long? CodePersonneli { get; set; }
        public string? Nam { get; set; }
        public string? NameXanevadegi { get; set; }
        public string? CodeMelli { get; set; }
        public DateTime? TarixTavallod { get; set; }
        public string? Address { get; set; }
        public NezamVazife? NezamVazife { get; set; }

        public List<FarzandEntity>? Farzandan { get; set; }
        public List<TahseelEntity>? Tahseelat { get; set; }
        public List<JaygaheSazmaniEntity>? Jaygahha { get; set; }
    }
}
