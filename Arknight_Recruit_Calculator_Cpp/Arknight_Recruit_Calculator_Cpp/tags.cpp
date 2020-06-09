#include "tags.h"

void tags::print_tag(unordered_map<string, int> tag)
{
	for (auto x : tag)
	{
		cout << x.first << " ";
	}
	cout << endl;
}

void tags::generate_Tags(vector<string> input)
{
	for (int a = 0; a < input.size(); ++a)
	{
		if (!dict[input[a]].empty())
		{
			cout << "[ " << input[a] << " ]" << endl;
			print_tag(dict[input[a]]);
			cout << endl;
		}
		for (int b = a + 1; b < input.size(); ++b)
		{
			unordered_map<string, int> ab = compare_Tags(dict[input[a]], dict[input[b]]);
			if (!ab.empty())
			{
				cout << "[ " << input[a] << " + " << input[b] << " ]" << endl;
				print_tag(ab);
				cout << endl;
			}
			for (int c =  b + 1; c < input.size(); ++c)
			{
				if (!ab.empty() && !compare_Tags(ab, dict[input[c]]).empty())
				{
					cout << "[ " << input[a] << " + " << input[b] << " + " << input[c] << " ]" << endl;
					print_tag(compare_Tags(ab, dict[input[c]]));
					cout << endl;
				}
			}
		}
	}
}

unordered_map<string, int> tags::compare_Tags(unordered_map<string, int> tag1, unordered_map<string, int> tag2)
{
	unordered_map<string, int>	tag3;
	unordered_map<string, int>	bigTag;
	unordered_map<string, int>	smallTag;

	bigTag = (tag1.size() > tag2.size()) ? tag1 : tag2;
	smallTag = (tag1.size() > tag2.size()) ? tag2 : tag1;

	for (auto x : bigTag)
		if (smallTag.find(x.first) != smallTag.end())
			tag3[x.first] = x.second;

	return tag3;
}

