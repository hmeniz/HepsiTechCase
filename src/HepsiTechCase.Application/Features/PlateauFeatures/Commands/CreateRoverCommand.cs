using HepsiTechCase.Domain;
using HepsiTechCase.Domain.Aggreagates.Plateau;
using MediatR;

namespace HepsiTechCase.Application.Features.PlateauFeatures.Commands;

public class CreateRoverCommand : IRequest<Guid>
{
    public Plateau Plateau { get; set; }
    public string RoverPositionInput { get; set; }
}