using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioPatentes.Models
{
    interface IProcesable
    {
        string ProcesarPatente(string patente, out string nueva);
    }
}
