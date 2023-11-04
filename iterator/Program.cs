namespace IteratorPattern
{
    public class Item
    {
        string name;
        public Item(string name)
        {
            this.name = name;
        }
        public string Name
        {
            get { return name; }
        }
    }

    public interface IAbstractIterator
    {
        Item First();
        Item Next();
        bool IsDone { get; }
        Item CurrentItem { get; }
        int Step { get; set; }
    }

    public interface IAbstractCollection
    {
        IAbstractIterator CreateIterator();
    }

    public class Collection : IAbstractCollection
    {
        List<Item> items = new List<Item>();
        public IAbstractIterator CreateIterator()
        {
            return new Iterator(this);
        }
        public int Count
        {
            get { return items.Count; }
        }
        public Item this[int index]
        {
            get { return items[index]; }
            set { items.Add(value); }
        }
    }

    public class Iterator : IAbstractIterator
    {
        Collection collection;
        int current = 0, step = 1;
        public Iterator(Collection collection)
        {
            this.collection = collection;
        }
        public Item First()
        {
            current = 0;
            return collection[current] as Item;
        }
        public Item Next()
        {
            current += step;
            if (!IsDone) return collection[current] as Item;
            else return null;
        }
        public int Step
        {
            get { return step; }
            set { step = value; }
        }
        public Item CurrentItem
        {
            get { return collection[current] as Item; }
        }
        public bool IsDone
        {
            get { return current >= collection.Count; }
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            // Build a collection
            Collection collection = new Collection();
            collection[0] = new Item("Item 0");
            collection[1] = new Item("Item 1");
            collection[2] = new Item("Item 2");
            collection[3] = new Item("Item 3");
            collection[4] = new Item("Item 4");
            collection[5] = new Item("Item 5");
            collection[6] = new Item("Item 6");
            collection[7] = new Item("Item 7");
            collection[8] = new Item("Item 8");
            // Create iterator
            IAbstractIterator iterator = collection.CreateIterator();
            // Skip every other item
            iterator.Step = 3;
            Console.WriteLine("Iterating over collection:");
            for (Item item = iterator.First(); !iterator.IsDone; item = iterator.Next())
            {
                Console.WriteLine(item.Name);
            }
            // Wait for user
            Console.ReadKey();
        }
    }
}