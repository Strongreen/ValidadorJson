using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft;
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
            textBox2.Text = "";

            var jsonRecebido = textBox1.Text;

            try
            {
                var resultadoDoParse = JSchema.Parse(jsonRecebido);
            }
            catch (JsonReaderException ex)
            {
                var lineNumber = ex.LineNumber;
                var linePosition = ex.LinePosition;

                textBox2.Text = string.Format("JSON inválido na linha {0} e na coluna {1}.", lineNumber, linePosition);

                return;
            }

            ////////////

            var schema = JSchema.Parse(@"{
                                            'type': 'object',
                                            'properties': {
                                                'idExterno': {'type':'string'},
                                                'ambienteEmissao': {'type':'string'},
                                                'enviarPorEmail': {'type':'boolean'},
                                                'cliente': {
                                                    'type': 'object',
                                                    'properties': {
                                                        'nome': {'type':'string'},
                                                        'endereco': {
                                                            'type': 'object',
                                                            'logradouro': {'type':'string'}
                                                        }
                                                    },
                                                    'required': ['nome']
                                                }
                                            },
                                            'required': ['idExterno', 'ambienteEmissao']
                                        }");

            var parseObj = JObject.Parse(jsonRecebido);

            IList<ValidationError> errors;
            var valid = parseObj.IsValid(schema, out errors);

            if (valid)
            {
                textBox2.Text = "JSON Válido";
            }
            else
            {
                var strBuilder = new StringBuilder();
                foreach (var error in errors)
                {
                    if (error.ErrorType == ErrorType.Type)
                    {
                        strBuilder.AppendLine(string.Format("Erro no campo {0} esperando {1} e veio {2} na linha {3} na coluna {4}",
                            error.Path,
                            error.Schema.Type.Value.ToString(),
                            error.Value.GetType().ToString(),
                            error.LineNumber,
                            error.LinePosition));
                    }
                    else if (error.ErrorType == ErrorType.Required)
                    {
                        var campos = string.Join(",", ((IList<string>)error.Value));

                        if (string.IsNullOrEmpty(error.Path))
                        {
                            strBuilder.AppendLine(string.Format("Campo {0} obrigatório na raiz", campos));
                        }
                        else
                        {
                            strBuilder.AppendLine(string.Format("Campo {0} obrigatório dentro de {1}", campos, error.Path));
                        }
                    }
                }

                textBox2.Text = strBuilder.ToString();
            }







            //var y = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, object>>(x);

            //foreach (var item in y)
            //{
            //    MessageBox.Show(item.Value.ToString());
            //}

            //for (int i = 0; i < y.Count; i++)
            //{
            //    var nomeChave = y.Keys.ElementAt(i).ToString();

            //    MessageBox.Show(y[nomeChave].ToString());
            //}

        }


        class Herika
        {
            public string nome { get; set; }

            public override string ToString()
            {
                return base.ToString();
            }
        }
    }
}
