class Program
{
    static void Main()
    {
        Perpustakaan perpustakaan = new Perpustakaan();

        perpustakaan.TambahBuku(new BukuFiksi("haha", "James", "1999"));
        perpustakaan.TambahBuku(new BukuNonFiksi("Gatau", "Darrel", "2010"));
        perpustakaan.TambahBuku(new Majalah("hehe", "Agathon", "2014"));

        perpustakaan.DaftarBuku();
        perpustakaan.PinjamBuku(0);
        perpustakaan.PinjamBuku(1);
        perpustakaan.DaftarBuku();
        perpustakaan.DaftarBukuDipinjam();
        perpustakaan.KembalikanBuku(0);
        perpustakaan.DaftarBukuDipinjam();
        perpustakaan.DaftarBuku();
    }
}

interface IBuku
{
    void TampilkanInfo();
}

abstract class Buku
{

    public string Judul { get; set; }
    public string Penulis { get; set; }
    public string TahunTerbit { get; set; }

    public string StatusBuku { get; set; } = "Tersedia";

    public Buku(string judul, string penulis, string tahunTerbit)
    {
        Judul = judul;
        Penulis = penulis;
        TahunTerbit = tahunTerbit;
    }

    public abstract void TampilkanInfo();
}

class BukuFiksi : Buku
{
    public BukuFiksi(string judul, string penulis, string tahunPenerbit) : base(judul, penulis, tahunPenerbit)
    {
    }
    public override void TampilkanInfo()
    {
        Console.WriteLine("Buku Fiksi:");
        Console.WriteLine($"Judul: {Judul}");
        Console.WriteLine($"Penulis: {Penulis}");
        Console.WriteLine($"Tahun Terbit: {TahunTerbit}");
        Console.WriteLine($"Status: {StatusBuku}");
    }
}

class BukuNonFiksi : Buku
{
    public BukuNonFiksi(string judul, string penulis, string tahunPenerbit) : base(judul, penulis, tahunPenerbit)
    {
    }
    public override void TampilkanInfo()
    {
        Console.WriteLine("Buku Non Fiksi:");
        Console.WriteLine($"Judul: {Judul}");
        Console.WriteLine($"Penulis: {Penulis}");
        Console.WriteLine($"Tahun Terbit: {TahunTerbit}");
        Console.WriteLine($"Status: {StatusBuku}");
    }
}

class Majalah : Buku
{
    public Majalah(string judul, string penulis, string tahunPenerbit) : base(judul, penulis, tahunPenerbit)
    {
    }
    public override void TampilkanInfo()
    {
        Console.WriteLine($"Judul: {Judul}");
        Console.WriteLine($"Penulis: {Penulis}");
        Console.WriteLine($"Tahun Trbit: {TahunTerbit}");
        Console.WriteLine($"Status: {StatusBuku}");
    }
}

class Perpustakaan
{
    private List<Buku> daftarBuku = new List<Buku>();
    private List<Buku> daftarPinjam = new List<Buku>();

    public void TambahBuku(Buku buku)
    {
        daftarBuku.Add(buku);
    }

    public void UbahBuku(int index, Buku bukuBaru)
    {
        if (index >= 0 && index < daftarBuku.Count)
        {
            daftarBuku[index] = bukuBaru;
        }
        else
        {
            Console.WriteLine("Index tidak valid");
        }
    }

    public void PinjamBuku(int index)
    {
        if (index >= 0 && index < daftarBuku.Count && daftarPinjam.Count <= 3)
        {
            Buku buku = daftarBuku[index];
            if (buku.StatusBuku == "Tersedia")
            {
                buku.StatusBuku = "Dipinjam";
                daftarPinjam.Add(buku);
                Console.WriteLine("Buku berhasil dipinjam");
            }
            else
            {
                Console.WriteLine("Buku sedang dipinjam");
            }
        }
        else if (daftarPinjam.Count > 3)
        {
            Console.WriteLine("Buku yang dipinjam melebihi batas peminjaman");
        }
        else
        {
            Console.WriteLine("Buku tidak tersedia");
        }
    }

    public void KembalikanBuku(int index)
    {
        if (index >= 0 && index < daftarPinjam.Count)
        {
            Buku buku = daftarPinjam[index];
            buku.StatusBuku = "Tersedia";
            daftarBuku.Add(buku);
            daftarPinjam.RemoveAt(index);
            Console.WriteLine("Buku berhasil dikembalikan");
        }
        else
        {
            Console.WriteLine("Buku tidak ditemukan");
        }
    }

    public void DaftarBuku()
    {
        Console.WriteLine("\nDaftar buku perpustakaan:");
        foreach (var buku in daftarBuku)
        {
            buku.TampilkanInfo();
            Console.WriteLine();
        }
    }

    public void DaftarBukuDipinjam()
    {
        Console.WriteLine("\nDaftar buku yang dipinjam:");
        foreach (var buku in daftarPinjam)
        {
            buku.TampilkanInfo();
            Console.WriteLine();
        }
    }
}