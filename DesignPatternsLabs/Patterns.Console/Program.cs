DatabaseConnection.Use(f =>
{
    f.Open();
});

WriterFactory.Make(WriterType.Json);
WriterFactory.Make(WriterType.Xml);

sealed class DatabaseConnection : IDisposable
{
    private string Host { get; set; }
    private string User { get; set; }
    private string Password { get; set; }

    private DatabaseConnection() 
    {
        Host = "";
        User = "";
        Password = "";
    }

    public bool Open() => true;
    private bool Close() => true;
    public static void Use(Action<DatabaseConnection> act)
    {
        using var instance = new DatabaseConnection();
        act(instance);
    }

    public void Dispose()
    {
        Close();
    }
}

struct Property (string Name, string Value)
{
    public override readonly string ToString()
        => $"Name: {Name} | Value: {Value}";
}

enum WriterType
{
    Text,
    Json,
    Xml
}

abstract class Writer
{
    public abstract bool Write(List<Property> properties);
}

sealed class JsonWriter : Writer
{
    public override bool Write(List<Property> properties)
    {
        return true;
    }
}

sealed class XmlWriter : Writer
{
    public override bool Write(List<Property> properties)
    {
        return true;
    }
}

sealed class TextWriter : Writer
{
    public override bool Write(List<Property> properties)
    {
        return true;
    }
}

sealed class WriterFactory
{
    private static readonly Dictionary<WriterType, Writer> Writers = [];

    static WriterFactory()
    {
        Writers.Add(WriterType.Json, new JsonWriter());
        Writers.Add(WriterType.Xml, new XmlWriter());
        Writers.Add(WriterType.Text, new TextWriter());
    }

    public static Writer Make(WriterType type)
    {
        Writers.TryGetValue(type, out Writer? value);

        return value ?? new JsonWriter();
    }
}

