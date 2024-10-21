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
			//for (int j = 0; j < 2; j++)
			//{
			//	if (Vane(lista, sum - j*lista[i], i + 1))
			//	{
			//		return true;
			//	}
			//}
			//return false;

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

		static List<int[]> osszes_megoldas;
		static int[] akt_mo;
		static void Összes(List<int> lista, int sum, int i = 0)
		{
			// kilépési feltételek
			bool siker = sum == 0;
			bool reménytelen = sum < 0;
			bool levél = i == lista.Count;

			if (siker)
			{
				osszes_megoldas.Add(akt_mo.ToArray()); // ToArray nagyon fontos! futtassuk le nélküle és csodálkozzunk!
				return;
			}

			if (reménytelen)
				return;

			if (levél)
				return;

			// rekurzív rész -- a probléma visszavezetése kisebb problémárav VÉGIGPRÓBÁLGATÁS

			// ha beveszem az i-edik elemet a kiválasztott részhalmazba
			//akt_mo[i] = 1;
			//Összes(lista, sum - lista[i], i + 1);

			//// ha nem veszem be az i-edik elemet a kiválasztott részhalmazba
			//akt_mo[i] = 0;
			//Összes(lista, sum, i + 1);


			//// itt látszik a végigpróbálgatásban a ciklus. Később ilyenek lesznek a backtrackek! kicseréli a felső két elágazást.
			for (int j = 1; j >= 0; j--)
			{
				akt_mo[i] = j;
				Összes(lista, sum - j * lista[i], i + 1);
			}
		}

		static int[] legjobb_megoldas;
		static bool defined; // használunk egy ilyet: Ez pontosan akkor lesz igaz, ha találtunk már valaha akármilyen megoldást.
		// static int[] akt_mo; // fent már deklarálva van...

		static void Legjobb(List<int> lista, int sum, int i = 0)
		{
			// kilépési feltételek
			bool siker = sum == 0;
			bool reménytelen = sum < 0 || (defined && legjobb_megoldas.Sum() <= akt_mo.Sum());
			bool levél = i == lista.Count;

			if (siker)
			{
				if (!defined || akt_mo.Sum() < legjobb_megoldas.Sum())  // ha A akkor B == -a V b
				{
					legjobb_megoldas = akt_mo.ToArray();
					defined = true;
				}
				return;
			}

			if (reménytelen)
				return;

			if (levél)
				return;

			// rekurzív rész -- a probléma visszavezetése kisebb problémárav VÉGIGPRÓBÁLGATÁS

			// ha beveszem az i-edik elemet a kiválasztott részhalmazba
			//akt_mo[i] = 1;
			//Összes(lista, sum - lista[i], i + 1);

			//// ha nem veszem be az i-edik elemet a kiválasztott részhalmazba
			//akt_mo[i] = 0;
			//Összes(lista, sum, i + 1);


			//// itt látszik a végigpróbálgatásban a ciklus. Később ilyenek lesznek a backtrackek! kicseréli a felső két elágazást.
			for (int j = 1; j >= 0; j--)
			{
				akt_mo[i] = j;
				Legjobb(lista, sum - j * lista[i], i + 1);
			}
		}


		static void Main(string[] args)
		{

			int x = 50;

			List<int> lista = new List<int> { 3, 6, 8, 2, 4, 2, 7, 9, 8, 4, 5, 3, 9, 6, 5, 8, 9 };
            Console.WriteLine(string.Join(", ", lista));
            //Console.WriteLine(Vane(lista, x));
            elso_megoldas = new int[lista.Count];
			Console.WriteLine(Első(lista, x));
			Console.WriteLine(string.Join(", ", elso_megoldas));

			osszes_megoldas = new List<int[]>(); // ebben lesznek a megoldások
			akt_mo = new int[lista.Count]; // ezt fogja használni  -- de ez igazából nem az eredmény része, ez csak egy -segédváltozó. Eleinte csupa nulla az egész tömb.
			Összes(lista, x); // ő fogja feltölteni
            Console.WriteLine("Összes megoldás");
			foreach (int[] mo in osszes_megoldas)
			{
                Console.WriteLine(string.Join(", ", mo));
            }

            Console.WriteLine("Legjobb megoldás:");
            defined = false;
			Legjobb(lista, x);
            Console.WriteLine(string.Join(", ", legjobb_megoldas));
			Console.WriteLine(string.Join(", ", lista));


			Console.ReadKey();
        }
	}
}
