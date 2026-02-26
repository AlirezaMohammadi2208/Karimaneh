using System;
using System.Collections.Generic;
using System.Text;

namespace Karimaneh.Application.Features.Members.DTOs
{
    public record CreateMemberRequestDto(string FullName
        , string NationalCode, string FatherName, string ShebaNumber
        , string AccountNumber, string CardNumber, string AvatarName,
        bool LoanRequest , string phoneNumber) 
    {
       
    }
}
