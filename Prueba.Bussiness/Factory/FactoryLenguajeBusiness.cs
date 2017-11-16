using Prueba.Bussiness.Implementacion;
using Prueba.Bussiness.Interfaces;

namespace Prueba.Bussiness.Factory
{
    public class FactoryLenguajeBusiness
    {
       public static ILenguajeBusiness Intancia(string tipo="HTML") 
        {
           // En este caso se realiza la creacion de un Factory por si se quiere realizar una nueva implementacion a partir de la interface

                 return (new HTMLBusiness());

        }
    }
}
