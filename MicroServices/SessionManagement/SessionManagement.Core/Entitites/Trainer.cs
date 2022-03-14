using System;
using System.Collections.Generic;
using System.Text;

namespace SessionManagement.Core.Entitites
{
    public class Trainer : BaseEntity
    {
        public string Name { get; private set; }
        private Trainer()
        {

        }
        public Trainer(long id, string name)
        {
            this.Id = id;
            this.Name = name;
        }
    }
}
