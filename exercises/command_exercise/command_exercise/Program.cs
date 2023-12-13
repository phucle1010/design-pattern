using System;

// Receiver class
class Table
{
    private double[,] data;

    public Table(int rows, int columns)
    {
        data = new double[rows, columns];
    }

    public double this[int i, int j]
    {
        get { return data[i, j]; }
        set { data[i, j] = value; }
    }

    public double Sum()
    {
        double sum = 0;
        foreach (var value in data)
        {
            sum += value;
        }
        return sum;
    }

    public void SetDefault(double defaultValue)
    {
        for (int i = 0; i < data.GetLength(0); i++)
        {
            for (int j = 0; j < data.GetLength(1); j++)
            {
                data[i, j] = defaultValue;
            }
        }
    }

    public double FindMax()
    {
        double max = data[0, 0];
        foreach (var value in data)
        {
            if (value > max)
            {
                max = value;
            }
        }
        return max;
    }

    public double FindMin()
    {
        double min = data[0, 0];
        foreach (var value in data)
        {
            if (value < min)
            {
                min = value;
            }
        }
        return min;
    }
}

// Command interface
interface ICommand
{
    void Execute();
}

// Concrete command for sum operation
class SumCommand : ICommand
{
    private Table table;

    public SumCommand(Table table)
    {
        this.table = table;
    }

    public void Execute()
    {
        double result = table.Sum();
        Console.WriteLine($"Sum of the table: {result}");
    }
}

// Concrete command for set default operation
class SetDefaultCommand : ICommand
{
    private Table table;
    private double defaultValue;

    public SetDefaultCommand(Table table, double defaultValue)
    {
        this.table = table;
        this.defaultValue = defaultValue;
    }

    public void Execute()
    {
        table.SetDefault(defaultValue);
        Console.WriteLine($"Table set to default value: {defaultValue}");
    }
}

// Concrete command for find max operation
class FindMaxCommand : ICommand
{
    private Table table;

    public FindMaxCommand(Table table)
    {
        this.table = table;
    }

    public void Execute()
    {
        double result = table.FindMax();
        Console.WriteLine($"Maximum value in the table: {result}");
    }
}

// Concrete command for find min operation
class FindMinCommand : ICommand
{
    private Table table;

    public FindMinCommand(Table table)
    {
        this.table = table;
    }

    public void Execute()
    {
        double result = table.FindMin();
        Console.WriteLine($"Minimum value in the table: {result}");
    }
}

// Invoker class
class TableInvoker
{
    private ICommand command;

    public void SetCommand(ICommand command)
    {
        this.command = command;
    }

    public void ExecuteCommand()
    {
        command.Execute();
    }
}

class Program
{
    static void Main()
    {
        Console.Write("Enter the number of rows: ");
        int rows = int.Parse(Console.ReadLine());

        Console.Write("Enter the number of columns: ");
        int columns = int.Parse(Console.ReadLine());

        Table table = new Table(rows, columns);

        Console.WriteLine("Enter values for the table:");
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                Console.Write($"Enter value for element [{i},{j}]: ");
                table[i, j] = double.Parse(Console.ReadLine());
            }
        }

        TableInvoker invoker = new TableInvoker();

        while (true)
        {
            Console.WriteLine("\n*******************************************");
            Console.WriteLine("Choose an operation:");
            Console.WriteLine("1. Sum");
            Console.WriteLine("2. Set Default Value");
            Console.WriteLine("3. Find Max");
            Console.WriteLine("4. Find Min");
            Console.WriteLine("5. Exit\n");
            Console.Write("Your choice is:");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    invoker.SetCommand(new SumCommand(table));
                    invoker.ExecuteCommand();
                    break;

                case 2:
                    Console.Write("Enter the default value: ");
                    double defaultValue = double.Parse(Console.ReadLine());
                    invoker.SetCommand(new SetDefaultCommand(table, defaultValue));
                    invoker.ExecuteCommand();
                    break;

                case 3:
                    invoker.SetCommand(new FindMaxCommand(table));
                    invoker.ExecuteCommand();
                    break;

                case 4:
                    invoker.SetCommand(new FindMinCommand(table));
                    invoker.ExecuteCommand();
                    break;

                case 5:
                    Console.WriteLine("Exiting program.");
                    return;

                default:
                    Console.WriteLine("Invalid choice. Please enter a number between 1 and 5.");
                    break;
            }
        }
    }
}
