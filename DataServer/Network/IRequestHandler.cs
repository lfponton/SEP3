using System.Threading.Tasks;

namespace DataServer.Network
{
    public interface IRequestHandler
    {
        Task<string> ProcessClientRequestType(string requestType, string args);
    }
}