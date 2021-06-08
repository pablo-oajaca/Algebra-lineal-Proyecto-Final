using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algebra_lineal_Proyecto_Final
{
    class Poblacion
    {
        string edades;
        string PoblacionInicial;
        string PorcentajeNatalidad;
        string PorcentajeSupervivencia;

        public string Edades { get => edades; set => edades = value; }
        public string PoblacionInicial1 { get => PoblacionInicial; set => PoblacionInicial = value; }
        public string PorcentajeNatalidad1 { get => PorcentajeNatalidad; set => PorcentajeNatalidad = value; }
        public string PorcentajeSupervivencia1 { get => PorcentajeSupervivencia; set => PorcentajeSupervivencia = value; }
        
        public object this[string propertyName]
        {
            get { return this.GetType().GetProperty(propertyName).GetValue(this, null); }
            set { this.GetType().GetProperty(propertyName).SetValue(this, value, null); }
        }
    
    }
}
