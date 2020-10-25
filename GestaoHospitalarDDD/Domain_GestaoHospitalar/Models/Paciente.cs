using Domain_GestaoHospitalar.Entities;
using Domain_GestaoHospitalar.Enuns;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain_GestaoHospitalar.Models
{
    public class Paciente : EntityBase
    {
        public Paciente()
        {
            this.Ativo = true;
        }

        [ForeignKey("EstadoPaciente")]
        [Display(Name ="Estado do Paciente")]
        public Guid EstadoPacienteId { get; set; }
        public EstadoPaciente EstadoPaciente { get; set; }

        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public DateTime DataInternacao { get; set; }
        public string Email { get; set; }
        public bool Ativo { get; set; }
        public string Cpf { get; set; }
        public TipoPaciente TipoPaciente { get; set; }
        public Sexo Sexo { get; set; }
        public string Rg { get; set; }
        public string RgOrgao { get; set; }
        public DateTime RgDataEmissao { get; set; }

        public override string ToString()
        {
            return this.Id + " - " + this.Nome;
        }
    }
}
