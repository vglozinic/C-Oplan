namespace Prototip_OPPlan
{
    partial class Form1
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
            this.gMapControl1 = new GMap.NET.WindowsForms.GMapControl();
            this.ime = new System.Windows.Forms.TextBox();
            this.prez = new System.Windows.Forms.TextBox();
            this.dodaj = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.strana = new System.Windows.Forms.ComboBox();
            this.mr = new System.Windows.Forms.ComboBox();
            this.izvj = new System.Windows.Forms.Button();
            this.play = new System.Windows.Forms.Button();
            this.konacno = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // gMapControl1
            // 
            this.gMapControl1.Bearing = 0F;
            this.gMapControl1.CanDragMap = true;
            this.gMapControl1.EmptyTileColor = System.Drawing.Color.Navy;
            this.gMapControl1.GrayScaleMode = false;
            this.gMapControl1.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.gMapControl1.LevelsKeepInMemmory = 5;
            this.gMapControl1.Location = new System.Drawing.Point(30, 162);
            this.gMapControl1.MarkersEnabled = true;
            this.gMapControl1.MaxZoom = 2;
            this.gMapControl1.MinZoom = 2;
            this.gMapControl1.MouseWheelZoomEnabled = true;
            this.gMapControl1.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.gMapControl1.Name = "gMapControl1";
            this.gMapControl1.NegativeMode = false;
            this.gMapControl1.PolygonsEnabled = true;
            this.gMapControl1.RetryLoadTile = 0;
            this.gMapControl1.RoutesEnabled = true;
            this.gMapControl1.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.gMapControl1.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.gMapControl1.ShowTileGridLines = false;
            this.gMapControl1.Size = new System.Drawing.Size(708, 451);
            this.gMapControl1.TabIndex = 0;
            this.gMapControl1.Zoom = 0D;
            this.gMapControl1.OnMarkerClick += new GMap.NET.WindowsForms.MarkerClick(this.gMapControl1_OnMarkerClick);
            this.gMapControl1.OnRouteClick += new GMap.NET.WindowsForms.RouteClick(this.gMapControl1_OnRouteClick);
            this.gMapControl1.Load += new System.EventHandler(this.gMapControl1_Load);
            this.gMapControl1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.gMapControl1_MouseDoubleClick);
            // 
            // ime
            // 
            this.ime.Location = new System.Drawing.Point(119, 22);
            this.ime.Name = "ime";
            this.ime.Size = new System.Drawing.Size(100, 20);
            this.ime.TabIndex = 1;
            // 
            // prez
            // 
            this.prez.Location = new System.Drawing.Point(119, 72);
            this.prez.Name = "prez";
            this.prez.Size = new System.Drawing.Size(100, 20);
            this.prez.TabIndex = 2;
            // 
            // dodaj
            // 
            this.dodaj.Location = new System.Drawing.Point(134, 116);
            this.dodaj.Name = "dodaj";
            this.dodaj.Size = new System.Drawing.Size(85, 23);
            this.dodaj.TabIndex = 3;
            this.dodaj.Text = "dodaj marker";
            this.dodaj.UseVisualStyleBackColor = true;
            this.dodaj.Click += new System.EventHandler(this.dodaj_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(406, 17);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 4;
            // 
            // strana
            // 
            this.strana.FormattingEnabled = true;
            this.strana.Location = new System.Drawing.Point(406, 56);
            this.strana.Name = "strana";
            this.strana.Size = new System.Drawing.Size(121, 21);
            this.strana.TabIndex = 5;
            // 
            // mr
            // 
            this.mr.FormattingEnabled = true;
            this.mr.Location = new System.Drawing.Point(406, 96);
            this.mr.Name = "mr";
            this.mr.Size = new System.Drawing.Size(121, 21);
            this.mr.TabIndex = 6;
            // 
            // izvj
            // 
            this.izvj.Location = new System.Drawing.Point(567, 116);
            this.izvj.Name = "izvj";
            this.izvj.Size = new System.Drawing.Size(75, 23);
            this.izvj.TabIndex = 7;
            this.izvj.Text = "izvještaj";
            this.izvj.UseVisualStyleBackColor = true;
            this.izvj.Click += new System.EventHandler(this.izvj_Click);
            // 
            // play
            // 
            this.play.Location = new System.Drawing.Point(663, 116);
            this.play.Name = "play";
            this.play.Size = new System.Drawing.Size(75, 23);
            this.play.TabIndex = 8;
            this.play.Text = "play";
            this.play.UseVisualStyleBackColor = true;
            this.play.Click += new System.EventHandler(this.play_Click);
            // 
            // konacno
            // 
            this.konacno.Location = new System.Drawing.Point(773, 162);
            this.konacno.Name = "konacno";
            this.konacno.Size = new System.Drawing.Size(248, 451);
            this.konacno.TabIndex = 9;
            this.konacno.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Ime markera:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(64, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Vrsta: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(314, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Izaberi marker:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(349, 59);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Strana:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(275, 96);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(115, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Postaviti marker ili rutu:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1054, 639);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.konacno);
            this.Controls.Add(this.play);
            this.Controls.Add(this.izvj);
            this.Controls.Add(this.mr);
            this.Controls.Add(this.strana);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.dodaj);
            this.Controls.Add(this.prez);
            this.Controls.Add(this.ime);
            this.Controls.Add(this.gMapControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GMap.NET.WindowsForms.GMapControl gMapControl1;
        private System.Windows.Forms.TextBox ime;
        private System.Windows.Forms.TextBox prez;
        private System.Windows.Forms.Button dodaj;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox strana;
        private System.Windows.Forms.ComboBox mr;
        private System.Windows.Forms.Button izvj;
        private System.Windows.Forms.Button play;
        private System.Windows.Forms.RichTextBox konacno;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}

