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
            webDriver.Url = "https://www.nstu.ru/";

            Assert.AreEqual("НГТУ. Новосибирский государственный технический университет", webDriver.Title);

            webDriver.Close();
        }

        [TestCase]//видимость объектов
        public void DisplayObject()
        {
            webDriver.Url = "https://www.nstu.ru/";

            IWebElement element = webDriver.FindElement(By.XPath("//*[@id=\"query\"]"));
            bool status = element.Displayed;

            webDriver.Close();
        }

        [TestCase]//переход по ссылке
        public void LinkPath()
        {
            webDriver.Url = "https://www.nstu.ru/";

            webDriver.Navigate().Forward();
            webDriver.Navigate().Back();

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

        [TestCase]//эмуляция нажатия на кнопку

        [TearDown]//все тесты выполнены
        public void TestEnd()
        {
            webDriver.Quit();
        }
    }
}
