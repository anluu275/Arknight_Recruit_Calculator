using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Arknight_Recruit_Calculator
{
    

    public class MainWindowViewModel : BaseViewModel
    {
        //recruitment tags
        #region tags
        List<Character> senior_operator = new List<Character>();
        List<Character> melee = new List<Character>();
        List<Character> ranged = new List<Character>();
        List<Character> guard = new List<Character>();
        List<Character> medic = new List<Character>();
        List<Character> vanguard = new List<Character>();
        List<Character> caster = new List<Character>();
        List<Character> sniper = new List<Character>();
        List<Character> defender = new List<Character>();
        List<Character> supporter = new List<Character>();
        List<Character> specialist = new List<Character>();
        List<Character> healing = new List<Character>();
        List<Character> support = new List<Character>();
        List<Character> dps = new List<Character>();
        List<Character> aoe = new List<Character>();
        List<Character> slow = new List<Character>();
        List<Character> survival = new List<Character>();
        List<Character> defence = new List<Character>();
        List<Character> debuff = new List<Character>();
        List<Character> shift = new List<Character>();
        List<Character> crowd_control = new List<Character>();
        List<Character> nuker = new List<Character>();
        List<Character> summon = new List<Character>();
        List<Character> fast_redeploy = new List<Character>();
        List<Character> dp_recovery = new List<Character>();

        #endregion tags

        //Dictionary for tag access
        private Dictionary<string, List<Character>> recruit_tags = new Dictionary<string, List<Character>>();

        //Dictionary of tag buttons for UI
        private Dictionary<string, bool> ui_Buttons = new Dictionary<string, bool>();
        private StringBuilder sb;
        private string _stringResult;

        private ICommand _checkCommand;

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

        public MainWindowViewModel()
        {
            //Hard coded tags 
            #region Initialize tags
            #region senior_operator
            senior_operator.Add(new Character("Specter", 5));
            senior_operator.Add(new Character("Texas", 5));
            senior_operator.Add(new Character("Zima", 5));
            senior_operator.Add(new Character("Ptilopsis", 5));
            senior_operator.Add(new Character("Silence", 5));
            senior_operator.Add(new Character("Warfarin", 5));
            senior_operator.Add(new Character("Project Red", 5));
            senior_operator.Add(new Character("Manticore", 5));
            senior_operator.Add(new Character("Cliffheart", 5));
            senior_operator.Add(new Character("FEater", 5));
            senior_operator.Add(new Character("Provence", 5));
            senior_operator.Add(new Character("Blue Poison", 5));
            senior_operator.Add(new Character("Firewatch", 5));
            senior_operator.Add(new Character("Meteorite", 5));
            senior_operator.Add(new Character("Platinum", 5));
            senior_operator.Add(new Character("Pramanix", 5));
            senior_operator.Add(new Character("Istina", 5));
            senior_operator.Add(new Character("Mayer", 5));
            senior_operator.Add(new Character("Indra", 5));
            senior_operator.Add(new Character("Nearl", 5));
            senior_operator.Add(new Character("Liskarm", 5));
            senior_operator.Add(new Character("Vulcan", 5));
            senior_operator.Add(new Character("Croissant", 5));
            #endregion senior_operator
            #region melee
            melee.Add(new Character("Texas", 5));
            melee.Add(new Character("Zima", 5));
            melee.Add(new Character("Project Red", 5));
            melee.Add(new Character("Manticore", 5));
            melee.Add(new Character("Cliffheart", 5));
            melee.Add(new Character("FEater", 5));
            melee.Add(new Character("Specter", 5));
            melee.Add(new Character("Indra", 5));
            melee.Add(new Character("Nearl", 5));
            melee.Add(new Character("Liskarm", 5));
            melee.Add(new Character("Vulcan", 5));
            melee.Add(new Character("Croissant", 5));
            melee.Add(new Character("Scavenger", 4));
            melee.Add(new Character("Vigna", 4));
            melee.Add(new Character("Gravel", 4));
            melee.Add(new Character("Rope", 4));
            melee.Add(new Character("Shaw", 4));
            melee.Add(new Character("Doberman", 4));
            melee.Add(new Character("Estelle", 4));
            melee.Add(new Character("Mousse", 4));
            melee.Add(new Character("Frostleaf", 4));
            melee.Add(new Character("Matoimaru", 4));
            melee.Add(new Character("Cuora", 4));
            melee.Add(new Character("Gummy", 4));
            melee.Add(new Character("Matterhorn", 4));
            #endregion melee
            #region ranged
            ranged.Add(new Character("Ptilopsis", 5));
            ranged.Add(new Character("Silence", 5));
            ranged.Add(new Character("Warfarin", 5));
            ranged.Add(new Character("Provence", 5));
            ranged.Add(new Character("Blue Poison", 5));
            ranged.Add(new Character("Firewatch", 5));
            ranged.Add(new Character("Meteorite", 5));
            ranged.Add(new Character("Platinum", 5));
            ranged.Add(new Character("Pramanix", 5));
            ranged.Add(new Character("Istina", 5));
            ranged.Add(new Character("Mayer", 5));
            ranged.Add(new Character("Myrrh", 4));
            ranged.Add(new Character("Perfumer", 4));
            ranged.Add(new Character("Haze", 4));
            ranged.Add(new Character("Gitano", 4));
            ranged.Add(new Character("ShiraYuki", 4));
            ranged.Add(new Character("Meteor", 4));
            ranged.Add(new Character("Jessica", 4));
            ranged.Add(new Character("EarthSpirit", 4));
            #endregion ranged
            #region guard
            guard.Add(new Character("Specter", 5));
            guard.Add(new Character("Indra", 5));
            guard.Add(new Character("Doberman", 4));
            guard.Add(new Character("Estelle", 4));
            guard.Add(new Character("Mousse", 4));
            guard.Add(new Character("Frostleaf", 4));
            guard.Add(new Character("Matoimaru", 4));
            //guard.Add(new Character("Melantha", 3));
            //guard.Add(new Character("Castle-3", 2));
            #endregion guard
            #region medic
            medic.Add(new Character("Ptilopsis", 5));
            medic.Add(new Character("Silence", 5));
            medic.Add(new Character("Warfarin", 5));
            medic.Add(new Character("Myrrh", 4));
            medic.Add(new Character("Perfumer", 4));
            #endregion medic
            #region vanguard
            vanguard.Add(new Character("Texas", 5));
            vanguard.Add(new Character("Zima", 5));
            vanguard.Add(new Character("Scavenger", 4));
            vanguard.Add(new Character("Vigna", 4));
            #endregion vanguard
            #region caster
            caster.Add(new Character("Haze", 4));
            caster.Add(new Character("Gitano", 4));
            #endregion caster
            #region sniper
            sniper.Add(new Character("Provence", 5));
            sniper.Add(new Character("Blue Poison", 5));
            sniper.Add(new Character("Firewatch", 5));
            sniper.Add(new Character("Meteorite", 5));
            sniper.Add(new Character("Platinum", 5));
            sniper.Add(new Character("ShiraYuki", 4));
            sniper.Add(new Character("Meteor", 4));
            sniper.Add(new Character("Jessica", 4));
            #endregion sniper
            #region defender
            defender.Add(new Character("Nearl", 5));
            defender.Add(new Character("Liskarm", 5));
            defender.Add(new Character("Vulcan", 5));
            defender.Add(new Character("Croissant", 5));
            defender.Add(new Character("Cuora", 4));
            defender.Add(new Character("Gummy", 4));
            defender.Add(new Character("Matterhorn", 4));
            #endregion defender
            #region supporter
            supporter.Add(new Character("Pramanix", 5));
            supporter.Add(new Character("Istina", 5));
            supporter.Add(new Character("Mayer", 5));
            supporter.Add(new Character("Earthspirit", 4));
            #endregion supporter
            #region specialist
            specialist.Add(new Character("Project Red", 5));
            specialist.Add(new Character("Manticore", 5));
            specialist.Add(new Character("Cliffheart", 5));
            specialist.Add(new Character("FEater", 5));
            specialist.Add(new Character("Gravel", 4));
            specialist.Add(new Character("Rope", 4));
            specialist.Add(new Character("Shaw", 4));
            #endregion specialist
            #region healing
            healing.Add(new Character("Ptilopsis", 5));
            healing.Add(new Character("Silence", 5));
            healing.Add(new Character("Warfarin", 5));
            healing.Add(new Character("Nearl", 5));
            healing.Add(new Character("Myrrh", 4));
            healing.Add(new Character("Perfumer", 4));
            healing.Add(new Character("Gummy", 4));
            //healing.Add(new Character("Hibiscus", 3));
            //healing.Add(new Character("Ansel", 3));
            //healing.Add(new Character("Lancet-2", 2));
            #endregion healing
            #region support
            support.Add(new Character("Zima", 5));
            support.Add(new Character("Ptilopsis", 5));
            support.Add(new Character("Warfarin", 5));
            support.Add(new Character("Doberman", 5));
            #endregion support
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
            //dps.Add(new Character("Plume", 3));
            //dps.Add(new Character("Steward", 3));
            //dps.Add(new Character("Kroos", 3));
            //dps.Add(new Character("Adnachiel", 3));
            //dps.Add(new Character("Melantha", 3));
            #endregion dps
            #region aoe
            aoe.Add(new Character("Meteorite", 5));
            aoe.Add(new Character("Specter", 5));
            aoe.Add(new Character("Gitano", 4));
            aoe.Add(new Character("ShiraYuki", 4));
            aoe.Add(new Character("Estelle", 4));
            #endregion aoe
            #region slow
            slow.Add(new Character("FEater",5));
            slow.Add(new Character("Istina", 5));
            slow.Add(new Character("ShiraYuki", 4));
            slow.Add(new Character("Earthspirit", 4));
            slow.Add(new Character("Frostleaft", 4));
            #endregion slow
            #region survival
            survival.Add(new Character("Manticore", 5));
            survival.Add(new Character("Specter", 5));
            survival.Add(new Character("Indra", 5));
            survival.Add(new Character("Vulcan", 5));
            survival.Add(new Character("Jessica", 4));
            survival.Add(new Character("Estelle", 4));
            survival.Add(new Character("Matoimaru", 4));
            //survival.Add(new Character("Melantha", 3));
            #endregion survival
            #region defence
            defence.Add(new Character("Nearl", 5));
            defence.Add(new Character("Liskarm", 5));
            defence.Add(new Character("Vulcan", 5));
            defence.Add(new Character("Croissant", 5));
            defence.Add(new Character("Gravel", 4));
            defence.Add(new Character("Coura", 4));
            defence.Add(new Character("Gummy", 4));
            defence.Add(new Character("Matterhorn", 4));
            #endregion defence
            #region debuff
            debuff.Add(new Character("Meteorite", 5));
            debuff.Add(new Character("Pramanix", 5));
            debuff.Add(new Character("Haze", 4));
            debuff.Add(new Character("Meteor", 4));
            #endregion debuff
            #region shift
            shift.Add(new Character("Cliffheart", 5));
            shift.Add(new Character("FEater", 5));
            shift.Add(new Character("Croissant", 5));
            shift.Add(new Character("Rope", 4));
            shift.Add(new Character("Shaw", 4));
            #endregion shift
            #region crowd_control
            crowd_control.Add(new Character("Texas", 5));
            crowd_control.Add(new Character("Project Red", 5));
            crowd_control.Add(new Character("Mayer", 5));
            #endregion crowd_control
            #region nuker
            nuker.Add(new Character("Firewatch", 5));
            #endregion nuker
            #region summon
            summon.Add(new Character("Mayer", 5));
            #endregion summon
            #region fast_redeploy
            fast_redeploy.Add(new Character("Project Red", 5));
            fast_redeploy.Add(new Character("Gravel", 4));
            #endregion fast_redeploy
            #region dp_recovery
            dp_recovery.Add(new Character("Texas", 5));
            dp_recovery.Add(new Character("Zima", 5));
            dp_recovery.Add(new Character("Scavenger", 4));
            dp_recovery.Add(new Character("Vigna", 4));
            #endregion dp_recovery
            #endregion Initialize tags
            //Dict of tags, Used to access tags via comparison from user_input list of strings
            #region recruit_tags
            recruit_tags.Add("senior_operator", senior_operator);
            recruit_tags.Add("melee", melee);
            recruit_tags.Add("ranged", ranged);
            recruit_tags.Add("guard", guard);
            recruit_tags.Add("medic", medic);
            recruit_tags.Add("vanguard", vanguard);
            recruit_tags.Add("caster", caster);
            recruit_tags.Add("sniper", sniper);
            recruit_tags.Add("defender", defender);
            recruit_tags.Add("supporter", supporter);
            recruit_tags.Add("specialist", specialist);
            recruit_tags.Add("healing", healing);
            recruit_tags.Add("support", support);
            recruit_tags.Add("dps", dps);
            recruit_tags.Add("aoe", aoe);
            recruit_tags.Add("slow", slow);
            recruit_tags.Add("survival", survival);
            recruit_tags.Add("defence", defence);
            recruit_tags.Add("debuff", debuff);
            recruit_tags.Add("shift", shift);
            recruit_tags.Add("crowd_control", crowd_control);
            recruit_tags.Add("nuker", nuker);
            recruit_tags.Add("summon", summon);
            recruit_tags.Add("fast_redeploy", fast_redeploy);
            recruit_tags.Add("dp_recovery", dp_recovery);
            #endregion recruit_tags
        }

        #region function
        void generate_tags(List<string> user_input)
        {
            sb = new StringBuilder();
            for (int a = 0; a < user_input.Count; ++a)
            {
                if (recruit_tags[user_input[a]].Count > 0)
                {
                    sb.Append( "[ " + user_input[a] + " ]\n");
                    sb.Append(tagList_To_String(recruit_tags[user_input[a]]) + "\n");
                }
                for (int b = a + 1; b < user_input.Count; ++b)
                {
                    List<Character> ab = new List<Character>();
                    ab = compare_tags(recruit_tags[user_input[a]], recruit_tags[user_input[b]]);
                    if (ab.Count > 0)
                    {
                        sb.Append( "[ " + user_input[a] + " + " + user_input[b] +  " ]\n");
                        sb.Append(tagList_To_String(ab) + "\n");
                    }
                    for (int c = b + 1; c < user_input.Count; ++c)
                    {
                        List<Character> abc = new List<Character>();
                        abc = compare_tags(ab, recruit_tags[user_input[c]]);
                        if (abc.Count > 0)
                        {
                            sb.Append("[ " + user_input[a] + " + " + user_input[b] + " + " + user_input[c] + " ]\n");
                            sb.Append(tagList_To_String(abc) + "\n");
                        }
                    }
                }
            }
        }
        string tagList_To_String(List<Character> tag)
        {
            string results = "";

            for (int i = 0; i < tag.Count - 1; ++i)
            {
                results += tag[i].OP_Name + " , ";

                //Future Project of figuring out String coloring based off of Star_Rarity Value
                //if (tag[i].Star_Rarity == 5)
                //{
                //    results.Foreground = Red;
                //}
                //else if (tag[i].Star_Rarity == 4)
                //{
                //    results.Foreground = Yellow;
                //}
                //else if (tag[i].Star_Rarity == 3)
                //{
                //    results.Foreground = Blue;
                //}
                //else if (tag[i].Star_Rarity == 2)
                //{
                //    results.Foreground = Gray;
                //}
            }
            results += tag[tag.Count - 1].OP_Name;
            return results;
        }
        List<Character> compare_tags(List<Character> tag1, List<Character> tag2)
        {
            List<Character> tag3 = new List<Character>();

            for (int i = 0; i < tag1.Count; ++i)
            {
                if (tag2.Contains(tag1[i]))
                    tag3.Add(new Character(tag1[i].OP_Name, tag1[i].Star_Rarity));
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
            {
                ui_Buttons.Add(viewparam, true);
            }
            else if (ui_Buttons[viewparam] == false)
            {
                ui_Buttons[viewparam] = true;
            }
            else
            {
                ui_Buttons[viewparam] = false;
            }

            foreach (KeyValuePair<string,bool> entry in ui_Buttons)
            {
                if (entry.Value == true)
                    user_input.Add(entry.Key);
            }

            generate_tags(user_input);
            StringResult = sb.ToString();
        }
        #endregion Commands


    }
}
