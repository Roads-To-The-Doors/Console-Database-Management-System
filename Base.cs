using System;
using System.Collections.Generic;
using System.Text;
using System.IO;


namespace Console_Database_Management_System
{
    class Base
    {
        // Добавить строку
        public static void AddNote(string fileName)
        {
            if (System.IO.File.Exists(GetAllPath(fileName)))
            {
                for (int i = 1; i > 0; ++i)
                {
                    Console.Write("\n Admin.Add_note.Line_to_write> ");
                    
                    string line = Convert.ToString(Console.ReadLine());

                    char[] phrase = line.ToCharArray();

                    if (phrase.Length >= 2 && phrase[phrase.Length - 2] == '\\' && phrase[phrase.Length - 1] == '0')
                    {
                        break;
                    }
                    else
                    {
                        StreamWriter writer = new System.IO.StreamWriter(GetAllPath(fileName), true);

                        writer.WriteLine(line);

                        writer.Close();
                    }
                }

                Console.WriteLine("\n      Entries have been added.");
            }
            else
            {
                Console.WriteLine("\n       The file does not exist");
            }
        }

        // Вывести строки
        public static void OutNotes(string fileName)
        {
            if (System.IO.File.Exists(GetAllPath(fileName)))
            {
                StreamReader sr = new StreamReader(GetAllPath(fileName));

                string line;

                int i = 0;

                Console.WriteLine();

                while ((line = sr.ReadLine()) != null)
                {
                    Console.WriteLine($" {i}.        {line}");

                    ++i;
                }

                sr.Close();
            }
            else
            {
                Console.WriteLine("\n       The file does not exist");
            }
        }

        // Замена строки
        public static void ReplaceNote(string fileName)
        {
            if (System.IO.File.Exists(GetAllPath(fileName)))
            {
                Console.WriteLine("\n       Enter the line number");

                Console.Write("\n Admin.Replace.Number_line_to_replace> ");

                int numLine = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("\n       Enter the line");

                Console.Write("\n Admin.Replace.Line_to_replace> ");

                string repline = Console.ReadLine();
                
                string[] lines = System.IO.File.ReadAllLines(GetAllPath(fileName));

                if (numLine < 0 || numLine >= lines.Length)
                {
                    Console.WriteLine("\n       !Error!");

                    //ReplaceNote(fileName);
                }
                else 
                {
                    lines[numLine] = repline;

                    StreamWriter scr = new StreamWriter(GetAllPath(fileName));

                    for (int i = 0; i < lines.Length; ++i)
                    {
                        scr.WriteLine(lines[i]);
                    }

                    scr.Close();
                }
            }
            else
            {
                Console.WriteLine("\n       The file does not exist");
            }
        }

        // Удаление строки
        public static void RemoveNote(string fileName)
        {
            if (System.IO.File.Exists(GetAllPath(fileName)))
            {
                Console.WriteLine("\n       Enter the line number");

                Console.Write("\n Admin.Remove_note.Number_line_to_remove> ");

                int numLine = Convert.ToInt32(Console.ReadLine());

                string[] lines = System.IO.File.ReadAllLines(GetAllPath(fileName));

                if (numLine < 0 || numLine >= lines.Length)
                {
                    Console.WriteLine("\n       !Error!");

                    //RemoveNote(fileName);
                }
                else
                {
                    if (numLine == lines.Length - 1)
                    {
                        StreamWriter sc = new StreamWriter(GetAllPath(fileName));

                        for (int i = 0; i < lines.Length - 1; ++i)
                        {
                            sc.WriteLine(lines[i]);
                        }

                        sc.Close();

                        Console.WriteLine("\n       The line has been deleted");
                    }
                    else
                    {
                        for (int i = numLine; i < lines.Length - 1; ++i)
                        {
                            lines[i] = lines[i + 1];
                        }

                        StreamWriter sc = new StreamWriter(GetAllPath(fileName));

                        for (int i = 0; i < lines.Length - 1; ++i)
                        {
                            sc.WriteLine(lines[i]);
                        }

                        sc.Close();

                        Console.WriteLine("\n       The line has been deleted");
                    }
                }
            }
            else
            {
                Console.WriteLine("\n       The file does not exist");
            }
        }

        // Создание базы
        public static void CreateDataBase(string fileName)
        {
            if (!System.IO.File.Exists(GetAllPath(fileName)))
            {
                FileStream sr = File.Create(GetAllPath(fileName));
                
                sr.Close();

                Console.WriteLine($"\n       The file {fileName} was created successfully");
            }
            else
            {
                Console.WriteLine("\n       Such a file already exists!");
            }
        }

        // Удаление базы
        public static void DeleteDataBase(string fileName)
        {
            if (System.IO.File.Exists(GetAllPath(fileName)))
            {
                System.IO.File.Delete(GetAllPath(fileName));

                Console.WriteLine($"\n       Base {fileName} was successfully deleted");
            }
            else
            {
                Console.WriteLine($"\n       There is no database named {fileName}");
            }
        }

        // Показать все базы
        public static void ShowDataBases()
        {
            Console.Write("\n   Databases: ");

            string[] files = Directory.GetFiles(Program.dir);

            if (files.Length == 0)
            {
                Console.WriteLine("no");
            }
            else
            {
                Console.WriteLine();

                foreach (string s in files)
                {
                    Console.Write("\n       ");

                    for (int i = Program.dir.Length + 1; i < s.Length - 4; ++i)
                    {
                        Console.Write(s[i]);
                    }

                    Console.WriteLine();
                }
            }
        }

        // Получаем полный путь к файлу, введя его имя // Только для использования в функциях
        private static string GetAllPath(string fileName)
        {
            return (Program.dir + "\\" + fileName + ".txt");
        }
    }
}
