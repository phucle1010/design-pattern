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