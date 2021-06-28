using System;
using System.Collections.Generic;
using System.Linq;

namespace Calculator
{
    public class Calc
    {
        List<IPart> parts;
        List<string> posibleSign;
        List<string> posibleNumbers;
        Dictionary<MathOperations, (List<MathOperations> left, List<MathOperations> right)> neighbour;
        // Parse items from input to list of parts.
        Dictionary<string, MathOperations> signs;

        public Calc()
        {
            posibleSign = new List<string>() { "+", "-", "*", "/", "^", "(", ")", " " };
            posibleNumbers = new List<string>() { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "," };
            parts = new List<IPart>();
            neighbour = new Dictionary<MathOperations, (List<MathOperations> Left, List<MathOperations> Right)>();
            signs = new Dictionary<string, MathOperations>();
            InitDictionaryNeighbour();
            InitDictionarySigns();
        }

        private void InitDictionaryNeighbour()
        {
            // Every avalaible sign or numbers before and after plus, minus,multiply and divide
            List<MathOperations> LeftForStandard = new List<MathOperations>() { MathOperations.number, MathOperations.close, MathOperations.open };
            List<MathOperations> RightForStandard = new List<MathOperations>() { MathOperations.number, MathOperations.open, MathOperations.sqrt };
            neighbour.Add(MathOperations.plus, (LeftForStandard, RightForStandard));

            neighbour.Add(MathOperations.minus, (left: LeftForStandard, right: RightForStandard));
            neighbour.Add(MathOperations.multiply, (left: LeftForStandard, right: RightForStandard));
            neighbour.Add(MathOperations.divided, (left: LeftForStandard, right: RightForStandard));

            List<MathOperations> LeftForOpenBracket = new List<MathOperations>() { MathOperations.plus, MathOperations.minus, MathOperations.multiply, MathOperations.divided, MathOperations.sqrt, MathOperations.open };
            List<MathOperations> RightForOpenBracket = new List<MathOperations>() { MathOperations.number, MathOperations.sqrt, MathOperations.minus };
            neighbour.Add(MathOperations.open, (left: LeftForOpenBracket, right: RightForOpenBracket));

            List<MathOperations> LeftForCloseBracket = new List<MathOperations>() { MathOperations.number, MathOperations.sqrt, MathOperations.minus, MathOperations.close };
            List<MathOperations> RightForCloseBracket = new List<MathOperations>() { MathOperations.plus, MathOperations.minus, MathOperations.multiply, MathOperations.divided, MathOperations.sqrt };
            neighbour.Add(MathOperations.close, (left: LeftForCloseBracket, right: RightForCloseBracket));

            List<MathOperations> LeftForSqrt = new List<MathOperations>() { MathOperations.plus, MathOperations.minus, MathOperations.multiply, MathOperations.divided, MathOperations.open };
            List<MathOperations> RightForSqrt = new List<MathOperations>() { MathOperations.number, MathOperations.open };
            neighbour.Add(MathOperations.sqrt, (left: LeftForSqrt, right: RightForSqrt));

            List<MathOperations> LeftForNumber = new List<MathOperations>() { MathOperations.plus, MathOperations.minus, MathOperations.multiply, MathOperations.divided, MathOperations.open, MathOperations.sqrt, MathOperations.exp };
            List<MathOperations> RightForNumber = new List<MathOperations>() { MathOperations.plus, MathOperations.minus, MathOperations.multiply, MathOperations.divided, MathOperations.close, MathOperations.exp };
            neighbour.Add(MathOperations.number, (left: LeftForNumber, right: RightForNumber));
        }
        // probably will be enough check only right side of each sign
        private void InitDictionarySigns()
        {
            signs.Add("+", MathOperations.plus);
            signs.Add("-", MathOperations.minus);
            signs.Add("*", MathOperations.multiply);
            signs.Add("/", MathOperations.divided);
            signs.Add("^", MathOperations.exp);
            signs.Add("sqrt", MathOperations.sqrt);
            signs.Add("(", MathOperations.open);
            signs.Add(")", MathOperations.close);
        }
        OperationResult TestOperationLeft(MathOperations Element, MathOperations LeftElement)
        {
            (List<MathOperations> Left, List<MathOperations> Right) AlowedOperationList;
            if (neighbour.TryGetValue(Element, out AlowedOperationList))
            {
                if (AlowedOperationList.Left.Contains(LeftElement))
                {
                    return OperationResult.Success;
                }
                else
                {
                    return OperationResult.ErrorInputData;
                }
            }
            else
            {
                return OperationResult.ErrorInputData;
            }
        }
        OperationResult CheckBrackets(string input)
        {
            // First fast checking if it have sense
            // check brackets
            int count_open = input.Count(x => x == '(');
            int count_close = input.Count(x => x == ')');
            if (count_close != count_open)
            {
                return new OperationResult() { IsSuccess = false, Message = "Niewłaściwa ilość nawiasów" };
            }
            return OperationResult.Success;
        }
        OperationResult PrepareInput(string input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                if (posibleNumbers.Contains(Convert.ToString(input[i])))
                {
                    int start = i;
                    int stop;
                    for (stop = i; stop < input.Length; stop++)
                    {
                        if (char.IsDigit(input[stop]) || input[stop] == ',' || input[stop] == ' ')
                        {
                            continue;
                        }
                        else
                        {
                            break;
                        }
                    }
                    //set index on last digit
                    i = stop - 1;
                    parts.Add(new Number() { Value = Convert.ToDouble(input.Substring(start, stop - start)), Type = Type.number });
                }
                else
                if (posibleSign.Contains(Convert.ToString(input[i])))
                {
                    if (input[i] == ' ')
                    {
                        //we dont need space - but it isn't error if expresion contain
                        continue;
                    }
                    if (signs.ContainsKey(input[i].ToString()))
                    {
                        parts.Add(new OperatorSign() { Type = Type.operationSign, MathOperations = signs[input[i].ToString()] });
                    }
                }
                else
                if (input[i] == 's')
                {
                    if (input.Substring(i, 4) == "sqrt")
                    {
                        parts.Add(new OperatorSign() { Type = Type.operationSign, MathOperations = MathOperations.sqrt });
                        i = i + 3;
                    }
                    else
                    {
                        return new OperationResult() { IsSuccess = false, Message = "Nie poprawna składnia" };
                    }
                }
                else
                {
                    return new OperationResult() { IsSuccess = false, Message = "Nie odpowiednia składnia" };
                }

            }
            return OperationResult.Success;
        }

        private OperationResult ValidInput()
        {
            if (parts.Count == 0)
            {
                return OperationResult.ErrorInputData;
            }
            if (parts.Count == 1 && parts[0] is OperatorSign)
            {
                return new OperationResult()
                {
                    IsSuccess = false,
                    Message = "Napisałeś Znak \"" + signs?.First(x => x.Value == (parts[0] as OperatorSign)?.MathOperations).Key + "\" I co niby mam sobie z tym zrobić?"
                };
            }
            if (parts[0] is Number)
            {
                //continue;
            }
            else
            if (parts[0] is OperatorSign)
            {
                switch ((parts[0] as OperatorSign).MathOperations)
                {

                    case MathOperations.minus:
                        // now change next number to negative number//
                        if (parts[1] is Number)
                        {
                            (parts[1] as Number).Value = -(parts[1] as Number).Value;
                            parts.RemoveAt(0);
                        }
                        break;
                    //Correct signs
                    case MathOperations.plus:
                    case MathOperations.open:
                    case MathOperations.sqrt:
                        break;
                    //incorerect signs
                    case MathOperations.close:
                    case MathOperations.exp:
                    case MathOperations.multiply:
                    case MathOperations.divided:
                        return new OperationResult() { IsSuccess = false, Message = $"Znak {signs?.First(x => x.Value == (parts[0] as OperatorSign)?.MathOperations).Key} Nie może być na początku." };

                }
            }
            for (int i = 1; i < parts.Count; i++)
            {
                //If is minus after open bracket that mean that we have negative number
                if (parts[i] is OperatorSign && (parts[i] as OperatorSign).MathOperations == MathOperations.minus
                && (parts[i - 1] is OperatorSign) && (parts[i - 1] as OperatorSign).MathOperations == MathOperations.open)
                {
                    (parts[i + 1] as Number).Value = -(parts[i + 1] as Number).Value;
                    parts.RemoveAt(i);
                }

                if (parts[i] is Number && parts[i - 1] is OperatorSign)
                {
                    var result = TestOperationLeft(MathOperations.number, (parts[i - 1] as OperatorSign).MathOperations);
                    if (result.IsSuccess)
                    {
                        continue;
                    }
                    else
                    {
                        return new OperationResult()
                        {
                            IsSuccess = false,
                            Message = $"Element {signs?.First(x => x.Value == (parts[i - 1] as OperatorSign)?.MathOperations).Key } na miejscu {i} Nie może stać po lewej stronie liczby."
                        };
                    }
                }
                if (parts[i] is OperatorSign && parts[i - 1] is OperatorSign)
                {
                    var result = TestOperationLeft((parts[i] as OperatorSign).MathOperations, (parts[i - 1] as OperatorSign).MathOperations);
                    if (result.IsSuccess)
                    {
                        continue;
                    }
                    else
                    {
                        return new OperationResult()
                        {
                            IsSuccess = false,
                            Message = "Element " + signs?.First(x => x.Value == (parts[i - 1] as OperatorSign)?.MathOperations).Key + " na miejscu " + (i) + " Nie może stać po lewej stronie od " + signs?.First(x => x.Value == (parts[i] as OperatorSign)?.MathOperations).Key
                        };
                    }
                }


            }
            int last = parts.Count() - 1;
            if (parts[last] is Number)
            {
                //continue;
            }
            else
            if (parts[last] is OperatorSign)
            {
                switch ((parts[last] as OperatorSign).MathOperations)
                {
                    case MathOperations.close:
                        break;
                    case MathOperations.minus:
                    case MathOperations.plus:
                    case MathOperations.sqrt:
                    case MathOperations.exp:
                    case MathOperations.multiply:
                    case MathOperations.divided:
                    case MathOperations.open:
                        return new OperationResult()
                        {
                            IsSuccess = false,
                            Message = "Znak " + signs?.First(x => x.Value == (parts[last] as OperatorSign)?.MathOperations).Key + " Nie może być na końcu"
                        };

                }
            }

            return OperationResult.Success;
        }

        private double GoInside(int begin, int end)
        {
            int startSize = parts.Count();
            int position = begin;
            int stop = end;
            do
            {
                if (parts[position].Type == Type.operationSign && (parts[position] as OperatorSign).MathOperations == MathOperations.open)
                {
                    var bracket = findIndexOpenClose(position);
                    // go inside check if is more brackets inside
                    double resultCalculations = GoInside(bracket.indexOpen + 1, bracket.indexClose - 1);
                    //refresh indexes //
                    bracket = findIndexOpenClose(position);
                    parts.RemoveRange(bracket.indexOpen, bracket.indexClose - bracket.indexOpen + 1);
                    parts.Insert(bracket.indexOpen, new Number() { Type = Type.number, Value = resultCalculations });
                    int diff = startSize - parts.Count;
                    stop = stop - diff;
                    startSize = startSize - diff;
                    position = bracket.indexOpen + 1;
                }
                else
                {
                    position++;
                }
            } while (position < stop);

            // no more brackets - Calculate all and return value.
            double resultCalcutations = CalcExpresion(begin, stop);
            return resultCalcutations;
        }

        private (OperationResult operationResult, int indexOpen, int indexClose) findIndexOpenClose(int start)
        {
            int counter = 0;
            int firstBracket = -1;
            int position;

            for (position = start; position < parts.Count(); position++)
            {
                if (parts[position].Type == Type.operationSign && (parts[position] as OperatorSign).MathOperations == MathOperations.open)
                {
                    if (firstBracket == -1)
                    {
                        firstBracket = position;
                    }
                    counter++;
                }
                if (parts[position].Type == Type.operationSign && (parts[position] as OperatorSign).MathOperations == MathOperations.close)
                {
                    counter--;
                }
                if (firstBracket != -1 && counter == 0)
                {
                    return (OperationResult.Success, firstBracket, position);
                }
            }
            return (new OperationResult() { IsSuccess = false, Message = "Coś wyjątkowo dziwnego. Brak nawiasów otwierających." }, 0, 0);
        }
        private double Addition(double a, double b)
        {
            return a + b;
        }
        private double Subtraction(double a, double b)
        {
            return a - b;
        }
        private double Multiplication(double a, double b)
        {
            return a * b;
        }
        private double Division(double a, double b)
        {
            if (b == 0)
            {
                throw new DivideByZeroException("Nie dziel cholero nigdy przez zero !!");
            }
            else
            {
                return a / b;
            }
        }
        private double CalcExpresion(int begin, int end)
        {
            // if in brackets is only one number or is only one item
            if ((begin == end && parts[begin] is Number) || parts.Count == 1)
            {
                return (parts[begin] as Number).Value;
            }

            // if first sign is minus and next is number( like -1 ) 

            if (end - begin == 1 && parts[begin] is OperatorSign && parts[end] is Number)
            {
                if ((parts[begin] as OperatorSign).MathOperations == MathOperations.plus)
                {
                    return (parts[end] as Number).Value;
                }
                if ((parts[begin] as OperatorSign).MathOperations == MathOperations.minus)
                {
                    return -(parts[end] as Number).Value;
                }
            }

            int signPosition = 0;
            double resultCalculations = 0;

            MathOperations sign = MathOperations.sqrt;
            do
            {
                signPosition = parts.FindIndex(begin, end - begin, (x) => x.Type == Type.operationSign && (x as OperatorSign).MathOperations == sign);
                if (signPosition != -1)
                {
                    if (parts[signPosition + 1] is Number)
                    {
                        resultCalculations = Math.Sqrt((parts[signPosition + 1] as Number).Value);
                    }
                    else
                    {
                        throw new ArgumentException("Chcesz wyciągnąć pierwiastek z czegoś co nie jest liczbą!");
                    }
                    parts.RemoveRange(signPosition, 2);
                    parts.Insert(signPosition, new Number() { Type = Type.number, Value = resultCalculations });
                    end = end - 2 + 1;
                }

            } while (signPosition != -1);

            sign = MathOperations.exp;
            do
            {
                signPosition = parts.FindIndex
                    (
                        begin,
                        end - begin,
                        (x) => x.Type == Type.operationSign && (x as OperatorSign).MathOperations == sign
                    );
                if (signPosition != -1)
                {
                    if (parts[signPosition - 1] is Number && parts[signPosition + 1] is Number)
                    {
                        resultCalculations = Math.Pow((parts[signPosition - 1] as Number).Value, (parts[signPosition + 1] as Number).Value);
                    }
                    else
                    {
                        throw new ArgumentException("Coś nie tak z danymi. Potęgowanie wykonujemy na liczbach.");
                    }
                    parts.RemoveRange(signPosition - 1, 3);
                    parts.Insert(signPosition - 1, new Number() { Type = Type.number, Value = resultCalculations });
                    end = end - 3 + 1;
                }

            } while (signPosition != -1);

            List<MathOperations> expresion = new List<MathOperations>() {
                MathOperations.multiply,
                MathOperations.divided,
                MathOperations.minus,
                MathOperations.plus,
            };

            for (int i = 0; i < expresion.Count; i++)
            {
                signPosition = 0;
                sign = expresion[i];
                do
                {
                    signPosition = parts.FindIndex(begin, end - begin, (x) => x.Type == Type.operationSign && (x as OperatorSign)?.MathOperations == sign);
                    if (signPosition != -1)
                    {
                        if ((parts[signPosition - 1] is Number) && (parts[signPosition + 1] is Number))
                        {
                            switch (sign)
                            {
                                case MathOperations.multiply:
                                    resultCalculations = Multiplication((parts[signPosition - 1] as Number).Value, (parts[signPosition + 1] as Number).Value);
                                    break;
                                case MathOperations.divided:
                                    resultCalculations = Division((parts[signPosition - 1] as Number).Value, (parts[signPosition + 1] as Number).Value);
                                    break;
                                case MathOperations.plus:
                                    resultCalculations = Addition((parts[signPosition - 1] as Number).Value, (parts[signPosition + 1] as Number).Value);
                                    break;
                                case MathOperations.minus:
                                    resultCalculations = Subtraction((parts[signPosition - 1] as Number).Value, (parts[signPosition + 1] as Number).Value);
                                    break;
                            }
                            parts.RemoveRange(signPosition - 1, 3);
                            parts.Insert(signPosition - 1, new Number() { Type = Type.number, Value = resultCalculations });
                            end = end - 3 + 1;
                        }
                        else
                        {
                            throw new ArgumentException("Podstawowe działania wykonujemy na liczbach. Sprawdź walidator.");
                        }
                    }
                } while (signPosition != -1);

            }
            return resultCalculations;
        }
        public CalcOperationResult GetExpression(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return new CalcOperationResult() { IsSuccess = false, Message = "Nieodpowiednie dane wejsciowe" };
            }

            OperationResult result = CheckBrackets(input);
            // if first check is ok then we can check another things //
            if (result.IsSuccess)
            {
                //we can continue
                result = PrepareInput(input);
                if (result.IsSuccess)
                {
                    result = ValidInput();
                    if (result.IsSuccess)
                    {
                        return new CalcOperationResult()
                        {
                            IsSuccess = true,
                            Message = "Dzialanie wyliczono!",
                            calcResult = GoInside(0,
                            parts.Count())
                        };
                    }
                }
            }
            return new CalcOperationResult()
            {
                IsSuccess = result.IsSuccess,
                Message = result.Message
            };
        }

    }
}