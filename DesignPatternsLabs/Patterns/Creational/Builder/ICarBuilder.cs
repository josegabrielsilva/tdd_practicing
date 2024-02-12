namespace Patterns.Creational.Builder
{
    public interface ICarBuilder
    {
        Car WithBrand(string brand);
        Car WithModel(string model);
        Car WithColor(string color);
    }
}