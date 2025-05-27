namespace lab_2_0.Composite;

public interface IComponent
{
    void Display(int indent = 0);
}

public class BookCategory : IComponent
{
    public string Name { get; }
    private readonly List<IComponent> _components;

    public BookCategory(string name)
    {
        Name = name;
        _components = new List<IComponent>();
    }

    public void AddComponent(IComponent component)
    {
        _components.Add(component);
    }

    public void RemoveComponent(IComponent component)
    {
        _components.Remove(component);
    }

    public void Display(int indent = 0)
    {
        Console.WriteLine($"{new string(' ', indent)}Category: {Name}");
        foreach (var component in _components)
        {
            component.Display(indent + 2);
        }
    }
}
