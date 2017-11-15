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
       Result<LenguajeDto> GetPruebaLenguaje(LenguajeDto Codigo);

    }
}
