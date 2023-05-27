using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Hamm_11_15
    {
        private static int[,] ReverseColumns(int[,] matrix)         
        {
            // Utworzenie funkcji  dostosowanej do tego aby odwracać kolejność kolumn macierzy
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            int[,] reversed = new int[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    reversed[i, j] = matrix[i, cols - j - 1];
                }
            }

            return reversed;
        }
        public static int[] Hamm_15_11(int[] code)
        {
            int[,] I = new int[11, 11];
            for (int i = 0; i < 11; i++)
            {
                I[i, i] = 1;
            }

            int[,] P = new int[,]
            {
            { 0, 0, 1, 1 },
            { 0, 1, 0, 1 },
            { 0, 1, 1, 0 },
            { 0, 1, 1, 1 },
            { 1, 0, 0, 1 },
            { 1, 0, 1, 0 },
            { 1, 0, 1, 1 },
            { 1, 1, 0, 0 },
            { 1, 1, 0, 1 },
            { 1, 1, 1, 0 },
            { 1, 1, 1, 1 }
            };

            int[,] reversedP = ReverseColumns(P);   

            int[,] G = new int[11, 15];
            for (int i = 0; i < 11; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    G[i, j] = reversedP[i, j];
                }

                for (int j = 4; j < 15; j++)
                {
                    G[i, j] = I[i, j - 4];
                }
            }

            int[] c = new int[15];
            for (int i = 0; i < 15; i++)
            {
                int sum = 0;
                for (int j = 0; j < 11; j++)
                {
                    sum += code[j] * G[j, i];
                }
                c[i] = sum % 2;
            }

            return c;
        }


        public static int[] Decoder_Hamm_15_11(int[] c)
        {
            int[,] I = new int[4, 4];
            for (int i = 0; i < 4; i++)
            {
                I[i, i] = 1;
            }

            int[,] P = new int[,]
            {
            { 0, 0, 1, 1 },
            { 0, 1, 0, 1 },
            { 0, 1, 1, 0 },
            { 0, 1, 1, 1 },
            { 1, 0, 0, 1 },
            { 1, 0, 1, 0 },
            { 1, 0, 1, 1 },
            { 1, 1, 0, 0 },
            { 1, 1, 0, 1 },
            { 1, 1, 1, 0 },
            { 1, 1, 1, 1 }
            };

            int[,] reversedP = ReverseColumns(P);
            int[,] H = new int[4, 15];
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    H[i, j] = I[i, j];
                }

                for (int j = 4; j < 15; j++)
                {
                    H[i, j] = reversedP[j - 4, i];
                }
            }

            int[] s = new int[15];
            for (int i = 0; i < 15; i++)
            {
                int sum = 0;
                for (int j = 0; j < 4; j++)
                {
                    sum += c[j] * H[j, i];
                }
                s[i] = sum % 2;
            }

            int S = s[0] * 1 + s[1] * 2 + s[2] * 4 + s[3] * 8;

            bool flag = true;
            if (S != 0)
            {
                c[S] = Convert.ToInt32(!Convert.ToBoolean(c[S]));
                S = s[0] * 1 + s[1] * 2 + s[2] * 4 + s[3] * 8;
                if (S != 0)
                {
                    flag = false;
                }
            }

            int[] decoded = new int[11];
            for (int i = 0; i < 11; i++)
            {
                decoded[i] = c[i + 4];
            }

            return decoded;
        }
    }
}
