using ConsoleApp1;
using System;

public class Program
{
    public static void Main(string[] args)
    {
        int[] input = new int[] { 1, 1, 0, 1 }; // Default Data 
        int[] input11 = new int[] {1,1, 1, 1 ,1,0,0,0,1,0,1};

        int[] encoded = Hamm.Coder_Hamm(input);
        int[] decoded = Hamm.Decoder_Hamm(encoded);
        int[] encoded15_11 = Hamm_11_15.Hamm_15_11(input11);
        int[] decoded15_11 = Hamm_11_15.Decoder_Hamm_15_11(encoded15_11);

        Console.WriteLine("Encoded data: " + string.Join(", ", encoded));
        Console.WriteLine("Decoded data : " + string.Join(", ", decoded));
        Console.WriteLine("Encoded Data (15/11)" + string.Join(", ", encoded15_11));
        Console.WriteLine("Dencoded Data (15/11)" + string.Join(", ", decoded15_11));

    }
}
