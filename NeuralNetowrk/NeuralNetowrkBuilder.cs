using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NeuralNetowrk
{
    public partial class NeuralNetowrkBuilder : Form
    {
        private Thread TrainingThread { get; set; }
        private readonly string _fileDataSetName = "TrainingData/shapes_dataset.csv";
        private readonly string _testDataSetName = "TrainingData/shapes_training_set.csv";

        private double[][] Inputs { get; set; }
        private List<double[]> Labels { get; set; }
        private Dictionary<string, double> IndexesByLabel { get; set; }
        private Dictionary<double, string> LabelsByIndex { get; set; }

        public NeuralNetowrk.Core.FFNeuralNetowrk.NeuralNetowrk NeuralNetowrk { get; set; }

        public NeuralNetowrkBuilder()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NeuralNetowrk = new NeuralNetowrk.Core.FFNeuralNetowrk.NeuralNetowrk(
                int.Parse(InputNeuronsTextBox.Text),
                int.Parse(HiddenNeuronsTextBox.Text),
                int.Parse(OutputNeuronTextBox.Text),
                double.Parse(LearningRateTextBox.Text)
                );

            TrainButton.Enabled = true;
        }

        private void NeuralNetowrkBuilder_Load(object sender, EventArgs e)
        {
            var index = 1.0;
            var trainingLines = File.ReadAllLines(_fileDataSetName).Skip(1);
            var parsedDataSet = trainingLines.Select(line => line.Split(",").ToArray()).ToList();
            var indexedDataSet = parsedDataSet.GroupBy(x => x[2].Trim()).Select(x => new { Index = index++, Label = x.Key }).ToDictionary(x => x.Label, x => x.Index);

            IndexesByLabel = new Dictionary<string, double>();
            LabelsByIndex = new Dictionary<double, string>();
            Labels = new List<double[]>();

            indexedDataSet.ToList().ForEach(item =>
            {
                IndexesByLabel.Add(item.Key.Trim(), item.Value);
                LabelsByIndex.Add(item.Value, item.Key.Trim());
            });

            Inputs = parsedDataSet.Select(x => x.Take(2)).Select(item => item.Select(x => double.Parse(x) / 10).ToArray()).ToArray();

            Enumerable.Range(0, Inputs.Length).ToList().ForEach(index =>
            {
                double[] output = new double[3];
                double outputIndex = IndexesByLabel[parsedDataSet[index][2].Trim()];
                output[(int)outputIndex - 1] = outputIndex / 10;
                Labels.Add(output);
            });
        }

        private void TrainButton_Click(object sender, EventArgs e)
        {
            Action callback = () =>
            {
                EpochNumberLabel.Invoke(() => EpochNumberLabel.Text = NeuralNetowrk.Epoch.ToString());
                SSELabel.Invoke(() => SSELabel.Text = NeuralNetowrk.SSE.ToString());
            };

            TrainingThread = new Thread(() => NeuralNetowrk.Train(Inputs, Labels.ToArray(), double.Parse(SSETextBox.Text), int.Parse(MaxEpochsTextBox.Text), callback));
            TrainingThread.Start();
        }

        private void PredictionButton_Click(object sender, EventArgs e)
        {
            if (!NeuralNetowrk.Trained)
                return;

            if (string.IsNullOrEmpty(XInputTextBox.Text) || string.IsNullOrEmpty(YInputTextBox.Text))
                return;

            var input = new double[]
            {
                double.Parse(XInputTextBox.Text) / 10,
                double.Parse(YInputTextBox.Text) / 10
            };

            var prediction = NeuralNetowrk.Predict(input);
            PredictionLabel.Text = LabelsByIndex[prediction + 1];
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var lines = File.ReadAllLines(_testDataSetName).ToList();
            lines = lines.Skip(1).ToList();

            var parsedDataSet = lines.Select(line => line.Split(",").ToArray()).ToList();
            var labels = parsedDataSet.Select(x => x.Last()).ToList();
            var inputs = parsedDataSet.Select(x => x.Take(2)).Select(item => item.Select(x => double.Parse(x) / 10).ToArray()).ToArray();
            var index = 0;

            foreach (var input in inputs)
            {
                input[0] = input[0];
                input[1] = input[1];
                var prediction = NeuralNetowrk.Predict(input);
                var predicatedLabel = LabelsByIndex[prediction + 1];

                var passed = predicatedLabel.Trim() == labels[index].Trim() ? "Passed" : "Failed";
                string listboxItem = $"{input[0]}, {input[1]}: [{predicatedLabel}], [{passed}]";
                TestDataSetListBox.Items.Add(listboxItem);
                index++;
            }
        }
    }
}
