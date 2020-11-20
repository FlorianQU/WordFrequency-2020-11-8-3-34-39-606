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

            List<Input> inputList = new List<Input>();
            foreach (var word in splitStrings)
            {
                Input input = new Input(word, 1);
                inputList.Add(input);
            }

            //get the map for the next step of sizing the same word
            Dictionary<string, List<Input>> map = GetListMap(inputList);

            List<Input> list = new List<Input>();
            foreach (var entry in map)
            {
                Input input = new Input(entry.Key, entry.Value.Count);
                list.Add(input);
            }

            inputList = list;

            inputList.Sort((w1, w2) => w2.WordCount - w1.WordCount);

            List<string> strList = new List<string>();

            foreach (Input input in inputList)
            {
                string str = input.Value + " " + input.WordCount;
                strList.Add(str);
            }

            return string.Join("\n", strList.ToArray());
        }

        private Dictionary<string, List<Input>> GetListMap(List<Input> inputList)
        {
            Dictionary<string, List<Input>> map = new Dictionary<string, List<Input>>();
            foreach (var input in inputList)
            {
                if (!map.ContainsKey(input.Value))
                {
                    List<Input> arr = new List<Input>();
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
