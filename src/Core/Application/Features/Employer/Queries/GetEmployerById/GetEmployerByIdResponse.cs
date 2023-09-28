namespace Application.Features.Employer.Queries.GetEmployerById;

public class GetEmployerByIdResponse
{
    public long Id { get; set; }

    public string CompanyName { get; set; }

    public string TelephoneNumber { get; set; }

    public string Address { get; set; }

    public int NumberOfJobPostings { get; set; }
}