namespace FactoryMethodExercise
{
    public interface Bill
    {
        public void calcFee() { }
    }

    public class LaudaryBill : Bill
    {
        public void calcFee()
        {
            Console.WriteLine("Phí = Đơn giá * Số kg");
        }
    }

    public class PrintBill : Bill
    {
        public void calcFee()
        {
            Console.WriteLine("Phí = Đơn giá * Số trang");
        }
    }

    public class RentMotorBill : Bill
    {
        public void calcFee()
        {
            Console.WriteLine("Phí = Đơn giá giờ * Số giờ thuê");
        }
    }

    public class Service
    {
        public enum ServiceType
        {
            Laudary, Print, RentMotor
        }
        public Service() { }
        public Bill CreateService(int type)
        {
            Bill b = null;
            switch (type)
            {
                case (int)ServiceType.Laudary:
                    b = new LaudaryBill();
                    break;
                case (int)ServiceType.Print:
                    b = new PrintBill();
                    break;
                case (int)ServiceType.RentMotor:
                    b = new RentMotorBill();
                    break;
            }
            return b;
        }
    }


    public class Program
    {
        static void Main(string[] args)
        {
            const int LAUDARY_CHOICE = 1, PRINT_CHOICE = 2, RENT_CHOICE = 3;
            Console.WriteLine("Hệ thống đang có sẵn 3 dịch vụ: \n(1) - Giặt ủi\n(2) - In ấn\n(3) - Thuê xe máy\nBạn chọn dịch vụ nào: ");
            int choice = Int32.Parse(Console.ReadLine());
            Service s = new Service();
            if (choice == LAUDARY_CHOICE)
            {
                s.CreateService(LAUDARY_CHOICE - 1).calcFee();
            }
            else if (choice == PRINT_CHOICE)
            {
                s.CreateService(PRINT_CHOICE - 1).calcFee();
            }
            else if (choice == RENT_CHOICE)
            {
                s.CreateService(RENT_CHOICE - 1).calcFee();
            }
        }
    }
}