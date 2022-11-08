using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

using MyBank.Models;

namespace MyBank
{
    class Program
    {
        static async System.Threading.Tasks.Task Main(string[] args)
        {
            Console.WriteLine("Bienvenido a NGB");
            try
            {
                var Accounts = new ArrayList();
                Console.WriteLine("¿Que desea hacer?");
                var opcion = 1;
                List<BankAccount> cuentas = new List<BankAccount>();
                while (opcion > 0 && opcion < 5)
                {
                    var now = DateTime.Now;
                    Console.WriteLine(" 1 - Crear una cuenta\n 2 - Añadir dinero\n 3 - Sacar dinero\n 4 - Ver listado de operaciones\nOtro - Salir");
                    opcion = Convert.ToInt32(Console.ReadLine());
                    if (opcion == 1)
                    {
                        Console.WriteLine("Introduzca un nombre");
                        var nombre = Console.ReadLine();
                        Console.WriteLine("Nombre: " + nombre);
                        Console.WriteLine("Introduzca el balance inicial");
                        decimal balanceInicial = Convert.ToDecimal(Console.ReadLine());
                        while (balanceInicial < 0)
                        {
                            Console.WriteLine("Cantidad no válida debe ser >0\nIntroduzca una cantidad valida");
                            balanceInicial = Convert.ToDecimal(Console.ReadLine());
                        }
                        Console.WriteLine("Balance: " + balanceInicial);
                        cuentas.Add(new BankAccount(nombre, balanceInicial));
                        Console.WriteLine("Cuenta ID: " + cuentas[cuentas.Count - 1].Number + " Propietario: " + cuentas[cuentas.Count - 1].Owner + " Balance: " + cuentas[cuentas.Count - 1].Balance);
                    }
                    if (opcion == 2)
                    {
                        Console.WriteLine("Introduzca el ID de la cuenta");
                        int id = Convert.ToInt32(Console.ReadLine());
                        while (id > cuentas.Count)
                        {
                            Console.WriteLine("ID no válida, id max:" + cuentas.Count);
                            id = Convert.ToInt32(Console.ReadLine());
                        }
                        Console.WriteLine("Introduzca la cantidad que desea añadir");
                        decimal ingreso = Convert.ToDecimal(Console.ReadLine());
                        while (ingreso < 0)
                        {
                            Console.WriteLine("Cantidad no válida debe ser >0\nIntroduzca una cantidad valida");
                            ingreso = Convert.ToDecimal(Console.ReadLine());
                        }
                        Console.WriteLine("Introduzca el concepto");
                        var concepto = Console.ReadLine();
                        cuentas[id - 1].MakeDeposit(ingreso, DateTime.Now, concepto);
                        Console.WriteLine("")
    ;
                    }
                    if (opcion == 3)
                    {
                        Console.WriteLine("Introduzca el ID de la cuenta");
                        int id = Convert.ToInt32(Console.ReadLine());
                        while (id > cuentas.Count)
                        {
                            Console.WriteLine("ID no válida, id max:" + cuentas.Count);
                            id = Convert.ToInt32(Console.ReadLine());
                        }
                        Console.WriteLine("Introduzca la cantidad que desea retirar");
                        decimal ingreso = Math.Abs(Convert.ToDecimal(Console.ReadLine()));
                        Console.WriteLine("Introduzca el concepto");
                        var concepto = Console.ReadLine();
                        cuentas[id - 1].MakeWithdrawal(ingreso, DateTime.Now, concepto);
                        Console.WriteLine("");
                    }
                    if (opcion == 4)
                    {
                        Console.WriteLine("Introduzca el ID de la cuenta");
                        int id = Convert.ToInt32(Console.ReadLine());
                        while (id > cuentas.Count)
                        {
                            Console.WriteLine("ID no válida, id max:" + cuentas.Count);
                            id = Convert.ToInt32(Console.ReadLine());
                        }
                        Console.WriteLine(cuentas[id - 1].GetAccountHistory());
                        Console.WriteLine("");
                    }
                }
                //Transformar a json el fichero de 
                for (int i = 0; i < cuentas.Count; i++)
                {
                    cuentas[i].AccountHistoryJSON();
                }


            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine("ArgumentOutOfRangeException: " + e.ToString());
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine("InvalidOperationException: " + e.ToString());
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.ToString());
            }

        }
    }
}
