using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vehiclesupr
{
	internal class Program
	{
		static void Main(string[] args)		// kinda lame of a main but i dont gave the time right now
		{
			Vehicle car1 = new Car();
			Vehicle truck1 = new Truck();

			Console.WriteLine("Trying to make the car drive 100km:");
			car1.Drive(100);

			Console.WriteLine("\nTrying to refill the car with the wrong fuel");
			IFuel gasoline = new Gasoline(30);
			car1.Refueling(gasoline);

			Console.WriteLine("\nTrying to refill the car with the right fuel");
			IFuel diesel = new Diesel(30);
			car1.Refueling(diesel);

			Console.WriteLine("\nTrying to make the car drive 250km with the fuel now.");
			car1.Drive(250);
			Console.WriteLine();


			Console.WriteLine();
			Console.WriteLine(new String('*', 100));
			Console.WriteLine();


			Console.WriteLine("\nTrying to make the truck drive 100km:");
			car1.Drive(100);

			Console.WriteLine("\nTrying to refill the truck with the wrong fuel");
			IFuel diesel1 = new Diesel(20);
			car1.Refueling(gasoline);

			Console.WriteLine("\nTrying to refill the truck with the right fuel");
			IFuel gasoline1 = new Gasoline(20);
			car1.Refueling(diesel);

			Console.WriteLine("\nTrying to make the truck drive 250km with the fuel now.");
			car1.Drive(250);

			Console.WriteLine();
		}

	}
	interface IFuel
	{
		string Fuel_Type { get;}
		double Quantity { get; set; }
		bool Check(IFuel comparison);
	}
	class Gasoline : IFuel
	{
		public Gasoline() {	}
		public Gasoline(double quantity)
		{
			this.Quantity = quantity;
		}
		public string Fuel_Type { get { return "gasoline"; } }
		public double Quantity { get; set; }
		public bool Check(IFuel comparison) => comparison.Fuel_Type == this.Fuel_Type && this.Quantity >= 20;
	}
	class Diesel : IFuel
	{
		public Diesel() { }
		public Diesel(double quantity)
		{
			this.Quantity = quantity;
		}
		public string Fuel_Type { get { return "diesel"; } }
		public double Quantity { get; set; }
		public bool Check(IFuel comparison) => comparison.Fuel_Type == this.Fuel_Type && this.Quantity >= 20;
	}
	
	abstract class Vehicle
	{
		private const double FUEL_FOR_ONE_KM = (double)8 / 100;
		public string type_vehicle = "vehicle";
		public IFuel used_fuel;
		public IFuel current_fuel;
		public abstract void Refueling(IFuel fuel);

		public void Drive(double distance)
		{
			var fuel_burnt = distance * FUEL_FOR_ONE_KM;
			
			if(fuel_burnt <= current_fuel.Quantity)
			{
				current_fuel.Quantity -= fuel_burnt;
				Console.WriteLine("The {0} successfully drove {1}km. [Remaining fuel: {2}]", type_vehicle, distance, current_fuel.Quantity);
			}
			else
				Console.WriteLine("The {0} doesn't have enough fuel to drive that much. [Remaining fuel: {1}] [Needed fuel: {2}]", type_vehicle, current_fuel.Quantity, fuel_burnt);
		}
	}
	class Car : Vehicle
	{
		public Car()
		{
			type_vehicle = "car";
			used_fuel = new Diesel();
			current_fuel = new Diesel(0);
		}
		public string Type_Vehicle { get { return type_vehicle; } }
		public IFuel Used_Fuel { get { return used_fuel; } }

		public override void Refueling(IFuel fuel)
		{
			bool passed_check = fuel.Check(used_fuel);

			if (passed_check)
			{
				current_fuel.Quantity += fuel.Quantity;
				Console.WriteLine("The car has successfully been filled. [Fuel: {0}]", current_fuel.Quantity);
			}
			else
				Console.WriteLine("The fuel didn't pass the check and the car wasn't filled. [Fuel: {0}]", current_fuel.Quantity);
		}
	}
	class Truck : Vehicle
	{
		public Truck()
		{
			type_vehicle = "truck";
			used_fuel = new Gasoline();
			current_fuel = new Gasoline(0);
		}
		public string Type_Vehicle { get { return type_vehicle; } }
		public IFuel Used_Fuel { get { return used_fuel; } }

		public override void Refueling(IFuel fuel)
		{
			bool passed_check = fuel.Check(used_fuel);

			if (passed_check)
			{
				current_fuel.Quantity += fuel.Quantity;
				Console.WriteLine("The truck has successfully been filled. [Fuel: {0}]", current_fuel.Quantity);
			}
			else
				Console.WriteLine("The fuel didn't pass the check and the truck wasn't filled. [Fuel: {0}]", current_fuel.Quantity);
		}
	}
}
