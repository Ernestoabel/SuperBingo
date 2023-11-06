using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Bingo2E
{
    public partial class FrmCarton : Form
    {
        static Random rnd;
        int cantidadNumerosPendientes;
        public readonly string nombreJugador;
        List<int> numeros;
        Label[] lbls;
        FrmBolillero frmbolilero = new FrmBolillero();
        public delegate void MiDelegado(int numero);
        public MiDelegado fm;


        public FrmCarton(string nombJug)
        {
            cantidadNumerosPendientes = 15;
            rnd = new Random();
            lbls = new Label[15];
            numeros = new List<int>();
            InitializeComponent();
            CargarLabels();
            NumerosRandom();
            CargarNumerosGrilla();
            this.lb_jugador.Text = nombJug;
            this.nombreJugador = nombJug;
            agregarFuncion(TacharNumero);
            agregarFuncion(ActUltNumero);
        }

        public void agregarFuncion(MiDelegado func)
        {
            //frmbolilero.fm += func;
            fm += func;
        }

        void CargarLabels()
        {
            lbls[0] = lbl_num1;
            lbls[1] = lbl_num2;
            lbls[2] = lbl_num3;
            lbls[3] = lbl_num4;
            lbls[4] = lbl_num5;
            lbls[5] = lbl_num6;
            lbls[6] = lbl_num7;
            lbls[7] = lbl_num8;
            lbls[8] = lbl_num9;
            lbls[9] = lbl_num10;
            lbls[10] = lbl_num11;
            lbls[11] = lbl_num12;
            lbls[12] = lbl_num13;
            lbls[13] = lbl_num14;
            lbls[14] = lbl_num15;
        }

        public void ActualizarUltimoNumero(string texto)
        {
            this.lbl_ultimoNum.Text = texto;
        }

        void NumerosRandom()
        {
            for (int i = 0; i < 15; i++)
            {
                int num = rnd.Next(0, 100);

                while (numeros.Contains(num))
                {
                    num = rnd.Next(0, 100);
                }
                numeros.Add(num);
            }

        }

        void CargarNumerosGrilla()
        {
            numeros.Sort();

            for (int i = 0; i < numeros.Count; i++)
            {
                lbls[i].Text = numeros[i].ToString();
            }
        }

        public void TacharNumero(int numero)
        {
            for (int i = 0; i < numeros.Count; i++)
            {
                if (numero == numeros[i])
                {
                    lbls[i].BackColor = Color.Green;
                    cantidadNumerosPendientes--;
                }
            }

        }

        public int CantidadNumerosPendientes()
        {
            int numerosPendientes = 0;

            foreach (Label lbl in lbls)
            {
                if (lbl.BackColor != Color.Green)
                {
                    numerosPendientes++;
                }
            }
            return numerosPendientes;
        }

        public void ActUltNumero(int numero)
        {
            string number = numero.ToString();
            ActualizarUltimoNumero(number);
        }

        private void FrmCarton_Load(object sender, EventArgs e)
        {
        }
    }

}
