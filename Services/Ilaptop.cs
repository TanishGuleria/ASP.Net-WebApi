using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP.NetWebApi.Model;

namespace ASP.NetWebApi.Services
{
    public interface Ilaptop
    {

        IEnumerable<Laptop> GetLaptop(int? pageno, int? pagesize );
        IEnumerable<Laptop> GetLaptopbyid(int id);
        IEnumerable<Laptop> Getsort(string sort);
        IEnumerable<Laptop> Getsearch (string s);

        void AddLaptop(Laptop l);
        void UpdateLaptop(Laptop l);
        void DeleteLaptop(int id);




    }
}
