using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.IO;

namespace Character
{
    public class CharacterManager
    {
        public Dictionary<string, Character> characterDict;
        public Dictionary<string, List<Character>> characterGroupDict;

        public CharacterManager()
        {
            
        }

        public void LoadCharacters()
        {
            const string relativePath = "/Resources/Art/Characters/";
            string[] filenames = Directory.GetFiles(Application.dataPath + relativePath, "*.png").Select(Path.GetFileName).ToArray();

            foreach (string file in filenames)
            {
                StreamReader sr = new StreamReader(Application.dataPath + relativePath + file);
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    /*Request r = new Request(speechbubble);
                    r.Initialize(line);
                    requestList.Add(r.attributes[RequestAttribute.ID], r);*/
                }
            }
        }
    }
}