using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kreta.Models
{
    public class Student
    {
        private int id;
        private string fullName;
        private int schoolClassId;

        public Student(int id, string fullname, int osztalyId)
        {
            this.Id = id;
            this.FullName = fullname;
            this.SchoolClassId = osztalyId;
        }

        public int Id { get => id; set => id = value; }
        public string FullName { get => fullName; set => fullName = value; }
        public int SchoolClassId { get => schoolClassId; set => schoolClassId = value; }


            //Egy diák megelőzi a másikat, ha a neve előbb van mint a másik diák neve.
            //Ha a két név megegyezik, az a diák van előbb emelyiknek kisebb az id-je.
            //1. feladat: írja meg a teszteket, hogy teljeskörűen lefedjék a feladatot!
            //2. feladat: fejlessze ki a metódust úgy, hogy a teszteknek megfelelően működjön!
            //A metódus -1-et ad vissza, ha a this objektum megelőzi az obj nevű objektumot.
            //A metódus +1-et ad vissza, ha a this objektum követi az obj nevű objektumot.
            //A metódus 0-t ad vissza, ha a két objektum megegyezik.

            //Érje el, hogy az osztály diákjai rendezve jelenjenek meg.

    }
}
