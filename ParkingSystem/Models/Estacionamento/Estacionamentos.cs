﻿using ParkingSystem.Models.Veiculo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingSystem.Models.Estacionamento
{
    class Estacionamentos : IDisposable
    {

        public enum Campos
        {
            ID,
            IDVAGA,
            IDVEICULO,
            ENTRADA, 
            SAIDA,
            VALORTOTAL
        }

        public int Id { get; set; }
        public Vagas Vaga { get; set; }
        public Veiculos Veiculo { get; set; }
        public DateTime Entrada { get; set; }
        public DateTime? Saida { get; set; }
        public double ValorTotal { get; set; }

        public Estacionamentos()
        {

        }

        public Estacionamentos(int id, Vagas vaga, Veiculos veiculo, DateTime entrada, DateTime? saida, double valor)
        {
            this.Id = id;
            this.Vaga = vaga;
            this.Veiculo = veiculo;
            this.Entrada = entrada;
            this.Saida = saida;
            this.ValorTotal = valor;
        }

        public void Dispose()
        {
            this.Id = 0;
            this.Vaga.Dispose();
            this.Veiculo.Dispose();
            this.ValorTotal = 0;
        }
    }
}