using Alura.LeilaoOnline.Selenium.Fixtures;
using Alura.LeilaoOnline.Selenium.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;
using System.Reflection;
using Xunit;

namespace Alura.LeilaoOnline.Selenium
{
    [Collection("Chrome Driver")]
    public class AoNavegarParaHome : IClassFixture<TextFixture>
    {
        private IWebDriver driver;

        //Setup
        public AoNavegarParaHome(TextFixture fixture) => driver = fixture.Driver;


        [Fact]
        public void DadoChromeAbertoDeveMostrarLeiloesNoTitulo()
        {
    

            //  Act

            driver.Navigate().GoToUrl("http://localhost:5000");

            //  Assert
            Assert.Contains("Leilões", driver.Title);
        }

        [Fact]
        public void DadoChromeAbertoDeveMostrarProximosLeiloesNaPagina()
        {
        




            //  Act

            driver.Navigate().GoToUrl("http://localhost:5000");

            //  Assert
            Assert.Contains("Próximos Leilões", driver.PageSource);

        }

    }
}
