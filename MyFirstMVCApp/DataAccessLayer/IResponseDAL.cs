using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyFirstMVCApp.Web.Models;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MyFirstMVCApp.DataAccessLayer
{
    public interface IResponseDAL
    {
        List<Libs> GetAllLibs();
        Libs GetLibById(int id);
        bool CreateLib(Libs newLib);
    }
}