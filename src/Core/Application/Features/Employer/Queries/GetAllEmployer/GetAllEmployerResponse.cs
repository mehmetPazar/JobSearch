namespace Application.Features.Employer.Queries.GetAllEmployer;

public class GetAllEmployerResponse
{
    public long Id { get; set; }

    public string CompanyName { get; set; }

    public string TelephoneNumber { get; set; }

    public string Address { get; set; }

    public int NumberOfJobPostings { get; set; }
}