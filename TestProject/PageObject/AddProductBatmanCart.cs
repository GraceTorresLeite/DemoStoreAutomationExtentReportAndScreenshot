using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestProject.PageObject
{
    public class AddProductBatmanCart
    {
        private IWebDriver Driver { get; }

        public AddProductBatmanCart(IWebDriver webDriver)
        {
            Driver = webDriver;
        }

        public IWebElement chooseProduct => Driver.FindElement(By.XPath("//form[@name='product_form_96']/div[2]/bdi/a[@title='Batman: Arkham City (X360) CE']"));
        // IWebElement increaseOne => Driver.FindElement(By.ClassName("cm-increase ty-value-changer__increase"));
        IWebElement btnCart => Driver.FindElement(By.Id("button_cart_96"));


        public void addProduct()
        {
            chooseProduct.Click();
            //increaseOne.Click();
            btnCart.Submit();
        }
    }
}