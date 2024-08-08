using System.ComponentModel.DataAnnotations;

public class Message
{
    public int Id { get; set; }

    [Required]
    public string User { get; set; }

    [Required]
    public string EncryptedMessage { get; set; }

    [Required]
    public string DecryptedMessage { get; set; }
}
