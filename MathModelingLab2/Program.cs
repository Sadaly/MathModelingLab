using MathNet.Numerics;
using System;

class Program
{
	static double[] MR = { 4, 5, 3, 5, 6 };

	static double[] sigma = { 7, 6, 4, 6, 7 };

	static int n = MR.Length;

	static double ComputeVariance(double[] weights)
	{
		double variance = 0;
		for (int i = 0; i < n; i++)
		{
			variance += weights[i] * weights[i] * sigma[i] * sigma[i];
		}
		return variance;
	}

	static double[] ComputeVarianceGradient(double[] weights)
	{
		double[] grad = new double[n];
		for (int i = 0; i < n; i++)
		{
			grad[i] = 2 * weights[i] * sigma[i] * sigma[i];
		}
		return grad;
	}

	static double[] ComputeConstraints(double[] weights)
	{
		double sumWeights = 0;
		double weightedMR = 0;

		for (int i = 0; i < n; i++)
		{
			sumWeights += weights[i];
			weightedMR += weights[i] * MR[i];
		}

		return new double[] { sumWeights - 1, weightedMR - 4 };
	}

	static double[] SolveOptimization()
	{
		double[] weights = new double[n];
		double[] lambda = { 0, 0 };
		double learningRate = 0.01;
		int maxIterations = 1000000;
		double tolerance = 1e-9;  

		for (int i = 0; i < n; i++)
		{
			weights[i] = 1.0 / n;
		}

		for (int iter = 0; iter < maxIterations; iter++)
		{
			double[] grad = ComputeVarianceGradient(weights);

			double[] constraints = ComputeConstraints(weights);
			double constraint1 = constraints[0];
			double constraint2 = constraints[1];

			for (int i = 0; i < n; i++)
			{
				grad[i] += lambda[0] * (1) + lambda[1] * MR[i];
			}

			for (int i = 0; i < n; i++)
			{
				weights[i] -= learningRate * grad[i];
			}

			lambda[0] += learningRate * constraint1;
			lambda[1] += learningRate * constraint2;

			if (Math.Abs(constraint1) < tolerance && Math.Abs(constraint2) < tolerance)
			{
				Console.WriteLine($"Конвергенция достигнута на итерации {iter + 1}");
				break;
			}

			if (iter % 1000 == 0)
			{
				Console.WriteLine($"Итерация {iter + 1}: Дисперсия = {ComputeVariance(weights)}");
			}
		}

		return weights;
	}

	static double ComputeWeightedExpectation(double[] weights)
	{
		double weightedMR = 0;
		for (int i = 0; i < n; i++)
		{
			weightedMR += weights[i] * MR[i];
		}
		return weightedMR;
	}
	static void Main(string[] args)
	{
		double d = 4;  
		double x1 = 2;  
		double tolerance = 1e-9; 
		double stepSize = 1e-5;  

		for (int iteration = 0; iteration < 9999999; iteration++)
		{
			double dFdx1 = -40 + 22 * x1;

			x1 -= stepSize * dFdx1;

			if (Math.Abs(dFdx1) < tolerance)
			{
				break;
			}


			if (iteration % 1000 == 0)
			{
				double x2 = d - x1; 
				double totalCost = CalculateTotalCost(x1, x2);
				Console.WriteLine($"Итерация {iteration}: x1 = {x1}, x2 = {x2}, Общие затраты = {totalCost}");
			}
		}

		x1 = Math.Round(x1);
		double x2_final = d - x1;
		double finalCost = CalculateTotalCost(x1, x2_final);
		Console.WriteLine($"Оптимальные значения: x1 = {x1}, x2 = {x2_final}");
		Console.WriteLine($"Общие затраты для оптимальных значений: {finalCost}");


		double[] optimalWeights = SolveOptimization();

		Console.WriteLine("Оптимальные веса:");
		for (int i = 0; i < n; i++)
		{
			Console.WriteLine($"w{i + 1}: {optimalWeights[i]}");
		}

		double variance = ComputeVariance(optimalWeights);
		Console.WriteLine($"Дисперсия для оптимальных весов: {variance}");

		double weightedExpectation = ComputeWeightedExpectation(optimalWeights);
		Console.WriteLine($"Сумма взвешенных математических ожиданий: {weightedExpectation}");

		if (Math.Abs(weightedExpectation - 4) < 1e-6)
		{
			Console.WriteLine("Сумма взвешенных математических ожиданий совпадает с 4.");
		}
		else
		{
			Console.WriteLine("Сумма взвешенных математических ожиданий не совпадает с 4.");
		}
	}


	static double CalculateTotalCost(double x1, double x2)
	{
		return 11 + 5 * x1 + 6 * x1 * x1 + 5 * x2 + 5 * x2 * x2;
	}
}
