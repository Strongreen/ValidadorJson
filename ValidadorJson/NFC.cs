using Newtonsoft.Json.Schema;
using System;

    class NFC
    {

    public NFC()
    {
       //this.schemaNFC = schemaNFC;
    }

    JSchema schemaNFC = JSchema.Parse(@"{ 'type': 'object',
                                               'properties': {
                                                    'id':  { 'type':'string'},
                                                    'ambienteEmissao': { 'type':'string'},
                                                    'pedido': {
                                                        'type': 'object',
                                                        'properties': {
                                                            'presencaConsumidor': { 'type':'string'},
                                                            'pagamento': {
                                                                'tipo': { 'type':'string'},
                                                                'formas': [
                                                                    {
                                                                        'tipo': { 'type':'string'},
                                                                        'valor': {'type':'float'},
                                                                    },
                                                                    {
                                                                        'tipo': { 'type':'string'},
                                                                        'valor': {'type':'float'},
                                                                        'credenciadoraCartao': {
                                                                            'tipoIntegracaoPagamento': { 'type':'string'},
                                                                            'cnpjCredenciadoraCartao': { 'type':'string'},
                                                                            'bandeira': { 'type':'string'},
                                                                            'autorizacao': { 'type':'string'},
                                                                        }
                                                                    }
                                                                  ]
                                                                }
                                                            }
                                                         },
                                                        'cliente': {
                                                          'type': 'object',
                                                          'properties': {
                                                            'tipoPessoa': { 'type':'string'},
                                                            'nome': { 'type':'string'},
                                                            'email': { 'type':'string'},
                                                            'telefone': { 'type':'string'},
                                                            'cpfCnpj': { 'type':'string'},
                                                            'endereco': {
                                                                'type': 'object',
                                                                'properties': {
                                                                    'pais': { 'type':'string'},
                                                                    'uf': { 'type':'string'},
                                                                    'cidade': { 'type':'string'},
                                                                    'logradouro': { 'type':'string'},
                                                                    'numero': { 'type':'string'},
                                                                    'complemento': { 'type':'string'},
                                                                    'bairro': { 'type':'string'},
                                                                    'cep': { 'type':'string'},
                                                                  }
                                                             }
                                                        }
                                                    },
                                                    'enviarPorEmail': {'type': [ 'boolean', 'null' ]},
                                                    'itens': [
                                                        {
                                                        'type': 'object',
                                                        'properties': {
                                                            'cfop': { 'type':'string'},
                                                            'codigo': { 'type':'string'},
                                                            'descricao': { 'type':'string'},
                                                            'ncm': { 'type':'string'},
                                                            'quantidade':  {'type':'integer'},
                                                            'unidadeMedida': { 'type':'string'},
                                                            'valorUnitario': {'type':'float'},
                                                            'descontos': {'type':'float'},
                                                            'impostos': {
   		                                                        'type': 'object',
    		                                                    'properties': {
                                                                    'percentualAproximadoTributos': {
                                                                        'detalhado': {
                                                                        'percentualFederal': {'type':'float'},
                                                                        'percentualEstadual': {'type':'float'},
                                                                        'percentualMunicipal': {'type':'float'},
                                                                    },
                                                                    'fonte': { 'type':'string'},
                                                                    },
                                                                    'icms': {
                                                                        'situacaoTributaria': { 'type':'string'},
                                                                        'origem':  {'type':'integer'},
                                                                        'aliquota': {'type':'float'},
                                                                    }
                                                                }
	                                                        }
	                                                 
                                                         }
                                                      ]
                                                   }
                                                }
                                             }
                                          ");

    
}

