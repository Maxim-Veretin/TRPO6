using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

//План тестирования:
//1. Проверить заголовок страницы
//2. Проверка видимости объектов
//3. Переход по ссылке
//4. Заполнение текстового поля
//5. Эмуляция нажатия на кнопку

namespace SiteTest
{
    [TestFixture]
    public class Class1
    {
        IWebDriver webDriver = new ChromeDriver();

        [TestCase]//заголовок
        public void MainTitle()
        {
            //webDriver.Url = "https://www.nstu.ru/";

            //Assert.AreEqual("НГТУ. Новосибирский государственный технический университет", webDriver.Title);
            webDriver.Url = "https://sibsutis.ru/";

            Assert.AreEqual("Сибирский государственный университет телекоммуникаций и информатики", webDriver.Title);
            webDriver.Close();
        }

        [TestCase]//видимость объектов
        public void DisplayObject()
        {
            //webDriver.Url = "https://www.nstu.ru/";

            //IWebElement element = webDriver.FindElement(By.XPath("//*[@id=\"query\"]"));
            webDriver.Url = "https://sibsutis.ru/";

            IWebElement element = webDriver.FindElement(By.XPath("//*[@id=\"layout\"]/div[2]/div[2]/div[2]/div[6]/div[2]/a[1]"));
            bool status = element.Displayed;
            Assert.True(status);

            webDriver.Close();
        }

        [TestCase]//переход по ссылке и эмуляция нажатия на кнопку 
        public void LinkPath_ButtonClick()
        {
            webDriver.Url = "https://sibsutis.ru/";

            IWebElement element = webDriver.FindElement(By.XPath("//*[@id=\"mainMenu\"]/a[1]"));
            bool status = element.Displayed;
            element.Click();
            //webDriver.Navigate().Forward();

            IWebElement element1 = webDriver.FindElement(By.XPath("//*[@id=\"layout\"]/h1/a"));
            bool status1 = element1.Displayed;
            Assert.True(status1);

           // webDriver.Close();
        }

        [TestCase]//заполнение текстового поля
        public void Enter()
        {
            webDriver.Url = "https://sibsutis.ru/";

            IWebElement search = webDriver.FindElement(By.XPath("//*[@id=\"qqq\"]"));//ссылка на строку поиска
            search.SendKeys("]t]аогевгоеошгеогеокык7говер");//ввод запроса

            IWebElement button = webDriver.FindElement(By.XPath("//*[@id=\"layout\"]/div[2]/div[2]/div[2]/div[3]/form/input[2]"));//ссылка на кнопку найти
            button.Click();

            Assert.IsTrue(webDriver.PageSource.Contains("К сожалению, на ваш поисковый запрос ничего не найдено."));

            webDriver.Close();
        }

        //[TestCase]//эмуляция нажатия на кнопку
        //public void But()
        //{
        //    webDriver.Url = "https://sibsutis.ru/";

        //    IWebElement button = webDriver.FindElement(By.XPath("//*[@id=\"layout\"]/div[2]/div[2]/div[2]/div[6]/div[2]/a[1]"));
        //    bool status = button.Displayed;
        //    Assert.True(status);

        //    button.PerformClick();
        //}

        [TearDown]//все тесты выполнены
        public void TestEnd()
        {
         //   webDriver.Quit();
        }
    }
}
