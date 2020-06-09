using System;
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
        public Dictionary<string, List<Character>> dict = new Dictionary<string, List<Character>>();
        
        //Dictionary of tag buttons for UI
        public Dictionary<string, bool> ui_Buttons = new Dictionary<string, bool>();
        public List<string> user_input = new List<String>();

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
            #region dict
            dict.Add("guard", guard);
            dict.Add("dps", dps);
            dict.Add("survival", survival);
            dict.Add("debuff", debuff);
            dict.Add("healing", healing);
            #endregion dict
        }

        #region function
        void generate_tags(List<string> user_input)
        {


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
            if (ui_Buttons[viewparam] == false)
                ui_Buttons[viewparam] = true;
            else
                ui_Buttons[viewparam] = false;
            foreach (KeyValuePair<string,bool> entry in ui_Buttons)
            {
                if (entry.Value)
                    user_input.Add(entry.Key);
            }
            //run generate tag function
        }

        #endregion Commands


    }
}
