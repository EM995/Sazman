namespace Sazman.Tests.TestEntities
{
    internal class Personnel : Base
    {
        public byte[]? Aks { get; set; }
        public long? CodePersonneli { get; set; }
        public string? Nam { get; set; }
        public string? NameXanevadegi { get; set; }
        public string? CodeMelli { get; set; }
        public DateTime? TarixTavallod { get; set; }
        public string? Address { get; set; }
        public NezamVazife? NezamVazife { get; set; }
    }
}
