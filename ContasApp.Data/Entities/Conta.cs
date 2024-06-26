﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContasApp.Data.Entities
{
    public class Conta
    {
        #region Atributos
        private Guid? _id;
        private string? _nome;
        private DateTime? _dataCriacao;
        private decimal? _valor;
        private string? _tipo;
        private string? _observacao;        
        private string? _categoria;
        #endregion

        #region Métodos
        public Guid? Id { get => _id; set => _id = value; }
        public string? Nome { get => _nome; set => _nome = value; }
        public DateTime? DataCriacao { get => _dataCriacao; set => _dataCriacao = value; }
        public decimal? Valor { get => _valor; set => _valor = value; }
        public string? Tipo { get => _tipo; set => _tipo = value; }
        public string? Observacao { get => _observacao; set => _observacao = value; }        
        public string? Categoria { get => _categoria; set => _categoria = value; }      
        #endregion
    }
}
