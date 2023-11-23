// namespace RefactoringGuru.DesignPatterns.Singleton.Conceptual.NonThreadSafe
// {
//     public sealed class SingletonCar
//     {
//         private SingletonCar() { }

//         private static SingletonCar _instance;

//         public static SingletonCar GetInstance()
//         {
//             if (_instance == null)
//             {
//                 _instance = new SingletonCar();
//             }
//             return _instance;
//         }

//         private string _color;
//         private int _maximumSpeed;

//         public string Color
//         {
//             get { return _color; }
//             set { _color = value; }
//         }

//         public int MaximumSpeed
//         {
//             get { return _maximumSpeed; }
//             set { _maximumSpeed = value; }
//         }

//         public void GetMaximumSpeed()
//         {
//             Console.WriteLine($"The maximum speed of the car is {_maximumSpeed} km/h.");
//         }
//     }

//     class Program
//     {
//         static void Main(string[] args)
//         {
//             // The client code.
//             SingletonCar s1 = SingletonCar.GetInstance();
//             SingletonCar s2 = SingletonCar.GetInstance();

//             if (s1 == s2)
//             {
//                 Console.WriteLine("Singleton works");
//             }
//             else
//             {
//                 Console.WriteLine("Singleton failed");
//             }

//             s1.MaximumSpeed = 200;
//             s1.GetMaximumSpeed();
//             s2.GetMaximumSpeed();

//             s2.MaximumSpeed=100;
//             s1.GetMaximumSpeed();
//             s2.GetMaximumSpeed();
//         }
//     }
// }