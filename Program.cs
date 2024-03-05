using System;
using System.Collections.Generic;
using System.IO;

namespace FileHandling
{
    public class Program
    {
        static List<FileHandlingConcept> l = new List<FileHandlingConcept>();
        static string path = @"D:/FileExampleConfirm.cs"; // Define the file path as a static field

        public static void Main(string[] args)
        {
            Program ob = new Program();

            while (true)
            {
                Console.WriteLine("1.Add Detail");
                Console.WriteLine("2.Show Detail");
                Console.WriteLine("3.Update Detail");
                Console.WriteLine("4.Delete Detail");
                Console.WriteLine("5.Exit");
                Console.WriteLine("Enter option:");
                int option = int.Parse(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        ob.AddDetail();
                        break;
                    case 2:
                        ob.ShowDetail();
                        break;
                    case 3:
                        ob.UpdateDetail();
                        break;
                    case 4:
                        ob.DeleteDetail();
                        break;
                    case 5:
                        Console.WriteLine("Exiting program...");
                        return; // Exit the program
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }

        public void AddDetail()
        {
            Console.WriteLine("Enter first name:");
            string fname = Console.ReadLine();
            Console.WriteLine("Enter phone number:");
            string phno = Console.ReadLine();
            Console.WriteLine("Enter age:");
            string age = Console.ReadLine();

            FileHandlingConcept concept = new FileHandlingConcept()
            {
                Name = fname,
                phno = phno,
                Age = age
            };

            l.Add(concept);

            using (StreamWriter sw = new StreamWriter(path, append: true))
            {
                sw.WriteLine($"{concept.Name},{concept.phno},{concept.Age}");
            }
        }

        public void ShowDetail()
        {
            if (File.Exists(path))
            {
                string[] lines = File.ReadAllLines(path);
                foreach (string line in lines)
                {
                    Console.WriteLine(line);
                }
            }
            else
            {
                Console.WriteLine("File does not exist.");
            }
        }
        public void DeleteDetail()
        {
            Console.WriteLine("Enter name:");
            string name = Console.ReadLine();
            if (File.Exists(path))
            {
                List<string> updatedLines = new List<string>();
                string[] lines = File.ReadAllLines(path);
                bool found = false;
                foreach (string line in lines)
                {
                    string[] parts = line.Split(',');
                    string currentName = parts[0]; // Assuming name is the first part in the line
                    if (currentName.Trim() == name.Trim()) // Trim to remove leading/trailing spaces
                    {
                        found = true;
                        Console.WriteLine("Detail found and deleted successfully.");
                    }
                    else
                    {
                        updatedLines.Add(line);
                    }
                }
                if (found)
                {
                    File.WriteAllLines(path, updatedLines);
                }
                else
                {
                    Console.WriteLine("Name not found in the file.");
                }
            }
            else
            {
                Console.WriteLine("File does not exist.");
            }
        }
        public void UpdateDetail()
        {
            Console.WriteLine("Enter name to update:");
            string nameToUpdate = Console.ReadLine();
            if (File.Exists(path))
            {
                List<string> updatedLines = new List<string>();
                string[] lines = File.ReadAllLines(path);
                bool found = false;
                foreach (string line in lines)
                {
                    string[] parts = line.Split(',');
                    string currentName = parts[0].Trim(); // Assuming name is the first part in the line
                    if (currentName == nameToUpdate)
                    {
                        found = true;
                        Console.WriteLine("Enter new first name:");
                        string newFname = Console.ReadLine();
                        Console.WriteLine("Enter new phone number:");
                        string newPhno = Console.ReadLine();
                        Console.WriteLine("Enter new age:");
                        string newAge = Console.ReadLine();

                        updatedLines.Add($"{newFname},{newPhno},{newAge}");
                        Console.WriteLine("Detail updated successfully.");
                    }
                    else
                    {
                        updatedLines.Add(line);
                    }
                }
                if (found)
                {
                    File.WriteAllLines(path, updatedLines);
                }
                else
                {
                    Console.WriteLine("Name not found in the file.");
                }
            }
            else
            {
                Console.WriteLine("File does not exist.");
            }
        }






        // Remove the detail from the list

        // Rewrite the file with the updated details








        public class FileHandlingConcept
        {
            public string Name { get; set; }
            public string phno { get; set; }
            public string Age { get; set; }

            public FileHandlingConcept()
            {
                this.Name = "";
                this.phno = "";
                this.Age = "";
            }
        }

    }
}

