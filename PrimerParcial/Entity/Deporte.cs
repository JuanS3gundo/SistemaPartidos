using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Deporte
    {
        private int idDeporte;
        private string tipoDeporte;

        public int IdDeporte { get => idDeporte; set => idDeporte = value; }
        public string TipoDeporte { get => tipoDeporte; set => tipoDeporte = value; }
    }
}
