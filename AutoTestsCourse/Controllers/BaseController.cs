﻿using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections;
using System.Collections.Generic;

namespace AddressBookAutotests.Controllers
{
    public class BaseController
    {
        protected ControllersManager Manager { get; }

        public BaseController(ControllersManager manager)
        {
            Manager = manager;
        }

        protected void FillTextBox(By location, string value)
        {
            if (value == null) return;
            Driver.FindElement(location).Click();
            Driver.FindElement(location).Clear();
            Driver.FindElement(location).SendKeys(value);
        }

        protected void FillTextBox(string name, string value)
        {
            FillTextBox(By.Name(name), value);
        }

        protected string GetTextBoxValue(By location)
        { 
            return Driver.FindElement(location).GetAttribute("value");
        }

        protected string GetTextBoxValue(string name)
        {
            return GetTextBoxValue(By.Name(name));
        }

        protected void SelectElementInComboBox(By location, string value)
        {
            if (string.IsNullOrEmpty(value)) return;
            Driver.FindElement(location).Click();
            new SelectElement(Driver.FindElement(location)).SelectByText(value);
        }

        private void CollectionClicker(ICollection<IWebElement> elements)
        {
            foreach (var element in elements) element.Click();
        }

        protected void SelectElementInComboBox(string name, string value)
        {
            SelectElementInComboBox(By.Name(name), value);
        }

        protected IWebDriver Driver { get => Manager.Driver; }

        public bool ExistsElement(string name) => ExistsElement(By.Name(name));

        public bool ExistsElement(By by)
        {
            try
            {
                Driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException ex)
            {
                return false;
            }
        }
    }
}
