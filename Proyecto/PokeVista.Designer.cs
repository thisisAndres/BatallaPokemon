namespace Proyecto
{
    partial class PokeVista
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            imagen = new PictureBox();
            nombre = new Label();
            checkBox1 = new CheckBox();
            tipo1 = new PictureBox();
            tipo2 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)imagen).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tipo1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tipo2).BeginInit();
            SuspendLayout();
            // 
            // imagen
            // 
            imagen.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            imagen.BackgroundImageLayout = ImageLayout.Center;
            imagen.Location = new Point(13, 20);
            imagen.Name = "imagen";
            imagen.Size = new Size(140, 96);
            imagen.SizeMode = PictureBoxSizeMode.CenterImage;
            imagen.TabIndex = 0;
            imagen.TabStop = false;
            imagen.MouseHover += imagen_MouseHover_1;
            // 
            // nombre
            // 
            nombre.AutoSize = true;
            nombre.Location = new Point(46, 119);
            nombre.Name = "nombre";
            nombre.Size = new Size(38, 15);
            nombre.TabIndex = 1;
            nombre.Text = "label1";
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(38, 199);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(86, 19);
            checkBox1.TabIndex = 5;
            checkBox1.Text = "Seleccionar";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // tipo1
            // 
            tipo1.Location = new Point(38, 142);
            tipo1.Name = "tipo1";
            tipo1.Size = new Size(85, 25);
            tipo1.TabIndex = 6;
            tipo1.TabStop = false;
            // 
            // tipo2
            // 
            tipo2.Location = new Point(38, 173);
            tipo2.Name = "tipo2";
            tipo2.Size = new Size(85, 25);
            tipo2.TabIndex = 7;
            tipo2.TabStop = false;
            // 
            // PokeVista
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(tipo2);
            Controls.Add(tipo1);
            Controls.Add(checkBox1);
            Controls.Add(nombre);
            Controls.Add(imagen);
            Name = "PokeVista";
            Size = new Size(169, 221);
            Load += PokeVista_Load;
            ((System.ComponentModel.ISupportInitialize)imagen).EndInit();
            ((System.ComponentModel.ISupportInitialize)tipo1).EndInit();
            ((System.ComponentModel.ISupportInitialize)tipo2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox imagen;
        private Label nombre;
        private CheckBox checkBox1;
        private PictureBox tipo1;
        private PictureBox tipo2;
    }
}
