using System;
using System.Collections.Generic;
namespace exer3
{
    class Program
    {
        static void Main(string[] args)

        {
            Console.WriteLine("veuillez entrer le nombre des etudiants: ");
            int nbrE = int.Parse(Console.ReadLine());

            Option genieLogiciel = new Option();
            genieLogiciel.nom = "GL";
            Console.WriteLine("veuillez entrer le nombre des places disponibles dans genie logiciel :");
            genieLogiciel.placesDispo = int.Parse(Console.ReadLine());

            Option AdministrationBaseDonnées = new Option();
            AdministrationBaseDonnées.nom = "ABD";
            Console.WriteLine("veuillez entrer le nombre des places disponibles dans ABD :");
            AdministrationBaseDonnées.placesDispo = int.Parse(Console.ReadLine());

            Option AdministrationSystemeReseau = new Option();
            AdministrationSystemeReseau.nom = "ASR";
            Console.WriteLine("veuilez entrer le nombre des places disponibles dans ASR :");
            AdministrationSystemeReseau.placesDispo = int.Parse(Console.ReadLine());

            var list = new List<Tuple<Etudiant, string, string, string>>();

            for (int i = 0; i < nbrE; i++)
            {
                Console.WriteLine("veuillez entrer le nom d'etudiant");
                string nomEt = Console.ReadLine();
                Console.WriteLine("veuillez entrer le prenom d'etudiant");
                string prenomEt = Console.ReadLine();
                Console.WriteLine("veuillez entrer la note d'etudiant de 1ère année :");
                float noteMoyeEt = float.Parse(Console.ReadLine());
                Etudiant etudiant = new Etudiant(nomEt, prenomEt, noteMoyeEt);

                Console.WriteLine("veuillez entrer le premier choix ");
                string op1 = Console.ReadLine();
                Console.WriteLine("entrez le deuxieme choix");
                string op2 = Console.ReadLine();
                Console.WriteLine("entrez le troisieme choix");
                string op3 = Console.ReadLine();


                var tuple = Tuple.Create(etudiant, op1, op2, op3);
                list.Add(tuple);

            }
            list.Sort(delegate (Tuple<Etudiant, string, string, string> et1, Tuple<Etudiant, string, string, string> et2) {
                return et2.Item1.noteMoye.CompareTo(et1.Item1.noteMoye);
            });


            var listEtGL = new List<Etudiant>();
            var listEtABD = new List<Etudiant>();
            var listEtASR = new List<Etudiant>();

            for (int J = 0; J < nbrE; J++)
            {
                switch (list[J].Item2)
                {
                    case "GL":
                        if (genieLogiciel.placesDispo > 0)
                        {
                            Etudiant item1 = list[J].Item1;
                            listEtGL.Add(item1);
                            --genieLogiciel.placesDispo;
                        }
                        else
                        {

                            switch (list[J].Item3)
                            {
                                case "ABD":
                                    if (AdministrationBaseDonnées.placesDispo > 0)
                                    {
                                        Etudiant item2 = list[J].Item1;
                                        listEtABD.Add(item2);
                                        --AdministrationBaseDonnées.placesDispo;
                                    }
                                    else
                                    {
                                        if (list[J].Item4 == "ASR" && AdministrationSystemeReseau.placesDispo > 0)
                                        {
                                            Etudiant item3 = list[J].Item1;
                                            listEtASR.Add(item3);
                                            --AdministrationSystemeReseau.placesDispo;
                                        }
                                    }
                                    break;

                                case "ASR":
                                    if (AdministrationSystemeReseau.placesDispo > 0)
                                    {
                                        Etudiant item2 = list[J].Item1;
                                        listEtASR.Add(item2);
                                        --AdministrationSystemeReseau.placesDispo;
                                    }
                                    else
                                    {
                                        if (list[J].Item4 == "ABD" && AdministrationBaseDonnées.placesDispo > 0)
                                        {
                                            Etudiant item3 = list[J].Item1;
                                            listEtABD.Add(item3);
                                            --AdministrationBaseDonnées.placesDispo;
                                        }
                                    }
                                    break;
                            }

                        }
                        break;

                    case "ABD":
                        if (AdministrationBaseDonnées.placesDispo > 0)
                        {
                            Etudiant item1 = list[J].Item1;
                            listEtABD.Add(item1);
                            --AdministrationBaseDonnées.placesDispo;
                        }
                        else
                        {

                            switch (list[J].Item3)
                            {
                                case "GL":
                                    if (genieLogiciel.placesDispo > 0)
                                    {
                                        Etudiant item2 = list[J].Item1;
                                        listEtGL.Add(item2);
                                        --genieLogiciel.placesDispo;
                                    }
                                    else
                                    {
                                        if (list[J].Item4 == "ASR" && AdministrationSystemeReseau.placesDispo > 0)
                                        {
                                            Etudiant item3 = list[J].Item1;
                                            listEtASR.Add(item3);
                                            --AdministrationSystemeReseau.placesDispo;
                                        }
                                    }
                                    break;

                                case "ASR":
                                    if (AdministrationSystemeReseau.placesDispo > 0)
                                    {
                                        Etudiant item2 = list[J].Item1;
                                        listEtASR.Add(item2);
                                        --AdministrationSystemeReseau.placesDispo;
                                    }
                                    else
                                    {
                                        if (list[J].Item4 == "GL" && genieLogiciel.placesDispo > 0)
                                        {
                                            Etudiant item3 = list[J].Item1;
                                            listEtGL.Add(item3);
                                            --genieLogiciel.placesDispo;
                                        }
                                    }
                                    break;
                            }

                        }
                        break;

                    case "ASR":
                        if (AdministrationSystemeReseau.placesDispo > 0)
                        {
                            Etudiant item1 = list[J].Item1;
                            listEtASR.Add(item1);
                            --AdministrationSystemeReseau.placesDispo;
                        }
                        else
                        {

                            switch (list[J].Item3)
                            {
                                case "ABD":
                                    if (AdministrationBaseDonnées.placesDispo > 0)
                                    {
                                        Etudiant item2 = list[J].Item1;
                                        listEtABD.Add(item2);
                                        --AdministrationBaseDonnées.placesDispo;
                                    }
                                    else
                                    {
                                        if (list[J].Item4 == "GL" && genieLogiciel.placesDispo > 0)
                                        {
                                            Etudiant item3 = list[J].Item1;
                                            listEtGL.Add(item3);
                                            --genieLogiciel.placesDispo;
                                        }
                                    }
                                    break;

                                case "GL":
                                    if (genieLogiciel.placesDispo > 0)
                                    {
                                        Etudiant item2 = list[J].Item1;
                                        listEtGL.Add(item2);
                                        --genieLogiciel.placesDispo;
                                    }
                                    else
                                    {
                                        if (list[J].Item4 == "ABD" && AdministrationBaseDonnées.placesDispo > 0)
                                        {
                                            Etudiant item3 = list[J].Item1;
                                            listEtABD.Add(item3);
                                            --AdministrationBaseDonnées.placesDispo;
                                        }
                                    }
                                    break;
                            }

                        }
                        break;

                }

            }

            // affichage de la liste finale
            Console.WriteLine("la liste de GL :");
            foreach (Etudiant item in listEtGL)
            {
                Console.WriteLine(item.nom + "\t" + item.prenom + "\t" + item.noteMoye);
            }
            Console.WriteLine("/////////////////////////////////////////////////");
            Console.WriteLine("la liste de ABD :");
            foreach (Etudiant item1 in listEtABD)
            {
                Console.WriteLine(item1.nom + "\t" + item1.prenom + "\t" + item1.noteMoye);
            }
            Console.WriteLine("/////////////////////////////////////////////////");
            Console.WriteLine("la liste de ASR :");

            foreach (Etudiant item2 in listEtASR)
            {
                Console.WriteLine(item2.nom + "\t" + item2.prenom + "\t" + item2.noteMoye);
            }
        }

    }
}



