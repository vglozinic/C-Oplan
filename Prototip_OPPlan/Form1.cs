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

using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms.Markers;
using GMap.NET.WindowsForms.ToolTips;

namespace Prototip_OPPlan
{
    public partial class Form1 : Form
    {


        public class podaci
        {

            public string imena;
            public string prezimena;
            public string vrsta;
            public double korX;
            public double korY;
        }


        public class temp
        {
            public double korX;
            public double korY;

        }

        public class rute
        {
            public int id_rute;
            public double start_X;
            public double tstart_X;
            public double tstart_Y;
            public double start_Y;
            public double finish_X;
            public double finish_Y;
            public string ime_markera;
            public double vektor_a;
            public double vektor_b;
            public double duzina;
            public int gotovo = 0;

        }



        GMapOverlay overlayOne;
        GMapOverlay sloj2 = new GMapOverlay("OverlayTwo");
        String country;
        String TheChosenOne;
        String marker_ruta;

        List<podaci> markeri = new List<podaci>();
        List<rute> rutes = new List<rute>();
        int brojac_gotovo = 0;
        int id;
        int idRute_povecaj = 0;

        public delegate void Dmarker(double s_x, double s_y);
        temp temporary = new temp();


        public Form1()
        {
            InitializeComponent();
        }

        private void gMapControl1_Load(object sender, EventArgs e)
        {
            gMapControl1.DragButton = MouseButtons.Left;
            gMapControl1.CanDragMap = true;
            gMapControl1.SetPositionByKeywords("Paris");
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
            strana.Items.Add("nasi");
            strana.Items.Add("neprijatelj");
            mr.Items.Add("marker");
            mr.Items.Add("rute");
            konacno.Text += " \r \r";
            konacno.Text += "Postavljanje markera:" + " \r";
            konacno.Text += "1. Definirati ime i vrstu markera i dodati ga u izbornik"+ "\r";
            konacno.Text += "2. Izabrati marker iz izbornika i definirati da li je prijatelj/neprijatelj"+ "\r";
            konacno.Text += "3. Definirati da li želite postaviti rutu ili marker"+ "\r";
            konacno.Text += "4. DOUBLE CLICK na poziciju gdje želite postaviti marker"+ "\r"+"\r";

            konacno.Text += "Postavljanje rute:" + " \r";
            konacno.Text += "1. Definirati da želiš postaviti rutu a ne marker" + "\r";
            konacno.Text += "2. CLICK na marker ili na već postavljenu rutu kojoj želiš pridodati novu (početna točka rute)" + "\r";
            konacno.Text += "4. DOUBLE CLICK na poziciju gdje želiš da nova ruta završava (završna točka rute)" + "\r" + "\r";

            konacno.Text += "NAPOMENA: na kartu se ne smije zapiknuti dva puta isti marker na različite pozicije, nisam još sredila taj dio, ali bude.." + "\r" + "\r";
        }


        private void gMapControl1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            double X = gMapControl1.FromLocalToLatLng(e.X, e.Y).Lng;
            double Y = gMapControl1.FromLocalToLatLng(e.X, e.Y).Lat;
            if (mr.Text == "marker")
            {


                gMapControl1.Position = new PointLatLng(Y, X);
                GMarkerGoogle marker;
                if (strana.Text == "neprijatelj")
                {
                    marker = new GMarkerGoogle(gMapControl1.Position, GMarkerGoogleType.pink);
                }
                else {
                    marker = new GMarkerGoogle(gMapControl1.Position, GMarkerGoogleType.blue);

                }

                TheChosenOne = comboBox1.Text;
                marker.ToolTipText = TheChosenOne;
                overlayOne.Markers.Add(marker);
                gMapControl1.Overlays.Add(overlayOne);
                markeri.Where(podaci => podaci.imena == TheChosenOne).First().korX = X;
                markeri.Where(podaci => podaci.imena == TheChosenOne).First().korY = Y;
                if (strana.Text == "neprijatelj")
                {
                    markeri.Where(podaci => podaci.imena == TheChosenOne).First().vrsta = "enemy";
                }
                else
                {
                    markeri.Where(podaci => podaci.imena == TheChosenOne).First().vrsta = "our_team";
                }


            }

            else if (mr.Text == "rute")
            {
                if (marker_ruta == null) {

                    MessageBox.Show("Moraš prvo kreirati barem jedan marker da bi mu mogao dodijeliti rutu...");
                }
                else { 
                rute nova_rute = new rute();
                nova_rute.start_X = temporary.korY;
                nova_rute.tstart_X = temporary.korY;
                nova_rute.start_Y = temporary.korX;
                nova_rute.tstart_Y = temporary.korX;
                nova_rute.finish_X = Y;
                nova_rute.finish_Y = X;
                idRute_povecaj++;
                nova_rute.id_rute = idRute_povecaj;
                nova_rute.ime_markera = marker_ruta;
                rutes.Add(nova_rute);
                List<PointLatLng> rutice = new List<PointLatLng>();
                PointLatLng start = new PointLatLng(temporary.korY, temporary.korX);
                PointLatLng end = new PointLatLng(Y, X);
                rutice.Add(start);
                rutice.Add(end);
                var r = new GMap.NET.WindowsForms.GMapRoute(rutice, "MyRoute");
                r.Name = Convert.ToString(idRute_povecaj);
                r.Stroke.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                r.IsHitTestVisible = true;
                GMapOverlay routesOverlay = new GMapOverlay("routes");
                routesOverlay.Routes.Add(r);
                gMapControl1.Overlays.Add(routesOverlay);
                gMapControl1.Zoom += 0.1;
                gMapControl1.Zoom -= 0.1;
                }
            }

            else
            {

                MessageBox.Show("Feel the nope!! Moraš il rute il markere odabrati za postavljanje.. :)");

            }
        }

        private void dodaj_Click(object sender, EventArgs e)
        {
            markeri.Add(new podaci { imena = ime.Text, prezimena = prez.Text });
            comboBox1.Items.Add(ime.Text);
        }

        private void izvj_Click(object sender, EventArgs e)
        {
            konacno.Text += " Plan napada:PARIS";

            for (int i = 0; i < rutes.Count; i++)
            {

                konacno.Text += " \r \r";
                konacno.Text += "Ime rute: " + rutes[i].id_rute + " \r";
                konacno.Text += "Marker kojem pripada: " + rutes[i].ime_markera + "\r" + "\r";



            }
        }

        private void gMapControl1_OnMarkerClick(GMapMarker item, MouseEventArgs e)
        {
            marker_ruta = item.ToolTipText;
            double X = gMapControl1.FromLocalToLatLng(e.X, e.Y).Lng;
            double Y = gMapControl1.FromLocalToLatLng(e.X, e.Y).Lat;
            temporary.korX = X;
            temporary.korY = Y;
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


        private void play_Click(object sender, EventArgs e)
        {
            gMapControl1.Zoom = 9;







            for (int i = 0; i < rutes.Count; i++)
            {
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

            var startKordinate = vratiPocetneTocke(item.Name);
            temporary.korX = startKordinate.Item2;
            temporary.korY = startKordinate.Item1;
        }
    }
}
