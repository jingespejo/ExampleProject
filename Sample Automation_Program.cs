using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace TestAuto
{
    class Program
    {
         static void Main(string[] args)
        {

            /*CREATE AUTOMATION THAT CHECK-OUT AN ITEM*/


            ChromeDriver chromeDriver = new ChromeDriver();
            //const string quote = "\"";

            chromeDriver.Manage().Window.Maximize();

            //Direct to web site
            string url = "https://staging.sunterrabbq.com.au/";
            chromeDriver.Navigate().GoToUrl(url);

            //Verify if succcessfully landed to test site
            var element = chromeDriver.FindElementByClassName("featured-section-heading");
            Assert.IsTrue(element.Displayed);
            Assert.AreEqual(element.Text.ToLower(), "Featured Products".ToLower());

            //Click the Grill menu
            var menu1 = chromeDriver.FindElementByLinkText("Grills");
            menu1.Click();

            //Verify if the succcessfully go to Grill page
            var grillPage = chromeDriver.FindElementByClassName("cat-brand-heading");
            Assert.IsTrue(grillPage.Displayed);
            Assert.AreEqual(grillPage.Text.ToLower(), "Grills".ToLower());

            //Click the Product#2 
            var productNo2 = chromeDriver.FindElementByXPath("//*[@id='product-listing-container']/form/ul/li[2]/article/figure/a/div/img");
            productNo2.Click();

            //Verify Product#2 description                
            var grillProductNo2 = chromeDriver.FindElementByXPath("//*[@id='main-content']/div[1]/div[2]/div[1]/section[2]/div/h1");
            Assert.IsTrue(grillProductNo2.Displayed);
           
            ///Click add to cart
            var addToCard = chromeDriver.FindElementById("form-action-addToCart");
            addToCard.Click();

            /** //Scrolling down the page till the element is found	
            IJavaScriptExecutor js = (IJavaScriptExecutor)chromeDriver;
            js.ExecuteScript("window.scrollBy(0,100)"); **/

            //Check out
            chromeDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            var checkOut = chromeDriver.FindElementByClassName("cart-actions");
            checkOut.Click();

            //Verify if in Check out page
            var orderSummary = chromeDriver.FindElementByClassName("cart-header");
            Assert.IsTrue(orderSummary.Displayed);
            Assert.AreEqual(orderSummary.Text.ToLower(), "Order Summary Edit Cart".ToLower());

            chromeDriver.Quit();
        }
    }
}
