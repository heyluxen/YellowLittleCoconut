namespace CAI_Sln;

public class Helper()
{
    public void Menu()
    {
        int opcion;
        //Este do-while es para mantenerse en el menú hasta que la opción elegida sea para salir.
        do
        {
            Console.WriteLine("Bienvenido, Me hace el favor y coloca una de las siguientes opciones");
            Console.WriteLine("Opcion 1: Enteros");
            Console.WriteLine("Opcion 2: Strings");
            Console.WriteLine("Opcion 3: Arreglos");
            Console.WriteLine("Opcion 4: Me voy");

            //Lo siguiente es para leer la opción

            string input = Console.ReadLine();

            //Y este if es para que si no es un entero lo que entra entonces solo le diga que coloque una opción válida.

            if (int.TryParse(input, out opcion))
            {
                switch (opcion)
                {
                    case 1:
                        //enteros
                        break;
                    case 2: 
                        //strings
                        break;
                    default:
                        Console.WriteLine("Ingrese una opción del menú");
                }
            }

        } while (opcion != 4);
    }

    public void Enteros()
    {
        Console.WriteLine("Este es el menú de los enteros. Otra vez elija lo que quiera hacer");
        Console.WriteLine("Opcion 1: Sumar");
        Console.WriteLine("Opcion 2: Restar");
        Console.WriteLine("Opcion 3: Multiplicar");
        Console.WriteLine("Opcion 4: Dividir");
        Console.WriteLine("Opcion 5: Otra");
        Console.WriteLine("Opcion 6: Devolverse");
    }

    public void Strings()
    {
        Console.WriteLine("Este es el menú de strings. De nuevo ponga la opción que quiera.");
        Console.WriteLine("Opción 1: Concatenar");
        Console.WriteLine("Opción 2: Buscar");
        Console.WriteLine("Opción 3: Formato");
        Console.WriteLine("Opción 4: Devolverse");
    }
}