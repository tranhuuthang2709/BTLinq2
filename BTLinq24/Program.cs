using System;
using System.Collections.Generic;
using System.Linq;

class Phongban
{
    public string tenphongban { get; set; }
    public string motaphongban { get; set; }
}

class Chucvu
{
    public string tenchucvu { get; set; }
    public string motachucvu { get; set; }
}

class Nhanvien
{
    public string ten { get; set; }
    public int tuoi { get; set; }
    public Chucvu Chucvu { get; set; }
    public Phongban Phongban { get; set; }
}
class Program
{
    static void Main(string[] args)
    {
        List<Phongban> phongban = new List<Phongban>();
        List<Chucvu> chucvu = new List<Chucvu>();
        List<Nhanvien> nhanvien = new List<Nhanvien>();

        Console.WriteLine("nhap ten phong ban :");
        string tenphongban = Console.ReadLine();
        Console.WriteLine("nhap mo ta phong ban  :");
        string motaphongban = Console.ReadLine();

        Console.WriteLine("nhap ten chuc vu:");
        string tenchucvu = Console.ReadLine();
        Console.WriteLine("nhap mo ta chuc vu :");
        string motachucvu = Console.ReadLine();


        Console.WriteLine("Nhap thong tin nhan vien (ten - tuoi - vi tri - phong ban):");
        string employeeInput = Console.ReadLine();
        while (!string.IsNullOrEmpty(employeeInput))
        {
            string[] nhanvien1 = employeeInput.Split('-');
            nhanvien.Add(new Nhanvien
            {
                ten = nhanvien1[0].Trim(),
                tuoi = Convert.ToInt32(nhanvien1[1].Trim()),
                Chucvu = chucvu.FirstOrDefault(p => p.tenchucvu == nhanvien1[2].Trim()),
                Phongban = phongban.FirstOrDefault(d => d.tenphongban == nhanvien1[3].Trim())
            });
            employeeInput = Console.ReadLine();
        }

        Console.WriteLine("nhap tu khoa tim kiem:");
        string keyword = Console.ReadLine();
        Console.WriteLine("tuoi tu:");
        int minAge = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("den tuoi:");
        int maxAge = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("vi tri:");
        string positionKeyword = Console.ReadLine();
        Console.WriteLine("phong ban:");
        string departmentKeyword = Console.ReadLine();

        var searchResult = nhanvien.Where(e => e.ten.Contains(keyword) ||
                                                 e.Chucvu.tenchucvu.Contains(positionKeyword) ||
                                                 e.Phongban.tenphongban.Contains(departmentKeyword) ||
                                                 e.tuoi >= minAge && e.tuoi <= maxAge);

        Console.WriteLine("ket qua:");
        foreach (var employee in searchResult)
        {
            Console.WriteLine($"Tên: {employee.ten}, Tuổi: {employee.tuoi}, Vị trí: {employee.Chucvu.tenchucvu}, Phòng ban: {employee.Phongban.tenphongban}");
        }
        Console.ReadLine();
    }
}
