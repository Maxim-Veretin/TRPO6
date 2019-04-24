using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

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
            webDriver.Url = "https://www.nstu.ru/";
            Assert.AreEqual("НГТУ. Новосибирский государственный технический университет", webDriver.Title);

            //webDriver.Close();
        }

        [TestCase]//видимость объектов
        public void DisplayObject()
        {
            webDriver.Url = "https://www.nstu.ru/";
            IWebElement element = webDriver.FindElement(By.XPath("//*[@id=\"query\"]"));
            bool status = element.Displayed;

            //webDriver.Close();
        }

        [TestCase]//переход по ссылке
        public void LinkPath()
        {
            webDriver.Url = "https://www.nstu.ru/";
            webDriver.Navigate().Forward();
        }

        [TestCase]//заполнение текстового поля

        [TearDown]//все тесты выполнены
        public void TestEnd()
        {
            webDriver.Quit();
        }
    }
}
