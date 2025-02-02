﻿using AddressBookAutotests.DataSets;
using AddressBookAutotests.Models;
using NUnit.Framework;

namespace AddressBookAutotests.Tests
{
    [TestFixture]
    public class ContactsTests : TestWithAuth
    {
        [Test, TestCaseSource(typeof(DataProviderAutoGenerator), nameof(DataProviderAutoGenerator.CreateContactDatas))]
        [Order(1)]
        [Description("Add new contact without group")]
        public void AddNewContactWithoutGroupTest(ContactData contactData)
        {
            Manager.Scenarios.AddNewContact(false, contactData);
        }

        [Test, TestCaseSource(typeof(DataProviderFromFile), nameof(DataProviderFromFile.CreatContactDatasFromCSV))]
        [Order(1)]
        [Description("Add new contact from CSV")]
        public void AddNewContactWithoutGroupTestCsv(ContactData contactData)
        {
            Manager.Scenarios.AddNewContact(false, contactData);
        }

        [Test, TestCaseSource(typeof(DataProviderFromFile), nameof(DataProviderFromFile.CreateContactDatasFromXML))]
        [Order(1)]
        [Description("Add new contact from XML")]
        public void AddNewContactWithoutGroupTestXml(ContactData contactData)
        {
            Manager.Scenarios.AddNewContact(false, contactData);
        }

        [Test, TestCaseSource(typeof(DataProviderFromFile), nameof(DataProviderFromFile.CreateContactDatasFromJson))]
        [Order(1)]
        [Description("Add new contact from JSON")]
        public void AddNewContactWithoutGroupTestJson(ContactData contactData)
        {
            Manager.Scenarios.AddNewContact(false, contactData);
        }

        [Test, TestCaseSource(typeof(DataProviderAutoGenerator), nameof(DataProviderAutoGenerator.CreateContactDatas))]
        [Order(2)]
        [Description("Add contact with group")]
        public void AddNewContactTest(ContactData contactData)
        {
            Manager.Scenarios.AddNewContact(true, contactData);
        }

        [Test]
        [Order(3)]
        [Description("Edit contact")]
        public void EditContactTest()
        {
            Manager.Scenarios.EditContact();
        }

        [Test]
        [Order(3)]
        [Description("Edit contact")]
        public void EditContactFIONotChange()
        {
            Manager.Scenarios.EditContactFIONotChange();
        }

        [Test]
        [Order(3)]
        [Description("Contact editor verification")]
        public void VerifyContactTableAndEdition()
        {
            Manager.Scenarios.VerifyContactTableAndEdition();
        }

        [Test]
        [Order(4)]
        [Description("Contact details verification")]
        public void VerifyContactTableAndDetails()
        {
            Manager.Scenarios.Details();
        }

        [Test]
        [Order(5)]
        [Description("Remove contact from contacts page")]
        public void RemoveContactTestFromContacts()
        {
            Manager.Scenarios.RemoveContact(false);
        }

        [Test]
        [Order(6)]
        [Description("Remove contact from contact's editor")]
        public void RemoveContactTestFromEditor()
        {
            Manager.Scenarios.RemoveContact(true);
        }
    }
}