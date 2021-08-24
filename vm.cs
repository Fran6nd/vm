
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;



namespace ConsoleApp1
{
    class Instruction
    {

        public string name { get; }
        public byte id { get; }
        public byte nb_args { get; }
        public Instruction(string name, byte id, byte nb_args)
        {
            this.name = name;
            this.id = id;
            this.nb_args = nb_args;
        }

    }
    class Program
    {
        public enum INSTRUCTIONS { EXIT, MOVE, ADD, SUB, LT, EQ, GT, JMPBACK, JMPFORWARD, GOTOBACK, GOTOFORWARD, SET, OUT };
        public enum REGISTRIES { RESH, RESL };
        static List<string> funcs_name = new List<string>();
        static List<byte> funcs_id = new List<byte>();
        static List<byte> funcs_args = new List<byte>();
        static void register(string name, INSTRUCTIONS i, int args)
        {
            Program.funcs_name.Add(name);
            Program.funcs_id.Add((byte)(int)i);
            Program.funcs_args.Add((byte)args);
        }
        static byte get_id_from_name(string name)
        {
            for (int i = 0; i < Program.funcs_name.Count; i++)
            {
                if (Program.funcs_name[i] == name)
                {
                    return (Program.funcs_id[i]);
                }
            }
            return (byte)0;
        }
        static byte get_args_from_name(string name)
        {
            for (int i = 0; i < Program.funcs_name.Count; i++)
            {
                if (Program.funcs_name[i] == name)
                {
                    return (Program.funcs_args[i]);
                }
            }
            return (byte)0;
        }
        static List<List<byte>> load_file(string file)
        {
            string text = File.ReadAllText(file);
            text = text.Replace("\n", " ").Replace("\r", " ").Replace("  ", " ");
            string[] words = text.Split(' ');

            List<List<byte>> output = new List<List<byte>>();
            foreach (string word in words)
            {
                if (word.All(char.IsDigit))
                {
                    output[output.Count-1].Add((byte)int.Parse(word));
                }
                else
                {
                    output.Add(new List<byte>());
                    output[output.Count-1].Add(Program.get_id_from_name(word));
                }
            }
            return output;

        }
        static int run(List<List<byte>> instructions)
        {
            byte[] memmory = new byte[256];
            for (int i = 0; i < instructions.Count; i++)
            {
                switch ((INSTRUCTIONS)instructions[i][0])
                {
                    case INSTRUCTIONS.EXIT:
                        return (int)instructions[i][1];
                    case INSTRUCTIONS.SET:
                        memmory[(int)(instructions[i][1])] = instructions[i][2];
                        break;
                    case INSTRUCTIONS.OUT:
                        Console.Write((char)(int)memmory[(int)(instructions[i][1])]);
                        break;
                    case INSTRUCTIONS.ADD:
                        {
                            int result = (int) memmory[(int)instructions[i][1]]+ (int) memmory[(int)instructions[i][2]];
                            int l = result & 0xff;
                            int h = result >> 8 & 0xff;
                            memmory[(int)REGISTRIES.RESH] = (byte)h;
                            memmory[(int)REGISTRIES.RESL] = (byte)l;
                        }
                        break;
                    case INSTRUCTIONS.SUB:
                        {
                            int result = (int) memmory[(int)instructions[i][1]]- (int) memmory[(int)instructions[i][2]];
                            /* RESH = 0x00 means positive result. */
                            memmory[(int)REGISTRIES.RESH] = 0x00;
                            if (result < 0)
                            {
                                result = -result;
                                /* RESH = 0xFF means negative result. */
                                memmory[(int)REGISTRIES.RESH] = 0xff;
                            }
                            memmory[(int)REGISTRIES.RESL] = (byte)result;
                        }
                        break;
                    case INSTRUCTIONS.MOVE:
                        memmory[(int)instructions[i][2]] = memmory[(int)instructions[i][1]];
                        break;
                }

            }
            return 0;
        }
        static void Main(string[] args)
        {
            Program.register("EXIT", INSTRUCTIONS.EXIT, 1);
            Program.register("MOVE", INSTRUCTIONS.MOVE, 2);
            Program.register("ADD", INSTRUCTIONS.ADD, 2);
            Program.register("SUB", INSTRUCTIONS.SUB, 2);
            Program.register("LT", INSTRUCTIONS.LT, 2);
            Program.register("EQ", INSTRUCTIONS.EQ, 2);
            Program.register("GT", INSTRUCTIONS.GT, 2);
            Program.register("JMPBACK", INSTRUCTIONS.JMPBACK, 1);
            Program.register("JMPFORWARD", INSTRUCTIONS.JMPFORWARD, 1);
            Program.register("GOTOBACK", INSTRUCTIONS.GOTOBACK, 1);
            Program.register("GOTOFORWARD", INSTRUCTIONS.GOTOFORWARD, 1);
            Program.register("SET", INSTRUCTIONS.SET, 2);
            Program.register("OUT", INSTRUCTIONS.OUT, 1);
            Console.WriteLine("Program exited with code: " + Program.run(Program.load_file("test")).ToString());
            Console.ReadLine();
        }
    }

}