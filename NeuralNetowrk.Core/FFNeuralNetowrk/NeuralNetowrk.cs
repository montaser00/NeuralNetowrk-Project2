using MultiClassNNClassifier.ActivationFunctions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetowrk.Core.FFNeuralNetowrk
{
    public class NeuralNetowrk
    {
        public double LearningRate { get; set; }
        public double SSE { get; set; }
        public List<Neuron> InputLayer { get; set; }
        public List<Neuron> HiddenLayer { get; set; }
        public List<Neuron> OutputLayer { get; set; }
        public IActivationFunction ActivationFunction { get; set; }
        public int Epoch { get; set; }
        public bool Trained { get; set; }
        public NeuralNetowrk(
            int numberOfInputNeurons,
            int numberOfHiddenNeurons,
            int numberOfOutputNeurons,
            double learningRate
            )
        {
            LearningRate = learningRate;

            InputLayer = new List<Neuron>();
            HiddenLayer = new List<Neuron>();
            OutputLayer = new List<Neuron>();

            InputLayer.AddRange(Enumerable.Range(0, numberOfInputNeurons)
                .Select(x => new Neuron()).ToList()
            );

            HiddenLayer.AddRange(Enumerable.Range(0, numberOfHiddenNeurons)
                .Select(x => new Neuron()).ToList()
            );

            OutputLayer.AddRange(Enumerable.Range(0, numberOfOutputNeurons)
                .Select(x => new Neuron()).ToList()
            );

            InputLayer.ForEach(inputNeuron =>
                HiddenLayer.ForEach(hiddenNeuron => inputNeuron.Links.Add(new Link(inputNeuron, hiddenNeuron, 0.04)))
            );

            HiddenLayer.ForEach(hiddenNeuron =>
                OutputLayer.ForEach(outputNeuron => hiddenNeuron.Links.Add(new Link(hiddenNeuron, outputNeuron, 0.03)))
            );

            ActivationFunction = new Tanh();
        }

        public void TrainIteration(double[] inputs, double[] outputs)
        {
            FeedInput(inputs);
            FeedOutput(outputs);
            ActivateHiddenLayer();
            ActivateOutputLayer();
            CalculateErrorAndGradientDecent();
            CalculateHiddenLayerWeightCorrections();
            CalculateGradientDecentAndThresholdForHiddenLayer();
            CalculateInputLayerWeightCorrections();
            UpdateWeights();
            UpdateThresholds();
            CalculateSumSquareError();
        }

        public void TrainEpoch(double[][] inputs, double[][] outputs)
        {
            for (int index = 0; index < inputs.Length; index++)
            {
                TrainIteration(inputs[index], outputs[index]);
            }
        }

        public void Train(double[][] inputs, double[][] outputs, double stopSSE, int maxEpochs, Action finishCallback)
        {
            for (int index = 0; index < maxEpochs; index++)
            {
                SSE = 0;
                TrainEpoch(inputs, outputs);
                if (SSE <= stopSSE)
                    break;
                finishCallback();
                Epoch = index;
            }

            Trained = true;
        }

        public double Predict(double[] input)
        {
            FeedInput(input);
            ActivateHiddenLayer();
            ActivateOutputLayer();

            var maxValue = OutputLayer.Max(x => x.YActual);
            var closestValue = OutputLayer.FindIndex(x => x.YActual == maxValue);

            return closestValue;
        }

        public void FeedInput(double[] inputs)
        {
            if (inputs.Length != InputLayer.Count)
                return;

            for (int i = 0; i < inputs.Length; i++)
                InputLayer[i].Input = inputs[i];
        }

        public void FeedOutput(double[] outputs)
        {
            if (outputs.Length != OutputLayer.Count)
                return;

            for (int i = 0; i < outputs.Length; i++)
                OutputLayer[i].YDesired = outputs[i];
        }

        public void ActivateHiddenLayer()
        {
            foreach (var hiddenNeuron in HiddenLayer)
            {
                var bigX = 0.0;
                var links = InputLayer.SelectMany(x => x.Links.Where(x => x.Output == hiddenNeuron));

                bigX += links.Sum(x => x.Weight * x.Source.Input) + hiddenNeuron.ThresholdSign * hiddenNeuron.Threshold;
                hiddenNeuron.YActual = ActivationFunction.Activate(bigX);
            }
        }

        public void ActivateOutputLayer()
        {
            foreach (var outputNeuron in OutputLayer)
            {
                var bigX = 0.0;
                var links = HiddenLayer.SelectMany(x => x.Links.Where(x => x.Output == outputNeuron));

                bigX += links.Sum(x => x.Weight * x.Source.YActual) + outputNeuron.ThresholdSign * outputNeuron.Threshold;
                outputNeuron.YActual = ActivationFunction.Activate(bigX);
            }
        }

        public void CalculateErrorAndGradientDecent()
        {
            foreach (var outputNeuron in OutputLayer)
            {
                outputNeuron.Error = outputNeuron.YDesired - outputNeuron.YActual;
                outputNeuron.GradientDecent = ActivationFunction.CalculateDerivative(outputNeuron.YActual) * outputNeuron.Error;
            }
        }

        public void CalculateHiddenLayerWeightCorrections()
        {
            foreach (var outputNeuron in OutputLayer)
            {
                var links = HiddenLayer.SelectMany(x => x.Links.Where(x => x.Output == outputNeuron));

                foreach (var link in links)
                {
                    link.DeltaWeight = LearningRate * link.Source.YActual * outputNeuron.GradientDecent;
                }
            }
        }

        public void CalculateGradientDecentAndThresholdForHiddenLayer()
        {
            foreach (var hiddenNeuron in HiddenLayer)
            {
                var affectToForwardNeurons = hiddenNeuron.Links.Sum(x => x.Weight * x.Output.GradientDecent);

                hiddenNeuron.GradientDecent = ActivationFunction.CalculateDerivative(hiddenNeuron.YActual) * affectToForwardNeurons;
                hiddenNeuron.DeltaThresold = LearningRate * hiddenNeuron.ThresholdSign * hiddenNeuron.GradientDecent;
            }
        }

        public void CalculateInputLayerWeightCorrections()
        {
            foreach (var hiddenNeuron in HiddenLayer)
            {
                var links = InputLayer.SelectMany(x => x.Links.Where(x => x.Output == hiddenNeuron));

                foreach (var link in links)
                {
                    link.DeltaWeight = LearningRate * link.Source.Input * hiddenNeuron.GradientDecent;
                }
            }
        }

        public void UpdateWeights()
        {
            InputLayer.ForEach(inputNeuron =>
            {
                inputNeuron.Links.ForEach(link => link.Weight = link.Weight + link.DeltaWeight);
            });

            HiddenLayer.ForEach(hiddenNeuron =>
            {
                hiddenNeuron.Links.ForEach(link => link.Weight = link.Weight + link.DeltaWeight);
            });
        }

        public void UpdateThresholds()
        {
            HiddenLayer.ForEach(hiddenNeuron =>
            {
                hiddenNeuron.Threshold = hiddenNeuron.Threshold + hiddenNeuron.DeltaThresold;
            });

            OutputLayer.ForEach(outputNeuron =>
            {
                outputNeuron.Threshold = outputNeuron.Threshold + outputNeuron.DeltaThresold;
            });
        }

        public void CalculateSumSquareError()
        {
            SSE += EvaluationFunctions.SSE.Calculate(OutputLayer.Select(x => x.Error).ToList());
        }
    }
}
