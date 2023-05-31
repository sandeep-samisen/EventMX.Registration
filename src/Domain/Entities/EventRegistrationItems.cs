using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventMX.Registration.Domain.Entities;
public class EventRegistrationItems : BaseAuditableEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int EventId { get; set; }
    public int Min { get; set; }
    public int Max { get; set; }
    public double Price { get; set; }
    public string Description { get; set; } = string.Empty;
}
