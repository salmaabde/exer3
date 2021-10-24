using System;
using System.Collections.Generic;
using System.Text;

namespace exer3
{
    class Etudiant
    {
        public string nom;
        public string prenom;
        public float noteMoye;

        public Etudiant(string nomE, string prenomE, float noteMoyeE)
        {
            nom = nomE;
            prenom = prenomE;
            noteMoye = noteMoyeE;
        }
    }
}
