using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Common;
using Domain.Constants;

namespace Domain.Entities;

[Table("job_postings")]
public class JobPosting : BaseEntity
{
    [Required]
    [Column("position")]
    public string Position { get; set; }

    [Required]
    [Column("description")]
    public string Description { get; set; }

    [Required]
    [Column("expiration_date")]
    public DateTime ExpirationDate { get; set; }

    [Column("quality")]
    public int Quality { get; set; }

    [Column("benefits")]
    public List<string> Benefits { get; set; }

    [Column("type")]
    public EmploymentType Type { get; set; }

    [Column("salary")]
    public decimal Salary { get; set; }

    [Required]
    [Column("employer_id")]
    public long EmployerId { get; set; }

    [ForeignKey("EmployerId")]
    public Employer Employer { get; set; }
}