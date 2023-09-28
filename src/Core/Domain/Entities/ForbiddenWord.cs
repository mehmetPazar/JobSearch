using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Common;

namespace Domain.Entities;

[Table("forbidden_words")]
public class ForbiddenWord : BaseEntity
{
    [Required]
    [Column("word")]
    public string Word { get; set; }
}