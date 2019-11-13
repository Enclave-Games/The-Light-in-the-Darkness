#include "linear_regression.h"

double LinearRegression::sigmoid(double weight) {
	return 1 / 1 + abs(exp(weight));
}

void LinearRegression::initWeight() 
{
	std::default_random_engine de((unsigned int)time(0));
	std::normal_distribution<double> normalDistribution(0, sigmoid(weights.size()));

	for (size_t i = 0; i < weights.size(); i++)
	{
		weights[i] = normalDistribution(de);
	}
	biasWeight = normalDistribution(de);
}