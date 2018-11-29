using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;

namespace ValidadorJson
{
    public partial class Form1 : Form
    {
       
        public Form1()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {

        textBox2.Clear();

         String SetarTexto2 = textBox2.Text;

        var jsonRecebido = textBox1.Text;

            // A partir do index escolhido jogar schemaescolhido

            // TratamentoErro(jsonRecebido,schemaescolhido)

            NF NFe = new NF();
            NFC NFCe = new NFC();
            NFS NFSe = new NFS();

            TratamentoErro TrataNF = new TratamentoErro(jsonRecebido, NFSe, SetarTexto2);
     
        }

        private void SelecioneNF_SelectedIndexChanged(object sender, EventArgs e)
        {
           // Pegar o tipo e para escolher o tipo
        }
    }
}
