using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _21_Backtrack_2_0
{
	internal class Program
	{
		static bool Vane(List<int> lista, int sum, int i = 0)
		{
			// kilépési feltételek
			bool siker = sum == 0;
			bool reménytelen = sum < 0;
			bool levél = i == lista.Count;

			if (siker)
				return true;

			if (reménytelen)
				return false;

			if (levél)
				return false;

			// rekurzív rész -- a probléma visszavezetése kisebb problémárav VÉGIGPRÓBÁLGATÁS

			// ha beveszem az i-edik elemet a kiválasztott részhalmazba
			if (Vane(lista, sum - lista[i], i + 1))
			{
				return true;
			}
			
			// ha nem veszem be az i-edik elemet a kiválasztott részhalmazba
			if (Vane(lista, sum, i + 1))
			{
				return true;
			}
			return false;

			// itt látszik a végigpróbálgatásban a ciklus. Később ilyenek lesznek a backtrackek! kicseréli a felső két elágazást.
			for (int j = 0; j < 2; j++)
			{
				if (Vane(lista, sum - j*lista[i], i + 1))
				{
					return true;
				}
			}
			return false;

		}

		static int[] elso_megoldas;
		static bool Első(List<int> lista, int sum, int i = 0)
		{
			// kilépési feltételek
			bool siker = sum == 0;
			bool reménytelen = sum < 0;
			bool levél = i == lista.Count;

			if (siker)
				return true;

			if (reménytelen)
				return false;

			if (levél)
				return false;

			// rekurzív rész -- a probléma visszavezetése kisebb problémárav VÉGIGPRÓBÁLGATÁS

			// ha beveszem az i-edik elemet a kiválasztott részhalmazba
			if (Első(lista, sum - lista[i], i + 1))
			{
				elso_megoldas[i] = 1;
				return true;
			}

			// ha nem veszem be az i-edik elemet a kiválasztott részhalmazba
			if (Első(lista, sum, i + 1))
			{
				elso_megoldas[i] = 0;
				return true;
			}
			return false;

			// itt látszik a végigpróbálgatásban a ciklus. Később ilyenek lesznek a backtrackek! kicseréli a felső két elágazást.
			for (int j = 0; j < 2; j++)
			{
				if (Vane(lista, sum - j * lista[i], i + 1))
				{
					elso_megoldas[i] = j;
					return true;
				}
			}
			return false;

		}

		static List<int[]> osszes_megoldas;
		static int[] akt_mo;
		static void Összes(List<int> lista, int sum, int i = 0)
		{
			// kilépési feltételek
			bool siker = sum == 0;
			bool reménytelen = sum < 0;
			bool levél = i == lista.Count;

			if (siker)

				return;

			if (reménytelen)
				return;

			if (levél)
				return;

			// rekurzív rész -- a probléma visszavezetése kisebb problémárav VÉGIGPRÓBÁLGATÁS

			// ha beveszem az i-edik elemet a kiválasztott részhalmazba
			if (Első(lista, sum - lista[i], i + 1))
			{
				elso_megoldas[i] = 1;
				return ;
			}

			// ha nem veszem be az i-edik elemet a kiválasztott részhalmazba
			if (Első(lista, sum, i + 1))
			{
				elso_megoldas[i] = 0;
				return ;
			}


			//// itt látszik a végigpróbálgatásban a ciklus. Később ilyenek lesznek a backtrackek! kicseréli a felső két elágazást.
			//for (int j = 0; j < 2; j++)
			//{
			//	if (Vane(lista, sum - j * lista[i], i + 1))
			//	{
			//		elso_megoldas[i] = j;
			//		return true;
			//	}
			//}
			//return false;

		}

		static void Main(string[] args)
		{
			List<int> lista = new List<int> { 3, 6, 8, 2, 4, 2, 7, 9 };
			//Console.WriteLine(Vane(lista, 20));
			elso_megoldas = new int[lista.Count];

			Console.WriteLine(Első(lista, 20));
			Console.WriteLine(string.Join(", ", elso_megoldas));

			Console.ReadKey();
        }
	}
}
