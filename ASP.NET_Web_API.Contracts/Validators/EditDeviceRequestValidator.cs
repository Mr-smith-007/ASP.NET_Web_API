using ASP.NET_Web_API.Contracts.Models.Devices;
using FluentValidation;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.NET_Web_API.Contracts.Validators
{
    public class EditDeviceRequestValidator : AbstractValidator<EditDeviceRequest>
    {
        public EditDeviceRequestValidator()
        {
            RuleFor(x => x.NewName).NotEmpty();
            RuleFor(x => x.NewRoom).NotEmpty().Must(BeSupported)
                .WithMessage($"Please choose one of the following locations: {string.Join(", ", Values.ValidRooms)}");
        }
                
        private bool BeSupported(string location)
        {
            return Values.ValidRooms.Any(e => e == location);
        }
    }
}
