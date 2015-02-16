using System;

namespace Formation.Data.Model
{
    public class Base
    {
        public Guid Id { get; set; }

        public void GenerateId()
        {
            Id = Guid.NewGuid();
        }

        public bool IsNew()
        {
            return Id == default(Guid);
        }
    }
}