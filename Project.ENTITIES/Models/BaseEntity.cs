﻿using Project.ENTITIES.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ENTITIES.Models
{
    public abstract class BaseEntity
    {
        public int ID { get; set; }
        public DateTime TimeCreated { get; set; }
        public DateTime? TimeModified { get; set; }
        public DateTime? TimeDeleted { get; set; }
        public DataStatus Status { get; set; }
        public BaseEntity()
        {
            TimeCreated = DateTime.Now;
            Status = DataStatus.Inserted;
        }
    }
}
