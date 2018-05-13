/*
 *  Desarrollado por Edsel Barbosa Gonzalez torby@outlook.com
 * */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OptimizadorDeProcesos
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int aux1LSF, aux2LSF, teLSF, trLSF, Rand, aux1SJF, aux2SJF, telSJF, trSJF;
        Random mAleatorio = new Random();

        private void button1_Click(object sender, EventArgs e)
        {
            aux1LSF = 0; aux2LSF = 0; teLSF = 0; trLSF = 0; Rand = 0;
            aux1SJF = 0; aux2SJF = 0; telSJF = 0; trSJF = 0;
            txtOrdenamientoLSF.Clear();
            txtTiempoDeEsperaLSF.Clear();
            txtTiempoRespuestaLSF.Clear();
            int num = Int32.Parse(txtNoDeProcesos.Text);
            int Quantum = Int32.Parse(txtQuantum.Text);
            int[] mVector = new int[num];
            int[] mVector2 = new int[num];
            int[] mVector3 = new int[num];
            int[] mAuxiliar = new int[num];
            int TrRR = 0, TeRR=0;
            //bool ban = true; 
            for (int mIndice = 0; mIndice < num; mIndice++)
            {
                Rand = mAleatorio.Next(1, 10);
                mVector[mIndice] = Rand;
                mVector2[mIndice] = Rand;
                mVector3[mIndice] = Rand;
            }
            Array.Sort(mVector);
            Array.Sort(mVector2);
            Array.Reverse(mVector2);
            for (int mIndice = 0; mIndice < num; mIndice++)
            {
                txtOrdenamientoLSF.Text += mVector[mIndice].ToString() + Environment.NewLine;
                txtOrdenamientoSJF.Text += mVector2[mIndice].ToString() + Environment.NewLine;
                txtOrdenamientoRR.Text += mVector3[mIndice].ToString() + Environment.NewLine;
            }
            for (int mIndice = 0; mIndice < num; mIndice++)
            {
                teLSF += aux1LSF;
                telSJF += aux1SJF;
                txtTiempoDeEsperaLSF.Text += aux1LSF.ToString() + Environment.NewLine;
                txtTiempoDeEsperaSJF.Text += aux1SJF.ToString() + Environment.NewLine;
                aux1LSF += mVector[mIndice];
                aux1SJF += mVector2[mIndice];
                
            }
            //Round Robin
                for (int mIndice = 0; mIndice < num; mIndice++)
                {

                    if (mVector3[mIndice] > 0)
                    {
                        if (mVector3[mIndice] > Quantum)
                        {
                            mAuxiliar[mIndice] = mVector3[mIndice] - Quantum;
                            txtTiempoRespuestaRR.Text += mAuxiliar[mIndice].ToString() + Environment.NewLine;
                            TrRR += mAuxiliar[mIndice];
                        }
                        else if (mVector3[mIndice] <= Quantum)
                        {
                            txtTiempoRespuestaRR.Text += mAuxiliar[mIndice].ToString() + Environment.NewLine;
                            TrRR += mVector3[mIndice];
                            mAuxiliar[mIndice] = 0;
                        }
                    }
                }

            for (int mIndice = 0; mIndice < num; mIndice++)
            {
                txtTiempoDeEsperaRR.Text += (mVector3[mIndice] - mAuxiliar[mIndice]).ToString() + Environment.NewLine;
                TeRR += (mVector3[mIndice] - mAuxiliar[mIndice]);
            }
            for (int mIndice = 0; mIndice < num; mIndice++)
            {
                aux2LSF += mVector[mIndice];
                aux2SJF += mVector2[mIndice];
                txtTiempoRespuestaLSF.Text += aux2LSF.ToString() + Environment.NewLine;
                txtTiempoRespuestaSJF.Text += aux2SJF.ToString() + Environment.NewLine;
                trLSF += aux2LSF;
                trSJF += aux2SJF;
            }
            txtTeLSF.Text = (teLSF / num).ToString();
            txtTrLSF.Text = (trLSF / num).ToString();
            txtTeSJF.Text = (telSJF / num).ToString();
            txtTrSJF.Text = (trSJF / num).ToString();
            txtTeRR.Text = (TeRR / num).ToString();
            txtTrRR.Text = (TrRR / num).ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }

     }
}
