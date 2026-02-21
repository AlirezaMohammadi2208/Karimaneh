using Common.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Common.Domain.ValueObjects
{
    public class NationalCode
    {
        private NationalCode() { } //EF
        public NationalCode(string value)
        {
            NationalCodeValidation(value);
            Value = value;
        }

        public string Value { get; private set; }

        public void NationalCodeValidation(string nationalCode)
        {
            if (!string.IsNullOrWhiteSpace(nationalCode))
                throw new InvalidValueException("کد ملی نمیتواند خالی باشد");
            if (nationalCode.Length != 10)
                throw new InvalidValueException("کد ملی باید 10 رقم باشد");
            if (!nationalCode.All(char.IsDigit))
                throw new InvalidValueException("کد ملی فقط باید عدد باشد");
            if (nationalCode.Distinct().Count() == 1)
                throw new InvalidValueException("کد ملی نامعتبر است");
            if (!IsNationalCodeValid(nationalCode))
                throw new InvalidValueException("کد ملی نامعتبر است");
        }
      
        private bool IsNationalCodeValid(string nationalId)
        {
            var isNumber = Regex.IsMatch(nationalId, @"^\d+$");
            if (isNumber == false)
                return false;

            var code = nationalId;

            if (Regex.IsMatch(code, @"^\d{10}$/")) return false;
            code = ("0000" + code).Substring(code.Length + 4 - 10);

            if (Convert.ToInt32(code.Substring(3, 6), 10) == 0) return false;

            var lastNumber = Convert.ToInt32(code.Substring(9, 1), 10);
            var sum = 0;

            for (var i = 0; i < 9; i++)
            {
                sum += Convert.ToInt32(code.Substring(i, 1), 10) * (10 - i);
            }

            sum = sum % 11;

            return sum < 2 && lastNumber == sum || sum >= 2 && lastNumber == 11 - sum;
        }
    }
}
