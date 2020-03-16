using System;
using System.Collections.Generic;
using System.Text;

namespace Programacion_Avanzada {
	//Calculadora de fracciones xd
	class Calculadora {
		Fraccion fraccion1, fraccion2, resultado;
		int x1, x2, y1, y2;
		public Calculadora(int num1, int den1, int num2, int den2) {
			fraccion1 = new Fraccion(num1, den1);
			fraccion2 = new Fraccion(num2, den2);
			resultado = new Fraccion();
			//Son los numeros originales que ingreso el usuario
			x1 = num1; x2 = num2;
			y1 = den1; y2 = den2;
			//Simplificar ecuaciones individualmente
			fraccion1.Simplificar();
			fraccion2.Simplificar();
		}
		public void Suma() {
			int tempNum = 0, tempDen = 0;
			/*
			Siendo las fraccion a/b + c/d = x/y
				x = (a*d)+(b*c)
				y = (d*b)
			*/
			tempNum = ((fraccion1.GetNumerador()) * (fraccion2.GetDenominador())) + ((fraccion1.GetDenominador() * (fraccion2.GetNumerador())));
			tempDen = fraccion1.GetDenominador() * (fraccion2.GetDenominador());
			resultado.SetValores(tempNum, tempDen);
			resultado.Mixto();
			VerResultado();
		}

		public void Resta() {
			int tempNum = 0, tempDen = 0;
			/*
			Siendo las fraccion a/b - c/d = x/y
				x = (a*d)-(b*c)
				y = (d*b)
			*/
			tempNum = ((fraccion1.GetNumerador()) * (fraccion2.GetDenominador())) - ((fraccion1.GetDenominador() * (fraccion2.GetNumerador())));
			tempDen = fraccion1.GetDenominador() * (fraccion2.GetDenominador());
			resultado.SetValores(tempNum, tempDen);
			resultado.Mixto();
			VerResultado();
		}
		public void Multiplicacion() {
			int auxX1 = fraccion1.GetNumerador(), auxX2 = fraccion2.GetNumerador(), auxY1 = fraccion1.GetDenominador(), auxY2 = fraccion2.GetDenominador();
			/*
			Siendo las fraccion a/b * c/d = x/y
				x = (a*c)
				y = (d*b)
			*/
			resultado.SetValores(auxX1 * auxX2, auxY1 * auxY2);
			resultado.Mixto();
			VerResultado();
		}
		public void Division() {
			int tempNum = 0, tempDen = 0;
			/*
			Siendo las fraccion a/b / c/d = x/y
				x = (a*d)
				y = (b*c)
			*/
			tempNum = ((fraccion1.GetNumerador()) * (fraccion2.GetDenominador()));
			tempDen = fraccion1.GetDenominador() * (fraccion2.GetNumerador());
			resultado.SetValores(tempNum, tempDen);
			resultado.Mixto();
			VerResultado();
		}

		public void Operacion() {
			int op;

			do {
				Console.WriteLine("Fraccion 1  = " + x1 + "/" + y1);
				Console.WriteLine("Fraccion 2  = " + x2 + "/" + y2 + "\n\n");

				Console.WriteLine("Que operacion desea realizar? \n1.- Suma\n2.- Resta\n3.- Multiplicacion\n4.- Division\n5.- Salir");
				op = int.Parse(Console.ReadLine());
				switch (op) {
					case 1: {
							Suma();
							Console.ReadKey(); // Pausa
							Console.Clear(); // Limpiar consola
							break;
						}
					case 2: {
							Resta();
							Console.ReadKey(); // Pausa
							Console.Clear();  // Limpiar consola
							break;
						}
					case 3: {
							Multiplicacion();
							Console.ReadKey(); // Pausa
							Console.Clear(); // Limpiar consola
							break;
						}
					case 4: {
							Division();
							Console.ReadKey(); // Pausa
							Console.Clear(); // Limpiar consola
							break;
						}
				}
			} while (op != 5);

		}

		public void LiberarMemoria() {
			fraccion1 = null;
			fraccion2 = null;
			resultado = null;
		}

		//para hacerlo misto xd
		//unsigned[(int)resultado*(resultado.denominador())]-(resultado.numerador()) / resultado.denominador()

		// Retorna la fraccion simplificada en una cadena de texto
		public string Simplificar(int x, int y) {
			string cadena = "";
			// Si la division da 1
			if (x / y == 1) {
				cadena += "1";
			// Buscando si numerador y denominador son divisible para simplificar entre sus valores
			} else if (x % y == 0) {
				cadena += (x / y);
			// Buscando si denominador y numerador son divisible para simplificar entre sus valores
			} else if (y % x == 0) {
				cadena += (x / x) + "/" + (y / x);
			// Dividiendo en mitades ambos numeros mientras no tengan residuo, division perfecta entre 2
			} else {
				while (x % 2 == 0 && y % 2 == 0) {
					x /= 2;
					y /= 2;
				}
				// Concatenar resultado de divisiones por 2
				cadena += x +  "/" + y;
			}
			return cadena;
		}

		//Aqui se simplifica el resultado de la operacion
		public void VerResultado() {
			int sim = 0;
			Console.WriteLine("Desea simplificar el resultado?\n1.-Si\n2.-No");
			sim = int.Parse(Console.ReadLine());

			switch (sim) {
				case 1: {
						if (this.resultado.getEntero() == 0) {
							Console.WriteLine("El resultado es: " + Simplificar(resultado.GetNumerador(), resultado.GetDenominador()));
						} else
							Console.WriteLine("El resultado es: " + resultado.getEntero() + " " + Simplificar(resultado.GetNumerador(), resultado.GetDenominador()));
							Console.WriteLine(" cuyo valor decimal es: " + ((float)resultado.GetNumerador() / (float)resultado.GetDenominador() + resultado.getEntero()) );
						break;
					}
				case 2: {
						if (resultado.getEntero() == 0) {
							Console.WriteLine("El resultado es: " + resultado.GetNumerador() + "/" + resultado.GetDenominador());
						} else
							Console.WriteLine("El resultado es: " + resultado.getEntero() + " " + resultado.GetNumerador() + "/" + resultado.GetDenominador());
						Console.WriteLine("cuyo valor decimal es: " + ((float)resultado.GetNumerador() / (float)resultado.GetDenominador() + resultado.getEntero()) );
						break;
					}
			}
		}
	};
}
