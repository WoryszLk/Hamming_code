using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Hamm
    {
        public static int[] Coder_Hamm(int[] data)
        {
            int[] out_code = new int[7];
            out_code[0] = (data[0] + data[1] + data[3]) % 2;
            out_code[1] = (data[0] + data[2] + data[3]) % 2;
            out_code[2] = data[0];
            out_code[3] = (data[1] + data[2] + data[3]) % 2;
            out_code[4] = data[1];
            out_code[5] = data[2];
            out_code[6] = data[3];

            return out_code;
        }
        public static int[] Decoder_Hamm(int[] code)
        {
            int[] out_data = (int[])code.Clone();
            bool flag = true;
            int x1_p = (code[2] + code[4] + code[6]) % 2;
            int x2_p = (code[2] + code[5] + code[6]) % 2;
            int x4_p = (code[4] + code[5] + code[6]) % 2;

            int x1_n = (code[0] + x1_p) % 2;
            int x2_n = (code[1] + x2_p) % 2;
            int x4_n = (code[3] + x4_p) % 2;

            int S = (x1_n * 1) + (x2_n * 2) + (x4_n * 4);
            if (S != 0)
            {
                out_data[S - 1] = Convert.ToInt32(!Convert.ToBoolean(out_data[S - 1]));
                flag = false;
            }

            return new int[] { out_data[2], out_data[4], out_data[5], out_data[6], Convert.ToInt32(flag) };
        }
      
      

    }
}
