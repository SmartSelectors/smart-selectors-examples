namespace dot_net_selenium_examples
{
    using System;
    using FluentAssertions;
    using NUnit.Framework;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using SmartSelectors;
    using SmartSelectors.Selenium;

    public class GitHubReadmeExamples
    {
        private IWebDriver _driver;
        private const string WorkflowsXPath = "//h1[@class='d-none d-lg-block f3']";
        private const string ExpectedHeader = "All workflows";

        [SetUp]
        public void SetUp()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            _driver.Manage().Window.Maximize();
        }

        [Test]
        public void GoToGitHubActions()
        {
            _driver.Navigate().GoToUrl("https://github.com/SmartSelectors/smart-selectors-dot-net");
            var actionsIcon = _driver.FindIcon(Icons.Arrow_Right);
            actionsIcon.Click();
            var header = _driver.FindElement(By.XPath(WorkflowsXPath));
            header.Text.Should().Be(ExpectedHeader);
        }

        [Test]
        public void GoToGitHubActionsWithSelfHealingSelector()
        {
            _driver.Navigate().GoToUrl("https://github.com/SmartSelectors/smart-selectors-dot-net");
            var actionsIcon = _driver.FindElement(By.XPath("#brokenSelector"), Icons.Arrow_Right);
            actionsIcon.Click();
            var header = _driver.FindElement(By.XPath(WorkflowsXPath));
            header.Text.Should().Be(ExpectedHeader);
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
        }
    }
}
