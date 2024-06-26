﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace ChurchManagement.Core.Entidades;

public partial class Tesouraria
{
    public Tesouraria(decimal? caixaFixo)
    {
        CaixaFixo = caixaFixo;
        DataMovimentacoes = DateTime.Now;
    }

    public int IdTesouraria { get; private set; }
    public decimal? CaixaFixo { get; set; }
    public DateTime? DataMovimentacoes { get; set; }

    // Construtor para inicializar com valores padrão
    // Método para adicionar quantidade
    public void AdicionarValor(decimal valor)
    {
        if (CaixaFixo.HasValue)
        {
            CaixaFixo += valor;
        }
        else
        {
            CaixaFixo = valor;
        }
        DataMovimentacoes = DateTime.Now;
    }

    public void RetirarValor(decimal valor)
    {
        if (CaixaFixo.HasValue)
        {
            CaixaFixo -= valor;
        }
        else
        {
            CaixaFixo = -valor;
        }
        DataMovimentacoes = DateTime.Now;
    }
    public void Update(decimal? caixaFixo)
    {
        CaixaFixo = caixaFixo;
        DataMovimentacoes = DateTime.Now;
    }
}