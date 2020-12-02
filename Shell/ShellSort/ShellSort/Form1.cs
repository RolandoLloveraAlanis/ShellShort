using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShellSort
{
    public partial class Form1 : Form
    {
        private static int ArregloObjetos = 15000;
        private Rosticeria[] MiArregloRosticeria = new Rosticeria[ArregloObjetos];
        private Rosticeria[] MiArregloRosticeria2 = new Rosticeria[ArregloObjetos];
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string[] tipoMoneda = { "Peso", "Dollar", "Ambos" };
            string[] domicilio = { "Si", "No" };
            Random ram = new Random();
            Rosticeria r;
            double ProbTrue = 0.2;
            DateTime dt = DateTime.Now;
            for (int i = 0; i < ArregloObjetos; i++)
            {
                r = new Rosticeria();
                r.RFC = Guid.NewGuid().ToString().Substring(0, 13);
                r.Nombre = Guid.NewGuid().ToString().Substring(0, 13);
                r.IngresoAnual = ram.Next(1, 120);
                r.NumEmpleados = ram.Next(1, 10);
                r.Distribuidor = (char)ram.Next('A', 'D');
                r.Inauguracion = dt;
                dt = dt.AddMinutes(1);
                r.ServicioDomicilio = ram.NextDouble() < ProbTrue;
                r.Moneda = tipoMoneda[ram.Next(0, 3)];
                r.Foto = "C:/Users/rolan/Pictures/c930159287293d31eccf3a708dcbe632";

                MiArregloRosticeria[i] = r;

            }
            for (int i = 0; i < ArregloObjetos; i++)
            {
                r = new Rosticeria();
                r.RFC = Guid.NewGuid().ToString().Substring(0, 13);
                r.Nombre = Guid.NewGuid().ToString().Substring(0, 13);
                r.IngresoAnual = ram.Next(1, 120);
                r.NumEmpleados = ram.Next(1, 10);
                r.Distribuidor = (char)ram.Next('A', 'D');
                r.Inauguracion = dt;
                dt = dt.AddMinutes(1);
                r.ServicioDomicilio = ram.NextDouble() < ProbTrue;
                r.Moneda = tipoMoneda[ram.Next(0, 3)];
                r.Foto = "C:/Users/rolan/Pictures/c930159287293d31eccf3a708dcbe632";

                MiArregloRosticeria2[i] = r;

            }
            Mostrar();
            Mostrar2();
        }
        private void Mostrar()
        {
            dgvRosticeria.Rows.Clear();

            foreach (Rosticeria ros in MiArregloRosticeria)
            {
                dgvRosticeria.Rows.Add(ros.RFC, ros.Nombre, ros.IngresoAnual, ros.NumEmpleados, ros.Distribuidor,
                    ros.ConvertirDeboolaString(), ros.Moneda, ros.Inauguracion, ros.Foto);
            }

        }
        private void Mostrar2()
        {
            dgvRosticeria2.Rows.Clear();

            foreach (Rosticeria ros in MiArregloRosticeria2)
            {
                dgvRosticeria2.Rows.Add(ros.RFC, ros.Nombre, ros.IngresoAnual, ros.NumEmpleados, ros.Distribuidor,
                    ros.ConvertirDeboolaString(), ros.Moneda, ros.Inauguracion, ros.Foto);
            }

        }


        private void button2_Click(object sender, EventArgs e)
        {
            Stopwatch stp = Stopwatch.StartNew();
            
            OrdenarShellSort<Rosticeria>(ref MiArregloRosticeria);
            stp.Stop();
            label1.Text = "Shell Sort";
            label1.Text = label1.Text + " Tiempo de ejecución: " + stp.Elapsed.TotalMilliseconds;
            Mostrar();
        }
        public void OrdenarShellSort<Tipo>(ref Tipo[] arreglo) where Tipo : IComparable<Tipo>
        {
            int salto = arreglo.Length / 2;
            while (salto > 0)
            {
                bool bandera = true;
                while (bandera == true)
                {
                    bandera = false;
                    int posicion = 0;
                    while (posicion < (arreglo.Length - salto))
                    {
                        if (arreglo[posicion].CompareTo(arreglo[posicion + salto]) == 1)
                        {
                            Intercambiar(ref arreglo, posicion, posicion + salto);
                            bandera = true;
                        }
                        posicion++;
                    }

                }
                salto = salto / 2;
            }
        }
        void Intercambiar<Tipo>(ref Tipo[] arreglo, int intA, int intB)
        {
            Tipo aux;
            aux = arreglo[intA];
            arreglo[intA] = arreglo[intB];
            arreglo[intB] = aux;
        }

        private void button3_Click(object sender, EventArgs e)
        {

            Stopwatch stp = Stopwatch.StartNew();
          
            OrdenarBurbujaIzquierda<Rosticeria>(ref MiArregloRosticeria2);
            stp.Stop();
            label2.Text = "Burbuja Izquierda";
            label2.Text = label2.Text + " Tiempo de ejecución: " + stp.Elapsed.TotalMilliseconds ;
            Mostrar2();
        }

        public void OrdenarBurbujaIzquierda<Tipo>(ref Tipo[] arreglo) where Tipo : IComparable<Tipo>
        {
            for (int i = 0; i < (arreglo.Length + 1); i++)
            {
                for (int j = (arreglo.Length - 1); j > i; j--)
                {
                    if (arreglo[j].CompareTo(arreglo[j - 1]) == -1)
                    {
                        Intercambiar<Tipo>(ref arreglo, j, (j - 1));
                    }
                }
            }
        }
    }
}
