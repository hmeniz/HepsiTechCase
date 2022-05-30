using HepsiTechCase.Domain.Exceptions;

namespace HepsiTechCase.Application.Factories.PlateauFactories;

public class PlateauSizeFactory
{
    public static (int X, int Y) GetPosition(string sizeInput)
    {
        if (string.IsNullOrWhiteSpace(sizeInput))
            throw new InputNotAppropriateException(sizeInput);

        var gridSize = sizeInput.Split(' ');

        if (gridSize.Length != 2)
            throw new InputNotAppropriateException(sizeInput);

        if (int.TryParse(gridSize[0], out int x) == false)
            throw new InputNotAppropriateException(sizeInput);

        if (int.TryParse(gridSize[1], out int y) == false)
            throw new InputNotAppropriateException(sizeInput);

        return new (x, y);
    }
}
