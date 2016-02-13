﻿using System;
using System.Data.Entity;
using InsuranceV2.Common.Enums;
using InsuranceV2.Common.Models;
using InsuranceV2.Infrastructure.Database.Context;

namespace InsuranceV2.Infrastructure.Database.Initializer
{
    public class MyDropCreateDatabaseIfModelChanges : DropCreateDatabaseIfModelChanges<InsuranceAppContext>
    {
        protected override void Seed(InsuranceAppContext context)
        {
            for (var i = 0; i < 10; i++)
            {
                var insuree = new Insuree
                {
                    FirstName = "FirstName " + i,
                    LastName = "LastName " + i,
                    DateOfBirth = DateTime.Now.AddYears(-30 + i),
                    HomeAddress = CreateAddress(),
                    WorkAddress = CreateAddress()
                };

                insuree.EmailAddresses.Add("first" + i + "@test.com", ContactType.Personal);
                insuree.EmailAddresses.Add("second" + i + "@test.com", ContactType.Business);

                insuree.PhoneNumbers.Add("1234567890" + i, ContactType.Personal);

                context.Insurees.Add(insuree);
            }
        }

        private static Address CreateAddress()
        {
            return new Address(
                "Street",
                "123",
                "12345",
                "City",
                "Country",
                ContactType.Personal
                );
        }
    }
}