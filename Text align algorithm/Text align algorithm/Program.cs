﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Text_align_algorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            int flag;
            int len; // justify: width
            Console.Write("WARNING!!! Text align width must be > 20. If you enter value less 20, correct execution of algorithm, not guaranteed." + "\n\n\n");


            Console.Write("Enter text align width ");
            len = int.Parse(Console.ReadLine());
            Console.Write("\n\n");


            Console.Write("Select algorithm parameters: "+"\n");
            Console.WriteLine("Enter the number 1: mode - read array - console output");
            Console.WriteLine("Enter the number 2: mode - enter the text - console output");
            Console.WriteLine("Enter the number 3: mode - read the file (text.txt) - write to file (textRelease.txt)");
            Console.WriteLine("Enter parameter: " + "\t");

           

            

            switch ( flag= int.Parse(Console.ReadLine()))
            {
                case 1:
                    AlignJustify(len);
                    break;
                case 2:
                    AlignJustifyEnterText(len);
                    break;

                case 3:
                    AlignJustifyReadFile(len);
                    break;
            }
            

            
            Console.Read();
        }

        static void AlignJustify(int len)
        {
            string str = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. " +
                            "Vestibulum sagittis dolor mauris, at elementum ligula tempor " +
                            "eget. In quis rhoncus nunc, at aliquet orci. Fusce at dolor " +
                            "sit amet felis suscipit tristique. Nam a imperdiet tellus. " +
                            "Nulla eu vestibulum urna. Vivamus tincidunt suscipit enim, nec ultrices nisi volutpat ac. " +
                            "Maecenas sit amet lacinia arcu, non dictum justo. Donec " +
                            "sed quam vel risus faucibus euismod. Suspendisse rhoncus " +
                            "rhoncus felis at fermentum. Donec lorem magna, ultricies a " +
                            "nunc sit amet, blandit fringilla nunc. In vestibulum " +
                            "velit ac felis rhoncus pellentesque. Mauris at tellus " +
                            "enim. Aliquam eleifend tempus dapibus. Pellentesque commodo, " +
                            "nisi sit amet hendrerit fringilla, ante odio porta lacus, ut elementum justo nulla et dolor.";


              

            string h;
            h = Justify(str, len);

            Console.Write("\n\n");

            Console.Write("Parameter 1; text align width = " + len + ".\n\n");
            Console.Write(h);
        }


        static void AlignJustifyEnterText(int len)
        {
            Console.Write("\n\n");
            Console.Write("Enter text ");
            string str=Console.ReadLine();




            string h;
            h = Justify(str, len);

            Console.Write("\n\n");

            Console.Write("Parameter 2; text align width = " + len + ".\n\n");
            Console.Write(h);
        }



        static void AlignJustifyReadFile(int len)
        {
            Console.Write("\n\n");
            string str;

            using (StreamReader sr = new StreamReader("text.txt"))
            {
                str = sr.ReadToEnd();
            }

                




            string h;
            h = Justify(str, len);

            using (StreamWriter wr = new StreamWriter("textRelease.txt", false, System.Text.Encoding.Default))
            {
                wr.Write(h);
            }

                Console.Write("\n\n");

            Console.Write("Parameter 3; text align width = " + len + ". File written.");
           
        }



        static string Justify(string str, int len)
        {
            int i = 0;   // i- index word in array
            bool whileSwitch; // switch for while cycle

            string str2, strN = "\n";

            List<string> resulListJustify = new List<string>();

            string[] masWords = str.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            while (i < masWords.Length)
            {
                str2 = masWords[i];

                while (str2.Length < len)
                {
                    i++;
                    if (i < masWords.Length)
                    {

                        if ((str2 + " " + masWords[i]).Length > len)
                            break;
                        else
                            str2 += " " + masWords[i];
                    }
                    else
                        break;
                }

                if (str2.Length == len)  // increase index an array of words, if a line length equals len
                { i++; }


                if (str2.Length == masWords[i - 1].Length) // if one word in line
                {
                    resulListJustify.Add(str2);
                    resulListJustify.Add(strN);
                    continue;
                }


                if (i != masWords.Length)            // the last line add to without spaces
                {
                    char[] line = str2.ToCharArray();

                    int amountSpaces = len - str2.Length, indexStr2Insert = 0;




                    while (amountSpaces > 0)
                    {
                        whileSwitch = true;

                        for (int j = 0; j < line.Length; j++)
                        {
                            if (line[j] == ' ' && amountSpaces != 0)
                            {
                                if (whileSwitch == true)
                                {
                                    str2 = str2.Insert(j, " ");    // add space to first gap in line
                                    whileSwitch = false;
                                }
                                else
                                {
                                    indexStr2Insert++;                              // index amount spaces
                                    str2 = str2.Insert(j + indexStr2Insert, " ");  // add spaces to all gaps, except the first gap
                                }

                                amountSpaces--;

                            }

                            if (amountSpaces == 0)
                                break;
                        }
                    }

                    resulListJustify.Add(str2);
                    resulListJustify.Add(strN);
                }
                else
                    resulListJustify.Add(str2);

            }

            string result = resulListJustify[0];

            for (int x = 1; x < resulListJustify.Count; x++)
                result += resulListJustify[x];

            return result;
        }
    }
}
