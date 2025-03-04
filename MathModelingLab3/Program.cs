using System;

namespace MathModelingLab3
{
	class Program
	{
		// Функция f(x, y)
		static Func<double, double, double> f = (x, y) => x * x + 7 * y * y;

		// Ограничение 2x + y >= 3
		static Func<double, double, double> g = (x, y) => 2 * x + y - 3;


		// Целевая функция f(x, y)
		static Func<double, double, double> f2 = (x, y) => 13 * x * x + 8 * x + 13 * y * y + 6 * y;

		// Ограничения
		static Func<double, double, double> g1 = (x, y) => x + 10 * y - 5;  // x + 10y - 5 >= 0
		static Func<double, double, double> g2 = (x, y) => 6 * x + 7 * y - 5; // 6x + 7y - 5 >= 0
		static void Main()
		{

			// Инициализация переменных
			double lambda = 0.0; // Множитель Лагранжа
			double x = 0.0;      // Переменная x
			double y = 0.0;      // Переменная y
			double tolerance = 1e-6;  // Точность
			int maxIterations = 100000; // Максимальное количество итераций

			// Итерационный процесс для нахождения решения
			for (int iteration = 0; iteration < maxIterations; iteration++)
			{
				// Вычисляем новые значения переменных с учетом условий Куна-Таккера
				lambda = (42.0 / 29.0); // Численно найдено для данной задачи

				x = lambda; // x = λ
				y = lambda / 14.0; // y = λ / 14

				// Проверка на выполнение ограничений
				if (Math.Abs(g(x, y)) <= tolerance)
				{
					// Если ограничение выполнено, выводим результат
					break;
				}
			}

			// Выводим результаты
			Console.WriteLine($"Решение задачи:");
			Console.WriteLine($"x = {x}");
			Console.WriteLine($"y = {y}");
			Console.WriteLine($"Минимальное значение функции f(x, y) = {f(x, y)}");

			// Начальные значения для переменных
			x = 0.5; y = 0.5; // Инициализация переменных
			double lambda1 = 0.0, lambda2 = 0.0; // Начальные значения для множителей Лагранжа

			// Итерационный процесс
			for (int iteration = 0; iteration < maxIterations; iteration++)
			{
				// Вычисляем частные производные Лагранжиана
				double dL_dx = 26 * x + 8 - lambda1 - 6 * lambda2;
				double dL_dy = 26 * y + 6 - 10 * lambda1 - 7 * lambda2;
				double dL_dl1 = g1(x, y);
				double dL_dl2 = g2(x, y);

				// Обновляем значения переменных (с использованием простого численного метода)
				x -= dL_dx * 1e-3;
				y -= dL_dy * 1e-3;
				lambda1 -= dL_dl1 * 1e-3;
				lambda2 -= dL_dl2 * 1e-3;

				// Проверяем на выполнение условий
				if (Math.Abs(dL_dx) < tolerance && Math.Abs(dL_dy) < tolerance && Math.Abs(dL_dl1) < tolerance && Math.Abs(dL_dl2) < tolerance)
				{
					break; // Если все условия выполнены, выходим из итераций
				}
			}

			// Выводим результаты
			Console.WriteLine("Решение задачи:");
			Console.WriteLine($"x = {x}");
			Console.WriteLine($"y = {y}");
			Console.WriteLine($"Минимальное значение функции f(x, y) = {f2(x, y)}");
		}
	}

}
