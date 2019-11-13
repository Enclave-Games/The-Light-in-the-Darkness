#pragma once
#include <vector>
#include <iostream>
#include <cstdlib>
#include <cmath>
#include <random>
#include <time.h>
#include <fstream>
#include <iomanip>
#include <sstream>

using namespace std;

class LinearRegression
{
public:
	void initWeight();
	double activation(vector<double>& inputs);
	void train(vector<vector<double>>& inputs, vector<double>& expectOutput);

private:
	vector<double> weights;
	vector<double> accumulatedGradient;
	double biasWeight;
	double biasAccumulatedGradient;
	double initLearningRate;
	double sigmoid(double weight);
};