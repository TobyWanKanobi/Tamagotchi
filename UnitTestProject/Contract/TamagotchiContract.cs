using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace TamagotchiWcfService.Contract
{
    [DataContract]
    public class TamagotchiContract
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public int Health { get; set; }

        [DataMember]
        public int Hunger { get; set; }

        [DataMember]
        public int Sleep { get; set; }

        [DataMember]
        public int Boredom { get; set; }

        [DataMember]
        public string Status { get; set; }

        [DataMember]
        public int Cooldown { get; set; }

        [DataMember]
        public bool IsAlive { get; set; }

        [DataMember]
        public DateTime LastAccess { get; set; }

        [DataMember]
        public DateTime LastAction { get; set; }
    }
}