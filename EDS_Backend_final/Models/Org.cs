using EDS_Backend_final.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class Org : AuditableEntity
{
    [Key]
    public int OrganizationID { get; set; }

    [Required]
    public string OrganizationCode { get; set; }

    [Required]
    [MaxLength(255)]
    public string ParentOrganizationCode { get; set; }

    public string ParentOrganizationLevel { get; set; }

    public string OrganizationLevel { get; set; }

    // Foreign key property for the relationship
    public int ClientID { get; set; }

    // Navigation property for the relationship
    public Client Client { get; set; }

    public List<OrgLevel> Levels { get; set; }
}
