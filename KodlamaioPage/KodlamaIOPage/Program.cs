using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;


CategoryManager categoryManager = new CategoryManager(new CategoryDal());
CourseManager courseManager = new CourseManager(new CourseDal());
InstructorManager instructorManager = new InstructorManager(new InstructorDal());



#region Category Manager

categoryManager.TAdd(new Category { Id = 5, Name = "Yeni Ders" });
Console.WriteLine("Bulunan :" + categoryManager.TGetById(2).Name);
categoryManager.TUpdate(new Category { Id = 1, Name = "Masaüstü Programlama" });
categoryManager.TDelete(2);
categoryManager.TGetAllList();

#endregion

Console.WriteLine("---------------------------------------------------------------");

#region Course Manager

courseManager.TAdd(new Course { Id = 4, CourseName = "Yeni Kurs", Description = "bu satır yeni olusturulmustur", Price = 100, CategoryId = 3, InstructorId = 4 });
Console.WriteLine("Bulunan : " + courseManager.TGetById(2).CourseName);
courseManager.TUpdate(new Course { Id = 3, CourseName = "HTML & CSS", Description = "Site yapımı", Price = 400, CategoryId = 3, InstructorId = 3 });
courseManager.TDelete(2);
courseManager.TGetAllList();

#endregion

Console.WriteLine("---------------------------------------------------------------");

#region Instructor Manager

instructorManager.TAdd(new Instructor { Id = 4, FirstName = "Sadık", LastName = "Turan" });
Console.WriteLine("Bulunan : " + instructorManager.TGetById(2).FirstName);
instructorManager.TUpdate(new Instructor { Id = 2, FirstName = "Atıl", LastName = "Samancıoğlu" });
instructorManager.TDelete(3);
instructorManager.TGetAllList();

#endregion

Console.WriteLine("---------------------------------------------------------------");

// Bir senaryo üzerinden gitmek istedim .Kategoriyi seçerek senaryoda bir işlem yaptırabilirsiniz.Şuan çalışan kısım Kategori Sayfasıdır.
#region Senaryo

List<string> lesson = new List<string>()
{
    "Kurs Sayfası",
    "Eğitmen Sayfası",
    "Kategori Sayfası  - Bu seçilmeli"
};

for (int i = 0; i < lesson.Count; i++)
{
    Console.WriteLine((i + 1) + "." + lesson[i]);
}
Console.WriteLine("-------------------------------------");

Console.Write("Hangi sayfaya gitmek istiyorusunuz? : ");

string girilenDeger = int.Parse(Console.ReadLine()) switch
{
    1 => "Kurs Sayfasına Girdiniz",
    2 => "Eğitmen Sayfasına Girdiniz",
    3 => "Kategori Sayfasına Girdiniz",
    _ => "Hatalı Giriş"
};
Console.WriteLine(girilenDeger);

Console.WriteLine("-------------------------------------");

List<string> operations = new List<string>()
{
    "Sil",
    "Güncelle",
    "Ekle",
    $"Aranacak ID",
    "Tümünü Listele"
};
for (int i = 0; i < operations.Count; i++)
{
    Console.WriteLine((i + 1) + "." + operations[i]);
}

Console.WriteLine("-------------------------------------");

Console.Write("Hangi işlemi yapmak istiyorusunuz? : ");

var secilenIslem = int.Parse(Console.ReadLine());
switch (secilenIslem)
{
    case 1:
        Console.Write("Silenecek Id giriniz");
        categoryManager.TDelete(int.Parse(Console.ReadLine()));
        break;
    case 2:
        Console.Write("Güncellenecek Önce Id ve Sonrasında yeni ismini veriniz : ");
        categoryManager.TUpdate(new Category { Id = int.Parse(Console.ReadLine()), Name = Console.ReadLine() });
        break;
    case 3:
        Console.Write("Ekleme isleminde Önce Id ve Sonrasında yeni ismini veriniz : ");
        categoryManager.TAdd(new Category { Id = int.Parse(Console.ReadLine()), Name = Console.ReadLine() });
        break;
    case 4:
        Console.Write("Aranacak Id Giriniz : ");
        Console.WriteLine(categoryManager.TGetById(int.Parse(Console.ReadLine())).Name);
        break;
    case 5:
        categoryManager.TGetAllList();
        break;
}

#endregion

Console.ReadLine();