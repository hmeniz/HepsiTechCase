namespace HepsiTechCase.Domain.Exceptions;

public class PlateauOutOfBoundaryException : Exception
{
    public PlateauOutOfBoundaryException(int plateauX, int plateauY, int x, int y)
       : base($"{x} {y} is outofboundary of {plateauX} {plateauY}")
    {
    }
}