using FluentValidation;
using SwarmApiService;
using SwarmAthonApi.Modules.Models;

namespace SwarmAthonApi
{
    public class AddResultValidator : AbstractValidator<ResultRequest>
    {
        public AddResultValidator()
        {         
        }
    }
}