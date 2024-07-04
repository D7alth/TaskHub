using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TaskHub.Models;

public class User
{
    [BsonId]
    [BsonElement("_id")]
    [BsonRepresentation(BsonType.ObjectId)]
    public Guid UserId { get; private set; } = new();
    [Required (ErrorMessage = "User Name is required")]
    [MaxLength(255)]
    public string? Name { get; set; }
    [Required (ErrorMessage = "Email is required")]
    [EmailAddress (ErrorMessage = "Invalid Email Address")]
    [MaxLength(255)]
    public string? Email { get; set; }
    [Required (ErrorMessage = "Password is required")]
    [PasswordPropertyText]
    public string? Password { get; set; }
}