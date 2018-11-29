using Newtonsoft.Json.Schema;
using System;

    class NF
    {
    public NF()
    {
       // this.schemaNF = schemaNF;
    }


    JSchema schemaNF = JSchema.Parse(@"{
                                        'type': 'object',
                                         'properties': {
                                              'id':  { 'type':'string'},
                                              'numero': {'type':'integer'},
                                              'serie':  { 'type':'string'},
                                              'naturezaOperacao':  { 'type':'string'},
                                              'tipoOperacao':  { 'type':'string'},
                                              'finalidade':  { 'type':'string'},
                                              'nfeReferenciada': {
                                               'chaveAcesso':  { 'type':'string'}
                                              },
                                            'ambienteEmissao':  { 'type':'string'},
                                            'consumidorFinal': {'type':'boolean'},
                                            'indicadorPresencaConsumidor':  { 'type':'string'},
                                            'indicadorFormaPagamento':  { 'type':'string'},
                                            'dataEmissao':  { 'type':'string'},
                                            'transporte': {
                                            'type': 'object',
                                            'properties': {
                                                'frete': {
                                                    'type': 'object',
                                                    'properties': {          
                                                        'modalidade':  { 'type':'string'},
                                                        'valor': {'type':'float'},
                                                       }
                                                   }
                                                }
                                            },
                                            'enderecoEntrega': {
                                            'type': 'object',
                                            'properties': {
                                                    'tipoPessoaDestinatario':  { 'type':'string'},
                                                    'cpfCnpjDestinatario':  { 'type':'string'},
                                                    'pais':  { 'type':'string'},
                                                    'uf':  { 'type':'string'},
                                                    'cidade':  { 'type':'string'},
                                                    'logradouro':  { 'type':'string'},
                                                    'numero':  { 'type':'string'},
                                                    'complemento':  { 'type':'string'},
                                                    'bairro':  { 'type':'string'},
                                                    'cep':  { 'type':'string'}
                                                }
                                            },
                                            'transportadora': {
                                                'type': 'object',
                                                'properties': {
                                                    'usarDadosEmitente': {'type':'boolean'},
                                                    'tipoPessoa':  { 'type':'string'},
                                                    'cpfCnpj':  { 'type':'string'},
                                                    'nome':  { 'type':'string'},
                                                    'inscricaoEstadual':  { 'type':'string'},
                                                    'enderecoCompleto':  { 'type':'string'},
                                                    'uf':  { 'type':'string'},
                                                    'cidade':  { 'type':'string'}
                                                  }
                                            },
                                            'veiculo': { 
                                                'type': 'object',
                                                'properties': {
                                                    'placa':  { 'type':'string'},
                                                    'uf': { 'type':'string'},
                                                }
                                            },
                                            'volume': {
                                                'type': 'object',
                                                'properties': {
                                                    'quantidade': {'type':'integer'},
                                                    'especie':  { 'type':'string'},
                                                    'marca':  { 'type':'string'},
                                                    'numeracao':  { 'type':'string'},
                                                    'pesoBruto': {'type':'float'},
                                                    'pesoLiquido': {'type':'float'}
                                                 }
                                            }
                                     },
                                     'cliente': {
                                        'type': 'object',
                                         'properties': {
                                            'endereco': {
                                                'type': 'object',
                                                'properties': {
                                                    'pais':  { 'type':'string'},
                                                    'uf':  { 'type':'string'},
                                                    'cidade':  { 'type':'string'},
                                                    'logradouro':  { 'type':'string'},
                                                    'numero':  { 'type':'string'},
                                                    'complemento':  { 'type':'string'},
                                                    'bairro':  { 'type':'string'},
                                                    'cep':  { 'type':'string'}
                                                 }
                                             },
                                                'tipoPessoa':  { 'type':'string'},
                                                'nome':  { 'type':'string'},
                                                'email':  { 'type':'string'},
                                                'cpfCnpj':  { 'type':'string'},
                                                'inscricaoMunicipal':  { 'type':'string'},
                                                'inscricaoEstadual':  { 'type':'string'},
                                                'indicadorContribuinteICMS':  { 'type':'string'},
                                                'telefone':  { 'type':'string'}
                                          }
                                      },
                                      'enviarPorEmail': {'type': [ 'boolean', 'null' ]},
                                      'itens': [
                                            {
                                            'type': 'object',
                                             'properties': {
                                                    'cfop':  { 'type':'string'},
                                                    'codigo':  { 'type':'string'},
                                                    'descricao':  { 'type':'string'},
                                                    'sku':  { 'type':'string'},
                                                    'ncm':  { 'type':'string'},
                                                    'cest':  { 'type':'string'},
                                                    'quantidade': {'type':'integer'},
                                                    'unidadeMedida':  { 'type':'string'},
                                                    'valorUnitario': {'type':'float'},
                                                    'impostos': {
                                                        'type': 'object',
                                                        'properties': {
                                                                'percentualAproximadoTributos': {
                                                                'simplificado': {
                                                                    'percentual': {'type':'float'},
                                                                  },
                                                                'detalhado': {
                                                                    'percentualFederal': {'type':'float'},
                                                                    'percentualEstadual': {'type':'float'},
                                                                    'percentualMunicipal': {'type':'float'}
                                                                },
                                                                'fonte': { 'type':'string'},
                                                         },
                                                        'icms': {
                                                            'situacaoTributaria':  { 'type':'string'},
                                                            'origem': {'type':'integer'},
                                                            'aliquota': {'type':'float'},
                                                            'baseCalculo': {'type':'float'},
                                                            'modalidadeBaseCalculo': {'type':'float'},
                                                            'percentualReducaoBaseCalculo': {'type':'float'},
                                                            'baseCalculoST': {'type':'float'},
                                                            'aliquotaST': {'type':'float'},
                                                            'modalidadeBaseCalculoST': {'type':'float'},
                                                            'percentualReducaoBaseCalculoST': {'type':'float'},
                                                            'percentualMargemValorAdicionadoST': {'type':'float'}

                                                        },
                                                        'pis': {
                                                            'situacaoTributaria':  { 'type':'string'}
                                                           },
                                                        'cofins': {
                                                            'situacaoTributaria':  { 'type':'string'}
                                                          },
                                                        'ipi': {
                                                            'porAliquota': {
                                                                'aliquota': {'type':'float'}
                                                               },
                                                              'situacaoTributaria':  { 'type':'string'}
                                                          }
                                                    }
                                                },
                                            }
                                              'informacoesAdicionais':  { 'type':'string'}
                                            }
                                          ],
                                          'informacoesAdicionais':  { 'type':'string'}
                                        }
                                    }");


    
}

