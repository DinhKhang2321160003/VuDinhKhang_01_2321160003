using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VuDinhKhang_01_2321160003
{
    public class NhanVien
    {
        public string MaSo { get; set; }
        public string HoTen { get; set; }
        public int LuongCung { get; set; }
        public virtual void Nhap()
        {
            Console.WriteLine("Nhap thong tin NV: ");
            Console.Write("Ma so: ");
            MaSo = Console.ReadLine();
            Console.Write("Ho ten: ");
            HoTen = Console.ReadLine();
            Console.Write("Luong cung: ");
            LuongCung = int.Parse(Console.ReadLine());
        }
        public virtual int Tinhluong()
        {
            return LuongCung;
        }
    }
    public class NhanVienBC : NhanVien
    {
        public string MucXepLoai { get; set; }
        public override void Nhap()
        {
            base.Nhap();
            Console.Write("Nhap muc xep loai (A, B, C): ");
            MucXepLoai = Console.ReadLine();
        }
        public override int Tinhluong()
        {
            switch (MucXepLoai)
            {
                case "A":
                    return (int)(1.8 * LuongCung);
                case "B":
                    return (int)(1.2 * LuongCung);
                case "C":
                    return (int)(0.8 * LuongCung);
                default:
                    return 0;
            }
            
        }
    }
    public class NhanVienHD : NhanVien
    {
        public int DoanhThu { get; set; }
        public override void Nhap()
        {
            base.Nhap();
            Console.Write("Nhap doanh thu: ");
            DoanhThu = int.Parse(Console.ReadLine());
        }
        public override int Tinhluong()
        {
            return LuongCung + (int)(0.05 * DoanhThu);
        }
    }
    public class QuanLyNV
    {
        private List<NhanVien> dsnv = new List<NhanVien>();
        public void NhapDS()
        {
            Console.Write("Nhap so luong NV: ");
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"Nhap thong tin nhan vien thu {i + 1}: ");
                Console.Write("Loai (1: Bien Che, 2: Hop Dong): ");
                int loai = int.Parse(Console.ReadLine());
                NhanVien nv;
                if (loai == 1)
                {
                    nv = new NhanVienBC();
                }
                else
                {
                    nv = new NhanVienHD();
                }
                nv.Nhap();
                dsnv.Add(nv);
            }
        }
        public void XuatDS()
        {
            Console.WriteLine("Danh sach nhan vien: ");
            foreach (var nv in dsnv)
            {
                Console.WriteLine($"Ma so: {nv.MaSo}, Ho ten: {nv.HoTen}, Luong thuc lanh: {nv.Tinhluong()}");
            }
        }
        public int TinhTongLuong()
        {
            int tongLuong = 0;
            foreach (var nv in dsnv)
            {
                tongLuong = nv.Tinhluong();
            }
                return tongLuong;
        }
        public double TinhluongTrungBinh()
        {
            return (double)TinhTongLuong() / dsnv.Count;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            QuanLyNV quanLyNV = new QuanLyNV();
            int luachon;
            do
            {
                Console.WriteLine("*******************Menu********************: ");
                Console.WriteLine("1. Nhap danh sach nhan vien : ");
                Console.WriteLine("2. Hien thi thong tin nhan vien : ");
                Console.WriteLine("3. Thong ke tong tien luong : ");
                Console.WriteLine("4. Tinh tien luong trung binh : ");
                Console.WriteLine("0. Thoat ");
                Console.Write("Chon: ");
                luachon = int.Parse(Console.ReadLine());
                switch (luachon)
                {
                    case 1:
                        quanLyNV.NhapDS();
                        break;
                    case 2:
                        quanLyNV.XuatDS();
                        break;
                    case 3:
                        Console.WriteLine($"Tong luong : {quanLyNV.TinhTongLuong()}");
                        break;
                    case 4:
                        Console.WriteLine($"Tong luong : {quanLyNV.TinhluongTrungBinh()}");
                        break;
                    case 0:
                        Console.WriteLine("Ket thuc chuong trinh");
                        break;
                    default:
                        Console.WriteLine("Lua chon khong hop le");
                        break;
                }
            } while (luachon != 0);
        }
    }
}
