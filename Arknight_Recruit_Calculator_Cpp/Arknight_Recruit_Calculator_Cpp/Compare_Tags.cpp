#include "Header.h"

unordered_map<string, int> compare_Tags(unordered_map<string, int> tag1, unordered_map<string, int> tag2)
{
	unordered_map<string, int>	tag3;
	unordered_map<string, int>	bigTag;
	unordered_map<string, int>	smallTag;
	
	bigTag = (tag1.size() > tag2.size()) ? tag1 : tag2;
	smallTag = (tag1.size() > tag2.size()) ? tag2 : tag1;
	
	for (auto x : bigTag)
	{
		if (smallTag.find(x.first) != smallTag.end())
			tag3[x.first] = x.second;
	}

	return tag3;
}