using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Application.Contracts;
using MathNet.Numerics.LinearAlgebra;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EchoController : ControllerBase
    {
        private readonly IDoWork _doWork;
        public EchoController(IDoWork doWork)
        {
            _doWork = doWork;

        }
        
        /// <summary>
        /// Return the matrix as a string in matrix format..
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet("Echo")]
        public async Task<IActionResult> Echo()
        {
            try
            {
                //ECHO & INVERT
                var result = await _doWork.Implement();
                //FLATTEN
                var result2 = await _doWork.Flatten();
                //SUM
                var result3 = await _doWork.Sum();
                //PRODUCT
                var result4 = await _doWork.Product();


                //ECHO
                Matrix<double> echo = Matrix<double>.Build.DenseOfRows(result);
                //INVERT
                Matrix<double> inverted = Matrix<double>.Build.DenseOfColumns(result);

                Console.WriteLine("ECHO");
                Console.WriteLine(echo);
                Console.WriteLine("INVERTED");
                Console.WriteLine(inverted);
                Console.WriteLine("FLATTEN");
                Console.WriteLine(String.Join(",", result2));
                Console.WriteLine(" ");
                Console.WriteLine("SUM OF MATRIX");
                Console.WriteLine(result3);
                Console.WriteLine(" ");
                Console.WriteLine("PRODUCT OF MATRIX");
                Console.WriteLine(result4);


                return Ok("Result is displayed in console.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}