/*
 * Creado por SharpDevelop.
 * Usuario: JESH
 * Fecha: 06/03/2020
 * Hora: 07:59 p. m.
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
namespace ACTIVIDAD2
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Button agregar_imaen;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.TextBox textBoxH;
		private System.Windows.Forms.RadioButton PrimRad;
		private System.Windows.Forms.RadioButton KruskalRad;
		private System.Windows.Forms.NumericUpDown numericDiameter;
		private System.Windows.Forms.TextBox textBoxP;
		private System.Windows.Forms.OpenFileDialog openFileDialog2;
		private System.Windows.Forms.Button imageParticleButton;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.agregar_imaen = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.textBoxH = new System.Windows.Forms.TextBox();
            this.PrimRad = new System.Windows.Forms.RadioButton();
            this.KruskalRad = new System.Windows.Forms.RadioButton();
            this.numericDiameter = new System.Windows.Forms.NumericUpDown();
            this.textBoxP = new System.Windows.Forms.TextBox();
            this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            this.imageParticleButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericDiameter)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(11, 10);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(917, 571);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PictureBox1MouseClick);
            // 
            // agregar_imaen
            // 
            this.agregar_imaen.Location = new System.Drawing.Point(1141, 20);
            this.agregar_imaen.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.agregar_imaen.Name = "agregar_imaen";
            this.agregar_imaen.Size = new System.Drawing.Size(217, 49);
            this.agregar_imaen.TabIndex = 1;
            this.agregar_imaen.Text = "AGREGAR IMAGEN";
            this.agregar_imaen.UseVisualStyleBackColor = true;
            this.agregar_imaen.Click += new System.EventHandler(this.Agregar_imaenClick);
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.textBox1.Location = new System.Drawing.Point(939, 167);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox1.Size = new System.Drawing.Size(575, 196);
            this.textBox1.TabIndex = 1;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // textBoxH
            // 
            this.textBoxH.Location = new System.Drawing.Point(949, 374);
            this.textBoxH.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxH.Multiline = true;
            this.textBoxH.Name = "textBoxH";
            this.textBoxH.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxH.Size = new System.Drawing.Size(297, 206);
            this.textBoxH.TabIndex = 2;
            // 
            // PrimRad
            // 
            this.PrimRad.Checked = true;
            this.PrimRad.Location = new System.Drawing.Point(960, 89);
            this.PrimRad.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.PrimRad.Name = "PrimRad";
            this.PrimRad.Size = new System.Drawing.Size(192, 49);
            this.PrimRad.TabIndex = 3;
            this.PrimRad.TabStop = true;
            this.PrimRad.Text = "PRIM";
            this.PrimRad.UseVisualStyleBackColor = true;
            // 
            // KruskalRad
            // 
            this.KruskalRad.Location = new System.Drawing.Point(1152, 89);
            this.KruskalRad.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.KruskalRad.Name = "KruskalRad";
            this.KruskalRad.Size = new System.Drawing.Size(192, 49);
            this.KruskalRad.TabIndex = 4;
            this.KruskalRad.Text = "KRUSKAL";
            this.KruskalRad.UseVisualStyleBackColor = true;
            // 
            // numericDiameter
            // 
            this.numericDiameter.Location = new System.Drawing.Point(1355, 79);
            this.numericDiameter.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.numericDiameter.Maximum = new decimal(new int[] {
            601,
            0,
            0,
            0});
            this.numericDiameter.Name = "numericDiameter";
            this.numericDiameter.Size = new System.Drawing.Size(160, 22);
            this.numericDiameter.TabIndex = 5;
            this.numericDiameter.Value = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.numericDiameter.ValueChanged += new System.EventHandler(this.NumericDiameterValueChanged);
            // 
            // textBoxP
            // 
            this.textBoxP.Location = new System.Drawing.Point(1259, 374);
            this.textBoxP.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxP.Multiline = true;
            this.textBoxP.Name = "textBoxP";
            this.textBoxP.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxP.Size = new System.Drawing.Size(255, 206);
            this.textBoxP.TabIndex = 6;
            // 
            // openFileDialog2
            // 
            this.openFileDialog2.FileName = "openFileDialog2";
            // 
            // imageParticleButton
            // 
            this.imageParticleButton.Location = new System.Drawing.Point(1355, 118);
            this.imageParticleButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.imageParticleButton.Name = "imageParticleButton";
            this.imageParticleButton.Size = new System.Drawing.Size(160, 28);
            this.imageParticleButton.TabIndex = 7;
            this.imageParticleButton.Text = "Imagen a particula";
            this.imageParticleButton.UseVisualStyleBackColor = true;
            this.imageParticleButton.Click += new System.EventHandler(this.ImageParticleButtonClick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1536, 607);
            this.Controls.Add(this.imageParticleButton);
            this.Controls.Add(this.textBoxP);
            this.Controls.Add(this.numericDiameter);
            this.Controls.Add(this.KruskalRad);
            this.Controls.Add(this.PrimRad);
            this.Controls.Add(this.textBoxH);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.agregar_imaen);
            this.Controls.Add(this.pictureBox1);
            this.ImeMode = System.Windows.Forms.ImeMode.On;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "MainForm";
            this.Text = "ACTIVIDAD2";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericDiameter)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
	}
}
