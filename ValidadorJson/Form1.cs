using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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

            JSchema schema = JSchema.Parse(@"{
                                            'type': 'object',
                                            'properties': {
                                                'idExterno': { 'type':'string'},
                                                'ambienteEmissao': { 'type':'string'},
                                                'enviarPorEmail': {'type': [ 'boolean', 'null' ]},
                                                'cliente': {
                                                    'type': 'object',
                                                    'properties': {
                                                        'nome': { 'type':'string'},
                                                        'tipoPessoa': {'type':'string'},
                                                        'email': {'type':[ 'string', 'null' ]},
                                                        'cpfCnpj': {'type':'string'},
                                                        'inscricaoMunicipal': {'type':'string'},
                                                        'inscricaoEstadual': {'type':'string'},
                                                        'telefone': {'type':'string'},
                                                        'endereco': {
                                                            'type': 'object',
                                                            'pais': {'type':'string'},
                                                            'logradouro': {'type':'string'},
                                                            'uf': {'type':'string'},
                                                            'cidade': {'type':'string'},
                                                            'numero': {'type':'string'},
                                                            'complemento': {'type':'string'},
                                                            'bairro': {'type':'string'},
                                                            'cep': {'type':'string'}
                                                           },
                                                        },
                                                    'required': ['nome'],
                                                    'servico': {
                                                        'type': 'object',
                                                        'properties': {
                                                            'descricao': {'type':'string'},
                                                            'aliquotaIss': {'type':'float'},
                                                            'codigoInternoServicoMunicipal': {'type':'integer'},
                                                            'issRetidoFonte': {'type':'boolean'},
                                                            'valorCofins': {'type':'float'},
                                                            'valorCsll': {'type':'float'},
                                                            'valorInss': {'type':'float'},
                                                            'valorIr': {'type':'float'},
                                                            'valorPis': {'type':'float'}
                                                          }
                                                    },
                                                   'valorTotal': {'type':'float'},
                                                 }
                                             },
                                            'required': ['idExterno', 'ambienteEmissao']
                                        }");

            var parseObj = JObject.Parse(jsonRecebido);

            IList<ValidationError> errors;
            var valid = parseObj.IsValid(schema, out errors);

            if (valid)
            {
                string formatted = JsonFormatting.Ident(jsonRecebido);
                textBox2.Text = "JSON Válido";
                textBox1.Text = formatted.ToString();
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
                            error.Value != null ? error.Value.GetType().ToString() : "null",
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
        public class JsonFormatting
        {
            public static string Ident(string jsonRecebido)
            {
                using (var sr = new StringReader(jsonRecebido))
                using (var sw = new StringWriter())
                {
                    var jr = new JsonTextReader(sr);
                    var jw = new JsonTextWriter(sw) { Formatting = Formatting.Indented };
                    jw.WriteToken(jr);
                    return sw.ToString();
                }
            }
        }

      }
}
