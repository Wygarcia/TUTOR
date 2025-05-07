namespace TUTOR.Model
{
    public class HistorialTip
    {
        public int HistorialTipId { get; set; }

        // Claves foráneas
        //public int UserId { get; set; }
        //public User User { get; set; } = null!;

        public int TipId { get; set; }
        public Tip Tip { get; set; } = null!;

        // Fecha y trazabilidad
        public DateTime FechaVisto { get; set; } = DateTime.UtcNow;

        public bool IsDeleted { get; set; } = false;
        public DateTime Modified { get; set; } = DateTime.UtcNow;
        public required string ModifiedBy { get; set; }
    }
}
