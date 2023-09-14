namespace Intelligent.Factory.Management.API.DTOs;

public class Page
{
    public int PageSize { get; set; } = 10;

    public int PageIndex { get; set; } = 1;

    public int? Total { get; set; }
}