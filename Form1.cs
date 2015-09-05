using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TESt
{
    public partial class Form1 : Form
    {
        void MassWrite(double[,] A, double[] B )
        {
            
            for (int i = 0; i < 4; i++)
            {
                this.dataGridView1.Rows.Add();
                for (int j = 0; j < 4; j++)
                {
                    this.dataGridView1.Rows[i].Cells[j].Value = (String.Format("{0:0.0}",A[i, j]));
                }
                this.dataGridView1.Rows[i].Cells[4].Value = (String.Format("{0:0.0}",B[i]));
            }

        }
        void FunctinoWork()
        {
            int n = 3;
            double[,] A;
            double[] B;
            double[] X=new double[n+1];
            double[] Z = new double[n+1];
            double[] E = new double[n + 1];
            int[] ArrayCh = new int[n+1];

            A = new double[4, 4] { { -3.0, 4.0, 1.0, 4.0 }, { 0, 1.0, 3.0, 2.0 }, { 4.0, 0, -2.0, -3.0 }, { 1000.0, 3.0, 1.0, -5.0 } };
            B = new double[] { -1.0, -1.0, 4.0, -2.0 };
            MassWrite(A, B);
            //array change
            for (int i = 0; i <= n; i++)
            {
                ArrayCh[i] = i;
            }
            /// Прямой проход
            for (int i = 0; i < n; i++)
            {
                int maxIndx = i;
                double maxval = A[i, i];

                /// Поиск главного элемента в строке
                for (int j = 0; j < n; j++)
                    if (Math.Abs(maxval) < Math.Abs(A[i, j]))
                    {
                        maxval = A[i, j];
                 
                    }
                //перестановка стопчиків
                if (i != maxIndx)
                {
                    
                    for (int k = 0; k <= n; k++)
                    {
                        double c;
                        c = A[k, i];
                        A[k, i] = A[k, maxIndx];
                        A[k, maxIndx] = c;
                    }
                    int tmp = ArrayCh[i];
                    ArrayCh[i] = ArrayCh[maxIndx];
                    ArrayCh[maxIndx] = tmp;
                }
                /// Делим строчку на главный элемент

                double R;
                for (int k = i+1; k <= n; k++)
                {
                    R = A[k, i] / A[i,i];
                    for (int j = i; j <=n; j++)
                    {
                        A[k, j] = A[k, j] - R * A[i,j];
                    }
                        B[k] = B[k] - B[i] * R;
                    
                }

            }
            for (int i = 0; i < 4; i++)
            {
                this.dataGridView3.Rows.Add();
                for (int j = 0; j < 4; j++)
                {
                    this.dataGridView3.Rows[i].Cells[j].Value = (String.Format("{0:0.0}", A[i, j]));
                }
                this.dataGridView3.Rows[i].Cells[4].Value = (String.Format("{0:0.0}", B[i]));
            }
            Z[n] = B[n] / A[n, n];
            for (int i = n - 1; i >= 0; i--)
            {
                double S = 0;
                for (int j = i+1; j <= n; j++)
                {
  S=S+A[i,j]*Z[j];
   Z[i]=(B[i]-S)/A[i,i];
   
                }
            }
          
            for (int i = 0; i<= n; i++)
            {
                X[ArrayCh[i]] = Z[i];
              
            }
            for (int i = 0; i <= n; i++)
            {
                this.dataGridView2.Rows.Add();
                this.dataGridView2.Rows[i].Cells[0].Value = (String.Format("{0:0.00000}",X[i]));
            }
            
  for (int j = 0; j <= n; j++)
            {
           
      double S = 0; 
            for (int i = 0; i <= n; i++)
            {
               S= S + A[j, i] * X[i];
                
            }
       E[j]=S-B[j]; 
      
      this.dataGridView2.Rows[j].Cells[1].Value = (String.Format("{0:0.00E+00}", E[j]));
        }
  }
        public Form1()
        {
            InitializeComponent();
            FunctinoWork();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


    }
}
