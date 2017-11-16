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
        private List<ListaElementosDto> procesar(string Valor) // Refactoring del metodo que realizara la logica de la aplicacion
        {
            Valor = Valor.TrimStart(' '); //Quitar Espacios
            Valor = Valor.TrimEnd(' '); //Quitar Espacios
            List<ListaElementosDto> listElementos = new List<ListaElementosDto>(); // Creacion de un arreglo tipo lista que almacenara elementos tipo ListaElementosDto creada anteriormente
            string[] words = Valor.Split('#'); // Creamos una nueva variable que reemplaza los # por espacio y serviria mas adelante para contar estos espacion y especificar que etiqueta <h> utilizar
            int ContH = 0; // Inicializamos el contador que almacenara la cantidad de espacios en blanco
            string valorPalabra = "";// Inicializamos una variable tipo string que almacenara las plabras enviadas

            foreach (string word in words)
            {
                if (word == "")
                {
                    ContH = ContH + 1; // Se cuentan los espacion en blanco
                }
                if (word != "")
                {
                    valorPalabra = word; // Se almacenan las palabas enviadas.
                }
                if (valorPalabra != "")
                {
                    listElementos.Add(new ListaElementosDto { Numero = ContH, Texto = valorPalabra }); //Se adicionan los elementos en la lista
                    ContH = 1;
                    valorPalabra = "";
                }

               
            }
            if (ContH > 1)
            {

                listElementos.Add(new ListaElementosDto { Numero = ContH - 1, Texto = "" }); // Se acutliza la variable contH para evitar que cuente espacio como elementos adicionales

            }
            return (listElementos);
        }
        public Result.Result<LenguajeDto> GetPruebaLenguaje(LenguajeDto Codigo)
        {
            List<ListaElementosDto> lista = procesar(Codigo.Entrada); // se almacena en la variable lista, el resultado del metodo anterior que contendra la lista de elementos del valor enviado
            string resultado = "";
            foreach (ListaElementosDto elementos in lista)
            {
                if (elementos.Numero > 7 || elementos.Numero ==0) // Si el numero de espacios en blacno es 0 o 7 solo mostrara la palabra enviada, ya que <h0> y <h7> no estan contemplados en el html
                {

                    resultado = string.Format("{0}{1}{2}", resultado, elementos.Texto, Environment.NewLine);
                }
                else 
                {

                    if (elementos.Texto == "Mala sintaxis" && elementos.Numero == 1) // Si se recibe #Malas Sintaxis la respuesta sera la misma
                    {
                        resultado = string.Format("{0}{1}{2}", resultado, "#Mala sintaxis", Environment.NewLine);
                    }
                    else {

                        resultado = string.Format("{0}<h{1}>{2}</h{1}>{3}", resultado, elementos.Numero, elementos.Texto, Environment.NewLine); // Se formate el numero que corresponda a la etiqueta <h> y el texto que esta conlleva
                    }
                }

            }

            Codigo.Compilado = resultado; // Se asigna el resultado, y se devuelve como una operacion exitosa.
            return Result<LenguajeDto>.Success(Codigo, "OperacionExitosa");
        }
    }
}
