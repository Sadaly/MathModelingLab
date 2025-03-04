using System;

class RandomVariableModeling
{
	// 1. Равномерно распределенные величины на интервале (a, b)
	static double UniformRandomVariable(double z, double a, double b)
	{
		return (b - a) * z + a;
	}

	// 2. Экспоненциально распределенные величины
	static double ExponentialRandomVariable(double z, double lambda)
	{
		return -Math.Log(z) / lambda;
	}

	// 3. Распределение Релея
	static double RayleighRandomVariable(double z, double sigma)
	{
		return sigma * Math.Sqrt(-2 * Math.Log(z));
	}

	static void Main()
	{
		// Исходные данные
		double A = 6.2;
		double B = 23.4;
		double M = 98;
		int numValues = 100;

		// Массив случайных чисел y[i], где y[i] = (A * y[i-1] + B) % M
		double[] y = new double[numValues + 1]; // Индекс 0 не используется
		y[0] = 3;

		// Генерация случайных чисел
		for (int i = 1; i <= numValues; i++)
		{
			y[i] = (y[i - 1] * A + B) % M;
		}

		// Генерация случайных чисел z[i], равномерно распределенных на интервале (0,1)
		double[] z = new double[numValues];
		for (int i = 0; i < numValues; i++)
		{
			z[i] = y[i + 1] / (M - 1);
		}

		// Равномерное распределение на интервале (a, b)
		double a = 3, b = 7;
		double[] uniformly = new double[numValues];
		for (int i = 0; i < numValues; i++)
		{
			uniformly[i] = UniformRandomVariable(z[i], a, b);
		}

		// Показательное распределение с параметром лямбда
		double lambda = 8;
		double[] exponential = new double[numValues];
		for (int i = 0; i < numValues; i++)
		{
			exponential[i] = ExponentialRandomVariable(z[i], lambda);
		}

		// Распределение Релея с параметром сигма
		double sigma = 3;
		double[] rayleigh = new double[numValues];
		for (int i = 0; i < numValues; i++)
		{
			rayleigh[i] = RayleighRandomVariable(z[i], sigma);
		}

		// Вывод таблицы
		Console.WriteLine(new string('-', 112));
		Console.WriteLine($"|{"NN",3}|{"y",21}|{"z_i",20}|{$"Равномерно на [{a}, {b}]",18}|{"Показательное lmbd=" + lambda,18}|{"Закон Релея sigma=" + sigma,21}|");
		Console.WriteLine(new string('-', 112));

		for (int i = 0; i < numValues; i++)
		{
			Console.WriteLine($"|{i + 1,3}|{y[i + 1],20:F16} |{z[i],19:F16} | {uniformly[i],18:F16} | {exponential[i],18:F16} | {rayleigh[i],19:F16} |");
		}

		// 4. Нормальное распределение
		int n = 12;
		double nu = 1; // математическое ожидание
		double D = 9;  // дисперсия

		// Моделируем одну случайную величину по нормальному закону с математическим ожиданием nu и дисперсией D
		double x0 = Math.Sqrt(12.0 / n) * SumOfRandomVariables(z, n) - 0.5 * n; // стандартное нормальное распределение
		double x = Math.Sqrt(D) * x0 + nu; // нормальное распределение с заданными параметрами
		Console.WriteLine($"Нормально распределенная величина: {x}");
	}

	// Метод для вычисления суммы первых n случайных величин
	static double SumOfRandomVariables(double[] z, int n)
	{
		double sum = 0;
		for (int i = 0; i < n; i++)
		{
			sum += z[i];
		}
		return sum;
	}
}
