using System.ComponentModel.DataAnnotations;
using TUTOR.Model;

public class User
{
    public int UserId { get; set; }
    public required string UserName { get; set; }
    public required string LastName { get; set; }

    [EmailAddress]
    public required string Correo { get; set; }
    public required string Phone { get; set; }
    public required string Password { get; set; }
    public bool IsDeleted { get; set; } = false;

    public DateTime Modified { get; set; } = DateTime.UtcNow;
    public required string ModifiedBy { get; set; }

    // Relaciones (opcional)
    //public ICollection<HistorialTip>? HistorialTips { get; set; }
}




