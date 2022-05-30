using HepsiTechCase.Domain.Attributes;
using HepsiTechCase.Domain.Enums;
using HepsiTechCase.Domain.Exceptions;

namespace HepsiTechCase.Application.Factories.PlateauFactories;

public class RoverPositionFactory
{
    public static (Directions Direction, int X, int Y) GetPosition(string positionInput)
    {
        if (string.IsNullOrWhiteSpace(positionInput))
            throw new InputNotAppropriateException(positionInput);

        var position = positionInput.Split(' ');
        if (position.Length != 3)
            throw new ArgumentException($"{positionInput} is not valid for rover position");

        if (int.TryParse(position[0], out int x) == false)
            throw new ArgumentException($"{position[0]} is not valid for rover position x");

        if (int.TryParse(position[1], out int y) == false)
            throw new ArgumentException($"{position[1]} is not valid for rover position y");

        Directions direction = GetDirectionByValue(position[2].ToUpper());

        return new (direction, x, y);
    }

    private static Directions GetDirectionByValue(string directionInput)
    {
        foreach(Directions direction in (Directions[])Enum.GetValues(typeof(Directions)))
        {
            if (direction.GetValue() == directionInput)
                return direction;
        }

        throw new Exception($"{directionInput} is not appropriate direction");
    }
}
