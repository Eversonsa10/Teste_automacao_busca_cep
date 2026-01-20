using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Reqnroll;
using SeleniumExtras.WaitHelpers;
using System;
using System.Linq;
using Teste_Automacao_Busca_Cep.Pages;

namespace MeuProjetoTeste.StepDefinitions
{
    [Binding]
    public class BuscaCepSteps
    {
        private readonly IWebDriver _driver;
        private readonly BuscaCepPage _buscaCepPage;
        private readonly RastreamentoPage _rastreioPage;

        public BuscaCepSteps(ScenarioContext scenarioContext)
        {
            // aqui o Reqnroll injeta o objeto
            _driver = (IWebDriver)scenarioContext["WebDriver"];
            var wait = (WebDriverWait)scenarioContext["WebDriverWait"];

            // Inicializo as páginas
            _buscaCepPage = new BuscaCepPage(_driver, wait);
            _rastreioPage = new RastreamentoPage(_driver, wait);
        }

        [Given(@"que eu navego para o site dos Correios")]
        public void NavegarParaCorreios()
        {
            _driver.Navigate().GoToUrl("https://buscacepinter.correios.com.br/app/endereco/index.php");
        }

        [When(@"eu busco pelo CEP ""(.*)""")]
        public void QuandoEuBuscoPeloCEP(string cep)
        {
            _buscaCepPage.PreencherCep(cep);
            Console.WriteLine(">>> AGUARDANDO CAPTCHA MANUAL...");
            _buscaCepPage.AguardarResultadoOuErro();
        }

        [Then(@"o sistema deve informar que o CEP não existe")]
        public void EntaoOCEPNaoExiste()
        {
            string msg = _buscaCepPage.ObterMensagemDeErro();
            Assert.That(msg, Does.Contain("Não há dados").Or.Contains("Dados não encontrado"));
        }

        [Then(@"o resultado deve ser ""(.*)""")]
        public void EntaoOResultadoDeveSer(string esperado)
        {
            string logradouro = _buscaCepPage.ObterLogradouro();
            Assert.That(logradouro, Does.Contain("Rua Quinze de Novembro"));
        }

        [StepDefinition(@"eu volto para a tela inicial")]
        public void VoltarTelaInicial()
        {
            _buscaCepPage.ClicarNovaBusca();
        }

        [When(@"eu procuro pelo rastreamento ""(.*)""")]
        public void ProcuroRastreamento(string codigo)
        {
            _driver.Navigate().GoToUrl("https://rastreamento.correios.com.br/app/index.php");
            _rastreioPage.PreencherCodigoRastreio(codigo);
            Console.WriteLine(">>> AGUARDANDO RASTREIO MANUAL...");
            _rastreioPage.AguardarPopUpErro();
        }

        [Then(@"o sistema informa que o código não está correto")]
        public void ValidarCodigoIncorreto()
        {
            Assert.That(_rastreioPage.ObterTextoErro(), Does.Contain("Objeto não encontrado"));
        }
        [Then(@"eu fecho o navegador")]
        public void EntaoEuFechoONavegador()
        {
            // Como usamos a arquitetura de Drivers/Hooks, 
            // o navegador já fecha sozinho no [AfterScenario].
            // Mas para o Reqnroll não reclamar do passo "solto", 
            // podemos apenas dar um Quit ou deixar vazio.
            _driver.Quit();
        }
    }
}