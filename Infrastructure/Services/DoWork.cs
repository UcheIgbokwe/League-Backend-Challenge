using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Application.Behaviours;
using Application.Contracts;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Services
{
    public class DoWork : IDoWork
    {
        private readonly ILogger<DoWork> _logger;
        public DoWork(ILogger<DoWork> logger)
        {
            _logger = logger;

        }
        public async Task<double[][]> Implement()
        {
            try
            {
                double[][] biglist = new double[3][];
                var file = Path.Combine(Directory.GetCurrentDirectory(), "Resources", "matrixX.csv");
                using(var reader = new StreamReader(file))
                {
                    double[] terms = new double[3];
                    for (int inc = 0; !reader.EndOfStream; inc++)
                    {
                        var line = reader.ReadLine();
                        var values = line.Split(';');

                        terms[inc] = Convert.ToDouble(values[0]);
                    }
                    string termList = terms[0].ToString();
                    string termList1 = terms[1].ToString();
                    string termList2 = terms[2].ToString();

                    biglist[0] = new double[] {Convert.ToDouble(termList[0].ToString()),Convert.ToDouble(termList[1].ToString()),Convert.ToDouble(termList[2].ToString())};
                    biglist[1] = new double[] {Convert.ToDouble(termList1[0].ToString()),Convert.ToDouble(termList1[1].ToString()),Convert.ToDouble(termList1[2].ToString())};
                    biglist[2] = new double[] {Convert.ToDouble(termList2[0].ToString()),Convert.ToDouble(termList2[1].ToString()),Convert.ToDouble(termList2[2].ToString())};

                }
                return await Task.FromResult<double[][]>(biglist);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in DoWork.Implement: {ex.Message}");
                throw new InvalidResponseException(ex.Message);
            }
        }

        public async Task<List<string>> Flatten()
        {
            try
            {
                List<string> biglist = new();
                var file = Path.Combine(Directory.GetCurrentDirectory(), "Resources", "matrix.csv");
                using(var reader = new StreamReader(file))
                {
                    double[] terms = new double[3];
                    while(!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        var values = line.Split(';');
                        biglist.Add(values[0]);
                    }
                }
                return await Task.FromResult<List<string>>(biglist);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in DoWork.Flatten: {ex.Message}");
                throw new InvalidResponseException(ex.Message);
            }
        }

        public async Task<double> Sum()
        {
            try
            {
                double biglist = new();
                var file = Path.Combine(Directory.GetCurrentDirectory(), "Resources", "matrix.csv");
                using(var reader = new StreamReader(file))
                {
                    double[] terms = new double[3];
                    for (int inc = 0; !reader.EndOfStream; inc++)
                    {
                        var line = reader.ReadLine();
                        var values = line.Split(';');

                        terms[inc] = Convert.ToDouble(values[0]);
                    }
                    string termList = terms[0].ToString();
                    string termList1 = terms[1].ToString();
                    string termList2 = terms[2].ToString();

                    var biglist1 = Convert.ToDouble(termList[0].ToString()) + Convert.ToDouble(termList[1].ToString())+ Convert.ToDouble(termList[2].ToString());
                    var biglist2 = Convert.ToDouble(termList1[0].ToString()) + Convert.ToDouble(termList1[1].ToString())+ Convert.ToDouble(termList1[2].ToString());
                    var biglist3 = Convert.ToDouble(termList2[0].ToString()) + Convert.ToDouble(termList2[1].ToString())+ Convert.ToDouble(termList2[2].ToString());
                    biglist = biglist1 + biglist2 + biglist3;

                }
                return await Task.FromResult<double>(biglist);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in DoWork.Flatten: {ex.Message}");
                throw new InvalidResponseException(ex.Message);
            }
        }

        public async Task<double> Product()
        {
            try
            {
                double biglist = new();
                var file = Path.Combine(Directory.GetCurrentDirectory(), "Resources", "matrix.csv");
                using(var reader = new StreamReader(file))
                {
                    double[] terms = new double[3];
                    for (int inc = 0; !reader.EndOfStream; inc++)
                    {
                        var line = reader.ReadLine();
                        var values = line.Split(';');

                        terms[inc] = Convert.ToDouble(values[0]);
                    }
                    string termList = terms[0].ToString();
                    string termList1 = terms[1].ToString();
                    string termList2 = terms[2].ToString();

                    var biglist1 = Convert.ToDouble(termList[0].ToString()) * Convert.ToDouble(termList[1].ToString()) * Convert.ToDouble(termList[2].ToString());
                    var biglist2 = Convert.ToDouble(termList1[0].ToString()) * Convert.ToDouble(termList1[1].ToString()) * Convert.ToDouble(termList1[2].ToString());
                    var biglist3 = Convert.ToDouble(termList2[0].ToString()) * Convert.ToDouble(termList2[1].ToString()) * Convert.ToDouble(termList2[2].ToString());
                    biglist = biglist1 * biglist2 * biglist3;

                }
                return await Task.FromResult<double>(biglist);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in DoWork.Flatten: {ex.Message}");
                throw new InvalidResponseException(ex.Message);
            }
        }
    }
}