using Common.Application.CQRS.Command;
using Karimaneh.Application.Features.Wallets.Specifications;
using System;
using System.Collections.Generic;
using System.Text;

namespace Karimaneh.Application.Features.Members.Command.CreateMember
{
    public record CreateMemberCommand(string fullName
        , string NationalCode, string FatherName, string ShebaNumber
        , string AccountNumber, string CardNumber, string AvatarName,
        bool LoanRequest, Guid UserId) : IBaseCommand
    {
        //TODO : FormFile for avatar 
    }
}
