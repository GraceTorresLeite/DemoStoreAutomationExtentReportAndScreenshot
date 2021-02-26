using OpenQA.Selenium;


namespace TestProject.PageObject
{
    public class HomeSearchBatman
    {
        private IWebDriver Driver { get; }

        public HomeSearchBatman(IWebDriver webDriver)
        {
            Driver = webDriver;
        }

        IWebElement inputSearch => Driver.FindElement(By.Id("search_input"));
        IWebElement btnSearch => Driver.FindElement(By.XPath("//button[@title='Search']"));

        public void writeSearch(string search)
        {
            inputSearch.SendKeys(search);
            btnSearch.Submit();
        }


    }
}
