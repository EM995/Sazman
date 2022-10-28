namespace Sazman.DataModels.Models
{
    public class VahedeSazmaniEntity : BaseEntity
    {
        public string? OnvaneVahed { get; set; }

        public VahedeSazmaniEntity? VahedeSazmaniBalatar { get; set; }
        public Guid? VahedeSazmaniBalatarId { get; set; }

        public List<VahedeSazmaniEntity>? VahedhayeSazmaniZirmajmue { get; set; }

        public List<JaygaheSazmaniEntity>? Jaygahha { get; set; }
    }
}
