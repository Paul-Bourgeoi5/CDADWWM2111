using System;
using System.Text;

namespace DistributeurDeBanque
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;

            Console.SetWindowSize(150, 40);
            Console.WriteLine("Bonjour et bienvenue chez BFS, la Banque de France des Stagiaires pour les stagiaires, par les stagiaires.\n");

            //Tableau à escalier contenant les informations des clients
            //Nom,prénom,mot de passe, montant des comptes et dernière transaction
            string[][] customers = new String[15][];
            DefaultData(ref customers);

            //Tableau pour stocker le nombre de billet
            // Billets : 5,10,20,50,100,200,500
            int[] howManyCash = new int[7];


        }
        public static string GenerateToken()
        {
            string alphaNumeric = "abcdefghijklnmopqrstuvwxyz0123456789";
            StringBuilder addTokenChar = new StringBuilder("", 15);
            Random rand = new Random();

            for (int i = 0; i < addTokenChar.Capacity - 1; i++)
            {
                int indexCharToAdd = rand.Next(0, alphaNumeric.Length);
                char charToAdd = alphaNumeric[indexCharToAdd];
                charToAdd = CharToUpper(charToAdd);
                addTokenChar.Append(charToAdd);
            }
            string finalToken = "";
            finalToken = addTokenChar.ToString();
          /*  Console.WriteLine($"votre token est :{finalToken}");*/

            return finalToken;
        }

    
        public static char CharToUpper(char _charOfMyBuilder)
        {
            if (Char.IsLetter(_charOfMyBuilder))
            {
                string uhu;
                Random randChar = new Random();
                int test = randChar.Next(0, 2);
                if (test == 1)
                {
                    uhu = _charOfMyBuilder.ToString().ToUpper();
                    return uhu[0];
                }
            }
            return _charOfMyBuilder;

        }
        private static bool IsUserIsAuthentification(/*todo*/)
        {
            // todo
            return true;
        }

        private static void ConnectionUser(/*todo*/)
        {
            // todo
        }

        /// <summary>
        /// Show DAB menu & ask user an action.
        /// Execute after user has connected and authentificate
        /// </summary>
        private static void AskUserAction(string[] customer)
        {
            if (!IsUserIsAuthentification())
            {
                ConnectionUser();
            }
            else
            {
                // Acces menu variables
                const int MENU_SHOW_ACCOUNT = 1;
                const int MENU_PRINT_RIB = 2;
                const int MENU_DEPOSIT_CASH = 3;
                const int MENU_WITHDRAW_CASH = 4;
                const int MENU_DEPOSIT_CHEQUE = 5;
                const int MENU_TRANSFER_INTERNAL_ACCOUNT = 6;
                const int MENU_SHOW_INTEREST = 7;
                const int MENU_BUY_ACTIONS = 8;
                const int MENU_DISCONNECT = 9;
                const int MENU_BANK_HEIST = 0;
                const int MIN_MENU_CHOICE = MENU_BANK_HEIST;
                const int MAX_MENU_CHOICE = MENU_DISCONNECT;

                int? userAskMenu;
                bool showAgainMenu;

                // Try to ask user command
                do {
                    showAgainMenu = false;

                    // Show all actions that user can choose
                    Console.WriteLine("Voici les différentes actions possibles :\n");
                    Console.WriteLine($"Afficher le montant disponible sur les comptes ({MENU_SHOW_ACCOUNT})");
                    Console.WriteLine($"Imprimer le RIB ({MENU_PRINT_RIB})");
                    Console.WriteLine($"Déposer un montant ({MENU_DEPOSIT_CASH})");
                    Console.WriteLine($"Retirer un montant ({MENU_WITHDRAW_CASH})");
                    Console.WriteLine($"Déposer un chèque ({MENU_DEPOSIT_CHEQUE})");
                    Console.WriteLine($"Transferer un montant entre comptes internes ({MENU_TRANSFER_INTERNAL_ACCOUNT})");
                    Console.WriteLine($"Voir les interets des livrets ({MENU_SHOW_INTEREST})");
                    Console.WriteLine($"Acheter des actions en mode capitaliste ({MENU_BUY_ACTIONS})");
                    Console.WriteLine($"Se deconnecter ({MENU_DISCONNECT})");

                    try
                    {
                        // Get user action
                        userAskMenu = int.Parse(Console.ReadLine());

                        // Check if user has enter a correct command
                        if (userAskMenu < MIN_MENU_CHOICE || userAskMenu > MAX_MENU_CHOICE)
                        {
                            throw new Exception("Veuillez enter une action valide");
                        }

                        // Choose a correct action from user command
                        switch (userAskMenu)
                        {
                            case MENU_SHOW_ACCOUNT:
                                Program.Status(ref customer);
                                break;
                            case MENU_PRINT_RIB:
                                Program.printRIB(customer);
                                break;
                            case MENU_DEPOSIT_CASH:
                                Program.DepositeCash(
                                    Program.AskUserWhichAccountToMakeAction(),
                                    ref customer
                                );
                                break;
                            case MENU_WITHDRAW_CASH:
                                Program.WithdrawCash(
                                    Program.AskUserWhichAccountToMakeAction(),
                                    ref customer
                                );
                                break;
                            case MENU_DEPOSIT_CHEQUE:
                                Console.WriteLine("En travaux");
                                break;
                            case MENU_TRANSFER_INTERNAL_ACCOUNT:
                                Console.WriteLine("En travaux");
                                break;
                            case MENU_SHOW_INTEREST:
                                Console.WriteLine("En travaux");
                                break;
                            case MENU_BUY_ACTIONS:
                                Console.WriteLine("En travaux");
                                break;
                            case MENU_DISCONNECT:
                                Program.Disconnect();
                                break;
                            case MENU_BANK_HEIST:
                                Program.BankHeist(false, false, 100000, "MagicBus");
                                break;
                            default:
                                throw new Exception();
                        }

                        Console.WriteLine("Voulez vous réaliser de nouvelles actions ? (oui/non)");
                        showAgainMenu = Console.ReadLine().Equals("oui");
                    }
                    // When there is an error
                    catch (Exception)
                    {
                        Console.WriteLine("Erreur : veuillez selectionner une action valide.");
                        showAgainMenu = true;
                    }
                // Re execute menu if user want or if there is an error
                } while (showAgainMenu);
            }
        }

        private static int AskUserWhichAccountToMakeAction()
        {
            int userResponse;

            do
            {
                Console.WriteLine("Sur lequel de votre compte voulez vous réaliser l'action ?");
                try
                {
                    userResponse = int.Parse(Console.ReadLine());

                    if (userResponse < 0)
                    {
                        throw new Exception("Veuillez entrer un compte existant !");
                    }

                    return userResponse;
                }
                catch (Exception error)
                {
                    Console.WriteLine($"Erreur : {error.Message}");
                }
            } while (true);
        }
        /// <summary>
        /// montant disponible sur les comptes
        /// </summary>
        /// <param name="customer"></param>
        public static void Status(ref string[] customer)
        {
            for(int i = 3; i <= customer.Length-2; i++)
            {
                Console.WriteLine(customer[i]);
            }
        }

        public static void printRIB(string[] customer)
        {
            Console.WriteLine(customer[3] +".RIB");
        }

        public static void BankHeist(bool police, bool gun, int team, string pickup = "Rover")
        {
            if (police)
            {
                Console.WriteLine("Je me barre direct et je reviens plus tard !!!!!");
            } 
            else if (team > 5)
            {
                Console.WriteLine("Je dois louer un mini-bus");
            } 
            else if ( police == true && gun == true)
            {
                Console.WriteLine("Je sors mon flingue et je tire dans le tas");
            }
            else
            {
                Console.WriteLine($"Tout se passe bien et je monte dans le {pickup} !");
            }
        }

        public static void DefaultData( ref string[][] customers)
        {
            customers[0] = new string[] { "John", "Doe","****","2000","1000", "+100" };
            customers[1] = new string[] { "Serhat", "Gungor", "****", "1000", "1000", "+200" };
            customers[2] = new string[] { "Paul", "Carlito", "****", "3000", "1000","5", "+500" };
            customers[3] = new string[] { "Pierre", "Bourguignon", "****", "2500", "1000", "+3500" };
            customers[4] = new string[] { "Jacques", "Tartempion", "****", "20000", "100000", "-10000" };
        }

        /// <summary>
        /// Déposer de l'argent sur son compte
        /// </summary>
        /// <param name="numberAccount">Numéro du compte, initialisé à 1</param>
        /// <param name="customer">le client</param>
        /// <returns>le nouveau solde du compte</returns>
        public static int DepositeCash(int numberAccount, ref string[] customer)
        {
            int deposit;
            Console.WriteLine("Déposer combien ?");
            deposit = int.Parse(Console.ReadLine());
            

            customer[2+numberAccount] = (int.Parse(customer[2 + numberAccount]) + deposit).ToString();

            customer[customer.Length - 1] = "+" + deposit;

            return int.Parse(customer[2 + numberAccount]);
        }
        /// <summary>
        /// Retirer de l'argent
        /// </summary>
        /// <param name="numberAccount">Numéro du compte initialisé à 1</param>
        /// <param name="customer">le client</param>
        /// <returns>le nouveau solde du compte</returns>
        public static int WithdrawCash(int numberAccount, ref string[] customer)
        {
            int withdraw;
            Console.WriteLine("Retirer combien ?");
            withdraw = int.Parse(Console.ReadLine());
            customer[2 + numberAccount] = (int.Parse(customer[2 + numberAccount]) - withdraw).ToString();
            customer[customer.Length - 1] = "-" + withdraw;
            return int.Parse(customer[2 + numberAccount]);
        }

        public static void Disconnect()
        {
            Console.WriteLine("Bye bye !");
            Environment.Exit(0);
        }
    }
}
