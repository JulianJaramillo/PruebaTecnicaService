using Prueba.Bussiness.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prueba.Result;
using Prueba.Bussiness.Dto;

namespace Prueba.Bussiness.Implementacion
{
    public class HTMLBusiness : ILenguajeBusiness
    {
        private List<ListaElementosDto> procesar(string Valor)
        {
            List<ListaElementosDto> listElementos = new List<ListaElementosDto>();
            string[] words = Valor.Split('#');
            int ContH = 0;
            string valor = "";

            foreach (string word in words)
            {
                if (word == "")
                {
                    ContH = ContH + 1;
                }
                if (word != "")
                {
                    valor = word;
                }
                if (valor != "")
                {
                    listElementos.Add(new ListaElementosDto { Numero = ContH, Texto = valor });
                    ContH = 1;
                    valor = "";
                }
            }
            if (ContH > 1)
            {

                listElementos.Add(new ListaElementosDto { Numero = ContH - 1, Texto = "" });

            }
            return (listElementos);
        }
        public Result.Result<LenguajeDto> GetPruebaLenguaje(LenguajeDto Codigo)
        {
            List<ListaElementosDto> lista = procesar(Codigo.Entrada);
            string resultado = "";
            foreach (ListaElementosDto elementos in lista)
            {

                resultado = string.Format("{0}<H{1}>{2}</H{1}>{3}", resultado, elementos.Numero, elementos.Texto, Environment.NewLine);
            
            
            
            }

            Codigo.Compilado = resultado;
            return Result<LenguajeDto>.Success(Codigo, "OperacionExitosa");
        }
    }
}
