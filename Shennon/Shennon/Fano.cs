using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shennon
{
    class Fano
    {
        Dictionary<char, int> alphavit = new Dictionary<char, int>();
        List<KeyValuePair<char, int>> sortalpha = new List<KeyValuePair<char, int>>();
        Dictionary<char, string> outalpha = new Dictionary<char, string>();
        int left = 0;
        int right = 0;
        public int Sort(string s) 
        {
            for (int i = 0; i < s.Length; i++) 
            {
                if (!(alphavit.ContainsKey(s[i]))) 
                {
                    alphavit.Add(s[i], 0);
                }
                alphavit[s[i]]++;
            }
            sortalpha = alphavit.OrderByDescending(x => x.Value).ToList();
            return sortalpha.Count-1;
        }
        public void leftCycle(int R,int midpoint) 
        {
            for (int i = 0; i < R; i++)
            {
                if (i < midpoint)
                {
                    if (!(outalpha.ContainsKey(sortalpha[i].Key)))
                    {
                        outalpha.Add(sortalpha[i].Key, null);
                        outalpha[sortalpha[i].Key] += 0;
                    }
                    else outalpha[sortalpha[i].Key] += 0;
                }
            }
        }
        public void rightCycle(int R, int midpoint)
        {
            for (int i = 0; i < R; i++)
            {
                if (i < midpoint)
                {
                    if (!(outalpha.ContainsKey(sortalpha[i].Key)))
                    {
                        outalpha.Add(sortalpha[i].Key, null);
                        outalpha[sortalpha[i].Key] += 1;
                    }
                    else outalpha[sortalpha[i].Key] += 1;
                }
            }
        }
        public int Division(int L,int R) 
        {
            double sum = 0;
            int midpoint=0;
            for (int i = L; i < R; i++) 
            {
                try
                {
                    sum += sortalpha[i].Value;
                }
                catch { }
            }
            sum = Math.Floor(sum / 2.0);
            int hash = 0;
            for (int i = L; i < R; i++) 
            {
                try
                {
                    hash += sortalpha[i].Value;
                }
                catch { }
                if (hash <= sum) midpoint++;
                else
                break;
            }
            return midpoint;
        }
        public Dictionary<char, string> Rec(int L, int R) 
        {
            if (Math.Abs(L-R)!=0&&Math.Abs(L-R)>1)
            {
                int midpoint = Division(L, R);
                if (midpoint == 1)
                {
                    if (R == 1||R!=2)
                    {
                        for (int i = 0; i < R; i++)
                        {
                            if (!(outalpha.ContainsKey(sortalpha[i].Key)))
                            {
                                outalpha.Add(sortalpha[i].Key, null);
                                outalpha[sortalpha[i].Key] += 0;
                            }
                            else outalpha[sortalpha[i].Key] += 0;
                            break;
                        }
                        sortalpha.RemoveAt(0);
                        for (int i = 0; i < sortalpha.Count; i++)
                        {
                            if (!(outalpha.ContainsKey(sortalpha[i].Key)))
                            {
                                outalpha.Add(sortalpha[i].Key, null);
                                outalpha[sortalpha[i].Key] += 1;
                            }
                            else outalpha[sortalpha[i].Key] += 1;
                        }
                    }
                    if (R==2) 
                    {
                        if (!(outalpha.ContainsKey(sortalpha[0].Key)))
                        {
                            outalpha.Add(sortalpha[0].Key, null);
                            outalpha[sortalpha[0].Key] += 0;
                        }
                        else outalpha[sortalpha[0].Key] += 0;
                        sortalpha.RemoveAt(0);
                        if (!(outalpha.ContainsKey(sortalpha[0].Key)))
                        {
                            outalpha.Add(sortalpha[0].Key, null);
                            outalpha[sortalpha[0].Key] += 1;
                        }
                        else outalpha[sortalpha[0].Key] += 1;
                        sortalpha.RemoveAt(0);
                    }
                }
                else
                {
                    leftCycle(R, midpoint);
                    rightCycle(R, midpoint);
                }
                Rec(0, midpoint);
                Rec(0, sortalpha.Count);
            }
            return outalpha;
        }
    }
}
