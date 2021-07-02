using System.Threading.Tasks;

namespace Application.Contracts
{
    public interface IReadCsv
    {
        Task<double> CreateMatrix();
    }
}