namespace Sort
{
    public class SortByInsert
    {
        public void Sort(Items ToSort)
        {
            ToSort.Sorted.Add(ToSort.Source[0]);
            for (int i = 1; i < ToSort.Source.Count; i++)
            {
                bool insert = false;
                for (int j = 0; j < ToSort.Sorted.Count; j++)
                {
                    if (ToSort.Source[i] < ToSort.Sorted[j])
                    {
                        ToSort.Sorted.Insert(j, ToSort.Source[i]);
                        insert = true;
                        break;
                    }
                }
                if (insert == false)
                {
                    ToSort.Sorted.Add(ToSort.Source[i]);
                }
            }
            ToSort.isSorted = true;
        }

    }
}