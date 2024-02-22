using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class CategoryDal : ICategoryDal
    {
        private List<Category> _categories;

        public CategoryDal()
        {
            _categories = new List<Category>
            {
                new Category { Id = 1, Name = "Web Programlama" },
                new Category { Id = 2, Name = "Mobil Programlama" },
                new Category { Id = 3, Name = "Robotik Kodlama" }
            };
        }

        public void Add(Category entity)
        {
            _categories.Add(entity);
            Console.WriteLine("Başarıyla Eklendi");
        }

        public void Delete(int id)
        {
            _categories.Remove(_categories.SingleOrDefault(c => c.Id == id));
            Console.WriteLine("Başarıyla Silindi");
        }

        public List<Category> GetAllList()
        {
            foreach (var x in _categories)
            {
                Console.WriteLine(x.Name);
            }
            return _categories;
        }

        public Category GetById(int id)
        {
            var result = _categories.Find(x => x.Id == id);
            return result;
        }

        public void Update(Category entity)
        {
            var found = _categories.FirstOrDefault(x => x.Id == entity.Id);
            if (found != null)
            {
                found.Name = entity.Name;
                Console.WriteLine("Başarıyla güncellendi.");
            }
            else
            {
                Console.WriteLine("Başarısız işlem.");
            }
        }
    }
}
