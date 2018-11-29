using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using System;
using System.Collections.Generic;
using System.Text;



class TratamentoErro
    {
 
    public String jsonRecebido;
    public JSchema schema;
    private NF nFe;
    private NFC nFCe;
    private NFS nFSe;

   

        public TratamentoErro(string jsonRecebido, NF nFe, String SetarTexto2)
        {
            this.jsonRecebido = jsonRecebido;
            this.nFe = nFe;

        var parseObj = JObject.Parse(jsonRecebido);

        try
        {

            // tratar o erro se não inserir nada
            var resultadoDoParse = JSchema.Parse(jsonRecebido);

        }
        catch (JsonReaderException ex)
        {
            var lineNumber = ex.LineNumber;
            var linePosition = ex.LinePosition;

            // como chamar o textbox a partir daqui?
             SetarTexto2 = string.Format("JSON inválido na linha {0} e na coluna {1}.", lineNumber, linePosition);

            return;
        }

        IList<ValidationError> errors;

        var valid = parseObj.IsValid(schema, out errors);

        if (valid)
        {
            string formatted = JsonFormatting.Ident(jsonRecebido);
             SetarTexto2 = "JSON Válido";
             SetarTexto2 = formatted.ToString();
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

            SetarTexto2 = strBuilder.ToString();
        }

    
}

        public TratamentoErro(string jsonRecebido, NFC nFCe, String SetarTexto2)
        {
            this.jsonRecebido = jsonRecebido;
            this.nFCe = nFCe;

        var parseObj = JObject.Parse(jsonRecebido);

        try
        {

            // tratar o erro se não inserir nada
            var resultadoDoParse = JSchema.Parse(jsonRecebido);

        }
        catch (JsonReaderException ex)
        {
            var lineNumber = ex.LineNumber;
            var linePosition = ex.LinePosition;

            // como chamar o textbox a partir daqui?
            SetarTexto2 = string.Format("JSON inválido na linha {0} e na coluna {1}.", lineNumber, linePosition);

            return;
        }

        IList<ValidationError> errors;

        var valid = parseObj.IsValid(schema, out errors);

        if (valid)
        {
            string formatted = JsonFormatting.Ident(jsonRecebido);
            SetarTexto2 = "JSON Válido";
            SetarTexto2 = formatted.ToString();
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

            SetarTexto2 = strBuilder.ToString();
        }

    }


        public TratamentoErro(string jsonRecebido, NFS nFSe, String SetarTexto2)
        {
            this.jsonRecebido = jsonRecebido;
            this.nFSe = nFSe;
        var parseObj = JObject.Parse(jsonRecebido);

        try
        {

            // tratar o erro se não inserir nada
            var resultadoDoParse = JSchema.Parse(jsonRecebido);

        }
        catch (JsonReaderException ex)
        {
            var lineNumber = ex.LineNumber;
            var linePosition = ex.LinePosition;

            // como chamar o textbox a partir daqui?
            SetarTexto2 = string.Format("JSON inválido na linha {0} e na coluna {1}.", lineNumber, linePosition);

            return;
        }

        IList<ValidationError> errors;

        var valid = parseObj.IsValid(schema, out errors);

        if (valid)
        {
            string formatted = JsonFormatting.Ident(jsonRecebido);
            SetarTexto2 = "JSON Válido";
            SetarTexto2 = formatted.ToString();
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

   
}
        

    
}

