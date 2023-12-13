public class SinhVienThongThuong : ISinhVien
{
    private string hoTen;
    private string mssv;
    private int soTinChi;
    private decimal donGia;
    public int tiLeGiam = 0;

    public SinhVienThongThuong(string hoTen, string mssv, int soTinChi, decimal donGia)
    {
        this.hoTen = hoTen;
        this.mssv = mssv;
        this.soTinChi = soTinChi;
        this.donGia = donGia;
    }

    public decimal TinhHocPhi()
    {
        return soTinChi * donGia;
    }

    public void ThongTin()
    {
        Console.WriteLine("Thông tin sinh viên:");
        Console.WriteLine("Họ tên: " + hoTen);
        Console.WriteLine("MSSV: " + mssv);
        Console.WriteLine("Số tín chỉ: " + soTinChi);
        Console.WriteLine("Đơn giá: " + donGia);
    }
}

public abstract class Decorator : ISinhVien
{
    protected ISinhVien sinhVien;

    public Decorator(ISinhVien sinhVien)
    {
        this.sinhVien = sinhVien;
    }

    public virtual decimal TinhHocPhi()
    {
        return sinhVien.TinhHocPhi();
    }

    public virtual void ThongTin()
    {
        sinhVien.ThongTin();
    }
}

public enum DanhHieuType
{
    NamTot,
    XuatSac,
    CongHien
}

public class DanhHieuDecorator : Decorator
{
    private List<DanhHieuType> danhHieuList;

    public DanhHieuDecorator(ISinhVien sinhVien, List<DanhHieuType> danhHieuList) : base(sinhVien)
    {
        this.danhHieuList = danhHieuList;
    }

    public override decimal TinhHocPhi()
    {
        decimal hocPhi = sinhVien.TinhHocPhi();

        foreach (DanhHieuType danhHieu in danhHieuList)
        {
            switch (danhHieu)
            {
                case DanhHieuType.NamTot:
                    hocPhi -= hocPhi * 0.15m;
                    break;
                case DanhHieuType.XuatSac:
                    hocPhi -= hocPhi * 0.1m;
                    break;
                case DanhHieuType.CongHien:
                    hocPhi -= hocPhi * 0.08m;
                    break;
                default:
                    throw new ArgumentException("Not type");
            }
        }

        return hocPhi;
    }

    public override void ThongTin()
    {
        sinhVien.ThongTin();

        decimal giamHocPhi = 0;
        foreach (DanhHieuType danhHieu in danhHieuList)
        {
            switch (danhHieu)
            {
                case DanhHieuType.NamTot:
                    giamHocPhi += 15;
                    break;
                case DanhHieuType.XuatSac:
                    giamHocPhi += 10;
                    break;
                case DanhHieuType.CongHien:
                    giamHocPhi += 8;
                    break;
                default:
                    throw new ArgumentException("Not type");
            }
        }

        Console.WriteLine("Giảm học phí thêm: " + giamHocPhi + "%");
    }
}

public enum HoanCanhType
{
    Ngheo,
    CanNgheo,
    BinhThuong
    
}

public class HoanCanhDecorator : Decorator
{
    private HoanCanhType hoanCanhType;

    public HoanCanhDecorator(ISinhVien sinhVien, HoanCanhType hoanCanhType) : base(sinhVien)
    {
        this.hoanCanhType = hoanCanhType;
    }

    public override decimal TinhHocPhi()
    {
        decimal hocPhi = sinhVien.TinhHocPhi();

        switch (hoanCanhType)
        {
            case HoanCanhType.Ngheo:
                hocPhi -= hocPhi * 0.8m;
                break;
            case HoanCanhType.CanNgheo:
                hocPhi -= hocPhi * 0.5m;
                break;
                case HoanCanhType.BinhThuong:
               
                break;
            default:
                throw new ArgumentException("Not type");
        }

        return hocPhi;
    }

    public override void ThongTin()
    {
        sinhVien.ThongTin();

        decimal giamHocPhi = 0;
        switch (hoanCanhType)
        {
            case HoanCanhType.Ngheo:
                giamHocPhi = 80;
                break;
            case HoanCanhType.CanNgheo:
                giamHocPhi = 50;
                break;
                case HoanCanhType.BinhThuong:
               
                break;
            default:
                throw new ArgumentException("Not type");
        }

        Console.WriteLine("Giảm học phí thêm: " + giamHocPhi + "%");
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        
        ISinhVien sinhVien = new SinhVienThongThuong("Nguyen Van A", "SV001", 10, 100000);

        List<DanhHieuType> danhHieuList = new List<DanhHieuType>(); 

        HoanCanhType hoanCanhType;

        for (int i = 0; i < 3; i++)
        {
            switch (i)
            {
                case 0:
                    Console.WriteLine("Danh hiệu sinh viên 5 tốt? (Y/N)");
                    string userInput0 = Console.ReadLine();

                    if (userInput0.Equals("Y", StringComparison.OrdinalIgnoreCase))
                    {
                        danhHieuList.Add(DanhHieuType.NamTot);
                    }
                    break;

                case 1:
                    Console.WriteLine("Danh hiệu sinh viên xuất sắc? (Y/N)");
                    string userInput1 = Console.ReadLine();

                    if (userInput1.Equals("Y", StringComparison.OrdinalIgnoreCase))
                    {
                        danhHieuList.Add(DanhHieuType.XuatSac);
                    }
                    break;

                case 2:
                    Console.WriteLine("Danh hiệu sinh viên cống hiến? (Y/N)");
                    string userInput2 = Console.ReadLine();

                    if (userInput2.Equals("Y", StringComparison.OrdinalIgnoreCase))
                    {
                        danhHieuList.Add(DanhHieuType.CongHien);
                    }
                    break;

                default:
                    throw new ArgumentException("Invalid type", "type");
            }
        }

        Console.WriteLine("Hoàn cảnh nghèo? (Y/N)");
        string userInput3 = Console.ReadLine();

        if (userInput3.Equals("Y", StringComparison.OrdinalIgnoreCase))
        {
            hoanCanhType = HoanCanhType.Ngheo;
        }
        else
        {
            Console.WriteLine("Hoàn cảnh cận nghèo? (Y/N)");
            string userInput4 = Console.ReadLine();
            
            if (userInput4.Equals("Y", StringComparison.OrdinalIgnoreCase))
            {
                hoanCanhType = HoanCanhType.CanNgheo;
            }
            else
            {
                hoanCanhType = HoanCanhType.BinhThuong; 
            }
        } 
       
        sinhVien = new DanhHieuDecorator(sinhVien, danhHieuList);

        sinhVien = new HoanCanhDecorator(sinhVien, hoanCanhType);
        
        sinhVien.ThongTin();
        decimal hocPhi = sinhVien.TinhHocPhi();
        Console.WriteLine("Học phí phải đóng: " + hocPhi);
    }
}