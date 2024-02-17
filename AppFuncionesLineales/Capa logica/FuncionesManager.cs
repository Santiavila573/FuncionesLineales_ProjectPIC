using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppFuncionesLineales
{
    class FuncionesManager
    {
        public Form_Funciones Form_Funciones
        {
            get => default;
            set
            {
            }
        }

        public double CalcularY(double x, double A, double B, double C)
        {
            return (C - A * x) / B;
        }
    }
}
