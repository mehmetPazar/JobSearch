namespace Application.Wrappers;

public class Link
{
    public Link(string href, string rel, string type)
    {
        Href = href;
        Rel = rel;
        Type = type;
    }

    public Link(string href)
    {
        Href = href;
    }

    public string Href { get; private set; }
    public string Rel { get; private set; }
    public string Type { get; private set; }
}