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
            Valor = Valor.TrimStart(' '); //Quitar Espacios
            Valor = Valor.TrimEnd(' ');
            List<ListaElementosDto> listElementos = new List<ListaElementosDto>();
            string[] words = Valor.Split('#');
            int ContH = 0;
            string valorPalabra = "";

            foreach (string word in words)
            {
                if (word == "")
                {
                    ContH = ContH + 1;
                }
                if (word != "")
                {
                    valorPalabra = word;
                }
                if (valorPalabra != "")
                {
                    listElementos.Add(new ListaElementosDto { Numero = ContH, Texto = valorPalabra });
                    ContH = 1;
                    valorPalabra = "";
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

                resultado = string.Format("{0}<h{1}>{2}</h{1}>{3}", resultado, elementos.Numero, elementos.Texto, Environment.NewLine);
            
            
            
            }

            Codigo.Compilado = resultado;
            return Result<LenguajeDto>.Success(Codigo, "OperacionExitosa");
        }
    }
}
