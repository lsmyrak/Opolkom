using Contracts.Dtos.Task;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Dtos.Work.Validators
{
    public class WorkValidator:AbstractValidator<WorkDto>
    {
        public WorkValidator() 
        {            
            RuleFor(x=>x.DateOfWork).NotEmpty();
            RuleFor(x => x.DateOfNote).NotEmpty();
            RuleFor(x => x.Price).NotEmpty();
            RuleFor(x=>x.Place).NotEmpty();
            RuleFor(x=>x.KindOfWork).NotEmpty();
            RuleFor(x=>x.Settled).NotEmpty();
            RuleFor(x=>x.Tasks).NotEmpty();
        }
    }
}
