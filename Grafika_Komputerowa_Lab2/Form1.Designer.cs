
namespace Grafika_Komputerowa_Lab2
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.heightOfCutHScrollBar = new System.Windows.Forms.HScrollBar();
            this.heightOfCutLabel = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.predefinedNormalMap2Button = new System.Windows.Forms.Button();
            this.predefinedNormalMap1Button = new System.Windows.Forms.Button();
            this.setStandardNormalMap = new System.Windows.Forms.Button();
            this.setNormalMapButton = new System.Windows.Forms.Button();
            this.kHScrollBar = new System.Windows.Forms.HScrollBar();
            this.kLabel = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.predefinedTexture2Button = new System.Windows.Forms.Button();
            this.predefinedTexture1Button = new System.Windows.Forms.Button();
            this.setStaticColorButton = new System.Windows.Forms.Button();
            this.setTextureButton = new System.Windows.Forms.Button();
            this.NullifyLightsMovingButton = new System.Windows.Forms.Button();
            this.zLightHScrollBar = new System.Windows.Forms.HScrollBar();
            this.label1 = new System.Windows.Forms.Label();
            this.coloringComboBox = new System.Windows.Forms.ComboBox();
            this.coloringLabel = new System.Windows.Forms.Label();
            this.mHScrollBar = new System.Windows.Forms.HScrollBar();
            this.mLabel = new System.Windows.Forms.Label();
            this.ksHScrollBar = new System.Windows.Forms.HScrollBar();
            this.kdHScrollBar = new System.Windows.Forms.HScrollBar();
            this.ksLabel = new System.Windows.Forms.Label();
            this.kdLabel = new System.Windows.Forms.Label();
            this.changeLightsColorButton = new System.Windows.Forms.Button();
            this.lightsColorLabel = new System.Windows.Forms.Label();
            this.changeObjectsColorButton = new System.Windows.Forms.Button();
            this.objectsColorLabel = new System.Windows.Forms.Label();
            this.labelTriangulationAccuracy = new System.Windows.Forms.Label();
            this.triangulationAccuracyHScrollBar = new System.Windows.Forms.HScrollBar();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.colorDialog2 = new System.Windows.Forms.ColorDialog();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Cursor = System.Windows.Forms.Cursors.VSplit;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.pictureBox);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.heightOfCutHScrollBar);
            this.splitContainer1.Panel2.Controls.Add(this.heightOfCutLabel);
            this.splitContainer1.Panel2.Controls.Add(this.groupBox2);
            this.splitContainer1.Panel2.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel2.Controls.Add(this.NullifyLightsMovingButton);
            this.splitContainer1.Panel2.Controls.Add(this.zLightHScrollBar);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Panel2.Controls.Add(this.coloringComboBox);
            this.splitContainer1.Panel2.Controls.Add(this.coloringLabel);
            this.splitContainer1.Panel2.Controls.Add(this.mHScrollBar);
            this.splitContainer1.Panel2.Controls.Add(this.mLabel);
            this.splitContainer1.Panel2.Controls.Add(this.ksHScrollBar);
            this.splitContainer1.Panel2.Controls.Add(this.kdHScrollBar);
            this.splitContainer1.Panel2.Controls.Add(this.ksLabel);
            this.splitContainer1.Panel2.Controls.Add(this.kdLabel);
            this.splitContainer1.Panel2.Controls.Add(this.changeLightsColorButton);
            this.splitContainer1.Panel2.Controls.Add(this.lightsColorLabel);
            this.splitContainer1.Panel2.Controls.Add(this.changeObjectsColorButton);
            this.splitContainer1.Panel2.Controls.Add(this.objectsColorLabel);
            this.splitContainer1.Panel2.Controls.Add(this.labelTriangulationAccuracy);
            this.splitContainer1.Panel2.Controls.Add(this.triangulationAccuracyHScrollBar);
            this.splitContainer1.Size = new System.Drawing.Size(1198, 821);
            this.splitContainer1.SplitterDistance = 897;
            this.splitContainer1.TabIndex = 0;
            // 
            // pictureBox
            // 
            this.pictureBox.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.pictureBox.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.pictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox.Location = new System.Drawing.Point(0, 0);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(897, 821);
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            this.pictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // heightOfCutHScrollBar
            // 
            this.heightOfCutHScrollBar.Location = new System.Drawing.Point(100, 400);
            this.heightOfCutHScrollBar.Maximum = 400;
            this.heightOfCutHScrollBar.Minimum = 150;
            this.heightOfCutHScrollBar.Name = "heightOfCutHScrollBar";
            this.heightOfCutHScrollBar.Size = new System.Drawing.Size(135, 24);
            this.heightOfCutHScrollBar.TabIndex = 26;
            this.heightOfCutHScrollBar.Value = 310;
            this.heightOfCutHScrollBar.ValueChanged += new System.EventHandler(this.heightOfCutHScrollBar_ValueChanged);
            // 
            // heightOfCutLabel
            // 
            this.heightOfCutLabel.AutoSize = true;
            this.heightOfCutLabel.Location = new System.Drawing.Point(49, 402);
            this.heightOfCutLabel.Name = "heightOfCutLabel";
            this.heightOfCutLabel.Size = new System.Drawing.Size(20, 20);
            this.heightOfCutLabel.TabIndex = 25;
            this.heightOfCutLabel.Text = "H";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.predefinedNormalMap2Button);
            this.groupBox2.Controls.Add(this.predefinedNormalMap1Button);
            this.groupBox2.Controls.Add(this.setStandardNormalMap);
            this.groupBox2.Controls.Add(this.setNormalMapButton);
            this.groupBox2.Controls.Add(this.kHScrollBar);
            this.groupBox2.Controls.Add(this.kLabel);
            this.groupBox2.Location = new System.Drawing.Point(16, 645);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(262, 164);
            this.groupBox2.TabIndex = 24;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Normal Map";
            // 
            // predefinedNormalMap2Button
            // 
            this.predefinedNormalMap2Button.Location = new System.Drawing.Point(217, 75);
            this.predefinedNormalMap2Button.Name = "predefinedNormalMap2Button";
            this.predefinedNormalMap2Button.Size = new System.Drawing.Size(38, 35);
            this.predefinedNormalMap2Button.TabIndex = 24;
            this.predefinedNormalMap2Button.Text = "2";
            this.predefinedNormalMap2Button.UseVisualStyleBackColor = true;
            this.predefinedNormalMap2Button.Click += new System.EventHandler(this.predefinedNormalMap2Button_Click);
            // 
            // predefinedNormalMap1Button
            // 
            this.predefinedNormalMap1Button.Location = new System.Drawing.Point(158, 75);
            this.predefinedNormalMap1Button.Name = "predefinedNormalMap1Button";
            this.predefinedNormalMap1Button.Size = new System.Drawing.Size(38, 35);
            this.predefinedNormalMap1Button.TabIndex = 23;
            this.predefinedNormalMap1Button.Text = "1";
            this.predefinedNormalMap1Button.UseVisualStyleBackColor = true;
            this.predefinedNormalMap1Button.Click += new System.EventHandler(this.predefinedNormalMap1Button_Click);
            // 
            // setStandardNormalMap
            // 
            this.setStandardNormalMap.Location = new System.Drawing.Point(6, 26);
            this.setStandardNormalMap.Name = "setStandardNormalMap";
            this.setStandardNormalMap.Size = new System.Drawing.Size(202, 40);
            this.setStandardNormalMap.TabIndex = 20;
            this.setStandardNormalMap.Text = "Set Standard Normal Map";
            this.setStandardNormalMap.UseVisualStyleBackColor = true;
            this.setStandardNormalMap.Click += new System.EventHandler(this.setStandardNormalMap_Click);
            // 
            // setNormalMapButton
            // 
            this.setNormalMapButton.Location = new System.Drawing.Point(6, 72);
            this.setNormalMapButton.Name = "setNormalMapButton";
            this.setNormalMapButton.Size = new System.Drawing.Size(133, 40);
            this.setNormalMapButton.TabIndex = 19;
            this.setNormalMapButton.Text = "Set Normal Map";
            this.setNormalMapButton.UseVisualStyleBackColor = true;
            this.setNormalMapButton.Click += new System.EventHandler(this.setNormalMapButton_Click);
            // 
            // kHScrollBar
            // 
            this.kHScrollBar.LargeChange = 1;
            this.kHScrollBar.Location = new System.Drawing.Point(62, 120);
            this.kHScrollBar.Name = "kHScrollBar";
            this.kHScrollBar.Size = new System.Drawing.Size(135, 24);
            this.kHScrollBar.TabIndex = 22;
            this.kHScrollBar.Value = 50;
            this.kHScrollBar.ValueChanged += new System.EventHandler(this.kHScrollBar_ValueChanged);
            // 
            // kLabel
            // 
            this.kLabel.AutoSize = true;
            this.kLabel.Location = new System.Drawing.Point(17, 122);
            this.kLabel.Name = "kLabel";
            this.kLabel.Size = new System.Drawing.Size(16, 20);
            this.kLabel.TabIndex = 21;
            this.kLabel.Text = "k";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.predefinedTexture2Button);
            this.groupBox1.Controls.Add(this.predefinedTexture1Button);
            this.groupBox1.Controls.Add(this.setStaticColorButton);
            this.groupBox1.Controls.Add(this.setTextureButton);
            this.groupBox1.Location = new System.Drawing.Point(16, 528);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(262, 117);
            this.groupBox1.TabIndex = 23;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Color / Texture";
            // 
            // predefinedTexture2Button
            // 
            this.predefinedTexture2Button.Location = new System.Drawing.Point(200, 78);
            this.predefinedTexture2Button.Name = "predefinedTexture2Button";
            this.predefinedTexture2Button.Size = new System.Drawing.Size(38, 35);
            this.predefinedTexture2Button.TabIndex = 20;
            this.predefinedTexture2Button.Text = "2";
            this.predefinedTexture2Button.UseVisualStyleBackColor = true;
            this.predefinedTexture2Button.Click += new System.EventHandler(this.predefinedTexture2Button_Click);
            // 
            // predefinedTexture1Button
            // 
            this.predefinedTexture1Button.Location = new System.Drawing.Point(141, 78);
            this.predefinedTexture1Button.Name = "predefinedTexture1Button";
            this.predefinedTexture1Button.Size = new System.Drawing.Size(38, 35);
            this.predefinedTexture1Button.TabIndex = 19;
            this.predefinedTexture1Button.Text = "1";
            this.predefinedTexture1Button.UseVisualStyleBackColor = true;
            this.predefinedTexture1Button.Click += new System.EventHandler(this.predefinedTexture1Button_Click);
            // 
            // setStaticColorButton
            // 
            this.setStaticColorButton.Location = new System.Drawing.Point(6, 26);
            this.setStaticColorButton.Name = "setStaticColorButton";
            this.setStaticColorButton.Size = new System.Drawing.Size(107, 52);
            this.setStaticColorButton.TabIndex = 18;
            this.setStaticColorButton.Text = "Set Static Color";
            this.setStaticColorButton.UseVisualStyleBackColor = true;
            this.setStaticColorButton.Click += new System.EventHandler(this.setStaticColorButton_Click);
            // 
            // setTextureButton
            // 
            this.setTextureButton.Location = new System.Drawing.Point(134, 26);
            this.setTextureButton.Name = "setTextureButton";
            this.setTextureButton.Size = new System.Drawing.Size(104, 40);
            this.setTextureButton.TabIndex = 17;
            this.setTextureButton.Text = "Set Texture";
            this.setTextureButton.UseVisualStyleBackColor = true;
            this.setTextureButton.Click += new System.EventHandler(this.setTextureButton_Click);
            // 
            // NullifyLightsMovingButton
            // 
            this.NullifyLightsMovingButton.Location = new System.Drawing.Point(100, 486);
            this.NullifyLightsMovingButton.Name = "NullifyLightsMovingButton";
            this.NullifyLightsMovingButton.Size = new System.Drawing.Size(171, 36);
            this.NullifyLightsMovingButton.TabIndex = 16;
            this.NullifyLightsMovingButton.Text = "Nullify light\'s moving";
            this.NullifyLightsMovingButton.UseVisualStyleBackColor = true;
            this.NullifyLightsMovingButton.Click += new System.EventHandler(this.NullifyLightsMovingButton_Click);
            // 
            // zLightHScrollBar
            // 
            this.zLightHScrollBar.Location = new System.Drawing.Point(100, 361);
            this.zLightHScrollBar.Maximum = 800;
            this.zLightHScrollBar.Minimum = 400;
            this.zLightHScrollBar.Name = "zLightHScrollBar";
            this.zLightHScrollBar.Size = new System.Drawing.Size(135, 24);
            this.zLightHScrollBar.TabIndex = 15;
            this.zLightHScrollBar.Value = 400;
            this.zLightHScrollBar.ValueChanged += new System.EventHandler(this.zLightHScrollBar_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(48, 361);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(16, 20);
            this.label1.TabIndex = 14;
            this.label1.Text = "z";
            // 
            // coloringComboBox
            // 
            this.coloringComboBox.FormattingEnabled = true;
            this.coloringComboBox.Items.AddRange(new object[] {
            "Accurate",
            "Interpolation"});
            this.coloringComboBox.Location = new System.Drawing.Point(131, 439);
            this.coloringComboBox.Name = "coloringComboBox";
            this.coloringComboBox.Size = new System.Drawing.Size(140, 28);
            this.coloringComboBox.TabIndex = 13;
            this.coloringComboBox.TextUpdate += new System.EventHandler(this.coloringComboBox_TextUpdate);
            this.coloringComboBox.DropDownClosed += new System.EventHandler(this.coloringComboBox_DropDownClosed);
            this.coloringComboBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.coloringComboBox_KeyPress);
            // 
            // coloringLabel
            // 
            this.coloringLabel.AutoSize = true;
            this.coloringLabel.Location = new System.Drawing.Point(34, 443);
            this.coloringLabel.Name = "coloringLabel";
            this.coloringLabel.Size = new System.Drawing.Size(66, 20);
            this.coloringLabel.TabIndex = 12;
            this.coloringLabel.Text = "Coloring";
            // 
            // mHScrollBar
            // 
            this.mHScrollBar.LargeChange = 1;
            this.mHScrollBar.Location = new System.Drawing.Point(100, 301);
            this.mHScrollBar.Minimum = 1;
            this.mHScrollBar.Name = "mHScrollBar";
            this.mHScrollBar.Size = new System.Drawing.Size(135, 24);
            this.mHScrollBar.TabIndex = 11;
            this.mHScrollBar.Value = 10;
            this.mHScrollBar.ValueChanged += new System.EventHandler(this.mHScrollBar_ValueChanged);
            // 
            // mLabel
            // 
            this.mLabel.AutoSize = true;
            this.mLabel.Location = new System.Drawing.Point(48, 301);
            this.mLabel.Name = "mLabel";
            this.mLabel.Size = new System.Drawing.Size(22, 20);
            this.mLabel.TabIndex = 10;
            this.mLabel.Text = "m";
            // 
            // ksHScrollBar
            // 
            this.ksHScrollBar.LargeChange = 1;
            this.ksHScrollBar.Location = new System.Drawing.Point(100, 239);
            this.ksHScrollBar.Name = "ksHScrollBar";
            this.ksHScrollBar.Size = new System.Drawing.Size(135, 24);
            this.ksHScrollBar.TabIndex = 9;
            this.ksHScrollBar.Value = 50;
            this.ksHScrollBar.ValueChanged += new System.EventHandler(this.ksHScrollBar_ValueChanged);
            // 
            // kdHScrollBar
            // 
            this.kdHScrollBar.LargeChange = 1;
            this.kdHScrollBar.Location = new System.Drawing.Point(100, 173);
            this.kdHScrollBar.Name = "kdHScrollBar";
            this.kdHScrollBar.Size = new System.Drawing.Size(135, 24);
            this.kdHScrollBar.TabIndex = 8;
            this.kdHScrollBar.Value = 50;
            this.kdHScrollBar.ValueChanged += new System.EventHandler(this.kdHScrollBar_ValueChanged);
            // 
            // ksLabel
            // 
            this.ksLabel.AutoSize = true;
            this.ksLabel.Location = new System.Drawing.Point(48, 243);
            this.ksLabel.Name = "ksLabel";
            this.ksLabel.Size = new System.Drawing.Size(24, 20);
            this.ksLabel.TabIndex = 7;
            this.ksLabel.Text = "Ks";
            // 
            // kdLabel
            // 
            this.kdLabel.AutoSize = true;
            this.kdLabel.Location = new System.Drawing.Point(48, 177);
            this.kdLabel.Name = "kdLabel";
            this.kdLabel.Size = new System.Drawing.Size(27, 20);
            this.kdLabel.TabIndex = 6;
            this.kdLabel.Text = "Kd";
            // 
            // changeLightsColorButton
            // 
            this.changeLightsColorButton.Location = new System.Drawing.Point(166, 112);
            this.changeLightsColorButton.Name = "changeLightsColorButton";
            this.changeLightsColorButton.Size = new System.Drawing.Size(88, 38);
            this.changeLightsColorButton.TabIndex = 5;
            this.changeLightsColorButton.Text = "Change";
            this.changeLightsColorButton.UseVisualStyleBackColor = true;
            this.changeLightsColorButton.Click += new System.EventHandler(this.changeLightsColorButton_Click);
            // 
            // lightsColorLabel
            // 
            this.lightsColorLabel.AutoSize = true;
            this.lightsColorLabel.Location = new System.Drawing.Point(37, 121);
            this.lightsColorLabel.Name = "lightsColorLabel";
            this.lightsColorLabel.Size = new System.Drawing.Size(89, 20);
            this.lightsColorLabel.TabIndex = 4;
            this.lightsColorLabel.Text = "Light\'s color";
            // 
            // changeObjectsColorButton
            // 
            this.changeObjectsColorButton.Location = new System.Drawing.Point(166, 68);
            this.changeObjectsColorButton.Name = "changeObjectsColorButton";
            this.changeObjectsColorButton.Size = new System.Drawing.Size(88, 38);
            this.changeObjectsColorButton.TabIndex = 3;
            this.changeObjectsColorButton.Text = "Change";
            this.changeObjectsColorButton.UseVisualStyleBackColor = true;
            this.changeObjectsColorButton.Click += new System.EventHandler(this.changeObjectsColorButton_Click);
            // 
            // objectsColorLabel
            // 
            this.objectsColorLabel.AutoSize = true;
            this.objectsColorLabel.Location = new System.Drawing.Point(37, 77);
            this.objectsColorLabel.Name = "objectsColorLabel";
            this.objectsColorLabel.Size = new System.Drawing.Size(100, 20);
            this.objectsColorLabel.TabIndex = 2;
            this.objectsColorLabel.Text = "Object\'s color";
            // 
            // labelTriangulationAccuracy
            // 
            this.labelTriangulationAccuracy.AutoSize = true;
            this.labelTriangulationAccuracy.Location = new System.Drawing.Point(37, 12);
            this.labelTriangulationAccuracy.Name = "labelTriangulationAccuracy";
            this.labelTriangulationAccuracy.Size = new System.Drawing.Size(159, 20);
            this.labelTriangulationAccuracy.TabIndex = 1;
            this.labelTriangulationAccuracy.Text = "Triangulation Accuracy";
            // 
            // triangulationAccuracyHScrollBar
            // 
            this.triangulationAccuracyHScrollBar.Location = new System.Drawing.Point(37, 35);
            this.triangulationAccuracyHScrollBar.Maximum = 27;
            this.triangulationAccuracyHScrollBar.Minimum = 9;
            this.triangulationAccuracyHScrollBar.Name = "triangulationAccuracyHScrollBar";
            this.triangulationAccuracyHScrollBar.Size = new System.Drawing.Size(176, 24);
            this.triangulationAccuracyHScrollBar.TabIndex = 0;
            this.triangulationAccuracyHScrollBar.Value = 9;
            this.triangulationAccuracyHScrollBar.ValueChanged += new System.EventHandler(this.triangulationAccuracyHScrollBar_ValueChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1198, 821);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Label labelTriangulationAccuracy;
        private System.Windows.Forms.HScrollBar triangulationAccuracyHScrollBar;
        private System.Windows.Forms.Button changeObjectsColorButton;
        private System.Windows.Forms.Label objectsColorLabel;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button changeLightsColorButton;
        private System.Windows.Forms.Label lightsColorLabel;
        private System.Windows.Forms.ColorDialog colorDialog2;
        private System.Windows.Forms.HScrollBar ksHScrollBar;
        private System.Windows.Forms.HScrollBar kdHScrollBar;
        private System.Windows.Forms.Label ksLabel;
        private System.Windows.Forms.Label kdLabel;
        private System.Windows.Forms.HScrollBar mHScrollBar;
        private System.Windows.Forms.Label mLabel;
        private System.Windows.Forms.ComboBox coloringComboBox;
        private System.Windows.Forms.Label coloringLabel;
        private System.Windows.Forms.HScrollBar zLightHScrollBar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button NullifyLightsMovingButton;
        private System.Windows.Forms.Button setTextureButton;
        private System.Windows.Forms.Button setStaticColorButton;
        private System.Windows.Forms.Button setNormalMapButton;
        private System.Windows.Forms.Button setStandardNormalMap;
        private System.Windows.Forms.HScrollBar kHScrollBar;
        private System.Windows.Forms.Label kLabel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button predefinedTexture2Button;
        private System.Windows.Forms.Button predefinedTexture1Button;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button predefinedNormalMap2Button;
        private System.Windows.Forms.Button predefinedNormalMap1Button;
        private System.Windows.Forms.HScrollBar heightOfCutHScrollBar;
        private System.Windows.Forms.Label heightOfCutLabel;
    }
}

