using System;
using System.Reflection;

namespace Sem3Lab6_Reflection
{
    public class Program
    {
        public class AgeValidationAttribute : System.Attribute
        {
            public int Age { get; set; }
            public AgeValidationAttribute()
            {

            }
            public AgeValidationAttribute(int age)
            {
                this.Age = age;
            }
        }

        [AgeValidation(18)]
        public class Man
        {
            public string Name { get; set; }
            public uint Age { get; set; }
            public double Money { get; set; }
            public Man(string name, uint age, double money)
            {
                this.Age = age;
                this.Name = name;
                this.Money = money;
            }
        }
        public class Car
        {
            public string model { get; private set; }
            public double price { get; private set; }
            public string bodyType { get; private set; }
            public int power { get; private set; }
            public double engineCapacity { get; private set; }
            public static uint count { get; private set; }
            public Car(string model, double price, string bodyType, int power, double engineCapacity)
            {
                this.model = model;
                this.price = price; ;
                this.bodyType = bodyType;
                this.power = power;
                this.engineCapacity = engineCapacity;
                count = 10;
            }
            static bool validateCustomer(Man customer)
            {
                Type t = customer.GetType();
                var attributes = t.GetCustomAttributes(typeof(AgeValidationAttribute), false);
                foreach (AgeValidationAttribute attribute in attributes)
                {
                    return customer.Age >= attribute.Age;
                }
                return true;
            }
            public bool Buy(Man customer)
            {
                if (count <= 0)
                    return false;

                if (validateCustomer(customer) && customer.Money >= this.price)
                {
                    customer.Money -= this.price;
                    count--;
                    return true;
                }
                return false;
            }
            public void Drive()
            {
                Console.WriteLine("Wroooooom wrooooooom I'm Prado with gas");
            }
            public void Display()
            {
                Console.WriteLine($"Model: {this.model} | Price: {this.price} \n" +
                    $" Body Type: {this.bodyType} | Power: {this.power} \n" +
                    $" Engine Capacity: {this.engineCapacity}");
            }
        }

        static void Main(string[] args)
        {
            try
            {
                Type classCar = typeof(Car);
                //var classCar = Type.GetType("Sem3Lab6_Reflection.Car");

                //shortcut for written later
                /*foreach (var item in classCar.GetMembers())
                {
                    Console.WriteLine($"{item.DeclaringType} {item.MemberType} {item.Name}");
                }*/

                Console.WriteLine("Fields:");
                foreach (FieldInfo field in classCar.GetFields())
                {
                    Console.WriteLine($"{field.FieldType} {field.Name}");
                }

                Console.WriteLine("Properties:");
                foreach (PropertyInfo prop in classCar.GetProperties())
                {
                    Console.WriteLine($"{prop.PropertyType} {prop.Name}");
                }

                Console.WriteLine("Methods:");
                foreach (MethodInfo method in classCar.GetMethods())
                {
                    string modificator = string.Empty;
                    if (method.IsStatic)
                        modificator += " static";
                    if (method.IsVirtual)
                        modificator += " virtual";
                    Console.Write($"{modificator} {method.ReturnType.Name} {method.Name} (");

                    var parameters = method.GetParameters();
                    for (int i = 0; i < parameters.Length; i++)
                    {
                        Console.Write($"{parameters[i].ParameterType.Name} {parameters[i].Name}");
                        if (i + 1 < parameters.Length) Console.Write(", ");
                    }
                    Console.WriteLine(")");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            Car lancer = new Car("Lancer X", 300000, "Sedan", 150, 1.8);
            Man vadik = new Man("Vadik", 19, 10000000000);
            Car jija = new Car("Zhiguli", 16000, "таз", 77, 1.8);
            Man max = new Man("Maxim", 16, 40000);
            Console.WriteLine("----------------------------------------\nVadim buying Lancer X: " + lancer.Buy(vadik));
            Console.WriteLine("Max buying ZHIGA: " + jija.Buy(max));
        }
    }
}
