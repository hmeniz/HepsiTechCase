using HepsiTechCase.Domain.Aggreagates.Plateau;
using MediatR;

namespace HepsiTechCase.Application.Features.PlateauFeatures.Commands;

public class LoadRoverInstructionsCommand : IRequest<Unit>
{
    public Plateau Plateau { get; set; }
    public Guid RoverId { get; set; }
    public string RoverInstructionsInput { get; set; }
}