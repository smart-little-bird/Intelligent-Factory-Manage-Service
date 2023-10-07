namespace Intelligent.Factory.Management.API.DTOs;

public record PageDto
{
    public int PageSize { get; set; }

    public int PageIndex { get; set; }

    public int Total { get; set; }
}