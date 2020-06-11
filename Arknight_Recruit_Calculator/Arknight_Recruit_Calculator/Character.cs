using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arknight_Recruit_Calculator
{
    public class Character : IEquatable<Character>
    {
        public string OP_Name { get; set; }
        public int Star_Rarity { get; set; }

        public Character(string name, int star)
        {
            OP_Name = name;
            Star_Rarity = star;
        }

        public bool Equals(Character other)
        {
            return this.OP_Name.Equals(other.OP_Name) && this.Star_Rarity.Equals(other.Star_Rarity);
        }

        public static bool operator ==(Character a, Character b)
        {
            return a.OP_Name.Equals(b.OP_Name) && a.Star_Rarity.Equals(b.Star_Rarity);
        }

        public static bool operator !=(Character a, Character b)
        {
            return !(a == b);
        }

    }
}
