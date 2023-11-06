using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace Bingo2E
{

    public partial class FrmBolillero : Form
    {
        static Random rnd;
        List<int> numerosDisponibles;
        List<int> numerosCantados;
        List<FrmCarton> cartones = new List<FrmCarton>();
        public delegate void MiDelegado(int numero);
        public MiDelegado fm;

        public FrmBolillero()
        {
            InitializeComponent();
            rnd = new Random();
            numerosDisponibles = new List<int>();
            numerosCantados = new List<int>();
            SetearEstadoInicial();
        }
        /*
        public void agregarFuncion (MiDelegado func)
        {
            fm += func;
        } 
        */
        private void SetearEstadoInicial()
        {
            numerosCantados.Clear();

            for (int i = 0; i < 100; i++)
            {
                numerosDisponibles.Add(i);
            }
        }

        private int ObtenerNumero()
        {
            int numeroQueSalio = rnd.Next(0, numerosDisponibles.Count);

            numeroQueSalio = numerosDisponibles[numeroQueSalio];

            numerosDisponibles.Remove(numeroQueSalio);

            numerosCantados.Add(numeroQueSalio);

            return numeroQueSalio;
        }

        private void btn_numero_Click(object sender, EventArgs e)
        {
            
            int numero = ObtenerNumero();
            label2.Text = "Ultimo Numero:" + numero.ToString();
            numerosCantados = numerosCantados.OrderBy(n => n).ToList();
            listBox1.Items.Clear();
            foreach (int num in numerosCantados)
            {
                listBox1.Items.Add(num);
            }
            //fm(numero);
            
            foreach (var carton in cartones)
            {
                carton.fm(numero);
                int numerosPendientes = carton.CantidadNumerosPendientes();
                if (numerosPendientes == 0)
                {
                    CantarBingo(carton.nombreJugador);
                }
            }

        }

        public void CantarBingo(string nombre)
        {
            MessageBox.Show("Ganador!!! : " + nombre);

            this.btn_numero.Enabled = false;

        }


        private void FrmBolillero_Load(object sender, EventArgs e)
        {
            /*
            new FrmCarton("Pepe").Show();
            new FrmCarton("Juana").Show();
            new FrmCarton("Caro").Show();
            */
            FrmCarton carton1 = new FrmCarton("Pepe");
            FrmCarton carton2 = new FrmCarton("Juana");
            FrmCarton carton3 = new FrmCarton("Caro");

            cartones.Add(carton1);
            cartones.Add(carton2);
            cartones.Add(carton3);

            foreach (var carton in cartones)
            {
                carton.Show();
            }
        }
    }
}
