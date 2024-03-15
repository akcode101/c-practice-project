using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Tests
{
   
    
    public class StringUtility { 
        public string capitalizeString (string o)
        {
            string capitalizedString = "";
            foreach (char c in o) {
                capitalizedString += char.ToUpper(c);
            }
            return capitalizedString;
        }

        public string lowercaseString(string o)
        {
            string lowercasedString = "";
            foreach (char c in o)
            {
                lowercasedString += char.ToLower(c);
            }
            return lowercasedString;
        }

        public string makeMockingString(string o)
        {
            string ans = "";
            int i = 0;
            while (i<o.Length)
            {
                if (o[i]==' ')
                {
                    ans += ' ';
                    i++;
                } else
                {
                    if (i%2==0)
                    {
                        ans += char.ToUpper(o[i]);
                    } else
                    {
                        ans += char.ToLower(o[i]);
                    }
                     i++;
                }
            }
            return ans;
        }

        public string substring(string o, int startIndex, int length)
        {

            if (length <= 0 || startIndex<0 || startIndex >= o.Length || length>o.Length)
            {
                return "";
            }
            else if (startIndex+length-1<o.Length)
            {
                string ans = "";
                for (int i=startIndex; i<startIndex+length; i++)
                {
                    ans += o[i];
                }
                return ans;
            } else
            {
                return "";
            }
        }

        public string concatStrings(string a, string b)
        {
            string ans = a;
            ans += b;
            return ans;
        }

        public bool findString(string haystack, string needle)
        {
            if (needle.Length > haystack.Length)
            {
                return false;
            }

            for (int i=0; i<haystack.Length - needle.Length; i++)
            {
                if (haystack.Substring(i, needle.Length)==needle)
                {
                    return true;
                }
            }
            return false;
        }

        public List<string> splitString(string s, string delim)
        {

            List<string> ans = new List<String>();


            if (delim.Length> s.Length)
            {
                ans.Add(s);
                return ans;
            }

            string curr = "";

            for (int i=0; i<s.Length; )
            {
                if (i<=s.Length - delim.Length)
                {
                    if (s.Substring(i, delim.Length) == delim)
                    {
                        ans.Add(curr);
                        curr = "";
                        i += delim.Length;
                    }
                    else
                    {
                        curr += s[i];
                        i++;
                    }
                } else
                {
                    curr += s[i];
                    i++;
                }
               

            }

            if (curr != "") ans.Add(curr);
            return ans;
        }

        public int compare(string a, string b)
        {

            for (int i = 0; i < Math.Min(a.Length, b.Length); i++)
            {
                if (a[i] < b[i])
                {
                    return -1;
                }
                else if (a[i] > b[i])
                {
                    return 1;
                }
            }

            if (a.Length == b.Length)
            {
                return 0;
            }
            else if (a.Length > b.Length)
            {
                return 1;
            }
            else
            {
                return -1;
            }
        }

    
    }

    public class Tests
    {

        StringUtility util = new StringUtility();
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void checkCapital()
        {
            String a = "ABCDe";
            String capitalA = util.capitalizeString(a);
            Assert.AreEqual( capitalA, "ABCDE");
        }

        [Test]
        public void checkLower()
        {
            String a = "ABCDe";
            String lowerA = util.lowercaseString(a);
            Assert.AreEqual(lowerA, "abcde");
        }

        [Test]
        public void checkMocking()
        {
            String o = "Eat food";
            String mockExpected = "EaT FoOd";
            String mockActual = util.makeMockingString(o);
            Assert.AreEqual(mockExpected, mockActual);
        }

        [Test]
        public void checkCompare()
        {
            String a = "eat";
            String b = "eats";
            int resCompare = util.compare(a, b);
            Assert.AreEqual(resCompare, -1);
        }

        [Test]
        public void checkConcat()
        {
            string a = "a";
            string b = "b";
            string c = util.concatStrings(a, b);
            Assert.AreEqual(c, "ab");
        }

        [Test]
        public void checkSubstring()
        {

            String hay = "abc";
            String sub = util.substring(hay, 1, 2);
            Assert.AreEqual(sub, "bc");
        }


        [Test]
        public void checkFind()
        {
            String hay = "asdfljkasdlfkjasdf";
            String needle = "kasd";
            bool isNeedleInHay = util.findString(hay, needle);
            Assert.AreEqual(isNeedleInHay, true);
        }

        [Test]
        public void checkSplit()
        {
            String o = "abc dfs ser serer";
            List<String> splitted = util.splitString(o, " ");
            List<String> splittedActual = new List<String> { "abc", "dfs", "ser", "serer" };
            Assert.AreEqual(splitted, splittedActual);

        }
    }
}