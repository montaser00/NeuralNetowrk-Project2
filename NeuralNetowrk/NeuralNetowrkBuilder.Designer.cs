namespace NeuralNetowrk
{
    partial class NeuralNetowrkBuilder
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            InputNeuronsTextBox = new TextBox();
            HiddenNeuronsTextBox = new TextBox();
            OutputNeuronTextBox = new TextBox();
            LearningRateTextBox = new TextBox();
            SSETextBox = new TextBox();
            MaxEpochsTextBox = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            button1 = new Button();
            label7 = new Label();
            label8 = new Label();
            TrainButton = new Button();
            SSELabel = new Label();
            EpochNumberLabel = new Label();
            XInputTextBox = new TextBox();
            YInputTextBox = new TextBox();
            PredictionButton = new Button();
            label9 = new Label();
            label10 = new Label();
            PredictionLabel = new Label();
            button2 = new Button();
            TestDataSetListBox = new ListBox();
            SuspendLayout();
            // 
            // InputNeuronsTextBox
            // 
            InputNeuronsTextBox.Enabled = false;
            InputNeuronsTextBox.Location = new Point(12, 54);
            InputNeuronsTextBox.Name = "InputNeuronsTextBox";
            InputNeuronsTextBox.Size = new Size(100, 23);
            InputNeuronsTextBox.TabIndex = 0;
            InputNeuronsTextBox.Text = "2";
            // 
            // HiddenNeuronsTextBox
            // 
            HiddenNeuronsTextBox.Location = new Point(12, 103);
            HiddenNeuronsTextBox.Name = "HiddenNeuronsTextBox";
            HiddenNeuronsTextBox.Size = new Size(100, 23);
            HiddenNeuronsTextBox.TabIndex = 1;
            HiddenNeuronsTextBox.Text = "5";
            // 
            // OutputNeuronTextBox
            // 
            OutputNeuronTextBox.Enabled = false;
            OutputNeuronTextBox.Location = new Point(12, 158);
            OutputNeuronTextBox.Name = "OutputNeuronTextBox";
            OutputNeuronTextBox.Size = new Size(100, 23);
            OutputNeuronTextBox.TabIndex = 2;
            OutputNeuronTextBox.Text = "3";
            // 
            // LearningRateTextBox
            // 
            LearningRateTextBox.Location = new Point(12, 212);
            LearningRateTextBox.Name = "LearningRateTextBox";
            LearningRateTextBox.Size = new Size(100, 23);
            LearningRateTextBox.TabIndex = 3;
            LearningRateTextBox.Text = "0.1";
            // 
            // SSETextBox
            // 
            SSETextBox.Location = new Point(322, 52);
            SSETextBox.Name = "SSETextBox";
            SSETextBox.Size = new Size(131, 23);
            SSETextBox.TabIndex = 4;
            SSETextBox.Text = "0.005";
            // 
            // MaxEpochsTextBox
            // 
            MaxEpochsTextBox.Location = new Point(322, 106);
            MaxEpochsTextBox.Name = "MaxEpochsTextBox";
            MaxEpochsTextBox.Size = new Size(131, 23);
            MaxEpochsTextBox.TabIndex = 5;
            MaxEpochsTextBox.Text = "150000";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(14, 36);
            label1.Name = "label1";
            label1.Size = new Size(83, 15);
            label1.TabIndex = 6;
            label1.Text = "Input Neurons";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(14, 84);
            label2.Name = "label2";
            label2.Size = new Size(94, 15);
            label2.TabIndex = 7;
            label2.Text = "Hidden Neurons";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 140);
            label3.Name = "label3";
            label3.Size = new Size(93, 15);
            label3.TabIndex = 8;
            label3.Text = "Output Neurons";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(14, 194);
            label4.Name = "label4";
            label4.Size = new Size(79, 15);
            label4.TabIndex = 9;
            label4.Text = "Learning Rate";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(322, 34);
            label5.Name = "label5";
            label5.Size = new Size(60, 15);
            label5.TabIndex = 10;
            label5.Text = "Goal (SSE)";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(322, 88);
            label6.Name = "label6";
            label6.Size = new Size(84, 15);
            label6.TabIndex = 11;
            label6.Text = "Max # of Epics";
            // 
            // button1
            // 
            button1.Location = new Point(14, 253);
            button1.Name = "button1";
            button1.Size = new Size(267, 23);
            button1.TabIndex = 12;
            button1.Text = "Build Neural Network";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(118, 58);
            label7.Name = "label7";
            label7.Size = new Size(144, 15);
            label7.TabIndex = 13;
            label7.Text = "Activation Function: TanH";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(118, 106);
            label8.Name = "label8";
            label8.Size = new Size(144, 15);
            label8.TabIndex = 14;
            label8.Text = "Activation Function: TanH";
            // 
            // TrainButton
            // 
            TrainButton.Enabled = false;
            TrainButton.Location = new Point(322, 135);
            TrainButton.Name = "TrainButton";
            TrainButton.Size = new Size(131, 23);
            TrainButton.TabIndex = 15;
            TrainButton.Text = "Train";
            TrainButton.UseVisualStyleBackColor = true;
            TrainButton.Click += TrainButton_Click;
            // 
            // SSELabel
            // 
            SSELabel.AutoSize = true;
            SSELabel.Location = new Point(322, 261);
            SSELabel.Name = "SSELabel";
            SSELabel.Size = new Size(31, 15);
            SSELabel.TabIndex = 16;
            SSELabel.Text = "SSE: ";
            // 
            // EpochNumberLabel
            // 
            EpochNumberLabel.AutoSize = true;
            EpochNumberLabel.Location = new Point(322, 236);
            EpochNumberLabel.Name = "EpochNumberLabel";
            EpochNumberLabel.Size = new Size(56, 15);
            EpochNumberLabel.TabIndex = 17;
            EpochNumberLabel.Text = "Epoch #: ";
            // 
            // XInputTextBox
            // 
            XInputTextBox.Location = new Point(509, 56);
            XInputTextBox.Name = "XInputTextBox";
            XInputTextBox.Size = new Size(100, 23);
            XInputTextBox.TabIndex = 18;
            // 
            // YInputTextBox
            // 
            YInputTextBox.Location = new Point(615, 56);
            YInputTextBox.Name = "YInputTextBox";
            YInputTextBox.Size = new Size(100, 23);
            YInputTextBox.TabIndex = 19;
            // 
            // PredictionButton
            // 
            PredictionButton.Location = new Point(509, 98);
            PredictionButton.Name = "PredictionButton";
            PredictionButton.Size = new Size(100, 23);
            PredictionButton.TabIndex = 20;
            PredictionButton.Text = "Predict";
            PredictionButton.UseVisualStyleBackColor = true;
            PredictionButton.Click += PredictionButton_Click;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(509, 38);
            label9.Name = "label9";
            label9.Size = new Size(14, 15);
            label9.TabIndex = 21;
            label9.Text = "X";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(615, 38);
            label10.Name = "label10";
            label10.Size = new Size(14, 15);
            label10.TabIndex = 22;
            label10.Text = "Y";
            // 
            // PredictionLabel
            // 
            PredictionLabel.AutoSize = true;
            PredictionLabel.Location = new Point(509, 139);
            PredictionLabel.Name = "PredictionLabel";
            PredictionLabel.Size = new Size(67, 15);
            PredictionLabel.TabIndex = 23;
            PredictionLabel.Text = "Prediction: ";
            // 
            // button2
            // 
            button2.Location = new Point(509, 169);
            button2.Name = "button2";
            button2.Size = new Size(100, 23);
            button2.TabIndex = 24;
            button2.Text = "Test Data Set";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // TestDataSetListBox
            // 
            TestDataSetListBox.FormattingEnabled = true;
            TestDataSetListBox.ItemHeight = 15;
            TestDataSetListBox.Location = new Point(509, 212);
            TestDataSetListBox.Name = "TestDataSetListBox";
            TestDataSetListBox.Size = new Size(173, 124);
            TestDataSetListBox.TabIndex = 25;
            // 
            // NeuralNetowrkBuilder
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(TestDataSetListBox);
            Controls.Add(button2);
            Controls.Add(PredictionLabel);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(PredictionButton);
            Controls.Add(YInputTextBox);
            Controls.Add(XInputTextBox);
            Controls.Add(EpochNumberLabel);
            Controls.Add(SSELabel);
            Controls.Add(TrainButton);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(button1);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(MaxEpochsTextBox);
            Controls.Add(SSETextBox);
            Controls.Add(LearningRateTextBox);
            Controls.Add(OutputNeuronTextBox);
            Controls.Add(HiddenNeuronsTextBox);
            Controls.Add(InputNeuronsTextBox);
            Name = "NeuralNetowrkBuilder";
            Text = "NeuralNetowrkBuilder";
            Load += NeuralNetowrkBuilder_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox InputNeuronsTextBox;
        private TextBox HiddenNeuronsTextBox;
        private TextBox OutputNeuronTextBox;
        private TextBox LearningRateTextBox;
        private TextBox SSETextBox;
        private TextBox MaxEpochsTextBox;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Button button1;
        private Label label7;
        private Label label8;
        private Button TrainButton;
        private Label SSELabel;
        private Label EpochNumberLabel;
        private TextBox XInputTextBox;
        private TextBox YInputTextBox;
        private Button PredictionButton;
        private Label label9;
        private Label label10;
        private Label PredictionLabel;
        private Button button2;
        private ListBox TestDataSetListBox;
    }
}