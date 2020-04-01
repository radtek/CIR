using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Cir.Azure.Functions.Test.ParameterGetter
{
    
    public class HeaderParameterGetterTest
    {
        private HeaderParameterGetter sut;
        private HttpRequest request;

        public HeaderParameterGetterTest()
        {
            var context = new DefaultHttpContext();
            request = context.Request;
            sut = new HeaderParameterGetter();
        }

        [Fact]
        public void CaseInsensitive()
        {
            // Arrange
            var expected = "value";
            request.Headers.Add("CaSeInSeNsItIvE", expected);

            // Act
            var actual = sut.GetString("CASEinsensitive", request);

            // Assert
            Assert.Equal(expected, actual);
        }


        [Fact]
        public void Missing()
        {
            // Arrange
            request.Headers.Add("X-Header", "a");
            // Act
            Assert.Throws<HeaderParameterException>(() => sut.GetString("Missing header", request));

            // Assert
        }
    }
}
