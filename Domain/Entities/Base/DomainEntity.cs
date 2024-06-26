﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Base
{
    public class DomainEntity
    {
        public DateTime? DeletionDate { get; set; }

        public DateTime? ModificationDate { get; set; }

        public DateTime CreationDate { get; set; }

        public void SetDeletionDate() => DeletionDate = DateTime.UtcNow;
        public void SetModificationDate() => ModificationDate = DateTime.UtcNow;
        public void SetCreationDate() => CreationDate = DateTime.UtcNow;
    }
}
