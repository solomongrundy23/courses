﻿using AddressBookAutotests.Models;
using System.Collections.Generic;

namespace AddressBookAutotests.DataSets
{
    public static class DataProvider
    {
        public static IEnumerable<CreateGroupData> CreateGroupDatas()
        {
            for (int i = 0; i < 10; i++) yield return CreateGroupData.Random();
        }

        public static IEnumerable<CreateContactData> CreateContactDatas()
        {
            for (int i = 0; i < 10; i++) yield return CreateContactData.Random();
        }
    }
}