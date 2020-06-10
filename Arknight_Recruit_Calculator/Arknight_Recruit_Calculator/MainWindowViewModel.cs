﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Arknight_Recruit_Calculator
{
    public class Character
    {
        public string OP_Name { get; set; }
        public int Star_Rarity { get; set; }

        public Character(string name, int star)
        {
            OP_Name = name;
            Star_Rarity = star;
        }
    }

    public class MainWindowViewModel : BaseViewModel
    {
        //recruitment tags
        #region tags
        List<Character> guard = new List<Character>();
        List<Character> dps = new List<Character>();
        List<Character> survival = new List<Character>();
        List<Character> debuff = new List<Character>();
        List<Character> healing = new List<Character>();
        #endregion tags

        //Dictionary for tag access
        private Dictionary<string, List<Character>> recruit_tags = new Dictionary<string, List<Character>>();

        //Dictionary of tag buttons for UI
        private Dictionary<string, bool> ui_Buttons = new Dictionary<string, bool>();
        private List<string> results = new List<string>();
        private string _stringResult;

        #region Properties

        public string StringResult
        {
            get
            {
                return _stringResult;
            }
            set
            {
                _stringResult = value;
                OnPropertyChanged(nameof(StringResult));
            }
        }

        #endregion Properties
        private ICommand _checkCommand;
        public MainWindowViewModel()
        {
            //Hard coded tags 
            #region Initialize tags
            #region guard
            guard.Add(new Character("Specter", 5));
            guard.Add(new Character("Indra", 5));
            guard.Add(new Character("Doberman", 4));
            guard.Add(new Character("Estelle", 4));
            guard.Add(new Character("Mousse", 4));
            guard.Add(new Character("Frostleaf", 4));
            guard.Add(new Character("Matoimaru", 4));
            guard.Add(new Character("Melantha", 3));
            guard.Add(new Character("Castle-3", 2));
            #endregion guard
            #region dps
            dps.Add(new Character("Manticore", 5));
            dps.Add(new Character("Cliffheart", 5));
            dps.Add(new Character("Provence", 5));
            dps.Add(new Character("Blue Poison", 5));
            dps.Add(new Character("Firewatch", 5));
            dps.Add(new Character("Platinum", 5));
            dps.Add(new Character("Istina", 5));
            dps.Add(new Character("Indra", 5));
            dps.Add(new Character("Vulcan", 5));
            dps.Add(new Character("Scanvenger", 4));
            dps.Add(new Character("Vigna", 4));
            dps.Add(new Character("Haze", 4));
            dps.Add(new Character("Meteor", 4));
            dps.Add(new Character("Jessica", 4));
            dps.Add(new Character("Doberman", 4));
            dps.Add(new Character("Mousse", 4));
            dps.Add(new Character("Frostleaf", 4));
            dps.Add(new Character("Matoimaru", 4));
            dps.Add(new Character("Plume", 3));
            dps.Add(new Character("Steward", 3));
            dps.Add(new Character("Kroos", 3));
            dps.Add(new Character("Adnachiel", 3));
            dps.Add(new Character("Melantha", 3));
            #endregion dps
            #region survival
            survival.Add(new Character("Manticore", 5));
            survival.Add(new Character("Specter", 5));
            survival.Add(new Character("Indra", 5));
            survival.Add(new Character("Vulcan", 5));
            survival.Add(new Character("Jessica", 4));
            survival.Add(new Character("Estelle", 4));
            survival.Add(new Character("Matoimaru", 4));
            survival.Add(new Character("Melantha", 3));
            #endregion survival
            #region debuff
            debuff.Add(new Character("Meteorite", 5));
            debuff.Add(new Character("Pramanix", 5));
            debuff.Add(new Character("Haze", 4));
            debuff.Add(new Character("Meteor", 4));
            #endregion debuff
            #region healing
            healing.Add(new Character("Ptilopsis", 5));
            healing.Add(new Character("Silence", 5));
            healing.Add(new Character("Warfarin", 5));
            healing.Add(new Character("Nearl", 5));
            healing.Add(new Character("Myrrh", 4));
            healing.Add(new Character("Perfumer", 4));
            healing.Add(new Character("Gummy", 4));
            healing.Add(new Character("Hibiscus", 3));
            healing.Add(new Character("Ansel", 3));
            healing.Add(new Character("Lancet-2", 2));
            #endregion healing
            #endregion Initialize tags
            //Dict of tags, Used to access tags via comparison from user_input list of strings
            #region recruit_tags
            recruit_tags.Add("guard", guard);
            recruit_tags.Add("dps", dps);
            recruit_tags.Add("survival", survival);
            recruit_tags.Add("debuff", debuff);
            recruit_tags.Add("healing", healing);
            #endregion recruit_tags
        }

        #region function
        void generate_tags(List<string> user_input)
        {
            string line;
            for (int a = 0; a < user_input.Count; ++a)
            {
                if (recruit_tags[user_input[a]].Count > 0)
                {
                    line = "[ " + user_input[a] + " ]";
                    results.Add(line);
                    results.Add(result_To_List(recruit_tags[user_input[a]]));
                    line = "";
                }
                for (int b = a + 1; b < user_input.Count; ++b)
                {
                    List<Character> ab = new List<Character>();
                    ab = compare_tags(recruit_tags[user_input[a]], recruit_tags[user_input[b]]);
                    if (ab.Count > 0)
                    {
                        line = "[ " + user_input[a] + " + " + user_input[b] +  " ]";
                        results.Add(line);
                        results.Add(result_To_List(ab));
                        line = "";
                    }
                    for (int c = b + 1; c < user_input.Count; ++c)
                    {
                        List<Character> abc = new List<Character>();
                        abc = compare_tags(ab, recruit_tags[user_input[c]]);
                        if (abc.Count > 0)
                        {
                            line = "[ " + user_input[a] + " + " + user_input[b] + " + " + user_input[c] + " ]";
                            results.Add(line);
                            results.Add(result_To_List(abc));
                            line = "";
                        }
                    }
                }
            }
        }

        string result_To_List(List<Character> tag)
        {
            string results = "";

            for (int i = 0; i < tag.Count - 1; ++i)
            {
                results += tag[i].OP_Name + " , ";
            }
            results += tag[tag.Count - 1].OP_Name;
            return results;
        }

        string result_To_String(List<string> results)
        {
            string resultString = "";

            for (int i = 0; i < results.Count; ++i)
            {
                resultString += results[i] + "\n";
            }

            return resultString;
        }
        List<Character> compare_tags(List<Character> tag1, List<Character> tag2)
        {
            List<Character> tag3 = new List<Character>();

            for (int i = 0; i < tag1.Count; ++i)
            {
                for (int x = 0; x < tag2.Count; ++x)
                {
                    if (tag1[i].OP_Name == tag2[x].OP_Name)
                    {
                        tag3.Add(new Character(tag1[i].OP_Name, tag1[i].Star_Rarity));
                    }
                }
            }
            return tag3;
        }
        #endregion function

        #region Commands

        public ICommand CheckCommand
        {
            get
            {
                if (_checkCommand == null)
                {
                    _checkCommand = new DoCommand<string>(CheckFunction);
                }
                return _checkCommand;
            }
        }
        private void CheckFunction(string viewparam)
        {
            List<string> user_input = new List<string>();
            if (!ui_Buttons.ContainsKey(viewparam))
                ui_Buttons.Add(viewparam, true);
            else
                ui_Buttons[viewparam] = false;
            foreach (KeyValuePair<string,bool> entry in ui_Buttons)
            {
                if (entry.Value == true)
                    user_input.Add(entry.Key);
            }
            generate_tags(user_input);
            StringResult = result_To_String(results);
        }

        #endregion Commands


    }
}
