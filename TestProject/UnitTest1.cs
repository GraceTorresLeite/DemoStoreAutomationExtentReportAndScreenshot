using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;
using TestProject.PageObject;

namespace TestProject
{
    [TestFixture]
    public class Tests
    {
        public IWebDriver driver;
        private string baseURL;
        public string screenshotsPasta;
        int count = 1;
        ExtentReports extent = null;
        ExtentTest test;

        [OneTimeSetUp]
        public void ExtentStart()
        {
            extent = new ExtentReports();
            var htmlReport = new ExtentHtmlReporter(@"C:\Users\grace.torres\source\repos\TestProject\TestProject\ExtentReports\");
            extent.AttachReporter(htmlReport);
        }
        [OneTimeTearDown]
        public void ExtentClose()
        {
            extent.Flush();
        }


        //Método para capturar screenshot da tela
        public void Screenshot(IWebDriver driver, string screenshotsPasta)
        {
            ITakesScreenshot camera = driver as ITakesScreenshot;
            // OpenQA.Selenium.Screenshot foto = camera.GetScreenshot();
            var picture = camera.GetScreenshot();
            picture.SaveAsFile(screenshotsPasta, ScreenshotImageFormat.Png);
        }

        [SetUp]
        public void setuptest()
        {
            driver = new ChromeDriver(@"c:\program files\google\chrome");
            driver.Manage().Window.Maximize();
            baseURL = "https://demo.cs-cart.com/";
            screenshotsPasta = @"C:\Users\grace.torres\source\repos\TestProject\screenshot\";
        }
       

        public void captureImage()
        {
            Screenshot(driver, screenshotsPasta + "Imagem_" + count++ + ".png");
            Thread.Sleep(1000);
        }

        [TearDown]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
                test.Log(Status.Pass, "tests Passed");
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
        }

        [Test]

        public void TakeScreenshots()
        {
            test = extent.CreateTest("TakeScreenshots").Info("Test Started");
            test.Log(Status.Info, "Chrome Browser lauched");

            driver.Navigate().GoToUrl(baseURL);
            Thread.Sleep(1000);
            captureImage();
            Thread.Sleep(1000);

            HomeSearchBatman homePage = new HomeSearchBatman(driver);
            homePage.writeSearch("Batman");
            test.Log(Status.Info, "Entered word Batman for search");
            Thread.Sleep(2000);
            captureImage();
            Thread.Sleep(1000);

            AddProductBatmanCart addProductCart = new AddProductBatmanCart(driver);
            addProductCart.addProduct();
            test.Log(Status.Info, "Product add inside cart");
            Thread.Sleep(10000);
            captureImage();
            Thread.Sleep(1000);

           
        }
    }

}