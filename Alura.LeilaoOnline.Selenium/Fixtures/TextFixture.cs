using Alura.LeilaoOnline.Selenium.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alura.LeilaoOnline.Selenium.Fixtures
{
    public class TextFixture : IDisposable
    {
        public IWebDriver Driver { get; private set; }

        //Setup
        public TextFixture() => Driver = new ChromeDriver(TestHelper.PastaDoExecutavel);


        //TearDown 
        public void Dispose() => Driver.Quit();
    }
}
