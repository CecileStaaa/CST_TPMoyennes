using System;

namespace HNI_TPmoyennes
{
    public class Eleve
    {
        public string prenom { get; }
        public string nom { get; }

        private List<Note> notes { get; } = new List<Note>(); //liste des notes de l'élève
        private const int MaxNotes = 200; //nombre de notes max
       
        public Eleve (string Prenom, string Nom)
        {
            prenom = Prenom;
            nom = Nom;
        }

        //méthode pour ajouter les notes de l'élève, dans la limie de 200 notes
        internal void ajouterNote(Note note)
        {
            if (notes.Count < MaxNotes)
            {
                notes.Add(note);
            }
        }

        // calcul de la moyenne d'un élève dans une matière
        public decimal? moyenneMatiere(int matiere)
        {
            var notesMatiere = new List<decimal>();
            foreach (Note note in notes)
            {
                if (note.matiere == matiere)
                    notesMatiere.Add((decimal)note.note);
            }
            if (notesMatiere.Count == 0) return null;
            return Math.Truncate(notesMatiere.Average() * 100) / 100; //renvoie la valeur de la moyenne, tronquée au centième
        }

        // calcul de la moyenne générale de l'élève : moyenne des moyennes par matière
        public decimal? moyenneGeneral()
        {
            var moyennesMatieres = notes.Select(n => n.matiere).Distinct().Select(m => moyenneMatiere(m).GetValueOrDefault()).ToList();
            if (moyennesMatieres.Count == 0) return null;
            return Math.Truncate(moyennesMatieres.Average() * 100) / 100;
        }

    }
   

}

