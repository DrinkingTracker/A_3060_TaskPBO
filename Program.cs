class Program
{
    private static void Main(string[] args)
    {
        RumahSakit RS1 = new RumahSakit();

        PasienAnak PA1 = new PasienAnak("GPT", 7, "Timeout");
        PasienDewasa PD1 = new PasienDewasa("Claude", 35, "Not Responding");
        Dokter DR1 = new Dokter("Cursor", 40, "Bedah");
        Perawat PR1 = new Perawat("Emergent", 28, "Perawat umum");

        RS1.TambahOrang(PA1);
        RS1.TambahOrang(PD1);
        RS1.TambahOrang(DR1);
        RS1.TambahOrang(PR1);

        Console.WriteLine("=== Daftar Orang di Rumah Sakit ===");
        RS1.DaftarOrang();

        // polymorphism
        Console.WriteLine();
        Console.WriteLine("=== Polymorphism: Aktivitas() ===");
        foreach (Orang i in RS1.daftarOrang)
        {
            i.Aktivitas();
        }

        // method khusus
        Console.WriteLine();
        Console.WriteLine("=== Method Khusus ===");
        PA1.Menangis();
        PD1.Konsultasi();
        PD1.CekKeluhan();
        DR1.Diagnosa();
        DR1.CekSpesialis();
        PR1.CekPasien();

        Console.WriteLine();
        Console.WriteLine("=== ngetes soal === \n");

        // soal 1
        Pasien pasien = new Pasien("Grok", 30, "Bad Gateway");
        DR1.Aktivitas();
        pasien.Aktivitas();
        Console.WriteLine();

        // soal 2
        DR1.Diagnosa();
        Console.WriteLine();

        // soal 3
        DR1.InfoOrang();
        DR1.CekSpesialis();
        Console.WriteLine();

        // soal 4
        PA1.Menangis();
        Console.WriteLine();

        // soal 5
        Orang orang = new Perawat("Seedance", 28, "Perawat umum");
        orang.Aktivitas();
        Console.WriteLine();
    }
}

class RumahSakit
{
    public List<Orang> daftarOrang { get; set; } = new List<Orang>();

    public void TambahOrang(Orang orang)
    {
        daftarOrang.Add(orang);
    }

    public void DaftarOrang()
    {
        if (daftarOrang.Count == 0)
        {
            Console.WriteLine("Belum ada orang di rumah sakit.");
            return;
        }

        foreach (Orang i in daftarOrang)
        {
            i.InfoOrang();
        }
    }
}

class Orang
{
    public string nama { get; set; }
    public int umur { get; set; }

    // constructor
    public Orang(string nama, int umur)
    {
        this.nama = nama;
        this.umur = umur;
    }

    // methods
    public virtual void Aktivitas()
    {
        Console.WriteLine($"{nama} berada di rumah sakit.");
    }

    public void InfoOrang()
    {
        Console.WriteLine($"Nama: {nama} \n Umur: {umur} tahun");
    }
}

class Pasien : Orang
{
    public string keluhan { get; set; }

    // constructor
    public Pasien(string nama, int umur, string keluhan) : base(nama, umur)
    {
        this.keluhan = keluhan;
    }

    // methods
    public void CekKeluhan()
    {
        Console.WriteLine($"{nama} mengeluhkan: {keluhan}");
    }

    public override void Aktivitas()
    {
        Console.WriteLine($"{nama} (pasien) sedang menunggu pemeriksaan.");
    }
}

class TenagaMedis : Orang
{
    public string spesialisasi { get; set; }

    // constructor
    public TenagaMedis(string nama, int umur, string spesialisasi) : base(nama, umur)
    {
        this.spesialisasi = spesialisasi;
    }

    // methods
    public void CekSpesialis()
    {
        Console.WriteLine($"{nama} memiliki spesialisasi: {spesialisasi}");
    }

    public override void Aktivitas()
    {
        Console.WriteLine($"{nama} (tenaga medis) sedang bertugas.");
    }
}

class Dokter : TenagaMedis
{
    // constructor
    public Dokter(string nama, int umur, string spesialisasi) : base(nama, umur, spesialisasi)
    {

    }

    // methods
    public void Diagnosa()
    {
        Console.WriteLine($"dr. {nama} ({spesialisasi}) sedang mendiagnosa pasien.");
    }

    public override void Aktivitas()
    {
        Console.WriteLine($"dr. {nama} sedang memeriksa pasien di ruang praktik.");
    }
}

class Perawat : TenagaMedis
{
    // constructor
    public Perawat(string nama, int umur, string spesialisasi) : base(nama, umur, spesialisasi)
    {

    }

    // methods
    public void CekPasien()
    {
        Console.WriteLine($"Perawat {nama} sedang mengecek kondisi pasien. ");
    }

    public override void Aktivitas()
    {
        Console.WriteLine($"Perawat {nama} sedang menyiapkan peralatan medis.");
    }
}

class PasienAnak : Pasien
{
    // constructor
    public PasienAnak(string nama, int umur, string keluhan) : base(nama, umur, keluhan)
    {

    }

    // methods
    public void Menangis()
    {
        Console.WriteLine($"{nama} menangis karena trauma diperiksa");
    }

    public override void Aktivitas()
    {
        Console.WriteLine($"{nama} ketar ketir sambil menunggu giliran.");
    }
}

class PasienDewasa : Pasien
{
    // constructor
    public PasienDewasa(string nama, int umur, string keluhan) : base(nama, umur, keluhan)
    {

    }

    // methods
    public void Konsultasi()
    {
        Console.WriteLine($"{nama} sedang berkonsultasi dengan dokter tentang {keluhan}.");
    }

    public override void Aktivitas()
    {
        Console.WriteLine($"{nama} (pasien dewasa) sedang mengisi formulir pendaftaran.");
    }
}