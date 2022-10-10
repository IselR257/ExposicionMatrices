/*Crea un arreglo o array multidimensional con un tamaño que definiremos nosotros por teclado,  
contendrá números aleatorios usando la función anterior y crearemos un array o arreglo unidimensional 
donde se copiaran los números que contiene el array multidimensional. Piensa que tamaño debe tener el array 
o arreglo unimensional. (imprimir este en un archivo de texto)*/

using System;
using System.IO;
public class Program
{
    public static void Main()
    {
        // Selector de control de mi menu
        int opc = 0;
        StreamWriter writer = null;
        int filas=0,columnas=0;
        int[,] matriz = new int[0,0];
        int[] array= new int[0];
        // Desplegar el menu
        do
        {
            Console.Clear();
            Console.WriteLine("MATRICES");
            Console.WriteLine("-----------------------");
            Console.WriteLine("1. DEFINIR TAMAÑO DE LA MATRIZ");
            Console.WriteLine("2. RELLENAR MATRIZ ALEATORIAMENTE");
            Console.WriteLine("3. COPIAR MATRIZ A UN ARREGLO");
            Console.WriteLine("4. IMPRIMIR EN UN ARCHIVO LA MATRIZ");
            Console.WriteLine("5. IMPRIMIR EN UN ARCHIVO EL ARRAY"); 
            Console.WriteLine("6. SALIR");
            Console.WriteLine("-----------------------");
            Console.WriteLine("INGRESE OPCION: ");
            opc= Convert.ToInt32(Console.ReadLine());
            
            //materializar el menu por medio de la estructura de control switch case
            switch (opc)
            {
                case 1:
                    
                    Console.WriteLine("Ingrese el tamaño de filas de la matriz: ");
                    filas =  int.Parse(Console.ReadLine());
                    Console.WriteLine("Ingrese el tamaño de columnas de la matriz");
                    columnas =  int.Parse(Console.ReadLine());
                    matriz = new int[filas,columnas];
                    break;
                case 2:
                    LlenaMatriz(matriz,filas,columnas);
                    array = new int[filas*columnas];
                    break;
                case 3:
                    CopiarMatriz(matriz,array,filas,columnas);
                    for (int i=1;i<=filas*columnas;i++) {
                        Console.WriteLine(array[i-1]);
                    }
                    break;
                case 4:
                    CreateFile(writer,"matriz");
                    WriteFile(writer,"matriz",matriz,array,filas,columnas);
                    ReadFile(writer,"matriz");
                    break;
                case 5:
                    CreateFile(writer,"arreglo");
                    WriteFile(writer,"arreglo",matriz,array,filas,columnas);
                    ReadFile(writer,"arreglo");
                    break; 
                case 6:
                    Console.WriteLine("Adios, gracias por usar el programa");
                    break;
                default:
                    Console.WriteLine("Opps algo salio mal, ingrese una opcion de nuevo");
                    break;
            }
            Console.ReadKey();
        } while (opc!=6);
    }
    //methods 
    public static void LlenaMatriz(int[,]matriz,int filas, int columnas){
        int i;
			int j;
			Random azar = new Random();
			for (i=1;i<=filas;i++) {
				for (j=1;j<=columnas;j++) {
					matriz[i-1,j-1] = azar.Next(0,10);
				}
			}
    }
    public static void CopiarMatriz(int[,] matriz, int[] array, int filas, int columnas){
        int i;
			int j;
			int salto;
			salto = 0;
			for (i=1;i<=filas;i++) {
				for (j=1;j<=columnas;j++) {
					array[j+salto-1] = matriz[i-1,j-1];
				}
				salto = salto+columnas;
			}
    }
    public static void CreateFile(StreamWriter writer, string nombre){
        File.Delete("./"+nombre+".txt");
        writer = new StreamWriter("./"+nombre+".txt");
        writer.Close();
        Console.WriteLine("File was created suscessfully");
    }
    public static void WriteFile(StreamWriter writer, string nombre, int[,]matriz,int[] array, int filas,int columnas){
        writer = new StreamWriter("./"+nombre+".txt");
        if (nombre =="matriz")
        {
            for (int i = 0; i < matriz.GetLength(0); i++) // filas 
            {
                for (int j = 0; j < matriz.GetLength(1); j++) // columnas
                {
                    writer.Write(matriz[i,j] + "\t");
                }
                writer.WriteLine("");
            }
        }else
        {
             for (int i=1;i<=filas*columnas;i++) {
                        writer.WriteLine(array[i-1]);
                    }
        }
        writer.Close();
        Console.WriteLine("File was upgrade suscessfully");
    }
    public static void ReadFile(StreamWriter writer,string nombre){
       StreamReader reader = new StreamReader("./"+nombre+".txt");
       do
        {
            Console.WriteLine(reader.ReadLine());
        }
        while(reader.Peek()!= -1);
        
    } 
}