namespace TUTOR.Model
{
    public class Tip
    {
        public int TipId { get; set; }

        public required string TipName { get; set; }
        public required string Contenido { get; set; }
        public required string Autor { get; set; }

        public bool IsDeleted { get; set; } = false;
        public DateTime Modified { get; set; } = DateTime.UtcNow;
        public required string ModifiedBy { get; set; }

        // Relación inversa (opcional)
        public ICollection<HistorialTip>? Historiales { get; set; }
    }
}
