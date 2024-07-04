using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TaskHub.Models;

public class Task 
{
    [BsonId]
    [BsonElement("_id")]
    [BsonRepresentation(BsonType.String)]
    public Guid TaskId { get; private set; } = new();
    [Required (ErrorMessage = "Title is required")] 
    [MaxLength(50)]
    public string? Title { get; set; }
    [Required (ErrorMessage = "Task description is required")]
    [MaxLength(255)]
    public string? Description { get; set; }
    public bool IsCompleted { get; set; } = false;
    [ForeignKey(nameof(User.UserId))]
    public List<Guid> UserId { get; set; } = [];
}
