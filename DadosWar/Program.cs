using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DadosWar
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\n Quit para salir");

            string entrada;     //Datos Entrada
            int nDados = 0;       //Numero de dados para la tirada
            int tirada = 0;

            while (true)        //Bucle Infinito
            {
                Retry:  //Etiqueta para volver a empezar

                Console.WriteLine("\n Introduce numero de dados:");
                entrada = Console.ReadLine().ToLower();

                if (entrada.Equals("quit"))//Comprobar fin de Programa
                {
                    break;
                }

                if (Int32.TryParse(entrada, out nDados))//Comprueba que entrada sea un numero entero
                {
                    Console.WriteLine("\n Son " + nDados + " dados");
                }
                else
                {
                    Console.WriteLine("\n No has introducido un Numero Entero");
                    goto Retry;     //Empezar de nuevo
                }

                TiradaSuperar:    //Continuamos con tirada

                Console.WriteLine("\n Escribe tirada a superar:");
                entrada = Console.ReadLine();

                if (entrada == "Quit" | entrada == "quit")//Comprobar fin de Programa
                {
                    break;
                }
                if (Int32.TryParse(entrada, out tirada))//Comprueba que entrada sea un numero entero
                {
                    Console.WriteLine("\n La tirada es " + tirada);
                    
                }
                else
                {
                    Console.WriteLine("\n No has introducido un Numero Entero");
                    goto TiradaSuperar;     //Empezar de nuevo
                }

                int[] tiradas = tiradaDados(nDados);
                //mostrar(tiradas);
                analizarTirada(tiradas, tirada);

                Console.WriteLine("\n Fin Bucle");
               
            }
        
        }
        static int[] tiradaDados(int nDados)
        {
            int[] resultados = new int[nDados]; //Array para los resultados de los dados
            Random dado= new Random();          //Variable Random

            for (int i = 0; i < nDados; i++)
            {
                resultados[i] = dado.Next(1,6);//Dado toma un numero aleatorio de 1 a 6
            }

            return resultados;
        }


        static void mostrar(int[] resultados)//Metodo para mostrar las tiradas
        {
            for (int i = 0; i < resultados.Length; i++)
            {
                Console.WriteLine("\n Resultado de la tirada " + (i+1)+ " es " + resultados[i]);
            }
        }


        static void analizarTirada(int[]tiradas, int tirada)//Metodo para analizar el numero de superados
        {
            string entrada;
            int res = 0;
            if (tirada>0)       //Comprobamos si la tirada es "X o mas" o es "X o menos"
            {
                Console.WriteLine("\n La tirada tiene que ser superior a " + tirada);
                res = superarTirada(tiradas, tirada);   //Resultado de la tirada, numero de aciertos
                Console.WriteLine("\n Han superado las tiradas " + res + " Dados");
            }
            else
            {
                int tiradaNeg = 1 - tirada; //La tirada de "X o menos" (-X) es igual a los fallos de "(1- (-X)) o mas"
                Console.WriteLine("\n La tirada tiene que ser menor a " + tiradaNeg);
                res = tiradas.Length -superarTirada(tiradas, tiradaNeg);//Resultado de la tirada, numero de aciertos
                Console.WriteLine("\n Han superado las tiradas " + res + " Dados");
            }

            Criticos:

            Console.WriteLine("\n ¿Quieres buscar Criticos? Responde S o N");//Recuento de 6 y 1 en la tirada
            entrada = Console.ReadLine();

            switch (entrada.ToLower())   //Selector de la respuesta, convierte mayusculas a minusculas
            {
                case "s":               //Respuesta Afirmativa
                    goto CriticosSi;
                case "n":               //Respuesta Negativa
                    return;
                default:                //Cualquier caso no contemplado de respuesta
                    Console.WriteLine("\n Escribe una respuesta valida");
                    goto Criticos;      //Te devuelve al comienzo de la pregunta
            }

            CriticosSi:
            Console.WriteLine("\n Criticos SI!!");
        }


        static int superarTirada(int[] tiradas, int tirada) //Metodo para contar las tiradas superadas
        {
            int superadas = 0;

            for (int i = 0; i < tiradas.Length; i++)
            {
                if (tiradas[i] >= tirada)   //Si es mayor a el numero de la tirada cuenta
                {
                    superadas++;
                }
            }
            return superadas;
        }
    }
}
