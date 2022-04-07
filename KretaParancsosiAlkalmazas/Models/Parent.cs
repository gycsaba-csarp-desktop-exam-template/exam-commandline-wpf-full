using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kreta.Models
{
    class Parent
    {
        private int id;
        private string name;
        private bool woomen;

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public bool Woomen { get => woomen; set => woomen = value; }

        public Parent(int id, string name, bool woomen)
        {
            this.id = id;
            this.name = name;
            this.woomen = woomen;
        }

        public Parent()
        {
            this.id = -1;
            this.name = string.Empty;
            this.woomen = true;
        }
    }
}
