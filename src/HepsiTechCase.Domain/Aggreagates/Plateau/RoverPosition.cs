using HepsiTechCase.Domain.Enums;
using HepsiTechCase.Domain.Exceptions;

namespace HepsiTechCase.Domain.Aggreagates.Plateau;

public class RoverPosition
{
    public int X { get; private set; }
    public int Y { get; private set; }
    public Plateau Plateau { get; private set; }
    public Directions Direction { get; private set; }

    internal RoverPosition(Plateau plateau, Directions direction, int x, int y)
    {
        this.Plateau = plateau;
        IsValidPosition(x, y);

        this.Direction = direction;
        this.X = x;
        this.Y = y;
    }

    internal void Move()
    {
        int nextX, nextY;

        nextX = this.Direction switch
        {
            Directions.North => X,
            Directions.East => X + 1,
            Directions.South => X,
            Directions.West => X - 1,
            _ => throw new InvalidOperationException(),
        };

        nextY = this.Direction switch
        {
            Directions.North => Y + 1,
            Directions.East => Y,
            Directions.South => Y - 1,
            Directions.West => Y,
            _ => throw new InvalidOperationException(),
        };

        if (IsValidPosition(nextX, nextY) == false)
            throw new PlateauOutOfBoundaryException(Plateau.X, Plateau.Y, nextX, nextY);

        this.X = nextX;
        this.Y = nextY;
    }

    private bool IsValidPosition(int x, int y)
    {
        if (x < 0 || x > this.Plateau.X
            || y < 0 || y > this.Plateau.Y)
        {
            return false;
        }

        return true;
    }

    internal void TurnLeft()
    {
        this.Direction = this.Direction switch
        {
            Directions.North => Directions.West,
            Directions.West => Directions.South,
            Directions.South => Directions.East,
            Directions.East => Directions.North,
            _ => throw new InvalidOperationException(),
        };
    }

    internal void TurnRight()
    {
        this.Direction = this.Direction switch
        {
            Directions.North => Directions.East,
            Directions.East => Directions.South,
            Directions.South => Directions.West,
            Directions.West => Directions.North,
            _ => throw new InvalidOperationException(),
        };
    }
}