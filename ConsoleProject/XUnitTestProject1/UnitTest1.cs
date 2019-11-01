using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;
using System.Reflection;
using Xunit;

namespace XUnitTestProject1
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {

            //Arrange - dado que um navegador está aberto

            IWebDriver driver = new ChromeDriver(
                Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)
                );



            // navego para uma URL


            driver.Navigate().GoToUrl("https://trivela.com.br/");


            //Deve ser apresentada a página correta

            Assert.Contains("Trivela", driver.Title);
        }

    
    }
}
