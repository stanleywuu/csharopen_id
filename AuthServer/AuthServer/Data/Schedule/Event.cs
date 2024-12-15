using System.ComponentModel.DataAnnotations;

namespace AuthServer.Data;

public enum EventStatus
{
    Pending,
    Accepting,
    Confirmed,
    Concluded,
    Cancelled
}

public class Event
{
    public Guid Id { get; set; }
    [MaxLength(500)]
    public string Name { get; set; } = null!;
    [MaxLength(5000)]
    public string Description { get; set; } = null!;
    
    public DateTime StartDateTime { get; set; }
    public DateTime? EndDateTime { get; set; }
    public EventStatus Status { get; set; }
    
    public string? EventJSON { get; set; }
}