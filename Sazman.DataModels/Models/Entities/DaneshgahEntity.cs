namespace Sazman.DataModels.Models
{
    public class DaneshgahEntity : BaseEntity
    {
        public string? Nam { get; set; }

        public List<TahseelEntity>? Tahseelat { get; set; }
    }
}
