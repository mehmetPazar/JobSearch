using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Common;

public class BaseEntity
{
    [Key]
    [Column("id")]
    public long Id { get; set; }

    [Column("created_by")]
    public string CreatedBy { get; set; }

    [Required]
    [Column("created")]
    public DateTime Created { get; set; }

    [Column("last_modified_by")]
    public string LastModifiedBy { get; set; }

    [Column("last_modified")]
    public DateTime? LastModified { get; set; }
}