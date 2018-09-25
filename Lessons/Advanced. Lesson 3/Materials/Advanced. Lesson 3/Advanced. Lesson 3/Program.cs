using System;
using System.Linq;

namespace Advanced.Lesson_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Car car = new Car();
            ITransport transport = new Car();            
            
            car.Move(2);
            car.FillUp(2);

            transport.Move(2);
            //transport.FillUp(2);  не компилируется
            (transport as Car)?.FillUp(2);

            SampleClass sc = new SampleClass();
            IControl ctrl = (IControl)sc;
            ISurface srfc = (ISurface)sc;

            // The following lines all call the same method.
            sc.Paint();
            ctrl.Paint();
            srfc.Paint();

            Garage garage = new Garage();
            garage.ParkTransport(car);
            garage.ParkTransport((Car)transport);

            Console.ReadLine();
        }
    }

    interface ITransport
    {
        void Move(double km);
    }

    public class Car: ITransport
    {
        public double MileAge { get; set; }
        public double Fuel { get; set; }

        public void Move(double km)
        {
            this.MileAge += km;
        }

        public void FillUp(double liters)
        {
            this.Fuel += liters;
        }
    }

    interface IControl
    {
        void Paint();
    }
    interface ISurface
    {
        void Paint();
    }
    class SampleClass : IControl, ISurface
    {
        // Both ISurface.Paint and IControl.Paint call this method. 
        public void Paint()
        {
            Console.WriteLine("Paint method in SampleClass");
        }        
    }


    interface ITransportStorage
    {
        ITransport[] Items { get; set; }

        ITransport GetTransport();

        void ParkTransport(ITransport transport);
    }

    /*class Garage: ITransportStorage
    {
        public ITransport[] Items { get; set; }

        public ITransport GetTransport() {
            ITransport availibleTransport = Items[0];
            Items = Items.Skip(1).ToArray();
            return availibleTransport;
        }

        public void ParkTransport(ITransport transport)
        {
            Items = Items.Concat(new[] { transport }).ToArray();
        }
    }*/

    interface ITransportStorage<T> where T: ITransport
    {
        T[] Items { get; set; }

        T GetTransport();

        void ParkTransport(T transport);
    }

    class Garage : ITransportStorage<Car>
    {
        public Car[] Items { get; set; }

        public Car GetTransport()
        {
            Car availibleTransport = Items[0];
            Items = Items.Skip(1).ToArray();
            return availibleTransport;
        }

        public void ParkTransport(Car transport)
        {
            Items = Items.Concat(new[] { transport }).ToArray();
        }
    }
}
