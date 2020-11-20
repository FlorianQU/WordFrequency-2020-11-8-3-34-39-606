using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace WordFrequency
{
    public class WordFrequencyGame
    {
        private string spacePattern;

        public string GetResult(string inputStr)
        {
            spacePattern = @"\s+";
            var splitInputStringArray = Regex.Split(inputStr, spacePattern);
            if (splitInputStringArray.Length == 1)
            {
                return inputStr + " 1";
            }

            string[] splitStrings = splitInputStringArray;

            List<WordCount> inputList = new List<WordCount>();
            foreach (var word in splitStrings)
            {
                WordCount wordCount = new WordCount(word, 1);
                inputList.Add(wordCount);
            }

            //get the map for the next step of sizing the same word
            Dictionary<string, List<WordCount>> map = SizingList(inputList);

            List<WordCount> list = new List<WordCount>();
            foreach (var entry in map)
            {
                WordCount wordCount = new WordCount(entry.Key, entry.Value.Count);
                list.Add(wordCount);
            }

            inputList = list;

            inputList.Sort((w1, w2) => w2.Count - w1.Count);

            List<string> strList = RenderInputList(inputList);

            return string.Join("\n", strList.ToArray());
        }

        private static List<string> RenderInputList(List<WordCount> inputList)
        {
            List<string> strList = new List<string>();
            foreach (WordCount input in inputList)
            {
                string str = input.Value + " " + input.Count;
                strList.Add(str);
            }

            return strList;
        }

        private Dictionary<string, List<WordCount>> SizingList(List<WordCount> inputList)
        {
            Dictionary<string, List<WordCount>> map = new Dictionary<string, List<WordCount>>();
            foreach (var input in inputList)
            {
                if (!map.ContainsKey(input.Value))
                {
                    List<WordCount> arr = new List<WordCount>();
                    arr.Add(input);
                    map.Add(input.Value, arr);
                }
                else
                {
                    map[input.Value].Add(input);
                }
            }

            return map;
        }
    }
}
