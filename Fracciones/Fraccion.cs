using System;
using System.Collections.Generic;
using System.Text;

namespace Programacion_Avanzada {
	class Fraccion {
		protected int Numerador, Denominador;
		protected int Entero;
		
		//Constructores
		public Fraccion() { }
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
		//Getters
		public int GetNumerador() { return Numerador; }
		public int GetDenominador() { return Denominador; }
		public void Simplificar() {
			for (int i = 2; i < Numerador * Denominador; i++) {
				if (Numerador % i == 0 && Denominador % i == 0) {
					Numerador /= i;
					Denominador /= i;
				}
			}
		}
		// Transforma  una fraccion impropia en una mixta 
		public void Mixto() {
			Entero = (int)(Numerador / Denominador);
			int temp = (int)(Numerador / Denominador);
			Numerador = (Numerador) - (Entero * Denominador);
		}

		public int getEntero() { return Entero; }
	};
}
