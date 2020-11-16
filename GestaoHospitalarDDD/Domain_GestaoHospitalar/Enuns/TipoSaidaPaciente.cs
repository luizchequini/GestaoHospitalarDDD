using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Domain_GestaoHospitalar.Enuns
{
    public enum TipoSaidaPaciente
    {
        [Description("Recebeu Alta")] Alta = 1,
        [Description("Transferido")] Transferido,
        [Description("Saiu à Revelia")] ARevelia,
        [Description("Veio a Óbito")] Obito,
        Outros
    }
}
