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
    public Guid TaskId { get; } = Guid.NewGuid();
    [Required (ErrorMessage = "Title is required")] 
    public string? Title { get; set; }
    [Required (ErrorMessage = "Task description is required")]
    public string? Description { get; set; }
    public bool IsCompleted { get; set; } = false;
    [Required (ErrorMessage = "The task must have a category")] 
    public List<Category> Categories { get; set; } = [];
}

public class Category
{
    [NotMapped]
    public string? Name {get; set; }
    [NotMapped]
    public Priority Priority { get; set; } = Priority.Low;
}

public enum Priority
{
    Low = 0,
    Medium = 1,
    High = 2
}