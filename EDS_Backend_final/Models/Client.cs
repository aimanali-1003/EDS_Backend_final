using EDS_Backend_final.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class Client : AuditableEntity
{
    [Key]
    public int ClientID { get; set; }

    [Required]
    [MaxLength(255)]
    public string ClientName { get; set; }

    [Required]
    public string ClientCode { get; set; }

    // Navigation property for the one-to-many relationship
    public List<Org> Orgs { get; set; }
}
