using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumWeb
{
    [TestFixture]
    class FirstTC
    {
        [Test]
        public  void Test()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Url = "http://google.com";
            driver.FindElement(By.Name("q")).SendKeys("five");
            driver.FindElement(By.Name("btnK"));
            var path = "//*[@id='rhs']//div[2]/div[1]/span";
            Assert.That(false, path);
            driver.Quit();
        }
    }
}