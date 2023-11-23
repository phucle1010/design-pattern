// interface IHandler
//     {
//         IHandler Successor { get; set; }

//         void RequestOrder(int amount);
//     }

// class MiniStorage : IHandler
//     {
//         public IHandler Successor { get; set; }

//         public void RequestOrder(int amount)
//         {
//             if (amount < 10)
//             {
//                 Console.WriteLine($"Mini storage: I can handle less than 10 quantity. DONE!");
//             }
//             else
//             {
//                 Console.WriteLine($"Mini storage: I received the request but I can not handle more than 10 quantity. Passed to Medium storage");
//                 Successor?.RequestOrder(amount);
//             }
//         }
//     }

// class MediumStorage : IHandler
//     {
//         public IHandler Successor { get; set; }

//         public void RequestOrder(int amount)
//         {
//             if (amount < 50)
//             {
//                 Console.WriteLine($"Medium storage: I can handle less than 50 quantity. DONE!");
//             }
//             else
//             {
//                 Console.WriteLine($"Medium storage: I received the request but I can not handle more than 50 quantity. Passed to Big storage");
//                 Successor?.RequestOrder(amount);
//             }
//         }
//     }

// class BigStorage : IHandler
//     {
//         public IHandler Successor { get; set; }

//         public void RequestOrder(int amount)
//         {
//             if (amount < 100)
//             {
//                 Console.WriteLine($"Big handler: I can handle less than 100 quantity. DONE!");
//             }
//             else
//             {
//                 Console.WriteLine($"Big storage: I received the request but I can not handle more than 100 quantity. Passed to Fatory");
//                 Successor?.RequestOrder(amount);
//             }
//         }
//     }

// class FactoryHandler : IHandler
//     {
//         public IHandler Successor { get; set; }

//         public void RequestOrder(int amount)
//         {
//             Console.WriteLine($"Factory: I received the request. You will receice product from us");

//         }
//     }

// class ChainOfHandlers
//     {
//         readonly IHandler _mini = new MiniStorage();
//         readonly IHandler _medium = new MediumStorage();
//         readonly IHandler _big = new BigStorage();
//         readonly IHandler _factory = new FactoryHandler();

//         public ChainOfHandlers()
//         {
//             _mini.Successor = _medium;
//             _medium.Successor = _big;
//             _big.Successor = _factory;
//         }

//         public void Handle(int amount)
//         {
//             _mini.RequestOrder(amount);
//         }
//     }
    
//     class Program
//     {
//         static void Main(string[] args)
//         {
//             var chain = new ChainOfHandlers();
//             Console.WriteLine("Enter quantity: ");
//             int amount = Convert.ToInt32(Console.ReadLine());
//             chain.Handle(amount);
//         }
//     }

