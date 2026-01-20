using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using MeuProjetoTeste.Drivers;
using Reqnroll;

namespace MeuProjetoTeste.Support
{
    [Binding]
    public class Hooks
    {
        private readonly WebDriverManager _driverManager;
        private readonly ScenarioContext _scenarioContext;

        public Hooks(WebDriverManager driverManager, ScenarioContext scenarioContext)
        {
            _driverManager = driverManager;
            _scenarioContext = scenarioContext;
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            IWebDriver driver = _driverManager.GetDriver();

            // Centralizamos os Waits no ScenarioContext para qualquer classe usar
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(40));

            _scenarioContext["WebDriver"] = driver;
            _scenarioContext["WebDriverWait"] = wait;
        }

        [AfterScenario]
        public void AfterScenario()
        {
            _driverManager.QuitDriver();
        }
    }
}