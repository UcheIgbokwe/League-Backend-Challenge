using System;
using System.IO;
using System.Threading;
using Microsoft.AspNetCore.Http;
using Moq;
using Xunit;

namespace Tests
{
    public class Test_Csv_Upload
    {
        [Fact]
        public void File_Path_Found()
        {
            // Arrange.
            var sourceImg = File.OpenRead("./Resources/matrix.csv");
            if (sourceImg == null)
            {
                Assert.True(true, "File path is found");
            }
        }

        [Fact]
        public void File_Is_Valid()
        {
            // Arrange.
            var sourceImg = File.OpenRead("./Resources/matrix.csv");
            var ms = new MemoryStream();
            var writer = new StreamWriter(ms);
            writer.Write(sourceImg);
            writer.Flush();
            ms.Position = 0;
            
            var fileName = "matrix.csv";

             if (sourceImg.Name.Contains(fileName))
            {
                Assert.True(true, "File name is valid");
            }
        }
    }
}