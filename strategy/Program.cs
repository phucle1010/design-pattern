namespace StrategyPattern
{
    public interface IStrategy
    {
        int spentTime { get; set; }
        void execute();
    }

    public class CarStrategy : IStrategy
    {
        public int spentTime { get; set; }
        public CarStrategy()
        {
            this.spentTime = 2;
        }
        public void execute()
        {
            Console.WriteLine("Car Direction: A -> B -> C -> D");
            Console.WriteLine($"Spent Time: {this.spentTime} hours");
        }
    }

    public class BikeStrategy : IStrategy
    {
        public int spentTime { get; set; }

        public BikeStrategy()
        {
            this.spentTime = 5;
        }
        public void execute()
        {
            Console.WriteLine("Bike Direction: A -> F -> J -> D");
            Console.WriteLine($"Spent Time: {this.spentTime} hours");
        }
    }

    public class MotorStrategy : IStrategy
    {
        public int spentTime { get; set; }
        public MotorStrategy()
        {
            this.spentTime = 3;
        }
        public void execute()
        {
            Console.WriteLine("Walking Direction: A -> H -> D");
            Console.WriteLine($"Spent Time: {this.spentTime} hours");
        }
    }

    public class Context
    {
        IStrategy _strategy;
        public Context() { }
        public Context(IStrategy strategy)
        {
            this._strategy = strategy;
        }
        public void showDirection()
        {
            this._strategy.execute();
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            int CAR_OPTION = 1, BIKE_OPTION = 2, MOTOR_OPTION = 3, EXIT_PROGRAM = 4;
            string YES_OPTION = "y", NO_OPTION = "n";
            Context context = new Context();
            while (true)
            {
                Console.Write("\nWhich option do you want to run?\n1.\tBy Car\n2.\tBy Bike\n3.\tBy Motor\nYour choice: ");
                int option = Int32.Parse(Console.ReadLine());
                if (option == CAR_OPTION)
                {
                    context = new Context(new CarStrategy());
                }
                else if (option == BIKE_OPTION)
                {
                    context = new Context(new BikeStrategy());
                }
                else if (option == MOTOR_OPTION)
                {
                    context = new Context(new MotorStrategy());
                }
                context.showDirection();
                Console.Write("Do you want to choose another direction? (y/n): ");
                string exitOption = Console.ReadLine();
                if (exitOption == YES_OPTION)
                {
                    continue;
                }
                else if (exitOption == NO_OPTION)
                {
                    break;
                }
            }
        }
    }
}