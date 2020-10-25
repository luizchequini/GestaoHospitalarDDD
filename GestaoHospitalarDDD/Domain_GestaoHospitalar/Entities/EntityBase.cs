using System;

namespace Domain_GestaoHospitalar.Entities
{
    public class EntityBase
    {
        public EntityBase()
        {
            this.Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
    }
}
