using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace ConsoleApplication55
{
    class Huffman
    {
        List<Uzel> UZLbI = new List<Uzel>();
        public Uzel Root { get; set; }
        public Dictionary<char, int> alphavit = new Dictionary<char, int>();
        public string s=null;
        Dictionary<char, string> alpha = new Dictionary<char, string>();
        public List<Uzel> Sort(List<Uzel> Uzels) 
        {
            for (int i = 0; i < Uzels.Count; i++) 
            {
                for (int j = 0; j < Uzels.Count - 1; j++) 
                {
                    if (Uzels[j].Value >= Uzels[j + 1].Value) 
                    {
                        Uzel uzl = Uzels[j];
                        Uzels[j] = Uzels[j+1];
                        Uzels[j + 1] = uzl;
                    }
                }
            }
            return Uzels;
        }
        public Dictionary<char, string> Pop 
        {
            get { return alpha; }
        }
        public void Rec(Uzel Root)
        {
            if (Root.Left != null)
            {
                s+=0;
                Rec(Root.Left);
            }
            if (Root.Right != null) 
            {
                s+=1;
                Rec(Root.Right);
            }
            if (Root.Sym != '*') 
            {
                alpha.Add(Root.Sym, s);
            }
            if(s.Length>0) s = s.Remove(s.Length - 1, 1);
        }
        public void CreateTree(string s) 
        {
            for (int i = 0; i < s.Length; i++)
            {
                if (!(alphavit.ContainsKey(s[i])))
                {
                    alphavit.Add(s[i], 0);
                }
                alphavit[s[i]]++;
            }
            foreach (KeyValuePair<char, int> pairs in alphavit) 
            {
                UZLbI.Add(new Uzel() { Sym = pairs.Key, Value = pairs.Value });
            }
            while (UZLbI.Count >= 2) 
            {
                //List<Uzel> sortuzlbI = UZLbI.OrderBy(x=>x.Value).ToList<Uzel>();
                List<Uzel> sortuzlbI = Sort(UZLbI);
                //for( int i=0;i<sortuzlbI.Count;i++)
                //{
                //    for (int j = i; j < sortuzlbI.Count - 1; j++) 
                //    {
                //        if (sortuzlbI[i].Value > sortuzlbI[j + 1].Value) 
                //        {
                //            int Valuei = sortuzlbI[j + 1].Value;
                //            char symi = sortuzlbI[j + 1].Sym;
                //            sortuzlbI[j + 1].Sym = sortuzlbI[i].Sym;
                //            sortuzlbI[j + 1].Value = sortuzlbI[i].Value;
                //            sortuzlbI[i].Sym = symi;
                //            sortuzlbI[i].Value = Valuei;
                //        }
                //    }
                //}
                
                if (sortuzlbI.Count > 1) 
                {
                    List<Uzel> put = sortuzlbI.Take(2).ToList<Uzel>();
                    Uzel father = new Uzel()
                    {
                        Sym = '*',
                        Value = put[0].Value + put[1].Value,
                        Left=put[0],
                        Right=put[1]
                        
                    };
                    UZLbI.Remove(put[0]);
                    UZLbI.Remove(put[1]);
                    UZLbI.Add(father);
                }
                this.Root = UZLbI.FirstOrDefault();
            }
            Rec(Root);
        }
    }
}
