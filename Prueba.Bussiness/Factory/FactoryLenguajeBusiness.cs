using Prueba.Bussiness.Implementacion;
using Prueba.Bussiness.Interfaces;

namespace Prueba.Bussiness.Factory
{
    public class FactoryLenguajeBusiness
    {
       public static ILenguajeBusiness Intancia(string tipo="HTML") 
        {
            //if (tipo == "HTML")
            //{
                 return (new HTMLBusiness());
            //}
            //else {
            //    return (new PascalBusiness());
            //}
        

        
        }
    }
}
