#ifndef TAGS_H_
# define TAGS_H_
#include "Header.h"

class tags
{
private:

#pragma region tags

	// Tags are arraged by {OP_Name, Star_Rarity}

	unordered_map<string, int>	guard = { {"Specter", 5}, {"Indra", 5}, {"Doberman", 4},
											  {"Estelle", 4}, {"Mousse", 4}, {"Frostleaf", 4},
											  {"Matoimaru",4}, {"Melantha", 3}, {"Castle-3", 2} };

	unordered_map<string, int>	aoe = { {"Meteorite", 5}, {"Specter" , 5}, {"Gitano", 4},
											  {"ShiraYuki", 4}, {"Estelle", 4}, {"Lava", 3} };

	unordered_map<string, int>	survival = { {"Manticore", 5}, {"Specter", 5}, {"Indra", 5},
											  {"Vulcan", 5}, {"Jessica", 4}, {"Estelle", 4},
											  {"Matoimaru", 4}, {"Melantha", 3} };

	unordered_map<string, int>	debuff = { {"Meteorite", 5}, {"Pramanix", 5}, {"Haze", 4}, {"Meteor", 4} };

	unordered_map<string, int>	shift = { {"Cliffheart", 5}, {"FEater", 5}, {"Croissant" , 5}, {"Rope", 4}, {"Shaw",4} };

#pragma endregion

	unordered_map <string, unordered_map<string, int>> dict = { {"guard", guard}, {"aoe", aoe}, {"survival", survival},
																{"debuff", debuff}, {"shift", shift} };

public:
	void print_tag(unordered_map<string, int> tag);
	void generate_Tags(vector<string> input);
	unordered_map<string, int> compare_Tags(unordered_map<string, int> tag1, unordered_map<string, int> tag2);




};

#endif // !TAGS_H_

