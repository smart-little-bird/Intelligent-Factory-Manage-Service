

namespace Intelligent.Factory.Management.Assistance.Services;

public interface IFileBuilder
{
    public bool Generate<T>() where T : class;
}