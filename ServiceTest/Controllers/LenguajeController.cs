
using Prueba.Bussiness.Dto;
using Prueba.Bussiness.Factory;
using Prueba.Bussiness.Interfaces;
using Prueba.Result;
using System.Web.Http;

namespace ServiceTest.Controllers
{
    public class LenguajeController : ApiController
    {   
        // Implementacio de la interface creada en la capa de Business
        ILenguajeBusiness iLenguaje;

        // Llamada al business y creacion del metodo tipo post       
        [Route("api/lenguajes/retorno")]
        public Result<LenguajeDto> PostHTML(LenguajeDto Codigo)
        {
            iLenguaje = FactoryLenguajeBusiness.Intancia();
            return iLenguaje.GetPruebaLenguaje(Codigo);
        }

    }
}
