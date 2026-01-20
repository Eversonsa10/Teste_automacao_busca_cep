using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace MeuProjetoTeste.Drivers
{
    public class WebDriverManager
    {
        private IWebDriver _driver;

        public IWebDriver GetDriver()
        {
            if (_driver == null)
            {
                var options = new ChromeOptions();
                options.AddArgument("--start-maximized");
                _driver = new ChromeDriver(options);
            }
            return _driver;
        }

        public void QuitDriver()
        {
            _driver?.Quit();
            _driver = null;
        }
    }
}
