using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba.Bussiness.Dto
{
    // Creacion de un objeto el mapeo de los datos al exponer el servicio
    public class LenguajeDto
    {
        public string Entrada { get; set; }
        public string Compilado { get; set; } //En esta variable se almacenara el resultado de la logica implementada en el Bussiness
    }
}
