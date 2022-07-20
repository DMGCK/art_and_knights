using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace art_and_knights.Models
{
    public class Artist
    {
        public string Name { get; set; }
        public string Medium { get; set; }
        public string CreatorId {get; set;}

        public Artist (string name, string medium) {
            Name = name;
            Medium = medium;
        }
    }
}