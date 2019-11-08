using System;
using System.Collections.Generic;

namespace Labb2
{
    public class SortedPosList
    {
        public List<Position> Positions = new List<Position>();

        public Position this[int key]
        {
            get => this.Positions[key];
        }

        public SortedPosList()
        {
        }

        public int count() => Positions.Count;

        public void Add(Position p)
        {
            Positions.Insert(0, p);

            for (int i = 0; i < Positions.Count-1; i++)
            {

                if (Positions[i] > Positions[i+1])
                {
                    var temp = Positions[i + 1];
                    Positions[i + 1] = Positions[i];
                    Positions[i] = temp;
                }
            }           
        }

        public bool Remove(Position p)
        {
            for (int i = 0; i < Positions.Count; i++)
            {
                if (Positions[i].Equals(p))
                {
                    Positions.RemoveAt(i);
                    return true;
                }
            }
            return false;
        }

        public SortedPosList Clone()
        {
            SortedPosList sortedPosList = new SortedPosList();
            for (int i = 0; i < Positions.Count; i++)
            {
                sortedPosList.Add(Positions[i].Clone());
            }
            return sortedPosList;
        }

        public SortedPosList CircleContent(Position centerPos, double radius)
        {
            SortedPosList sortedPosList = new SortedPosList();
            for (int i = 0; i < Positions.Count; i++)
            {
                if (Math.Pow(Positions[i].X - centerPos.X, 2) + Math.Pow(Positions[i].Y - centerPos.Y, 2) < Math.Pow(radius, 2))
                {
                    sortedPosList.Add(Positions[i].Clone());
                }
            }
            return sortedPosList;
        }

        public static SortedPosList operator +(SortedPosList sp1, SortedPosList sp2)
        {
            SortedPosList sortedPosList = sp1.Clone();
            for (int i = 0; i < sp2.Positions.Count; i++)
            {
                sortedPosList.Add(sp2.Positions[i].Clone());
            }
            return sortedPosList;

        }

        public static SortedPosList operator -(SortedPosList sp1, SortedPosList sp2)
        {
            SortedPosList sortedPosList = sp1.Clone();
            int i = 0;
            int j = 0;

            while(i < sp1.Positions.Count && j < sp2.Positions.Count)
            {
                if (sp1[i].Equals(sp2[j]))
                {
                    sortedPosList.Remove(sp1[i]);
                    i++;
                    j++;
                    
                }
                else if (sp1[i] < sp2[j])
                {
                    i++;
                }
                else
                {
                    j++;
                }

            }
            return sortedPosList;

        }

        public override string ToString()
        {
            return string.Join(", ", Positions);
        }
    }
}
