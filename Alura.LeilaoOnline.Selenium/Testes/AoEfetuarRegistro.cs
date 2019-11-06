using Alura.LeilaoOnline.Selenium.Fixtures;
using Alura.LeilaoOnline.Selenium.PageObjects;
using OpenQA.Selenium;
using Xunit;

namespace Alura.LeilaoOnline.Selenium.Testes
{
    [Collection("Chrome Driver")]
    public class AoEfetuarRegistro
    {
        private IWebDriver driver;

        public AoEfetuarRegistro(TestFixture fixture) => driver = fixture.Driver;


        [Fact]
        public void DadoInfoValidasDeveIrParaPaginaDeAgradecimento()
        {
            //arrange - dado chrome aberto, página inicial do sist. de leilões, 
            //dados de registro válidos informados
            driver.Navigate().GoToUrl("http://localhost:5000");

            //nome
            var inputNome = driver.FindElement(By.Id("Nome"));

            //email
            var inputEmail = driver.FindElement(By.Id("Email"));

            //password
            var inputSenha = driver.FindElement(By.Id("Password"));

            //confirmpassword
            var inputConfirmSenha = driver.FindElement(By.Id("ConfirmPassword"));

            //botão de registro
            var botaoRegistro = driver.FindElement(By.Id("btnRegistro"));

            inputNome.SendKeys("Daniel Portugal");
            inputEmail.SendKeys("daniel.portugal@caelum.com.br");
            inputSenha.SendKeys("123");
            inputConfirmSenha.SendKeys("123");

            //act - efetuo o registro
            botaoRegistro.Click();

            //assert - devo ser direcionado para uma página de agradecimento
            Assert.Contains("Obrigado", driver.PageSource);

        }

        [Theory]
        [InlineData("", "daniel.portugal@caelum.com.br", "123", "123")]
        [InlineData("Daniel Portugal", "daniel", "123", "123")]
        [InlineData("Daniel Portugal", "daniel.portugal@caelum.com.br", "123", "456")]
        [InlineData("Daniel Portugal", "daniel.portugal@caelum.com.br", "123", "")]
        public void DadoInfoinvalidasDeveContinuarNaHome(
            string nome,
            string email,
            string senha,
            string confirmSenha)
        {
            //arrange - dado chrome aberto, página inicial do sist. de leilões, 
            //dados de registro válidos informados
            driver.Navigate().GoToUrl("http://localhost:5000");

            //nome
            var inputNome = driver.FindElement(By.Id("Nome"));

            //email
            var inputEmail = driver.FindElement(By.Id("Email"));

            //password
            var inputSenha = driver.FindElement(By.Id("Password"));

            //confirmpassword
            var inputConfirmSenha = driver.FindElement(By.Id("ConfirmPassword"));

            //botão de registro
            var botaoRegistro = driver.FindElement(By.Id("btnRegistro"));

            inputNome.SendKeys(nome);
            inputEmail.SendKeys(email);
            inputSenha.SendKeys(senha);
            inputConfirmSenha.SendKeys(confirmSenha);

            //act - efetuo o registro
            botaoRegistro.Click();

            //assert - devo ser direcionado para uma página de agradecimento
            Assert.Contains("section-registro", driver.PageSource);

        }

        [Fact]
        public void DadoNomeEmBrancoDeveMostrarMensagemDesErro()
        {
            driver.Navigate().GoToUrl("http://localhost:5000");

            var botaoRegistro = driver.FindElement(By.Id("btnRegistro"));

            //act - efetuo o registro
            botaoRegistro.Click();

            //assert - devo ser direcionado para uma página de agradecimento
            var elemento = driver.FindElement(By.CssSelector("span.msg-erro[data-valmsg-for=Nome]"));
            Assert.Equal("The Nome field is required.", elemento.Text);

        }

        [Fact]
        public void DadoEmailInvalidoDeveMostrarMensagemDeErro()
        {
            var registro = new RegistroPO(driver);

                registro.Visitar();

            registro.PreencheFormulario(nome: "", email: "daniel", senha: "", confirmaSenha: "");

            var botaoRegistro = driver.FindElement(By.Id("btnRegistro"));

            var inputEmail = driver.FindElement(By.Id("Email"));

            inputEmail.SendKeys("ASAASSA");

            botaoRegistro.Click();

            registro.SubmeteFormulario();

            Assert.Equal("Please enter a valid email address.", registro.EmailMensagemErro);


        }
    }
}
