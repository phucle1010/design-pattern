// namespace FactoryDemo
// {
//     public interface Product
//     {
//         double doCalculatorTax(double price);
//     }
//     class ConcreteAlcohol : Product
// {
//     int odo=0;

//      public void SetOdo(int odo)
//     {
//         this.odo = odo;
//     }
//     public double doCalculatorTax(double price)
//     {
//         if(odo<20){
//             return price/1.25;
//         }
//         return price/1.5;
//     }

    
    
// }
// class ConcreteCigarette : Product
// {
//     public double doCalculatorTax(double price)
//     {
//         return price/1.65;
//     }

    
// }
// public class ConcreteSoftDrinks : Product
// {
//     public  double doCalculatorTax(double price)
//     {
//         return price/1.1;
//     }

    
// }

// public enum ProductType
// {
//     Alcohol,
//     Cigarette,
//     SoftDrinks
    
// }
// public abstract class TaxCalculator
// {
//     public abstract Product Create(ProductType type);
// }
// class ConTaxCalculator : TaxCalculator
// {
//     public override Product Create(ProductType type)
//     {
//         switch (type)
//         {
//             case ProductType.Alcohol:
//                 return new ConcreteAlcohol();          
//             case ProductType.Cigarette:
//                 return new ConcreteCigarette();
//             case ProductType.SoftDrinks:
//                 return new ConcreteSoftDrinks();      
//             default: 
//                 throw new ArgumentException("Invalid type", "type");

//         }
//     }
// }
// class Program
//     {
//         static void Main(string[] args)
//         {
//             var factory = new ConTaxCalculator();
//             Product alcohol1 = factory.Create(ProductType.Alcohol);
//             ConcreteAlcohol alcohol = (ConcreteAlcohol)alcohol1;
//             alcohol.SetOdo(35);
//             Console.WriteLine(alcohol.doCalculatorTax(10000));
//             Console.WriteLine("===========================================");

//             Product cigarette = factory.Create(ProductType.Cigarette);
//             Console.WriteLine(cigarette.doCalculatorTax(20000));
//             Console.WriteLine("===========================================");

//             Product softDrinks = factory.Create(ProductType.SoftDrinks);
//             Console.WriteLine(softDrinks.doCalculatorTax(3000));
//             Console.WriteLine("===========================================");

            
//         }
//     }
// }

// namespace FactoryDemo
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
//         private int _maximumSpeed=0;
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
            
//             s1.MaximumSpeed = 100;
//             s1.GetMaximumSpeed();
//             s2.GetMaximumSpeed();

//             s2.MaximumSpeed=200;
//             s1.GetMaximumSpeed();
//             s2.GetMaximumSpeed();
//         }
// }

//facade

// namespace FactoryDemo
// {
//     public class ShopFacade
//     {
//         private static ShopFacade _instance;

//         private AccountService accountService;
//         private PaymentService paymentService;
//         private ShippingService shippingService;
//         private EmailService emailService;
//         private SmsService smsService;

//         private ShopFacade()
//         {
//             accountService = new AccountService();
//             paymentService = new PaymentService();
//             shippingService = new ShippingService();
//             emailService = new EmailService();
//             smsService = new SmsService();
//         }

//         public static ShopFacade getInstance()
//         {
//             if (_instance == null)
//                 _instance = new ShopFacade();
//             return _instance;
//         }

//         public void buyProductByCashWithFreeShipping(string email)
//         {
//             accountService.GetAccout(email);
//             paymentService.PaymentByCash();
//             shippingService.FreeShipping();
//             emailService.SendMail(email);
//             Console.WriteLine("Done\n");
//         }

//         public void buyProductByPaypalWithStandardShipping(string email, string mobilePhone)
//         {
//             accountService.GetAccout(email);
//             paymentService.PaymentByPaypal();
//             shippingService.StandardShipping();
//             emailService.SendMail(email);
//             smsService.sendSMS(mobilePhone);
//             Console.WriteLine("Done\n");
//         }
//     }   

//     class Program
//     {
//         static void Main(string[] args)
//         {
//             ShopFacade.getInstance().buyProductByCashWithFreeShipping("18520282@gm.uit.edu.vn");
//             ShopFacade.getInstance().buyProductByPaypalWithStandardShipping("uit@gmail.edu.vn", "0123456789");
//         }
//     }
// }
// using System;

// class Program
// {
//     static void Main()
//     {
//         Console.Write("Nhap so phan tu cua mang: ");
//         int n = int.Parse(Console.ReadLine());

//         int[] arr = new int[n];

//         // Nhập các phần tử của mảng
//         Console.WriteLine("Nhap cac phan tu cua mang:");
//         for (int i = 0; i < n; i++)
//         {
//             Console.Write($"Phan tu thu {i + 1}: ");
//             arr[i] = int.Parse(Console.ReadLine());
//         }

//         // Bubble sort
//         BubbleSort(arr);

//         // In mảng sau khi sắp xếp
//         Console.WriteLine("Mang sau khi sap xep:");
//         foreach (int num in arr)
//         {
//             Console.Write(num + " ");
//         }

//         Console.ReadLine();
//     }

//     static void BubbleSort(int[] arr)
//     {
//         int n = arr.Length;
//         for (int i = 0; i < n - 1; i++)
//         {
//             for (int j = 0; j < n - i - 1; j++)
//             {
//                 if (arr[j] > arr[j + 1])
//                 {
//                     // Hoán đổi giá trị
//                     int temp = arr[j];
//                     arr[j] = arr[j + 1];
//                     arr[j + 1] = temp;
//                 }
//             }
//         }
//     }
// }
// using System;
// using System.Collections.Generic;
// using System.Threading;

// class Driver
// {
//     public string Name { get; set; }
//     public int DriverId { get; set; }

//     public virtual void AcceptRide(RideOder ride)
//     {
//     }

//     public virtual void RejectRide(RideOder ride)
//     {
//     }
// }

// class ConcreteDriver : Driver
// {
//     public override void AcceptRide(RideOder ride)
//     {
//         Console.WriteLine($"{Name} accepted the ride.");
//         ride.SetDriver(this);
//     }

//     public override void RejectRide(RideOder ride)
//     {
//         Console.WriteLine($"{Name} rejected the ride.");
//     }
// }

// class RideOder
// {
//     public Driver Driver { get; private set; }

//     public void SetDriver(Driver driver)
//     {
//         Driver = driver;
//     }
// }

// class RideDispatcher
// {
//     private List<Driver> drivers;

//     public RideDispatcher(List<Driver> drivers)
//     {
//         this.drivers = drivers;
//     }

//     public void FindDriver(RideOder ride)
//     {
//         DateTime startTime = DateTime.Now;
//         TimeSpan elapsedTime;
//         Random random = new Random();

//         while (true)
//         {
//             elapsedTime = DateTime.Now - startTime;

//             if (elapsedTime.TotalSeconds >= 30)
//             {
//                 Console.WriteLine("No driver available.");
//                 break;
//             }

//             foreach (Driver driver in drivers)
//             {
//                 DateTime startTime1 = DateTime.Now;
//                 TimeSpan elapsedTime1;
//                 while(true){
//                     elapsedTime1 = DateTime.Now - startTime1;
//                     int acceptRide = random.Next(3) ;
//                     Console.WriteLine($"Driver {driver.Name}, do you accept the ride? random value= {acceptRide}");
//                     if (acceptRide==0)
//                     {
//                         driver.AcceptRide(ride);
//                             return;
//                     }
//                      if (acceptRide==1)
//                     {
//                         driver.RejectRide(ride);
//                         break;
//                     }
//                     if(acceptRide==2)
//                     {
//                         Console.WriteLine("Waitting.....");
//                     }
// Thread.Sleep(500);
//                 }
//             }

//             Thread.Sleep(800); 
//         }
//     }
// }

// class Program
// {
//     static void Main(string[] args)
//     {
//         List<Driver> drivers = new List<Driver>
//         {
//             new ConcreteDriver { Name = "Driver 1", DriverId = 1 },
//             new ConcreteDriver { Name = "Driver 2", DriverId = 2 },
//             new ConcreteDriver { Name = "Driver 3", DriverId = 3 }
//         };

//         RideOder ride = new RideOder();
//         RideDispatcher dispatcher = new RideDispatcher(drivers);
//         dispatcher.FindDriver(ride);

//         if (ride.Driver != null)
//         {
//             Console.WriteLine($"Ride assigned to driver: {ride.Driver.Name}, ID: {ride.Driver.DriverId}");
//         }
//         else
//         {
//             Console.WriteLine("No driver found for the ride.");
//         }
//     }
// }
class Context{
        private State _state = null;
        public Context(State state)
        {
            this.TransitionTo(state);
        }
        public void TransitionTo(State state)
        {
            Console.WriteLine($"Context: Transition to {state.GetType().Name}.");
            this._state = state;
            this._state.SetContext(this);
        }
        public void Request1()
        {
            this._state.Handle1();
        }
        public void Request2()
        {
            this._state.Handle2();
        }
    }

    abstract class State
    {
        protected Context _context;

        public void SetContext(Context context)
        {
            this._context = context;
        }

        public abstract void Handle1();

        public abstract void Handle2();
    }

    class ConcreteStateA : State
    {
        public override void Handle1()
        {
            Console.WriteLine("ConcreteStateA handles request1.");
            Console.WriteLine("ConcreteStateA wants to change the state of the context.");
            this._context.TransitionTo(new ConcreteStateB());
        }

        public override void Handle2()
        {
            Console.WriteLine("ConcreteStateA handles request2.");
        }
    }

    class ConcreteStateB : State
    {
        public override void Handle1()
        {
            Console.Write("ConcreteStateB handles request1.");
        }

        public override void Handle2()
        {
            Console.WriteLine("ConcreteStateB handles request2.");
            Console.WriteLine("ConcreteStateB wants to change the state of the context.");
            this._context.TransitionTo(new ConcreteStateA());
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var context = new Context(new ConcreteStateA());
            context.Request1();
            context.Request2();
        }
    }