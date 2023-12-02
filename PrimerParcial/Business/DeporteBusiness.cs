using DAL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class DeporteBusiness
    {
        DeporteDao deporteDao = new DeporteDao();   
        public List<Deporte> GetDeportes()
        {
            return deporteDao.GetDeportes();
        }
    }
}
