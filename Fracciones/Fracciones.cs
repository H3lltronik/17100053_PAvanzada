using System;
using System.Collections.Generic;
using System.Text;

namespace Programacion_Avanzada {
    class Fracciones {
		int num1, den1, num2, den2, op;
		public void menu () {
			do {
				//Ingresar valores de la primera fraccion
				Console.WriteLine("Ingrese el numerador de la fraccion 1");
				num1 = int.Parse(Console.ReadLine());

				Console.WriteLine("Ingrese el denominador de la fraccion 1");
				den1 = int.Parse(Console.ReadLine());

				//Ingresar valores de la segunda fraccion
				Console.WriteLine("Ingrese el numerador de la fraccion 2");
				num2 = int.Parse(Console.ReadLine());

				Console.WriteLine("Ingrese el denominador de la fraccion 2");
				den2 = int.Parse(Console.ReadLine());

				Console.Clear();

				Calculadora calculadora = new Calculadora(num1, den1, num2, den2);
				calculadora.Operacion();

				Console.WriteLine("Desea ingresar otros valores? \n1.-Si \n2.-No");
				op = int.Parse(Console.ReadLine());
			} while (op != 2);
		}
    }
}
