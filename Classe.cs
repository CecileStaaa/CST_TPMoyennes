using System;


namespace HNI_TPmoyennes
{
    public class Classe
    {
        public string nomClasse { get; }
        public List<Eleve> eleves { get; private set; } = new List<Eleve>(); //liste des élèves dans la classe
        private const int MaxEleve = 30;
        public List<string> matieres { get; private set; } = new List<string>(); //liste des matières
        private const int MaxMatiere = 10;

        public Classe(string NomClasse)
        {
            nomClasse = NomClasse;
        }

        public void ajouterEleve(string Prenom, string Nom) //ajout des élèves à la classe, dans la limite de 30 élèves
        {
            if (eleves.Count < MaxEleve)
            {
                eleves.Add(new Eleve(Prenom, Nom));
            }
            
        }

        public void ajouterMatiere(string NomMatiere) //ajout des matières dans la limite de 10
        {
            if (matieres.Count < MaxMatiere)
            {
                matieres.Add(NomMatiere);
            }          
        }

        /* calcul de la moyenne générale dans une matière
         pour chaque élève, calcul de sa moyenne dans la matière, puis moyenne de toutes les moyennes */
       
        public decimal? moyenneMatiere(int matiere)
        {
            List<decimal> moyenneClasseMatiere = new List<decimal>();
            foreach (Eleve eleve in eleves)
            {
                decimal? moyenne = eleve.moyenneMatiere(matiere);
                if (moyenne.HasValue) moyenneClasseMatiere.Add(moyenne.Value);
            }
            if (moyenneClasseMatiere.Count == 0) return null;
            return Math.Truncate((moyenneClasseMatiere.Average() * 100)) / 100;

        }

        // calcul de la moyenne générale de la classe. Calcul de la moyenne de la classe dans chaque matière, puis moyenne des moyennes.
        public decimal? moyenneGeneral()
        {
            List<decimal> moyenneGeneraleClasse = new List<decimal>();
            for (int i = 0; i < matieres.Count; i++)
            {
                decimal? moyenneClasse = moyenneMatiere(i);
                if (moyenneClasse.HasValue) moyenneGeneraleClasse.Add(moyenneClasse.Value);
            }
            if (moyenneGeneraleClasse.Count == 0) return null;
            return Math.Truncate((moyenneGeneraleClasse.Average() * 100)) / 100;

        }

    }
    

}