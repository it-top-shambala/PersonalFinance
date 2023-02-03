namespace PersonalFinance.GUI.Models
{
    public static class SumFormatter
    {
        public static void RemoveLettersOrSymbols(ref string str)
        {
            if (!string.IsNullOrEmpty(str))
            {
                if (str[0] is ',' or '0')
                {
                    str = str.Remove(0, 1);
                }

                for (var i = 0; i < str.Length; i++)
                {
                    if (!char.IsDigit(str[i]) && str[i] != ',')
                    {
                        str = str.Remove(i, 1);
                    }
                }

                if (str.Contains(','))
                {
                    for (var i = str.IndexOf(',') + 1; i < str.Length; i++)
                    {
                        if (str[i] == ',')
                        {
                            str = str.Remove(i, 1);
                        }
                    }
                }
            }
        }

        public static void Cut(ref string str)
        {
            if (str.Contains(',') && str.IndexOf(',') + 3 == str.Length - 1)
            {
                str = str.Remove(str.IndexOf(',') + 3);
            }
        }
    }
}
