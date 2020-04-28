using ASP.NetWebApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace ASP.NetWebApi.Services
{
    public class LaptopRepository : Ilaptop
    {
        private LaptopContext context;

        public LaptopRepository(LaptopContext _context)
        {
            context = _context;
        }



        public void AddLaptop(Laptop l)
        {
            context.Laptops.Add(l);
            context.SaveChanges();
        }

        public void DeleteLaptop(int id)
        {
            var result = context.Laptops.Find(id);

            context.Laptops.Remove(result);
            context.SaveChanges(true);

        }
        public IEnumerable<Laptop> GetLaptop(int? pageno , int? pagesize)
        {
            var query = from p in context.Laptops.OrderBy(a => a.LaptopId) select p;
            int currentpage = pageno ?? 1;
            int curremtpagesize = pagesize ?? 5;
            var item = query.Skip((currentpage - 1) * curremtpagesize).Take(curremtpagesize).ToList();
            return item;
        }

        public IEnumerable<Laptop> GetLaptopbyid(int id)
        {
            var query = from p in context.Laptops.Where(a => a.LaptopId == id) select p;
            return query;
        }

        public IEnumerable<Laptop> Getsort(string sort)
        {
            if (sort == "desc")
            {
                return context.Laptops.OrderByDescending(c => c.LaptopPrice);
            }
            else if (sort == "asc")
            {
                return context.Laptops.OrderBy(c => c.LaptopPrice);
            }
            else
            {
                return context.Laptops;
            }
        }

        public IEnumerable<Laptop> Getsearch(string s)
        {
            var resut = context.Laptops.Where(p => p.LaptopBrand.StartsWith(s));
            return resut;
        }

        public void UpdateLaptop(Laptop l)
        {
            context.Laptops.Update(l);
            context.SaveChanges();
        }

        
    }
}
