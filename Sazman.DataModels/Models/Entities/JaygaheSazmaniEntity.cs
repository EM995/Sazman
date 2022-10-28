namespace Sazman.DataModels.Models
{
    public class JaygaheSazmaniEntity : BaseEntity
    {
        public string? OnvaneJaygah { get; set; }
        public bool? ModiriyyatAst { get; set; }

        public VahedeSazmaniEntity? VahedeSazmani { get; set; }
        public Guid? VahedeSazmaniId { get; set; }

        public PersonnelEntity? Personnel { get; set; }
        public Guid? PersonnelId { get; set; }
    }
}
