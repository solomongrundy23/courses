﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using AddressBookAutotests.Helpers;
using AddressBookAutotests.Models;

namespace TestDataGenerator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            args = new string[] { "auto" };
            Console.WriteLine("Program is started");
            if (args.Length == 0)
            {
                Console.WriteLine("Args is empty please enter params:");
                Console.WriteLine("1) auto");
                Console.Write("2) type=[contacts|groups|all] ");
                Console.Write("format=[csv|xml|json] ");
                Console.WriteLine("count=[0..2147483647]");
            }
            else
            {
                bool auto = false;
                if (args.Length == 1)
                    if (args[0].ToLower() == "auto")
                        auto = true;
                if (auto)
                    AutoGenerator();
                else
                    Generator(args);
            }
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
            Console.WriteLine("Program is closed");
        }

        static void AutoGenerator()
        {
            string[] args;
            args = "type=all format=csv count=5".Split(' '); Generator(args);
            args = "type=all format=xml count=5".Split(' '); Generator(args);
            args = "type=all format=json count=5".Split(' '); Generator(args);
        }

        static void Generator(string[] args)
        {
            try
            {
                IEnumerable<Param> paramList;
                try
                {
                    paramList = ParseParams(args).ToList();
                    Console.WriteLine("Params:");
                    Console.WriteLine(string.Join(Environment.NewLine, paramList));
                }
                catch (Exception ex)
                {
                    throw new Exception("Params has wrong format");
                }
                int count = int.Parse(paramList?.Where(x => x.Name == "count").FirstOrDefault().Value ?? "3");
                string format = paramList?.Where(x => x.Name == "format").FirstOrDefault().Value ?? "csv";
                string type = paramList?.Where(x => x.Name == "type").FirstOrDefault().Value ?? throw new Exception($"Type not selected");

                var fileHelper = new FileHelper();
                var fileFormat = GetFileFormat(format);
                switch (type.ToLower())
                {
                    case "groups": fileHelper.Save(GenerateGroups(count), FileName("groups", format), fileFormat); break;
                    case "contacts": fileHelper.Save(GenerateContacts(count), FileName("contacts", format), fileFormat); break;
                    case "all":
                        fileHelper.Save(GenerateGroups(count), FileName("groups", format), fileFormat);
                        fileHelper.Save(GenerateContacts(count), FileName("contacts", format), fileFormat);
                        break;
                    default: throw new Exception($"Unknown Type: \"{type}\"");
                }
                Console.WriteLine("File is writed");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        static string FileName(string type, string format)
        {
            string path = FileHelper.DataSetPath; 
            if (!Directory.Exists(path)) Directory.CreateDirectory(path);
            return path + $"{type}.{format}";
        }

        static FileHelper.FileFormat GetFileFormat(string format)
        {
            switch (format.ToLower())
            {
                case "csv": return FileHelper.FileFormat.Csv;
                case "xml": return FileHelper.FileFormat.Xml;
                case "json": return FileHelper.FileFormat.Json;
                default : throw new Exception($"Unknown FileFormat: \"{format}\"");
            }
        }

        struct Param
        {
            public Param(string name, string value)
            { 
                Name = name;
                Value = value;
            }
            public string Name { get; set; }
            public string Value { get; set; }

            public override string ToString()
            {
                return $"{Name} = \"{Value}\"";
            }
        }

        static IEnumerable<Param> ParseParams(string[] args)
        {
            var paramList = args.Where(x => x.Length > 1 && x.Contains("="));
            foreach (var paramString in paramList)
            {
                var spit = Regex.Match(paramString, "^(.*?)=(.*?)$");
                string name = spit.Groups[1].Value;
                string value = spit.Groups[2].Value;
                if (!(string.IsNullOrEmpty(name) || string.IsNullOrEmpty(value))) 
                    yield return new Param(name, value);
            }
        }

        static List<GroupData> GenerateGroups(int count)
        {
            var groups = new List<GroupData>();
            for (int i = 0; i < count; i++) groups.Add(GroupData.Random());
            return groups;
        }

        static List<ContactData> GenerateContacts(int count)
        {
            var contacts = new List<ContactData>();
            for (int i = 0; i < count; i++) contacts.Add(ContactData.Random());
            return contacts;
        }
    }
}