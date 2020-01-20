using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BarraProgresso
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.BackColor = this.label1.BackColor;
            this.TransparencyKey = this.label1.BackColor;

        }

        private void Timer1_Tick(object sender, EventArgs e)
        {

            if (progressBar1.Value < 100)
            {
                progressBar1.Value = progressBar1.Value + 2;
            }
            if (progressBar1.Value == 100)
            {
                Principal frmPrincipal = new Principal();
                frmPrincipal.Show(); // abre o form principal
                timer1.Stop();       // para o relógio
                this.Hide();         //fecha a janela após completar os 100%
            }

            if (progressBar1.Value == 10)
            {

                System.Uri Url = new System.Uri("http://www.google.com"); //é sempre bom por um site que costuma estar sempre on para testar a conexão
                System.Net.WebRequest WebReq;
                System.Net.WebResponse Resp;
                WebReq = System.Net.WebRequest.Create(Url);

                try
                {
                    Resp = WebReq.GetResponse();
                    Resp.Close();
                    WebReq = null;
                }
                catch
                {
                    timer1.Stop(); // para o relógio em caso de erro
                    MessageBox.Show("Não existe conexão com a internet.");
                    this.Dispose(); // encerra o sistema
                }
            }

        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
