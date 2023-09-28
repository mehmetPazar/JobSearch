using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Common;

namespace Domain.Entities;

[Table("employers")]
public class Employer : BaseEntity
{
    [Required]
    [Column("company_name")]
    public string CompanyName { get; set; }

    [Required]
    [Column("telephone_number")]
    public string TelephoneNumber { get; set; }

    [Required]
    [Column("address")]
    public string Address { get; set; }

    [Required]
    [Column("number_of_job_postings")]
    public int NumberOfJobPostings  { get; set; }

    public ICollection<JobPosting> JobPostings { get; } = new List<JobPosting>();
}