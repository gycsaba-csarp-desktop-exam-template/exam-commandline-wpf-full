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
            parents.Add(new Parent(1, "Kis Szonja", true));
            parents.Add(new Parent(2, "Nagy Imre", false));
            parents.Add(new Parent(3, "Szabó Ida", true));
            parents.Add(new Parent(4, "Szabó Sándor", false));
            parents.Add(new Parent(5, "Kis Éva", true));
            parents.Add(new Parent(6, "Kertész Zoltán", false));
            parents.Add(new Parent(7, "Olajos Magdolna", true));
            parents.Add(new Parent(8, "Izgalmas Márk", false));
            parents.Add(new Parent(9, "Faégető Vilmos", false));
            parents.Add(new Parent(10, "Törödő Tekla", true));
            parents.Add(new Parent(11, "Magyar Helga", true));
            parents.Add(new Parent(12, "Kertész László", true));
        }

        public void DeleteParent(int id)
        {
            Parent parentToDelete = parents.Find(parent => parent.Id == id);
            if (parentToDelete != null)
                parents.Remove(parentToDelete);
        }
    }
}
