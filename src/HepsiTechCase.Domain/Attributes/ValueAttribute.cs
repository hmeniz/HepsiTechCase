namespace HepsiTechCase.Domain.Attributes;

[AttributeUsage(AttributeTargets.All)]
public class ValueAttribute : Attribute
{
    public string Value;
    public ValueAttribute(string value) { Value = value; }
}


public static partial class EnumExtensions
{
    public static string GetValue(this Enum value)
    {
        var type = value.GetType();

        string name = Enum.GetName(type, value);
        if (name == null) { return null; }

        var field = type.GetField(name);
        if (field == null) { return null; }

        var attr = Attribute.GetCustomAttribute(field, typeof(ValueAttribute)) as ValueAttribute;
        if (attr == null) { return null; }

        return attr.Value;
    }
}