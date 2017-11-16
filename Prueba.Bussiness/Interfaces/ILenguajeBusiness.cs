using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prueba.Result;
using Prueba.Bussiness.Dto;

namespace Prueba.Bussiness.Interfaces
{
   public interface ILenguajeBusiness  
    {
       // Creacion de la interface que recibira el parametro tipo DTO y se extendera en la Implementacion
       Result<LenguajeDto> GetPruebaLenguaje(LenguajeDto Codigo);

    }
}
