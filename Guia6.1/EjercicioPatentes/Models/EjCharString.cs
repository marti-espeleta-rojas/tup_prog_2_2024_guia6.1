using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioPatentes.Models
{
    public class EjCharString : IProcesable
    {
        #region Pruebas fallidas
        /*public string ProcesarPatente(string patente, out string nueva)
        {
            nueva = patente.Replace(" ", "");
            int contLetra = 0;
            foreach (char c in nueva)
            {
                if (char.IsLetter(c))
                {
                    contLetra++;
                }
            }
            /*if (contLetra == 3 && contNumero == 3)
            {
                return "Automóviles y camionetas hasta 2016";
            }
            if (contLetra==4 && contNumero == 3)
            {
                return "Automóviles y camionetas desde 2016";
            }
            if (contLetra == 5 && contNumero == 3)
            {
                return "Motocicleta";
            }
            if (contLetra==2)
            {
                return "Acoplado";
            }
            else
            {
                return "Otro";
            }
            

            switch (contLetra)
            {
                case 3:
                    {
                        return "Automóviles y camionetas hasta 2016\r\n";
                    }
                case 4:
                    {
                        return "Automóviles y camionetas desde 2016\r\n";
                    }
                case 5:
                    {
                        return "Motocicleta\r\n";
                    }
                case 2:
                    {
                        return "Acoplado\r\n";
                    }
                default:
                    {
                        return "Otro\r\n";
                    }
            }

        }*/
        #endregion
        public string ProcesarPatente(string patente, out string nueva)
        {
            string patFormat = patente.Replace(" ", "").ToUpper();
            #region Caso hasta 2016
            bool esHasta2016 = patFormat.Length == 6;
            for (int i = 0; i<patFormat.Length && esHasta2016 == true; i++)
                /*fijate como se puede hacer una lógica en el for "(i; lógica(condición);i)".
                 * En el bucle, cuando esHasta2016 tome el valor false, se va a salir del mismo.
                 * Y entonces se seguirá con la comprobación de los demás*/
            {
                char d = patFormat[i];
                esHasta2016 &= (Char.IsLetter(d) && i < 3 || Char.IsNumber(d) && i < 6 && i>=3);
                /* & funciona como el += osea que esHasta2016 es verdadero "y" la primer
                 * condición sea true "O" la segunda lo sea. Para cualquiera de las dos.
                 * Entonces se va a estar reasignando en cada iteración para después
                 * comprobar su valor fuera del bucle.
                 */
            }
            if (esHasta2016)
            {
                nueva = patFormat;
                return "Automóviles y camionetas hasta 2016\r\n";
            }
            #endregion
            #region Caso desde 2016
            bool esDesde2016=patFormat.Length == 7;
            for (int i = 0; i<patFormat.Length && esDesde2016;i++)
            {
                char d = patFormat[i];
                esDesde2016 &= (Char.IsLetter(d) && i < 2 || Char.IsNumber(d) && i < 5 && i > 1 || Char.IsLetter(d) && i > 4 && i <= 6);
            }
            if (esDesde2016)
            {
                nueva = patFormat;
                return "Automóviles y camionetas desde 2016\r\n";
            }
            #endregion
            #region Caso Motocicleta
            bool esMoto=patFormat.Length == 8;
            for (int i = 0; i<patFormat.Length && esMoto; i++)
            {
                char d = patFormat[i];
                esMoto &= (Char.IsLetter(d) && i < 2 || Char.IsNumber(d) && i < 5 && i > 1 || Char.IsLetter(d) && i > 4 && i <= 7);
            }
            if (esMoto)
            {
                nueva = patFormat;
                return "Motocicleta\r\n";
            }
            #endregion
            #region Caso Acoplado
            bool esAcoplado = patFormat.Length == 6;
            for (int i = 0;i<patFormat.Length && esAcoplado; i++)
            {
                char d = patFormat[i];
                esHasta2016 &= (Char.IsLetter(d) && i < 2 || Char.IsNumber(d) && i < 6 && i > 1);
            }
            if (esAcoplado)
            {
                nueva = patFormat;
                return "Acoplado\r\n";
            }
            else
            {
                nueva = patFormat;
                return "Otro\r\n";
            }
            #endregion
        }
    }
}
