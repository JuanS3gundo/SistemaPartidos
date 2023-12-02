using DAL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace Business
{
    public class PartidoBusiness
    {
        PartidoDao partidoDao = new PartidoDao();   
        public void CargarPartidos(Partido AgregoPartido)
        {
            if (AgregoPartido.EquipoLocal == null )
            {
                if(AgregoPartido.EquipoVisitante == null)
                {
                    throw new Exception("Debe poner un equipo local y visitante");
                }
            }
            if(AgregoPartido.EquipoLocal.ToString().Length < 5)
            {
                if (AgregoPartido.EquipoVisitante.ToString().Length < 5)
                {
                    throw new Exception("Los nombres de los equipos deben superar los 5 caracteres");
                }
            }
            if(AgregoPartido.FechaPartido < DateTime.Now)
            {
                throw new Exception("la fecha del partido no puede ser menor al dia de hoy");
            }
            if(AgregoPartido.IdDeporte.ToString() == null)
            {
                throw new Exception("debe haber algun deporte");
            }
            partidoDao.CargarPartidos(AgregoPartido);
        }
        public List<Partido> GetPartidos()
        {
            return partidoDao.GetPartidos();
        }
        public void EliminarPartido(Partido partido)
        {
            partidoDao.EliminarPartidos(partido.IdPartido);
        }
        public void EditarPartidos(int marcadorLocal, int marcadorVisitante, int idPartido)
        {
            partidoDao.EditarPartidos(marcadorLocal, marcadorVisitante, idPartido);
        }

    }
}
