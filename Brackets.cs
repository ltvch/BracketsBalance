using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace CheckBrackets
{
    public class Brackets
    {
        Dictionary<char, char> bracketPairs = new Dictionary<char, char>
            {
                { '(', ')' },
                { '{', '}' },
                { '[', ']' }
            };
        Stack<char> matchedBrackets = new Stack<char>();
        public bool IsBalancedBrackets(string str)
        {
            try
            {
                ///повторяем для всех знаков в строке - параметре функции
                foreach (char c in str)
                {
                    ///если одна из открывающих скобок есть
                    ///то кладем в стек
                    if (bracketPairs.Keys.Contains(c))
                    {
                        matchedBrackets.Push(c);
                    }
                    else
                    {
                        ///если только закрывающая скобка
                        if (bracketPairs.Values.Contains(c))
                        {
                            ///есть ли есть пара для закрывающей скобки 
                            ///то извлекаем знак так как считаем отсутствующие пары
                            if (c == bracketPairs[matchedBrackets.First()])
                                matchedBrackets.Pop();
                            else
                                return false;
                        }
                        else
                            //продолжим просмотр пар
                            continue;
                    }
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine("Error - " + e.Message);
                return false;
            }

            return matchedBrackets.Count() == 0 ? true : false;
        }

        public bool IsBalansedBrackets(string str)
        {
            Stack<char> stack = new Stack<char>();
            foreach (var c in str)
            {
                ///есть ли открывающая скобка
                var isOpening = bracketPairs.ContainsKey(c);
                ///если есть 
                var pair = isOpening
                    ? bracketPairs[c]
                    : bracketPairs.First(x => x.Value == c).Key;

                if (isOpening)
                    stack.Push(c);
                else
                {
                    ///только закрыващая присутствует
                    if (!stack.Any())
                        return false;

                    if (stack.Peek() != pair)
                        return false;

                    stack.Pop();
                }
            }
            return !stack.Any();
        }

        public bool IsBalansedBrackets_(string values)
        {
            int curly = 0, round = 0, square = 0;
            foreach (char c in values)
            {
                /*
                if (c == '{')
                    curly ++;
                else if (c == '}')
                    curly--;
                else if (c == '[')
                    square++;
                else if (c == ']')
                    square--;
                else if (c == '(')
                    round++;
                else if (c == ')')
                    round--;
                    */
                switch (c)
                {
                    case '{':
                        curly++;
                        break;
                    case '}':
                        curly--;
                        break;
                    case '[':
                        square++;
                        break;
                    case ']':
                        square--;
                        break;
                    case '(':
                        round++;
                        break;
                    case ')':
                        round--;
                        break;
                    default:
                      //  Console.WriteLine("Can't match brackets.");
                        return false;
                }
            }
            if (curly == 0 && square == 0 && round == 0)
                return true;
            else
                return false;
        }
    }
}
