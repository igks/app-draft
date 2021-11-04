//===================================================
// Date         : 
// Author       : 
// Description  : User data model
//===================================================
// Revision History:
// Name             Date            Description
//
//===================================================
using System.Linq;
using API.DAL.Contexts;
using API.DTO;
using FluentValidation;

namespace API.Validations
{
    public class MasterValidator : AbstractValidator<MasterIn>
    {
        private readonly AppDbContext _context;

        public MasterValidator(AppDbContext context)
        {
            _context = context;

            RuleFor(x => x.MasterProperty1)
                .NotEmpty()
                .WithMessage("Field is required!");

            RuleFor(x => x)
                .Must(x => !Duplicate(x))
                .WithName("Field 1")
                .WithMessage("Record already exist");

            RuleForEach(x => x.Details).SetValidator(new DetailValidator(_context));
        }


        private bool Duplicate(MasterIn dto)
        {
            if (dto.Id.HasValue)
            {
                return _context.Master.Any(x => x.MasterProperty1.ToLower() == dto.MasterProperty1.ToLower() && x.Id != dto.Id.Value);
            }
            return _context.Master.Any(x => x.MasterProperty1.ToLower() == dto.MasterProperty1.ToLower());
        }
    }

}