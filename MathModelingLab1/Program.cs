using System;

namespace MathModelingLab1
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Задача 1");
			int max_price = 140;
			int max_square = 200;

			int Am = Math.Min(max_price / 6, max_square / 4);
			int Bm = Math.Min(max_price / 2, max_square / 6);
			int Cm = Math.Min(max_price / 4, max_square / 5);
			int Dm = Math.Min(max_price / 2, max_square / 9);

			int[] result1 = new int[4] { 0, 0, 0, 0 };

			Console.WriteLine("Максимальная стоимость: " + max_price);
			Console.WriteLine("Максимальная площадь: " + max_square);
			Console.WriteLine("Повышение производительности: 8, 5, 3, 5");
			Console.WriteLine("Стоимость единицы оборудования, тыс. руб.: 6, 2, 4, 2");
			Console.WriteLine("Площадь под единицу оборудования, м2: 4, 6, 5, 9");
			Console.WriteLine("Расчет:");

			for (int a = 0; a < Am; a++)
				for (int b = 0; b < Bm; b++)
					for (int c = 0; c < Cm; c++)
						for (int d = 0; d < Dm; d++)
						{
							if (MainFunction1(result1[0], result1[1], result1[2], result1[3]) < MainFunction1(a, b, c, d)
								&& GetPrice(a, b, c, d) <= max_price
								&& GetSquare(a, b, c, d) <= max_square)
							{
								result1[0] = a; result1[1] = b; result1[2] = c; result1[3] = d;
							}
						}

			Console.WriteLine($"Значения A, B, C, D: {result1[0]}, {result1[1]}, {result1[2]}, {result1[3]}");
			Console.WriteLine($"Повышение производительности: {MainFunction1(result1[0], result1[1], result1[2], result1[3])}");
			Console.WriteLine($"Общая стоимость: {GetPrice(result1[0], result1[1], result1[2], result1[3])}");
			Console.WriteLine($"Общая площадь: {GetSquare(result1[0], result1[1], result1[2], result1[3])}");
            Console.WriteLine();

			Console.WriteLine("Задача 2:");

			int max_hh_1 = 330;
			int max_hh_2 = 200;
			int max_hh_3 = 370;

			Console.WriteLine($"Трудоемкость 1: {max_hh_1}, 2: {max_hh_2}, 3: {max_hh_3}");
			Console.WriteLine($"Затраты человек-дней на товар 1 подразделениями 1 - 1, 2 - 1, 3 - 1");
			Console.WriteLine($"Затраты человек-дней на товар 2 подразделениями 1 - 2, 2 - 2, 3 - 3");
			Console.WriteLine("Расчет:");

			int max_x1 = max_hh_1 / 1 + max_hh_2 / 1 + max_hh_3 / 2;
			int max_x2 = max_hh_1 / 2 + max_hh_2 / 3 + max_hh_3 / 3;

			int[] result2 = new int[2] { 0, 0 };

			for (int x1 = 0; x1 < max_x1; x1++)
				for (int x2 = 0; x2 < max_x2; x2++)
				{
					if (MainFunction2(result2[0], result2[1]) < MainFunction2(x1, x2)
							&& GetHumanDays1(x1, x2) <= max_hh_1
							&& GetHumanDays2(x1, x2) <= max_hh_2
							&& GetHumanDays3(x1, x2) <= max_hh_3)
					{
						result2 = new int[2] { x1, x2 };
					}
				}

			Console.WriteLine($"Количество товара 1: {result2[0]}, Количество товара 2: {result2[1]}");
			Console.WriteLine($"Прибыль: {MainFunction2(result2[0], result2[1])} тыс. руб.");
            Console.WriteLine($"Количество человек-дней в группах: 1 - {GetHumanDays1(result2[0], result2[1])}, 2 - {GetHumanDays2(result2[0], result2[1])}, 3 - {GetHumanDays3(result2[0], result2[1])}");
			Console.WriteLine();

            Console.WriteLine("Задача 3:");
			int min_fats = 800;
			int min_prot = 700;
			int min_carb = 900;

			int[] feed1 = { 330, 170, 380 };
			int[] feed2 = { 240, 200, 440 };
			int[] feed3 = { 300, 110, 370 };
            Console.WriteLine("\t\tA\tB\tC\tМинимальные значения");
			Console.WriteLine($"Жиры\t\t{feed1[0]}\t{feed2[0]}\t{feed3[0]}\t{min_fats}");
			Console.WriteLine($"Белки\t\t{feed1[1]}\t{feed2[1]}\t{feed3[1]}\t{min_prot}");
			Console.WriteLine($"Углеводы\t{feed1[2]}\t{feed2[2]}\t{feed3[2]}\t{min_carb}");
			Console.WriteLine($"Цена\t\t{31}\t{23}\t{20}");
			int[] min_feed1 = { 330, 170, 380 };
			int min_feed1_count = 0;
			while (min_feed1[0] < min_fats
				|| min_feed1[1] < min_prot
				|| min_feed1[2] < min_carb)
			{
				min_feed1 = SumFeedNutrition(min_feed1, feed1);
				min_feed1_count += 1;
			}

			int[] min_feed2 = { 330, 170, 380 };
			int min_feed2_count = 0;
			while (min_feed2[0] < min_fats
				|| min_feed2[1] < min_prot
				|| min_feed2[2] < min_carb)
			{
				min_feed2 = SumFeedNutrition(min_feed2, feed2);
				min_feed2_count += 1;
			}

			int[] min_feed3 = { 330, 170, 380 };
			int min_feed3_count = 0;
			while (min_feed3[0] < min_fats
				|| min_feed3[1] < min_prot
				|| min_feed3[2] < min_carb)
			{
				min_feed3 = SumFeedNutrition(min_feed3, feed3);
				min_feed3_count += 1;
			}

			int[] result3 = new int[3] { min_feed1_count, min_feed2_count, min_feed3_count }; 
			for (int i = 0; i < min_feed1_count; i++)
				for (int j = 0; j < min_feed2_count; j++)
					for (int k = 0; k < min_feed3_count; k++)
					{
						var feed_nutrition = GetFeedNutrition(k, i, j);
						if (MainFunction3(k, i, j) < MainFunction3(result3[0], result3[1], result3[2])
							&& feed_nutrition[0] >= min_fats
							&& feed_nutrition[1] >= min_prot
							&& feed_nutrition[2] >= min_carb)
						{
							result3 = new int[] { k, i, j };
						}
					}
            Console.WriteLine($"Кол-во кг комбикорма №1: {result3[0]}, №2: {result3[1]}, №3: {result3[2]}");
			Console.WriteLine($"Итоговая стоимость: {MainFunction3(result3[0], result3[1], result3[2])}");
			var result3_nutrition = GetFeedNutrition(result3[0], result3[1], result3[2]);
			Console.WriteLine($"Итоговое содержание жиров: {result3_nutrition[0]}, белков: {result3_nutrition[1]}, углеводов: {result3_nutrition[2]}");

		}
		public static int MainFunction1(int A, int B, int C, int D)
		{
			return 8 * A + 5 * B + 3 * C + 5 * D;
		}
		public static int GetPrice(int A, int B, int C, int D)
		{
			return 6 * A + 2 * B + 4 * C + 2 * D;
		}
		public static int GetSquare(int A, int B, int C, int D)
		{
			return 4 * A + 6 * B + 5 * C + 9 * D;
		}
		public static int MainFunction2(int x1, int x2)
		{
			return 12 * x1 + 4 * x2;
		}
		public static int GetHumanDays1(int x1, int x2)
		{
			return x1 + 2 * x2;
		}
		public static int GetHumanDays2(int x1, int x2)
		{
			return x1 + 3 * x2;
		}
		public static int GetHumanDays3(int x1, int x2)
		{
			return 2 * x1 + 3 * x2;
		}
		public static int MainFunction3(int a, int b, int c)
		{
			return 31 * a + 23 * b + 20 * c;
		}
		public static int[] SumFeedNutrition(int[] feed1, int[] feed2)
		{
			int[] result = new int[3] { feed1[0] + feed2[0],
				feed1[1] + feed2[1],
				feed1[2] + feed2[2]};
			return result;
		}
		public static int[] GetFeedNutrition(int a, int b, int c) 
		{
			var result = SumFeedNutrition(new int[] { a * 330, a * 170, a * 380 },
				SumFeedNutrition(new int[] { b * 240, b * 200, b * 440 },
					new int[] { c * 300, c * 110, c * 370 }));
			return result;
				
		}
	}
}
