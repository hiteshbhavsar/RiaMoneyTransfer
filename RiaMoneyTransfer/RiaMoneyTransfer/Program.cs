namespace RiaMoneyTransfer
{
    class Program
    {
        
        static int[] denominations = {  10, 50, 100 };
        static List<List<int>> result=new();
        static Dictionary<int, string> names = new()
                {
                    {10,"10 EUR"},
                    {50, "50 EUR" },
                    {100,"100 EUR"}
                };

        static void CountCombinations(int value, int index, List<int> list)
        {
            if (value == 0)
            {
                List<int> nextResult = new();
                nextResult.AddRange(list.ToList());
                result.Add(nextResult);
                //list.Clear();
            }
            else if(value<0)
            {
                return;
            }

            for ( int i= index; i<denominations.Length;i++)
            {
                list.Add(denominations[i]);
                CountCombinations(value - denominations[i],i,list);
                list.Remove(denominations[i]);
            }
        }

        static void Main(string[] args)
        {
            
            Console.Write("Enter the amount value : ");
            Console.WriteLine();
            int iValue=Convert.ToInt32(Console.ReadLine());
            CountCombinations(iValue,0,new());


            Console.WriteLine("Output : ");

            for (int i=0;i<result.Count;i++)
            {
                Dictionary<string, int> countDenominations = new()
                {
                    {"100 EUR",0},
                    {"50 EUR",0},
                    {"10 EUR",0}
                };
                for (int j = 0; j < result[i].Count; j++)
                {
                    int c = result[i][j];

                    if (c == 10)
                    {
                        countDenominations["10 EUR"]= countDenominations["10 EUR"] + 1;
                    }
                    else if (c == 50)
                    {
                        countDenominations["50 EUR"]= countDenominations["50 EUR"] + 1;
                    }
                    else
                    {
                        countDenominations["100 EUR"]= countDenominations["100 EUR"] + 1;
                    }
                }
                bool checkmorethan1 = false;
                foreach(KeyValuePair<string,int> pair in countDenominations)
                {
                    if (pair.Value > 0)
                    {
                        if (!checkmorethan1)
                        {
                            Console.Write(pair.Value + " x " + pair.Key);
                        }
                        else
                        {
                            Console.Write(" + "+pair.Value + " x " + pair.Key);
                        }
                        checkmorethan1 = true;
                    }
                }
                Console.WriteLine();
            }
        }
    }
}