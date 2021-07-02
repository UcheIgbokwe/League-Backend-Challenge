using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using MathNet.Numerics.LinearAlgebra;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EchoController : ControllerBase
    {
        /// <summary>
        /// Return the matrix as a string in matrix format..
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet("GetResult")]
        //[ProducesResponseType(typeof(PinValidationDTO), statusCode: 200)]
        public async Task<IActionResult> GetResult()
        {
            try
            {
                var file = Path.Combine(Directory.GetCurrentDirectory(), "Resources", "matrix.csv");
                using(var reader = new StreamReader(file))
                {
                    List<string> listA = new List<string>();
                    List<string> listB = new List<string>();
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        var values = line.Split(';');

                        listA.Add(values[0]);
                    }
                }

                double[][] biglist = new double[3][];

                biglist[0] = new double[] { 1, 2, 3, 4, 5 };
                biglist[1] = new double[] { 5, 3, 3, 2, 1 };
                biglist[2] = new double[] { 3, 4, 4, 5, 2 };

                Matrix<double> matrix = Matrix<double>.Build.DenseOfColumns(biglist);
                Console.WriteLine(matrix);
                return Ok(matrix);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}