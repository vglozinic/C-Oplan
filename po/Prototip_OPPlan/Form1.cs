using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Text;
using System.Runtime.InteropServices;
using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms.Markers;
using GMap.NET.WindowsForms.ToolTips;
using AnimatorNS;
using oplan;
using CodeVendor.Controls;


namespace Prototip_OPPlan
{
    public partial class Form1 : Form
    {

        [DllImport("gdi32.dll")]
        private static extern IntPtr AddFontMemResourceEx(IntPtr pbfont,uint cbfont, IntPtr pdv,[In] ref uint pcFonts);

        FontFamily ff;
        Font font;

        public class temp
        {
            public double korX;
            public double korY;

        }



        private CodeVendor.Controls.Grouper Grouper1;

        GMapOverlay overlayOne;
        GMapOverlay sloj2 = new GMapOverlay("OverlayTwo");
        int sirina;
        int dubina;
        int d_mode = 0;
        String country="Paris";
        String TheChosenOne;
        String marker_ruta;

        List<podaci> markeri = new List<podaci>();
        int marker_Id = 1;
       
        List<rute> rutes = new List<rute>();
        int brojac_gotovo = 0;
        
        int idRute_povecaj = 0;

        public delegate void Dmarker(double s_x, double s_y);
        temp temporary = new temp();

        int prijavljeniKorisnik;

        public Form1(int id_korisnika)
        {
            InitializeComponent();
            loadFont();

            prijavljeniKorisnik = id_korisnika;

            zoviFont(font, this.prviLink, 8);
            zoviFont(font, this.drugiLink, 8);
            zoviFont(font, this.MMarkeri, 14);
            zoviFont(font, this.treciLink, 8);
            
            zoviFont(font, this.izvj, 14);
            zoviFont(font, this.OP_Plan, 14);

        }
        

        private void loadFont()
        {
            byte[] fontArray = Prototip_OPPlan.Properties.Resources.Montserrat_Regular;
            int dataLength = Prototip_OPPlan.Properties.Resources.Montserrat_Regular.Length;
            IntPtr ptrData = Marshal.AllocCoTaskMem(dataLength);
            Marshal.Copy(fontArray, 0, ptrData, dataLength);
            uint cFonts = 0;
            AddFontMemResourceEx(ptrData, (uint)fontArray.Length, IntPtr.Zero, ref cFonts);
            PrivateFontCollection pfc = new PrivateFontCollection();
            pfc.AddMemoryFont(ptrData, dataLength);
            Marshal.FreeCoTaskMem(ptrData);
            ff = pfc.Families[0];
            font = new Font(ff, 15f, FontStyle.Regular);
        }

        private void zoviFont(Font f, Control c, float size)
        {
            FontStyle fontStyle = FontStyle.Regular;
            c.Font = new Font(ff, size, fontStyle);

        }
        private void gMapControl1_Load(object sender, EventArgs e)
        {

            sirina = Screen.GetWorkingArea(this).Width;
            dubina= Screen.GetWorkingArea(this).Height;
            gMapControl1.DragButton = MouseButtons.Left;
            gMapControl1.CanDragMap = true;
            gMapControl1.SetPositionByKeywords(country);
            gMapControl1.MapProvider = GMapProviders.GoogleMap;
            gMapControl1.MinZoom = 3;
            gMapControl1.MaxZoom = 24;
            gMapControl1.Zoom = 9;
            gMapControl1.AutoScroll = true;
            gMapControl1.Manager.Mode = AccessMode.ServerAndCache;
            overlayOne = new GMapOverlay("OverlayOne");

            gMapControl1.Position = new PointLatLng(48.864716, 2.349014);
            GMarkerGoogle marker = new GMarkerGoogle(gMapControl1.Position, GMarkerGoogleType.pink);
            overlayOne.Markers.Add(marker);
            gMapControl1.Overlays.Add(overlayOne);
            gMapControl1.Size = new Size(sirina, dubina);

            konacno.Text += " \r \r";
            konacno.Text += "Postavljanje markera:" + " \r";
            konacno.Text += "1. Definirati ime i vrstu markera i dodati ga u izbornik"+ "\r";
            konacno.Text += "2. Izabrati marker iz izbornika i definirati da li je prijatelj/neprijatelj"+ "\r";
            konacno.Text += "3. Definirati da li želite postaviti rutu ili marker"+ "\r";
            konacno.Text += "4. DOUBLE CLICK na poziciju gdje želite postaviti marker"+ "\r"+"\r";

            konacno.Text += "Postavljanje rute:" + " \r";
            konacno.Text += "1. Definirati da želiš postaviti rutu a ne marker" + "\r";
            konacno.Text += "2. CLICK na marker ili na već postavljenu rutu kojoj želiš pridodati novu (početna točka rute)" + "\r";
            konacno.Text += "3. DOUBLE CLICK na poziciju gdje želiš da nova ruta završava (završna točka rute)" + "\r" + "\r";

          
        }

        private void GMapControl1_StyleChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void gMapControl1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            double X = gMapControl1.FromLocalToLatLng(e.X, e.Y).Lng;
            double Y = gMapControl1.FromLocalToLatLng(e.X, e.Y).Lat;
            if (r3.Checked==true)
            {


                gMapControl1.Position = new PointLatLng(Y, X);
                GMarkerGoogle marker;
                if (r2.Checked==true)
                {
                    marker = new GMarkerGoogle(gMapControl1.Position, GMarkerGoogleType.pink);
                }
                else {
                    marker = new GMarkerGoogle(gMapControl1.Position, GMarkerGoogleType.blue);

                }
                

                TheChosenOne = comboBox1.Text;
                marker.ToolTipText = marker_Id.ToString();
                
                overlayOne.Markers.Add(marker);
                gMapControl1.Overlays.Add(overlayOne);
                podaci m = new podaci();
                m.imena = TheChosenOne;
                m.prezimena= TheChosenOne;
                m.id_markera = marker_Id;
                marker_Id++;
                m.korX = X;
                m.korY = Y;
                if (r1.Checked==false)
                {
                    m.vrsta = "enemy";
                }
                else
                {
                    m.vrsta = "our_team";
                }
                markeri.Add(m);

            }

            else if (r4.Checked==true)
            {
                if (marker_ruta == null) {

                    MessageBox.Show("Moraš prvo kreirati barem jedan marker da bi mu mogao dodijeliti rutu...");
                }
                else { 
                rute nova_rute = new rute();
                nova_rute.start_X = temporary.korX;
                nova_rute.tstart_X = temporary.korX;
                nova_rute.start_Y = temporary.korY;
                nova_rute.tstart_Y = temporary.korY;
                nova_rute.finish_X = Y;
                nova_rute.finish_Y = X;
                idRute_povecaj++;
                nova_rute.id_rute = idRute_povecaj;
                nova_rute.ime_markera = marker_ruta;
                rutes.Add(nova_rute);
                List<PointLatLng> rutice = new List<PointLatLng>();
                PointLatLng start = new PointLatLng(temporary.korX, temporary.korY);
                PointLatLng end = new PointLatLng(Y, X);
                rutice.Add(start);
                rutice.Add(end);
                var r = new GMap.NET.WindowsForms.GMapRoute(rutice, "MyRoute");
                r.Name = Convert.ToString(marker_ruta);
                r.Stroke.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                r.IsHitTestVisible = true;
                GMapOverlay routesOverlay = new GMapOverlay("routes");
                routesOverlay.Routes.Add(r);
                gMapControl1.Overlays.Add(routesOverlay);
                gMapControl1.Zoom += 0.1;
                gMapControl1.Zoom -= 0.1;
                }
            }

           
        }

        private void dodaj_Click(object sender, EventArgs e)
        {
            country = ime_Mjesta.Text;
            gMapControl1.SetPositionByKeywords(country);

        }

        private void izvj_Click(object sender, EventArgs e)
        {
            if (d_mode == 0)
            {
                klikni_gumb(treciLink);
            }
            else
            {
                MessageBox.Show("moraš isključiti delete mode da bi ostale funkcionalnosti bile dostupne");
            }

            konacno.Text += " Plan napada:PARIS";

            for (int i = 0; i < rutes.Count; i++)
            {

                konacno.Text += " \r \r";
                konacno.Text += "Ime rute: " + rutes[i].id_rute + " \r";
                konacno.Text += "Marker kojem pripada: " + rutes[i].ime_markera + "\r" + "\r";
                konacno.Text +="Pocetak rute-X:" + rutes[i].start_X+"\r" + "\r";
                konacno.Text += "Pocetak rute-Y:" + rutes[i].start_Y+ "\r" + "\r";
                konacno.Text += "Kraj rute-X:" + rutes[i].finish_X+ "\r" + "\r";
                konacno.Text += "Kraj rute-Y:" + rutes[i].finish_Y+ "\r" + "\r";


            }
        }

        private void gMapControl1_OnMarkerClick(GMapMarker item, MouseEventArgs e)
        {
            marker_ruta = item.ToolTipText;
            if (d_mode == 0) { 
            
            double X = gMapControl1.FromLocalToLatLng(e.X, e.Y).Lng;
            double Y = gMapControl1.FromLocalToLatLng(e.X, e.Y).Lat;
            temporary.korX = Y;
            temporary.korY = X;
            }
            else
            {
               
               for(int i = 0; i < rutes.Count; i++)
                {
                    brisi_rutu(marker_ruta);
                }


                foreach (var a in gMapControl1.Overlays)
                {
                    foreach (var ruta in a.Routes)
                    {
                        if (ruta.Name == marker_ruta)
                        {
                            ruta.IsVisible = false;

                        }

                    }

                }
                for (int i = 0; i< markeri.Count; i++){
                    if (markeri[i].id_markera == int.Parse(marker_ruta))
                    {
                        markeri.RemoveAt(i);
                        item.IsVisible = false;
                    }

                }

                
            }

        }

        private double duzinaRute(double s_x, double s_y, double f_x, double f_y)
        {
            double duzina;
            duzina = ((f_x - s_x) * (f_x - s_x)) + ((f_y - s_y) * (f_y - s_y));
            duzina = Math.Sqrt(duzina);
            return duzina;
        }

        private double vrati_n(double s_X, double s_Y, double f_X, double f_Y)
        {
            double n;
            n = (f_Y - s_Y) / (f_X - s_X);
            return n;

        }

        private double vrati_k(double s_X, double s_Y, double f_X, double f_Y)
        {
            double k;
            k = (f_Y - s_Y) / (f_X - s_X);
            k = k * (-s_X) + s_Y;
            return k;

        }

        public void napraviMarker(double s_x, double s_y)
        {
            GMarkerGoogle marker;
            marker = new GMarkerGoogle(new PointLatLng(s_x, s_y), GMarkerGoogleType.blue);
            marker.ToolTipText = "12";

            sloj2.Markers.Add(marker);

        }



        public Tuple<double, double> simulacija(double tsx, double tsy, double s_x, double s_y, double f_x, double f_y, double a, double b)
        {
            double form = f_y - tsy;
            double form1 = f_x - tsx;
            form = Math.Abs(form);
            form1 = Math.Abs(form1);
            if (tsx > f_x && form1 >= 0.04)
            {
                s_x = s_x - 0.04;
                s_y = s_x * a + b;
            }
            else if (tsx < f_x && form1 >= 0.04)
            {

                s_x = s_x + 0.04;
                s_y = s_x * a + b;
            }

            else if (tsx > f_x && form >= 0.01)
            {
                s_x = s_x - 0.002;
                s_y = s_x * a + b;
            }
            else if (tsx < f_x && form >= 0.01)
            {
                s_x = s_x + 0.002;
                s_y = s_x * a + b;
            }

            Dmarker stvoriMarker = new Dmarker(napraviMarker);

            stvoriMarker(s_x, s_y);



            return new Tuple<double, double>(s_x, s_y);
        }


        public int JeliRutaPrijemeneGotova(int x)
        {
            if (x == 0)
            {
                return 1;
            }
            for (int i = x - 1; i >= 0; i--)
            {
                if (rutes[i].ime_markera == rutes[x].ime_markera && rutes[i].gotovo != 1)
                {

                    return 0;
                }

                else if (rutes[i].ime_markera == rutes[x].ime_markera && rutes[i].gotovo == 1)
                {
                    return 1;
                }

            }


            return 1;
        }

        private void ThreadProc()
        {
            int x;
            while (brojac_gotovo < rutes.Count)
            {
                for (int i = 0; i < rutes.Count; i++)
                {



                    if (rutes[i].gotovo != 1)
                    {
                        x = JeliRutaPrijemeneGotova(i);
                        if (x == 1)
                        {
                            double duz = duzinaRute(rutes[i].start_X, rutes[i].start_Y, rutes[i].tstart_X, rutes[i].tstart_Y);
                            if ((rutes[i].duzina - duz) <= 0)
                            {


                                rutes[i].gotovo = 1;
                                brojac_gotovo++;
                            }
                            else
                            {
                                if (rutes[i].gotovo != 1)
                                {
                                    var m = simulacija(rutes[i].tstart_X, rutes[i].start_Y, rutes[i].start_X, rutes[i].tstart_Y, rutes[i].finish_X, rutes[i].finish_Y, rutes[i].vektor_a, rutes[i].vektor_b);
                                    rutes[i].start_X = m.Item1;
                                    rutes[i].start_Y = m.Item2;
                                }


                            }






                        }
                    }

                }

                gMapControl1.Overlays.Add(sloj2);
                System.Threading.Thread.Sleep(300);
                sloj2.Clear();               

            }


        }






        public Tuple<double, double> vratiPocetneTocke(string idRute)
        {
            int id = int.Parse(idRute);
            for (int i = 0; i < rutes.Count; i++)
            {

                if (rutes[i].id_rute == id)
                {
                    marker_ruta = rutes[i].ime_markera;
                    return new Tuple<double, double>(rutes[i].finish_X, rutes[i].finish_Y);

                }

            }

            return new Tuple<double, double>(rutes[1].finish_X, rutes[1].finish_Y);

        }

        private void gMapControl1_OnRouteClick(GMapRoute item, MouseEventArgs e)
        {
            marker_ruta = item.Name;
            if (d_mode == 0) { 
            for (int i=0; i<rutes.Count; i++){

                if (rutes[i].ime_markera == item.Name)
                {
                    temporary.korX = rutes[i].finish_X;
                    temporary.korY = rutes[i].finish_Y;
                    
                }
            }

            }

            else
            {
                brisi_rutu(item.Name);
                item.IsVisible = false;

            }

        }

        private void brisi_rutu(string PremaOvomId)
        {
            for (int i = rutes.Count - 1; i >= 0; i--)
            {

                if (rutes[i].ime_markera == PremaOvomId)
                {
                    rutes.RemoveAt(i);
                    i = -1;
                }
            }


        }
        private void dizajniraj_gumb(Button x, Color boja, int sirina)
        {
            
              
             x.BackColor = boja;
            x.TabStop = false;
            x.FlatStyle = FlatStyle.Flat;
            x.FlatAppearance.BorderSize = 0;
            x.Height = 70;
            x.Width = sirina;
            x.TextAlign = ContentAlignment.MiddleLeft;
            x.Padding = new Padding(20, 0, 20, 0);
            Color back = System.Drawing.ColorTranslator.FromHtml("#FFDDBE");
            x.ForeColor = back;
            

        }


        private void dizajniraj_grupbox(Grouper x, Color boja, int sirina)
        {

            
         
            x.BackgroundColor = boja;
            
            x.BorderColor = boja;
            x.Width = sirina;
            
            Color back = System.Drawing.ColorTranslator.FromHtml("#FFF");
            x.ForeColor = back;
            x.BackColor= boja;
            

        }

        private void klikni_gumb(Grouper x)
        {
            animator1.DefaultAnimation = Animation.VertSlide;
            if (x.Visible == false) { 
            animator1.Show(x);
            }
            else
            {
                animator1.Hide(x);

            }

        }

        private void klikni_gumb_samosakrij(Grouper x)
        {
            animator1.DefaultAnimation = Animation.VertSlide;
            if (x.Visible == true)
            {
                animator1.Hide(x);
            }


        }

        private void DizajnirajGumb(Button x, Color back, Color border)
        {
            x.FlatStyle = FlatStyle.Flat;
                x.BackColor = back;
            x.FlatAppearance.BorderColor = border;
            x.FlatAppearance.BorderSize = 1;

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            this.TopMost = true;
           // this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            Color back= System.Drawing.ColorTranslator.FromHtml("#FFF");
            Color najtamnija = System.Drawing.ColorTranslator.FromHtml("#2ab6c5");
            Color svetlija= System.Drawing.ColorTranslator.FromHtml("#27a2b1");
            Color najsvetlija = System.Drawing.ColorTranslator.FromHtml("#218f9c");
            Color gumbic= System.Drawing.ColorTranslator.FromHtml("#1d8e9e");
            Color plaj_1 = System.Drawing.ColorTranslator.FromHtml("#067a9f");
            Color zelena1= System.Drawing.ColorTranslator.FromHtml("#02a35d");
            Color zelena3 = System.Drawing.ColorTranslator.FromHtml("#02b969"); 
            this.comboBox1.Items.Add("velka_pjesadija");
            this.comboBox1.Items.Add("tenkovska_brigada");
            this.comboBox1.Items.Add("mala_pjesadija");
            this.comboBox1.Items.Add("ljudi_sa_velkim puškama");
            this.comboBox1.Items.Add("ljudi_na_konjima");
            this.r3.Checked = true;
            this.BackColor = back;
            this.play.BackColor = plaj_1;
            this.save.BackColor = zelena3;
            this.delete_mode.BackColor = zelena1;
            this.Grouper1 = new CodeVendor.Controls.Grouper();
            Grouper1.BackColor = najtamnija;
            Grouper1.Width = 200;
            Grouper1.Height = 400;
            dizajniraj_gumb(OP_Plan, najtamnija, 230);
            dizajniraj_gumb(MMarkeri, svetlija, 300);
            dizajniraj_gumb(izvj, najsvetlija, 400);
            dizajniraj_grupbox(prviLink, najtamnija, 230);
            dizajniraj_grupbox(drugiLink, svetlija,300);
            dizajniraj_grupbox(treciLink, najsvetlija, 398);
            DizajnirajGumb(this.dodaj, gumbic, back);
            
        }

       
        private void OP_Plan_Click(object sender, EventArgs e)
        {
            if (d_mode == 0) { 
            klikni_gumb(prviLink);
            }
            else
            {
                MessageBox.Show("moraš isključiti delete mode da bi ostale funkcionalnosti bile dostupne");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (d_mode == 0)
            {
                klikni_gumb(drugiLink);
        }
            else
            {
                MessageBox.Show("moraš isključiti delete mode da bi ostale funkcionalnosti bile dostupne");
            }
}

        private void play_Click_1(object sender, EventArgs e)
        {
            for (int i = 0; i < rutes.Count; i++)
            {

                rutes[i].start_X = rutes[i].tstart_X;
                rutes[i].start_Y = rutes[i].tstart_Y;
            }
            brojac_gotovo = 0;

            klikni_gumb_samosakrij(prviLink);
            klikni_gumb_samosakrij(drugiLink);
            klikni_gumb_samosakrij(treciLink);



            for (int i = 0; i < rutes.Count; i++)
            {

                rutes[i].gotovo = 0;
            
                double A;
                double B;
                A = vrati_n(rutes[i].start_X, rutes[i].start_Y, rutes[i].finish_X, rutes[i].finish_Y);
                B = vrati_k(rutes[i].start_X, rutes[i].start_Y, rutes[i].finish_X, rutes[i].finish_Y);

                rutes[i].vektor_a = A;
                rutes[i].vektor_b = B;



                rutes[i].duzina = duzinaRute(rutes[i].start_X, rutes[i].start_Y, rutes[i].finish_X, rutes[i].finish_Y);
            }



            Thread novaDretva;
            int vrtnja = rutes.Count / 2 + 1;

            int gotova_dretva1 = vrtnja + 1;


            for (int i = vrtnja; i >= 1; i--)
            {
                if (gotova_dretva1 == i + 1)
                {
                    novaDretva = new Thread(new ThreadStart(ThreadProc));
                    novaDretva.Start();
                    if (brojac_gotovo == rutes.Count / i)
                    {
                        novaDretva.Abort();
                        gotova_dretva1 = i;

                    }
                }
            }






        }

        private void play_MouseHover(object sender, EventArgs e)
        {
            Color plaj_2 = System.Drawing.ColorTranslator.FromHtml("#058bae");
            play.Image = Prototip_OPPlan.Properties.Resources.play_flat;
            play.BackColor = plaj_2;
        }

        private void play_MouseLeave(object sender, EventArgs e)
        {
            Color plaj_1 = System.Drawing.ColorTranslator.FromHtml("#067a9f");
            play.Image = Prototip_OPPlan.Properties.Resources.play_flat2;
            play.BackColor = plaj_1;
        }



        private void delete_mode_Click_1(object sender, EventArgs e)
        {
            if (d_mode == 0)
            {
                Color zelena2 = System.Drawing.ColorTranslator.FromHtml("#05cb74");
                delete_mode.Image = Prototip_OPPlan.Properties.Resources.kantica2;
                delete_mode.BackColor = zelena2;
                klikni_gumb_samosakrij(prviLink);
                klikni_gumb_samosakrij(drugiLink);
                klikni_gumb_samosakrij(treciLink);
                d_mode = 1;
                MessageBox.Show("Sada ste uključili DELETE MODE, kliknete li na bilo koji objekt na karti, on će biti izbrisan!");
            }
            else
            {

                Color zelena1 = System.Drawing.ColorTranslator.FromHtml("#02a35d");
                delete_mode.Image = Prototip_OPPlan.Properties.Resources.kantica;
                delete_mode.BackColor = zelena1;
                d_mode = 0;
                MessageBox.Show("DELETE MODE isključen.");
            }
        }

        private void delete_mode_MouseHover(object sender, EventArgs e)
        {

            Color zelena1 = System.Drawing.ColorTranslator.FromHtml("#02a35d");
            Color zelena2 = System.Drawing.ColorTranslator.FromHtml("#05cb74");

            if (d_mode == 0)
            {
                delete_mode.Image = Prototip_OPPlan.Properties.Resources.kantica2;
                delete_mode.BackColor = zelena2;

            }

            else
            {
                delete_mode.Image = Prototip_OPPlan.Properties.Resources.kantica;
                delete_mode.BackColor = zelena1;


            }
        }

        private void delete_mode_MouseLeave(object sender, EventArgs e)
        {
            Color zelena1 = System.Drawing.ColorTranslator.FromHtml("#02a35d");
            Color zelena2 = System.Drawing.ColorTranslator.FromHtml("#05cb74");

            if (d_mode == 0)
            {
                delete_mode.Image = Prototip_OPPlan.Properties.Resources.kantica;
                delete_mode.BackColor = zelena1;



            }

            else
            {
                delete_mode.Image = Prototip_OPPlan.Properties.Resources.kantica2;
                delete_mode.BackColor = zelena2;

            }
        }

        private void save_MouseHover(object sender, EventArgs e)
        {
            Color zelena1 = System.Drawing.ColorTranslator.FromHtml("#02a35d");
            save.Image = Prototip_OPPlan.Properties.Resources.disketica2;
            save.BackColor = zelena1;
        }

        private void save_MouseLeave(object sender, EventArgs e)
        {
            Color zelena1 = System.Drawing.ColorTranslator.FromHtml("#02b969");
            save.Image = Prototip_OPPlan.Properties.Resources.disketica;
            save.BackColor = zelena1;
        }

        private void save_Click(object sender, EventArgs e)
        {
            frmNaziv formaNaziv = new frmNaziv(2, markeri, rutes);
            formaNaziv.Show();
        }
    }
}
