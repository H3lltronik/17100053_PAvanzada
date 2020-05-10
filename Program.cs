using System;

namespace Programacion_Avanzada {
    class Program {
		static void Main(string[] args) {
			int op, numerador = 0, denominador = 0;
			Calculadora calculadora = new Calculadora();
			/*calculadora.añadirFraccion(new Fraccion(5, 6));
			calculadora.añadirFraccion(new Fraccion(34, 15));
			calculadora.añadirFraccion(new Fraccion(8, 3));*/
			do {
				Console.Clear();
				calculadora.mostrarFracciones(false);

				Console.WriteLine("\n1.- Añadir fraccion");
				Console.WriteLine("2.- Sumar fracciones");
				Console.WriteLine("3.- Restar fracciones");
				Console.WriteLine("4.- Multiplicar fracciones");
				Console.WriteLine("5.- Dividir fracciones");
				Console.WriteLine("6.- Remover fraccion");
				Console.WriteLine("7.- Salir");
				op = readNumber();

				switch (op) {
					case 1: {
							Console.WriteLine("Numerador de la nueva faccion");
							numerador = readNumber();
							Console.WriteLine("Denominador de la nueva faccion");
							denominador = readNumber();
							calculadora.añadirFraccion(new Fraccion(numerador, denominador));

							Console.ReadKey();
							break;
					}
					case 2: {
							calculadora.Suma();
							var result = calculadora.getResultado();
							int mixto = 0;
							if (result != null) {
								mixto = askMixto();
								verResult(result, mixto);
							} else {
								Console.WriteLine("Hubo un error al hacer la operacion!");
							}

							Console.ReadKey();
							break;
					}
					case 3: {
							calculadora.Resta();
							var result = calculadora.getResultado();
							int mixto = 0;
							if (result != null) {
								mixto = askMixto();
								verResult(result, mixto);
							} else {
								Console.WriteLine("Hubo un error al hacer la operacion!");
							}

							Console.ReadKey();
							break;
					}
					case 4: {
							calculadora.Multiplicacion();
							var result = calculadora.getResultado();
							int mixto = 0;
							if (result != null) {
								mixto = askMixto();
								verResult(result, mixto);
							} else {
								Console.WriteLine("Hubo un error al hacer la operacion!");
							}

							Console.ReadKey();
							break;
					}
					case 5: {
							calculadora.Division();
							var result = calculadora.getResultado();
							int mixto = 0;
							if (result != null) {
								mixto = askMixto();
								verResult(result, mixto);
							} else {
								Console.WriteLine("Hubo un error al hacer la operacion!");
							}

							Console.ReadKey();
							break;
					}
					case 6: {
							Console.Clear();
							if (calculadora.obtenerFracciones ().Count <= 0 ) {
								Console.WriteLine("No se ha ingresado ni una fraccion!");
								Console.ReadKey();
							} else {
								Console.WriteLine("¿Que fraccion desea remover? Ingrese el numero de la fraccion:  (Ej: 1; 0 -> Regresar)");
								calculadora.mostrarFracciones();
								int remIndex = readNumber();
								if (remIndex == 0)
									break;
								calculadora.removerFraccion(remIndex - 1);
							}

							break;
					}
				}
				
			} while (op != 7);
		}

		static int askMixto () {
			Console.WriteLine("¿Desea ver el resultado como fraccion mixta?");
			Console.WriteLine("1.- Si");
			Console.WriteLine("2.- No");
			return readNumber();
		}

		static void verResult (Fraccion result, int mixto) {
			if (mixto == 1) {
				Console.WriteLine("El resultado es: {0}", result.Simplificar().Mixto());
			} else {
				Console.WriteLine("El resultado es: {0}", result.Simplificar());
			}
		}

		static int readNumber () {
			try {
				return int.Parse(Console.ReadLine());
			} catch (FormatException exc) {
				Console.WriteLine("Se ingreso un numero valido");
				return -1;
			}
		}
    }
}
