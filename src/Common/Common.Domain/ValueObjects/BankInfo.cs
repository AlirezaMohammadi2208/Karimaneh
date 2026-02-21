using Common.Domain.BaseModels;
using Common.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Domain.ValueObjects
{
    public class BankInfo 
    {
        private BankInfo() { } //EF
        public BankInfo(string accountNumber, string shebaNumber, string cardNumber)
        {
            CardNumberValidation(cardNumber);
            ShebaNumberValidation(shebaNumber);
            AccountNumber = accountNumber;
            ShebaNumber = shebaNumber;
            CardNumber = cardNumber;
        }

        public string AccountNumber { get; private set; }
        public string ShebaNumber { get; private set; }
        public string CardNumber { get; private set; }

        #region Validations
        public void CardNumberValidation(string cardNumber)
        {
            if (string.IsNullOrWhiteSpace(cardNumber))
                throw new InvalidValueException("شماره کارت باید پر شود");
            if (cardNumber.Length != 16)
                throw new InvalidValueException("شماره کارت باید 16 رقم باشد");
            if (!cardNumber.All(char.IsDigit))
                throw new InvalidValueException("شماره کارت فقط باید عدد باشد");
            if (IsValidCardNumber(cardNumber))
                throw new InvalidValueException("شماره کارت نامعتبر است");
        }
        private bool IsValidCardNumber(string cardNumber)
        {
            int sum = 0;
            bool alternate = false;

            for (int i = cardNumber.Length - 1; i >= 0; i--)
            {
                int digit = int.Parse(cardNumber[i].ToString());

                if (alternate)
                {
                    digit *= 2;
                    if (digit > 9)
                        digit -= 9;
                }

                sum += digit;
                alternate = !alternate;
            }

            return sum % 10 == 0;
        }
        public void ShebaNumberValidation(string shebaNumber)
        {
            if (!string.IsNullOrWhiteSpace(shebaNumber))
                throw new InvalidValueException("شماره شبا نمیتواند خالی باشد");
            shebaNumber = shebaNumber.Replace(" ", "").Replace("-", "").ToUpper();
            if (!shebaNumber.StartsWith("IR"))
                throw new InvalidValueException("شماره شبا باید با IR شروع شود");
            if (shebaNumber.Length != 26)
                throw new InvalidValueException("شماره شبا باید 26 کاراکتر داشته باشد");
            var numberPart = shebaNumber.Substring(2);
            if (!numberPart.All(char.IsDigit))
                throw new InvalidValueException("بعد از IR فقط باید عدد باشد");
            if (IsValidShebaNumber(shebaNumber))
                throw new InvalidValueException("شماره شبا نامعتبر است");
        }
        private bool IsValidShebaNumber(string shebaNumber)
        {
            var rearranged = shebaNumber.Substring(4) + shebaNumber.Substring(0, 4);
            var numericIban = new StringBuilder();
            foreach (var ch in rearranged)
            {
                if (char.IsLetter(ch))
                    numericIban.Append((ch - 'A') + 10);
                else
                    numericIban.Append(ch);
            }

            
            int remainder = 0;
            foreach (var digit in numericIban.ToString())
            {
                remainder = (remainder * 10 + (digit - '0')) % 97;
            }

            return remainder == 1;
        }
        #endregion
    }
}
