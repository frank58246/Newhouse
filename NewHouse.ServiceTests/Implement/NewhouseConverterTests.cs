using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NewHouse.Service.Dtos;
using NewHouse.Service.Implement;
using NewHouse.Service.Interface;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace NewHouse.Service.Implement.Tests
{
    [TestClass()]
    public class NewhouseConverterTests
    {
        private ICountyDistrictService _countyDistrictService;

        public NewhouseConverterTests()
        {
            this._countyDistrictService = Substitute.For<ICountyDistrictService>();
        }

        [TestMethod()]
        public async Task ConvertTo591DtoAsync_hid為126199_輸出相對應的Dto()
        {
            // Arrange
            var sut = this.GetSystemUnderTest();
            var hid = 126199;
            var html = this.GetHtmlDetail(hid);
            var expected = new Newhouse591Dto
            {
            };

            // Act
            var actual = await sut.ConvertTo591DtoAsync(html, hid);

            // Actual
            actual.Should().BeEquivalentTo(expected);
        }

        private NewhouseConverter GetSystemUnderTest()
        {
            return new NewhouseConverter(this._countyDistrictService);
        }

        private string GetHtmlDetail(int hid)
        {
            var baseDir = "TestData";
            var fileName = $"newhouse_html_detail_hid_{hid}.html";

            var path = Path.Combine(baseDir, fileName);

            if (File.Exists(path).Equals(false))
            {
                return string.Empty;
            }

            return File.ReadAllText(path);
        }
    }
}