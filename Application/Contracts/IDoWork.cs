using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Contracts
{
    public interface IDoWork
    {
        Task<double[][]> Implement();
        Task<List<string>> Flatten();
        Task<double> Sum();
        Task<double> Product();
    }
}