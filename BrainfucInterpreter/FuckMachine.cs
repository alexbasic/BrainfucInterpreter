using System;

namespace BrainfucInterpreter
{
    public class FuckMachine
    {
        private int _memorySize;
        private byte[] _memory;

        public FuckMachine()
        {
            _memorySize = 30000;
            _memory = new byte[_memorySize];
        }

        public void Run(string program)
        {
            int dataPointer = 0;
            int loopEnds = 0;

            for (var _programCounter = 0; _programCounter < program.Length; _programCounter++)
            {
                var programInstruction = program[_programCounter];
                switch (programInstruction)
                {
                    case '<': dataPointer--; break;
                    case '>': dataPointer++; break;
                    case '+': _memory[dataPointer]++; break;
                    case '-': _memory[dataPointer]--; break;
                    case '.': Console.Write(char.ConvertFromUtf32(_memory[dataPointer])); break;
                    case ',': _memory[dataPointer] = (byte)Console.Read(); break;
                    case '[':
                        {
                            if (_memory[dataPointer] == 0)
                            {
                                loopEnds++;
                                while (loopEnds > 0)
                                {
                                    _programCounter++;
                                    if (program[_programCounter] == '[') loopEnds++;
                                    if (program[_programCounter] == ']') loopEnds--;
                                }
                            }
                            break;
                        }
                    case ']':
                        {
                            if (_memory[dataPointer] != 0)
                            {
                                loopEnds++;
                                while (loopEnds > 0)
                                {
                                    _programCounter--;
                                    if (program[_programCounter] == '[') loopEnds--;
                                    if (program[_programCounter] == ']') loopEnds++;
                                }
                            }
                            break;
                        }
                    default: break;
                }
            }
        }
    }
}
