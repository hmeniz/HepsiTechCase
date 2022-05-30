using HepsiTechCase.Domain;
using HepsiTechCase.Domain.Aggreagates.Plateau;
using MediatR;

namespace HepsiTechCase.Application.Features.PlateauFeatures.Commands;

public class RunRoverInstructionsCommand : IRequest<RoverPosition>
{
    public Plateau Plateau { get; set; }
    public Guid RoverId { get; set; }
}
