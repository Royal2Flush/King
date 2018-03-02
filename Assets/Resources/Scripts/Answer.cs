using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Request
{
    public class Answer
    {
        /*private string text;
        private int changeEnergy;
        private int changeMoney;
        private List<HappinessChange> changeHappiness;
        private string changeRequestImportancy;*/

        private string[] commands;

        public Answer(string onChoice)
        {
            commands = onChoice.Split('|');
        }

        public int Execute()
        {
            int nextDecision = 0;

            foreach (string command in commands)
            {
                string[] commandStructure = command.Split('#');
                string c = commandStructure[0];
                string[] a = new string[commandStructure.Length - 1];
                commandStructure.CopyTo(a, 1);

                switch (c)
                {
                    case "Energy":
                        AddEnergy(a);
                        break;
                    case "Money":
                        AddMoney(a);
                        break;
                    case "GroupHappiness":
                        ChangeGroupHappiness(a);
                        break;
                    case "IndividualHappiness":
                        ChangeHappiness(a);
                        break;
                    case "GroupRequest":
                        break;
                    case "IndividualRequest":
                        break;
                    case "GroupForce":
                        break;
                    case "IndividualForce":
                        break;
                    case "AddCrew":
                        break;
                    case "RemoveCrew":
                        break;
                    case "Next":
                        nextDecision = ParseNextDecision(a);
                        break;
                    case "Other":
                        break;
                    default:
                        Debug.LogError("Unknown command: " + c);
                        break;
                }
            }

            return nextDecision;
        }

        private void AddEnergy(string[] a)
        {
            if (a.Length != 1)
            {
                Debug.LogError("AddEnergy received " + a.Length.ToString() + " arguments but expects 1");
                return;
            } 
            else
            {
                try
                {
                    int number = int.Parse(a[0]); // add Energy
                }
                catch (System.FormatException)
                {
                    Debug.LogError("AddEnergy argument is no Integer!");
                }
            }
        }

        private void AddMoney(string[] a)
        {
            if (a.Length != 1)
            {
                Debug.LogError("AddMoney received " + a.Length.ToString() + " arguments but expects 1");
                return;
            }
            else
            {
                try
                {
                    int number = int.Parse(a[0]); // add Money
                }
                catch (System.FormatException)
                {
                    Debug.LogError("AddMoney argument is no Integer!");
                }
            }
        }

        private void ChangeHappiness(string[] a)
        {
            if(a.Length != 2)
            {
                {
                    Debug.LogError("ChangeHappiness received " + a.Length.ToString() + " arguments but expects 2");
                    return;
                }
            }
            try
            {
                Character.Character.characterDict[a[0]].changeHappiness(int.Parse(a[1]));
            }
            catch (System.FormatException)
            {
                Debug.LogError("ChangeHapiness argument 1 is no Integer!");
                return;
            }
            catch (KeyNotFoundException)
            {
                Debug.LogError("ChangeHapiness argument 0 is " + a[0] + ", but it's not a valid name!");
                return;
            }
        }

        private void ChangeGroupHappiness(string[] a)
        {
            if (a.Length != 2)
            {
                {
                    Debug.LogError("ChangeGroupHappiness received " + a.Length.ToString() + " arguments but expects 2");
                    return;
                }
            }
            try
            {
                foreach(Character.Character c in Character.Character.characterGroupDict[a[0]])
                {
                    c.changeHappiness(int.Parse(a[1]));
                }
            }
            catch (System.FormatException)
            {
                Debug.LogError("ChangeGroupHapiness argument 1 is no Integer!");
                return;
            }
            catch (KeyNotFoundException)
            {
                Debug.LogError("ChangeGroupHapiness argument 0 is " + a[0] + ", but it's not a valid name!");
                return;
            }
        }

        private int ParseNextDecision(string[] a)
        {
            int r = 0;

            if (a.Length != 1)
            {
                Debug.LogError("ParseNextDecision received " + a.Length.ToString() + " arguments but expects 1");
                return 0;
            }
            else
            {
                try
                {
                    r = int.Parse(a[0]);
                }
                catch (System.FormatException)
                {
                    Debug.LogError("ParseNextDecision argument is no Integer!");
                }
            }
            return r;
        }

        /*string text;
        int changeEnergy;
        int changeMoney;
        HappinessChange[] changeHappiness;
        int nextDecision;*/

    }
}