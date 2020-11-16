using System.ComponentModel;

namespace Domain_GestaoHospitalar.Enuns
{
    public enum TipoMovimentoPaciente
    {
        [Description("Entrada do Paciente")] Entrada = 1,
        [Description("Saída do Paciente")] Saida

    }
}
