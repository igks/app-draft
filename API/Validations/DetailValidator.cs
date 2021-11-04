//===================================================
// Date         : 
// Author       : 
// Description  : User data model
//===================================================
// Revision History:
// Name             Date            Description
//
//===================================================
using API.DAL.Contexts;
using API.DTO;
using FluentValidation;

namespace API.Validations
{
    public class DetailValidator : AbstractValidator<DetailIn>
    {
        private readonly AppDbContext _context;

        public DetailValidator(AppDbContext context)
        {
            _context = context;

            RuleFor(x => x.DetailProperty1)
                .NotEmpty()
                .WithMessage("Field is required!");
        }
    }
}