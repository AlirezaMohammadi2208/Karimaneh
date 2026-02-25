using Common.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Common.Domain.ValueObjects
{
    public class PhoneNumber
    {
        public PhoneNumber(string value)
        {
            PhoneNumberValidation(value);
            Value = value;
        }

        private PhoneNumber() { } //EF
        public string Value { get; private set; }
        public void PhoneNumberValidation(string phoneNumber)
        {
            if (string.IsNullOrWhiteSpace(phoneNumber))
                throw new InvalidValueException("شماره موبایل نباید خالی باشد");
            phoneNumber = phoneNumber.Trim();
            if (!Regex.IsMatch(phoneNumber, @"^09\d{9}$"))
                throw new InvalidValueException("شماره موبایل نامعتبر است");
        }
    }
}
