using HepsiTechCase.Domain.Aggreagates.Plateau;
using MediatR;

namespace HepsiTechCase.Application.Features.PlateauFeatures.Commands;

public class CreatePlateauCommand : IRequest<Plateau>
{
    public string SizeInput { get; set; }
}