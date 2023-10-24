

namespace Intelligent.Factory.Management.API.Services;

public interface IFileBuilder
{
    public bool Generate<T>() where T : class;
}