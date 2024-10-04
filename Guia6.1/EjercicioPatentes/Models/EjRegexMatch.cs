using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EjercicioPatentes.Models
{
    public class EjRegexMatch : IProcesable
    {
        public string ProcesarPatente(string patente, out string nueva)
        {
            Match match = null;
            nueva = patente.Replace(" ", "");
            match = Regex.Match(nueva, @"^[A-Z]{3}[0-9]{3}$", RegexOptions.IgnoreCase);
            //IgnoreCase elimina la distinción entre mayúsculas y minúsculas esta bueno.
            if (match.Success)
            {
                return "Automóviles y camionetas hasta 2016\r\n";
            }
            match = Regex.Match(nueva, @"^[A-Z]{2}[0-9]{3}[A-Z]{2}$", RegexOptions.IgnoreCase);
            if (match.Success)
            {
                return "Automóviles y camionetas desde 2016\r\n";
            }
            match = Regex.Match(nueva, @"^[A-Z]{2}[0-9]{3}[A-Z]{3}$", RegexOptions.IgnoreCase);
            if (match.Success)
            {
                return "Motocicleta\r\n";
            }
            match = Regex.Match(nueva, @"^[A-Z]{2}[0-9]{4}$", RegexOptions.IgnoreCase);
            if (match.Success)
            {
                return "Acoplado\r\n";
            }
            else
            {
                return "Otro\r\n";
            }
        }
    }
}
