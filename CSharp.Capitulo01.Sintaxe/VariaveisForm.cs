using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharp.Capitulo01.Sintaxe
{
    public partial class VariaveisForm : Form
    {
        public VariaveisForm()
        {
            InitializeComponent();
        }

        private void aritmeticasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*Comentário
                Comentário
            Comentário*/

            int x = 42;
            int y;
            string nome = "Vítor";
            char letra = 'a';
            var dataNascimento = new DateTime(2000, 01, 21);
            bool aprovado = true;
            var media = 2M/*.3m*/;
            double distancia = 1.2d;
            float altura = 0.8f;
            long populacao = 2013/*L*/;

            var a = 2;
            var A = 10;
            int b = 6, c = 10, d = 13;

            //c = 9.9m; // estaticamente tipada.

            decimal bim1 = 2.9m;
            string @class = "3A";

            object objeto = "texto";
            objeto = 1;

            //var quantidade = resultadoListBox.Items.Count;
            resultadoListBox.Items.Clear();

            resultadoListBox.Items.Add("a = " + a);
            resultadoListBox.Items.Add(string.Concat("b = ", b/*, "c =", c*/));
            //resultadoListBox.Items.Add(string.Format("c = {0}, d = {1}", c, d));
            resultadoListBox.Items.Add(string.Format("c = {0}", c));
            resultadoListBox.Items.Add($"d = {d}");

            resultadoListBox.Items.Add($"c * d = {c * d}");
            resultadoListBox.Items.Add($"d / a = {d / a}");
            resultadoListBox.Items.Add($"d % a = {d % a}");
        }

        private void reduzidasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //int e = 9;

            resultadoListBox.Items.Clear();

            var x = 5;
            resultadoListBox.Items.Add("x = " + x);

            //x = x - 3;
            x -= 3;

            //x =- 3;
            //x *= 3;
            //x /= 3;

            resultadoListBox.Items.Add("x = " + x);
        }
    }
}
