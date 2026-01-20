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
    public class RastreamentoPage
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;

        public RastreamentoPage(IWebDriver driver, WebDriverWait wait)
        {
            _driver = driver;
            _wait = wait;
        }

        private By CampoObjeto = By.Id("objeto");
        private By TextoPopUp = By.XPath("//*[contains(text(), 'Objeto não encontrado')]");

        public void PreencherCodigoRastreio(string codigo)
        {
            var campo = _wait.Until(ExpectedConditions.ElementIsVisible(CampoObjeto));
            campo.Clear();
            campo.SendKeys(codigo);
        }

        public void AguardarPopUpErro()
        {
            _wait.Until(d => d.FindElements(TextoPopUp).Count > 0);
        }

        public string ObterTextoErro()
        {
            return _driver.FindElement(TextoPopUp).Text;
        }
    }
}
