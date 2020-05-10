using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Programacion_Avanzada {
	//Calculadora de fracciones xd
	class Calculadora {
		List<Fraccion> fracciones;
		Fraccion resultado;

		public Calculadora() {
			this.fracciones = new List<Fraccion>();
		}
		public void Suma () {
			try {
				this.resultado = this.fracciones[0];
				List<Fraccion> tempList = new List<Fraccion>(this.fracciones);
				tempList.RemoveAt(0);

				foreach (Fraccion fraccion in tempList) {
					this.resultado = this.resultado.suma(fraccion);
				}
			} catch (ArgumentOutOfRangeException exc) {
				Console.WriteLine("No se ha ingresado ni una fraccion!");
			}
		}

		public void Resta () {
			try {
				this.resultado = this.fracciones[0];
				List<Fraccion> tempList = new List<Fraccion>(this.fracciones);
				tempList.RemoveAt(0);

				foreach (Fraccion fraccion in tempList) {
					this.resultado = this.resultado.resta(fraccion);
				}
			} catch (ArgumentOutOfRangeException exc) {
				Console.WriteLine("No se ha ingresado ni una fraccion!");
			}
			
		}
		public void Multiplicacion () {
			try {
				this.resultado = this.fracciones[0];
				List<Fraccion> tempList = new List<Fraccion>(this.fracciones);
				tempList.RemoveAt(0);

				foreach (Fraccion fraccion in tempList) {
					this.resultado = this.resultado.multiplicacion(fraccion);
				}
			} catch (ArgumentOutOfRangeException exc) {
				Console.WriteLine("No se ha ingresado ni una fraccion!");
			}
		}
		public void Division () {
			try {
				this.resultado = this.fracciones[0];
				List<Fraccion> tempList = new List<Fraccion>(this.fracciones);
				tempList.RemoveAt(0);

				foreach (Fraccion fraccion in tempList) {
					this.resultado = this.resultado.division(fraccion);
				}
			} catch (ArgumentOutOfRangeException exc) {
				Console.WriteLine("No se ha ingresado ni una fraccion!");
			}
		}

		public void añadirFraccion (Fraccion fraccion) {
			if (fraccion.GetDenominador() == 0) {
				Console.WriteLine("El denominador no puede ser 0 jamas!");
				return;
			} else {
				this.fracciones.Add(fraccion);
				Console.WriteLine("Se ha añadido la fraccion!");
			}
		}

		public void removerFraccion (int indice) {
			if (this.fracciones.Count <= 0) {
				Console.WriteLine("No se ha ingresado ni una fraccion!");
			} else 
				this.fracciones.RemoveAt(indice);
		}

		public void añadirFraccion(int numerador, int denominador) {
			if (denominador == 0) {
				Console.WriteLine("El denominador no puede ser 0 jamas!");
				return;
			} else {
				this.fracciones.Add(new Fraccion(numerador, denominador));
				Console.WriteLine("Se ha añadido la fraccion!");
			}
		}

		//para hacerlo misto xd
		//unsigned[(int)resultado*(resultado.denominador())]-(resultado.numerador()) / resultado.denominador()

		// Retorna la fraccion simplificada en una cadena de texto
		public string Simplificar(int x, int y) {
			string cadena = "";
			
			if (y == 0) { // Si la division da indeterminacino x/0
				cadena += "Indeterminacion " + x + "/0";
			} else if (x / y == 1) { // Si la division da 1
				cadena += "1";
			} else if (x == 0) {
				cadena += "0";
			} else if (x % y == 0) {// Buscando si numerador y denominador son divisible para simplificar entre sus valores
				if (x / y > 0)
				cadena += (x / y);
			} else if (y % x == 0) { // Buscando si denominador y numerador son divisible para simplificar entre sus valores
				if (((float)(x) / (float)(y)) > 0)
					cadena += (x / x) + "/" + (y / x);
			} else { // Dividiendo en mitades ambos numeros mientras no tengan residuo, division perfecta entre 2
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
		/*public void VerResultado() {
			int sim = 0;
			Console.WriteLine("Desea simplificar el resultado?\n1.-Si\n2.-No");
			sim = int.Parse(Console.ReadLine());

			switch (sim) {
				case 1: {
						if (this.resultado.getEntero() == 0) {
							Console.WriteLine("El resultado es: " + Simplificar(resultado.GetNumerador(), resultado.GetDenominador()));
						} else {
							string auxSimplif = "";
							// Para que no muestre como fraccion simplificada en fraccionn mixta
							if (resultado.GetNumerador() > 0 && resultado.GetDenominador() > 0) {
								auxSimplif = Simplificar(resultado.GetNumerador(), resultado.GetDenominador());
							}
							Console.WriteLine("El resultado es: " + resultado.getEntero() + " " + auxSimplif);
						}

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
		}*/

		public List<Fraccion> obtenerFracciones () {
			return this.fracciones;
		}

		public Fraccion getResultado () {
			return this.resultado;
		}

		 public void mostrarFracciones (bool mixto = false) {
			int index = 1;
			foreach (Fraccion fraccion in fracciones) {
				if (mixto) {
					Console.WriteLine($"Fraccion {index++}: {fraccion.Mixto()}");
				} else {
					Console.WriteLine($"Fraccion {index++}: {fraccion}");
				}
			}
		}
	};
}
