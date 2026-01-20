using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teste_Automacao_Busca_Cep.Pages
{
    public class BuscaCepPage
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;

        public BuscaCepPage(IWebDriver driver, WebDriverWait wait)
        {
            _driver = driver;
            _wait = wait;
        }

        // Elementos (Seletores)
        private By CampoEndereco = By.Id("endereco");
        private By TabelaResultados = By.Id("resultado-DNEC");
        private By MensagemErro = By.Id("mensagem-resultado");
        private By BotaoNovaBusca = By.Id("btn_nbusca");
        private By CelulaLogradouro = By.XPath("//td[@data-th='Logradouro/Nome']");

        // Ações
        public void PreencherCep(string cep)
        {
            var campo = _wait.Until(ExpectedConditions.ElementIsVisible(CampoEndereco));
            campo.Clear();
            campo.SendKeys(cep);
        }

        public void AguardarResultadoOuErro()
        {
            _wait.Until(d => d.FindElements(TabelaResultados).Count > 0 ||
                             d.FindElements(MensagemErro).Count > 0);
        }

        public string ObterMensagemDeErro()
        {
            return _wait.Until(ExpectedConditions.ElementIsVisible(MensagemErro)).Text;
        }

        public string ObterLogradouro()
        {
            return _wait.Until(ExpectedConditions.ElementIsVisible(CelulaLogradouro)).Text;
        }

        public void ClicarNovaBusca()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(BotaoNovaBusca)).Click();
            _wait.Until(ExpectedConditions.ElementIsVisible(CampoEndereco));
        }
    }
}
