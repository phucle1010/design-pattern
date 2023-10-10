namespace CompositePattern
{
    public abstract class GiftBase
    {
        public string name { get; set; }
        public int price { get; set; }

        public GiftBase(string name, int price)
        {
            this.name = name;
            this.price = price;
        }

        public virtual int getTotalPrice() { return this.price; }
    }

    public interface IGiftComponent
    {
        void addGift(GiftBase g);
        void removeGift(GiftBase g);
    }

    public class GiftLeaf : GiftBase
    {
        public GiftLeaf(string name, int price) : base(name, price) { }

        public override int getTotalPrice()
        {
            Console.WriteLine($"{name} with the price {price}");
            return price;
        }
    }

    public class GiftComposite : GiftBase, IGiftComponent
    {
        private List<GiftBase> _gifts;

        public GiftComposite(string name, int price) : base(name, price)
        {
            _gifts = new List<GiftBase>();
        }
        public void Add(GiftBase gift)
        {
            _gifts.Add(gift);
        }
        public void Remove(GiftBase gift)
        {
            _gifts.Remove(gift);
        }
        public override int getTotalPrice()
        {
            int total = 0;

            Console.WriteLine($"{name} contains the following products with prices:");

            foreach (var gift in _gifts)
            {
                total += gift.getTotalPrice();
            }

            return total;
        }

        public void addGift(GiftBase g)
        {
            throw new NotImplementedException();
        }

        public void removeGift(GiftBase g)
        {
            throw new NotImplementedException();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var phone = new GiftLeaf("Phone", 256);
            phone.getTotalPrice();

            //composite gift
            var rootBox = new GiftComposite("RootBox", 0);
            var truckToy = new GiftLeaf("TruckToy", 289);
            var plainToy = new GiftLeaf("PlainToy", 587);
            rootBox.Add(truckToy);
            rootBox.Add(plainToy);
            var childBox = new GiftComposite("ChildBox", 0);
            var soldierToy = new GiftLeaf("SoldierToy", 200);
            childBox.Add(soldierToy);
            rootBox.Add(childBox);
            Console.WriteLine($"Total price of this composite present is: {rootBox.getTotalPrice()}");
        }
    }
}