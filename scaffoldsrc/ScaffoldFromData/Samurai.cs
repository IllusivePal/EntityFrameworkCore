﻿using System;
using System.Collections.Generic;

namespace ScaffoldFromData
{
    public partial class Samurai
    {
        public Samurai()
        {
            Quotes = new HashSet<Quotes>();
            SamuraiBattle = new HashSet<SamuraiBattle>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Quotes> Quotes { get; set; }
        public virtual ICollection<SamuraiBattle> SamuraiBattle { get; set; }
        public virtual SecretIdentity SecretIdentity { get; set; }
    }
}
