using System;
using System.Collections.Generic;
using System.Text;

namespace Programacion_Avanzada {
	class Fraccion {
		protected int Numerador, Denominador;
		
		//Constructores
		public Fraccion () {
			this.Numerador = 0;
			this.Denominador = 0;
		}
		public Fraccion(int _numerador, int _denominador) {
			Numerador = _numerador;
			Denominador = _denominador;
		}
		//Comprobar indeterminaciones
		public bool Indeterminacion() {
			if (Denominador == 0)
				return true;
			else
				return false;
		}
		//Asignar valores
		public void SetValores(int num, int den) {
			Numerador = num;
			Denominador = den;
		}

		// Operaciones
		public Fraccion suma (Fraccion sumando) {
			int newNumerador = (this.Numerador * sumando.Denominador) + (this.Denominador * sumando.Numerador);
			int newDenominador = sumando.Denominador * this.Denominador;

			return new Fraccion(newNumerador, newDenominador);
		}

		public Fraccion resta(Fraccion sumando) {
			int newNumerador = (this.Numerador * sumando.Denominador) - (this.Denominador * sumando.Numerador);
			int newDenominador = sumando.Denominador * this.Denominador;

			return new Fraccion(newNumerador, newDenominador);
		}

		public Fraccion multiplicacion(Fraccion sumando) {
			int newNumerador = this.Numerador * sumando.Numerador;
			int newDenominador = sumando.Denominador * this.Denominador;

			return new Fraccion(newNumerador, newDenominador);
		}

		public Fraccion division(Fraccion sumando) {
			int newNumerador = (this.Numerador * sumando.Denominador);
			int newDenominador = sumando.Numerador * this.Denominador;

			return new Fraccion(newNumerador, newDenominador);
		}
		//Getters
		public int GetNumerador() { return Numerador; }
		public int GetDenominador() { return Denominador; }
		public Fraccion Simplificar() {
			for (int i = 2; i < (Math.Abs(Numerador) * Math.Abs(Denominador)); i++) {
				if (Math.Abs(Numerador) % i == 0 && Math.Abs(Denominador) % i == 0) {
					Numerador /= i;
					Denominador /= i;
					i = 2;
				}
			}
			return this;
		}
		// Transforma  una fraccion impropia en una mixta 
		public String Mixto() {
			int Entero = 0;
			if (!Indeterminacion()) {
				if (Numerador < Denominador) {
					/*Console.WriteLine($"La fraccion {this} NO es una fraccion impropia.");
					Console.WriteLine($"Mostrando resultado en fraccion.");*/

					return this.ToString();
				} else {
					Entero = (int)(Numerador / Denominador);
					int temp = (int)(Numerador / Denominador);
					Numerador = (Numerador) - (Entero * Denominador);

					return $"{Entero} {Numerador}/{Denominador}";
				}
			}
			return $"Indeterminacion 0/0";
		}

		//public int getEntero() { return Entero; } 

		public override string ToString() {
			return $"{this.Numerador}/{this.Denominador}";
		}
	};
}
