#include "tags.h"

int main()
{
	//Given n Tags range of 0 to n
	//Tags being strings of text ex. "Guard", "DPS", "Healer"

	vector<string> arr = { "guard", "healer", "survival", "debuff", "aoe" };
	tags mytags;

	mytags.generate_Tags(arr);



}
