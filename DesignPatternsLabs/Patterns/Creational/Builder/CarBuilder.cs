namespace Patterns.Creational.Builder
{
    public class CarBuilder : ICarBuilder
    {
        private readonly Car Car = new();

        public Car WithBrand(string brand)
        {
            Car.Brand = brand;
            return Car;
        }

        public Car WithColor(string color)
        {
            Car.Brand = color;
            return Car;
        }

        public Car WithModel(string model)
        {
            Car.Brand = model;
            return Car;
        }
    }
}
