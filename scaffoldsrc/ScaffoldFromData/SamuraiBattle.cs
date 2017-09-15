using System;
using System.Collections.Generic;

namespace ScaffoldFromData
{
    public partial class SamuraiBattle
    {
        public int BattleId { get; set; }
        public int SamuraiId { get; set; }

        public virtual Battles Battle { get; set; }
        public virtual Samurais Samurai { get; set; }
    }
}
