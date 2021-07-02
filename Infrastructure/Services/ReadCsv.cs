using System;
using System.IO;
using System.Threading.Tasks;
using Application.Behaviours;
using Application.Contracts;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Services
{
    public class ReadCsv : IReadCsv
    {
        private readonly ILogger<ReadCsv> _logger;
        public ReadCsv(ILogger<ReadCsv> logger)
        {
            _logger = logger;

        }
        public async Task<double> CreateMatrix()
        {
            try
            {
                var file = Path.Combine(Directory.GetCurrentDirectory(), "Resources", "matrix.csv");

                return 0;
            }
            catch (Exception ex)
            {
                 _logger.LogError($"Error in ReadCsv.CreateMatrix: {ex.Message}");
                throw new InvalidResponseException(ex.Message);
            }
        }
    }
}