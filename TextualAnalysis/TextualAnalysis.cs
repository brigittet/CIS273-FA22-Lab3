﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace TextualAnalysis
{
    public class TextualAnalysis
    {
        public static string stopWordFilePath = "../../../Data/stop-words.txt";

        public TextualAnalysis()
        {
        }


        public static Dictionary<string, int> ComputeWordFrequencies(string s, bool ignoreStopWords = false)
        {
            var wordCounts = new Dictionary<string, int>();
            // s = "all the faith he had had had had no effect."

            // remove punctuation
            var cleanString = Regex.Replace(s, @"[^\w\s]", "");

            var words = cleanString.ToLower().Split().Where( s => s!="");

            // split the string into words (filtering out the empty strings)

            string[] stopWords = GetStopWordsFromFile(stopWordFilePath);

            //foreach word do something
                //if not ignoring stop words and word is a stop word
                //skip the stop word
                //else
                //either add word if new with count of one
                //or increment the word count if it's already in the dictionary
            foreach (var word in words)
            {
                if ((ignoreStopWords == true) && (stopWords.Contains(word)))
                {
                    continue;
                }
                else
                {
                    if (wordCounts.Keys.Contains(word))
                    {
                        wordCounts[word] = wordCounts[word] + 1;
                    }
                    else
                    {
                        wordCounts[word] = 1;
                    }
                }
            }

            return wordCounts;
        }


        public static Dictionary<string, int> ComputeWordFrequenciesFromFile(string path, bool ignoreStopWords = false)
        {
            // read in the file
            string text = System.IO.File.ReadAllText(path);

            // call the other method
            var wordCounts = ComputeWordFrequencies(text, ignoreStopWords);

            // return the result of the other method
            return wordCounts;

        }

        private static string[] GetStopWordsFromFile(string path)
        {
            var rawLines = System.IO.File.ReadAllLines(path);
            var lines = new List<string>();

            foreach (var line in rawLines)
            {
                // ignore blank lines
                if (line.Trim() != "")
                {
                    lines.Add(line.Trim().ToLower());
                }
            }

            return lines.ToArray();
        }

    }
}
