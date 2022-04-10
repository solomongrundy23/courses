﻿using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1
{
    public class Contact
    {
        public string? Aday;
        public string? Address;
        public string? Address2;
        public string? Amonth;
        public string? Ayear;
        public string? Bday;
        public string? Bmonth;
        public string? Byear;
        public string? Company;
        public string? Email;
        public string? Email2;
        public string? Email3;
        public string? Fax;
        public string? Firstname;
        public string? Home;
        public string? Homepage;
        public string? Lastname;
        public string? Middlename;
        public string? Mobile;
        public string? New_group;
        public string? Nickname;
        public string? Notes;
        public string? Phone2;
        public string? Theform;
        public string? Title;
        public string? Work;
        public Contact() { }
        public Contact(
            string aday,
            string address,
            string address2,
            string amonth,
            string ayear,
            string bday,
            string bmonth,
            string byear,
            string company,
            string email,
            string email2,
            string email3,
            string fax,
            string firstname,
            string home,
            string homepage,
            string lastname,
            string middlename,
            string mobile,
            string new_group,
            string nickname,
            string notes,
            string phone2,
            string theform,
            string title,
            string work
            ) 
        { 
            Aday = aday;
            Address = address;
            Address2 = address2;
            Amonth = amonth;
            Ayear = ayear;
            Bday = bday;
            Bmonth = bmonth;
            Byear = byear;
            Company = company;
            Email = email;
            Email2 = email2;
            Email3 = email3;
            Fax = fax;
            Firstname = firstname;
            Home = home;
            Homepage = homepage;
            Lastname = lastname;
            Middlename = middlename;
            Mobile = mobile;
            New_group = new_group;
            Nickname = nickname;
            Notes = notes;
            Phone2 = phone2;
            Theform = theform;
            Title = title;
            Work = work;
        }

        public static Contact Random
        {
            get
            {
                Contact result = new Contact();
                Faker fakerRu = new Faker("ru");
                Faker faker = new Faker();
                result.Aday = faker.Random.Int(1, 29).ToString();
                result.Address = fakerRu.Address.FullAddress();
                result.Address2 = fakerRu.Address.FullAddress();
                result.Amonth = faker.Date.Month();
                result.Ayear = faker.Random.Int(1900, 2022).ToString();
                result.Bday = faker.Random.Int(1, 29).ToString();
                result.Bmonth = faker.Date.Month();
                result.Byear = faker.Random.Int(1900, 2022).ToString();
                result.Company = fakerRu.Company.CompanyName();
                result.Email = faker.Internet.Email();
                result.Email2 = faker.Internet.Email();
                result.Email3 = faker.Internet.Email();
                result.Fax = fakerRu.Phone.PhoneNumber();
                result.Firstname = fakerRu.Name.FirstName();
                result.Home = fakerRu.Phone.PhoneNumber();
                result.Homepage = faker.Internet.Url();
                result.Lastname = fakerRu.Name.LastName();
                result.Middlename = fakerRu.Name.FirstName();
                result.Mobile = fakerRu.Phone.PhoneNumber();
                result.Nickname = fakerRu.Random.Word();
                result.Notes = fakerRu.Random.Words();
                result.Phone2 = fakerRu.Phone.PhoneNumber();
                result.Theform = faker.Random.Word();
                result.Title = fakerRu.Random.Word();
                result.Work = fakerRu.Phone.PhoneNumber();
                return result;
            }
        }
    }
}
