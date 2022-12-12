using System;
using System.IO;
using System.Collections.Generic;

public class Files
{
    List<string> file = new List<string>();

    public Files()
    {
        WriteInFile();

        file = ReadFromFile();
    }


    public void WriteInFile()
    {
        string overwrite = "hi";

        //Asks whether you want to overwrite the file or not
        while (overwrite.ToLower() != "yes" && overwrite.ToLower() != "no")
        {
            Console.Clear();
            Console.WriteLine("Do you want to overwrite everything in the file?");
            overwrite = Console.ReadLine();
        }

        //Writes over all of the text if the user wanted to
        if (overwrite.ToLower() == "yes")
        {
            Console.Clear();
            Console.WriteLine("What do you want to write in the file?");
            File.WriteAllText("file.txt", Console.ReadLine());
        }

        //Saves the file in a list and then adds an additional line to the list so it doesn't overwrite everything
        else if (overwrite.ToLower() == "no")
        {
            file = ReadFromFile();
            Console.Clear();
            Console.WriteLine("What do you want to write in the file?");
            file.Add(Console.ReadLine());
            File.WriteAllLines("file.txt", file);
        }
    }

    public List<string> ReadFromFile()
    {
        string[] tempFile = File.ReadAllLines("file.txt");

        file = new List<string>(tempFile);

        return file;
    }
}
