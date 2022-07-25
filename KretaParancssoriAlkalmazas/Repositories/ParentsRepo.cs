using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Kreta.Models;

namespace Kreta.Repositories
{
    public class ParentsRepo
    {
        private List<Parent> parents;

        public List<Parent> Parents { get => parents; set => parents = value; }

        public List<Parent> GetAllParents()
        {
            return new List<Parent>(parents);
        }

        public ParentsRepo()
        {
            parents = new List<Parent>();
            MakeTestData();
        }

        private void MakeTestData()
        {
            parents.Add(new Parent(1, "Kis", "Szonja", false, new DateTime(1974, 1, 13)));
            parents.Add(new Parent(2, "Nagy", "Imre", false, new DateTime(1974, 7, 7)));
            parents.Add(new Parent(3, "Szabó","Ida", false, new DateTime(1974, 8, 9)));
            parents.Add(new Parent(4, "Szabó","Sándor", false, new DateTime(1974, 11, 24)));
            parents.Add(new Parent(5, "Kis","Éva", true, new DateTime(1974, 9, 9)));
            parents.Add(new Parent(6, "Kertész","Zoltán", false, new DateTime(1974, 10, 19)));
            parents.Add(new Parent(7, "Olajos","Magdolna", true, new DateTime(1974, 8, 30)));
            parents.Add(new Parent(8, "Izgalmas","Márk", false, new DateTime(1974, 5, 9)));
            parents.Add(new Parent(9, "Faégető","Vilmos", false, new DateTime(1974, 3, 2)));
            parents.Add(new Parent(10, "Törödő","Tekla", true, new DateTime(1974, 2, 19)));
            parents.Add(new Parent(11, "Magyar","Helga", true, new DateTime(1974, 7, 8)));
            parents.Add(new Parent(12, "Kertész","László", true, new DateTime(1974, 3, 12)));
        }

        public void DeleteParent(int id)
        {
            Parent parentToDelete = parents.Find(parent => parent.Id == id);
            if (parentToDelete != null)
                parents.Remove(parentToDelete);
        }
    }
}
