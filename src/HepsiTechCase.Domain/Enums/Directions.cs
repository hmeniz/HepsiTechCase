using HepsiTechCase.Domain.Attributes;

namespace HepsiTechCase.Domain.Enums;

public enum Directions
{
    [Value("N")]
    North, 
    [Value("S")]
    South,
    [Value("W")]
    West,
    [Value("E")]
    East 
}