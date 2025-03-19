using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingConsoleDay2
{

    internal enum Color
    {
        Red,
        Blue,
        Green,
        Yellow,
        Black,
        White
    }

    internal enum Make
    {
        Toyota,
        Honda,
        Ford,
        Chevrolet,
        BMW,
        Mercedes,
        Audi
    }

    internal enum Model
    {
        Camry,
        Accord,
        A4
    }

    internal class Car
    {
        private string _make = string.Empty;
        private string _model = string.Empty;
        private string _color = string.Empty;
        private Car()
        {
        }

        public static Car BuildMyCar()
        {
            return new Car();
        }

        public Car WithMake(Make make)
        {
            _make = make.ToString();
            return this;
        }

        public Car WithModel(Model model)
        {
            _model = model.ToString();
            return this;
        }

        public Car WithColor(Color color)
        {
            _color = color.ToString();
            return this;
        }

        public void DisplayCarDetails()
        {
            Console.WriteLine($"Make: {_make}, Model: {_model}, Color: {_color}");
        }
    }
}
