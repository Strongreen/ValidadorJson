﻿using Newtonsoft.Json.Schema;
using System;


        public class NFS
        {

        public NFS()
        {
            // this.schemaNFS = schemaNFS;
        }

        JSchema schemaNFS = JSchema.Parse(@"{
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

    
}
    

