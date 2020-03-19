namespace dot_net_selenium_examples
{
    using System;
    using NUnit.Framework;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using SmartSelectors;
    using SmartSelectors.Selenium;

    public class GItHubReadmeExamples
    {
        private IWebDriver _driver;

        [SetUp]
        public void SetUp()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            _driver.Manage().Window.Maximize();
        }

        [Test]
        public void ClickFavoriteIcon()
        {
            _driver.Navigate().GoToUrl("https://github.com/SmartSelectors/smart-selectors-dot-net");
            var favoriteIcon = _driver.FindIcon(Icons.Favorite);
            favoriteIcon.Click();
        }

        [Test]
        public void ClickFavoriteIconWithSelfHealingSelector()
        {
            _driver.Navigate().GoToUrl("https://github.com/SmartSelectors/smart-selectors-dot-net");
            var favoriteIcon = _driver.FindElement(By.XPath("//button[contains(@class,'js-toggler-target')]"), Icons.Favorite);
            favoriteIcon.Click();
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
        }
    }
}
