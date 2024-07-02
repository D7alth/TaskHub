using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TaskHub.Models;

[Table("Users")]
public class User
{
    [BsonId]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [BsonElement("_id")]
    [Key]
    [BsonRepresentation(BsonType.String)]
    public Guid UserId { get; set; }
    [Required (ErrorMessage = "User Name is required")]
    public string? Name { get; set; }
    [Required (ErrorMessage = "Email is required")]
    [EmailAddress (ErrorMessage = "Invalid Email Address")]
    public string? Email { get; set; }
    [Required (ErrorMessage = "Password is required")]
    [PasswordPropertyText]
    public string? Password { get; set; }
    [ForeignKey(nameof(Task.TaskId))]
    public List<Task> Tasks { get; set; } = [];
}