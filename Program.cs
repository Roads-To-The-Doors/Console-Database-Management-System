using System;
using System.IO;
using System.Threading;

namespace Console_Database_Management_System
{
    class Program
    {
        public static void DoCommand()
        {
            Console.Write("\n Admin> ");

            string command = Convert.ToString(Console.ReadLine());

            switch (command)
            {
                case "help":

                    Console.WriteLine("\n       help - find out all the commands\n" +
                                      "\n       add note - add a new entry to the database. To finish typing, type \\0 in the last line\n" +
                                      "\n       out notes - outputs all the information from the file\n" +
                                      "\n       replace note - replacing a line (by number) with a given one\n" +
                                      "\n       delete db - moves the database to the trash (recoverable)\n" +
                                      "\n       create db - creates a new database\n" +
                                      "\n       show dbs - displays a list of all databases created by the user\n" +
                                      "\n       exit - exit the program\n" +
                                      "\n       uninstall - remove directory and files"
                                      );

                    DoCommand();

                    break;

                case "add note":

                    Console.WriteLine("\n       Enter name database");

                    Console.Write("\n Admin.Add_note.Name_database> ");

                    string nameDB = Convert.ToString(Console.ReadLine());

                    Console.WriteLine("\n       Enter need lines");

                    Base.AddNote(nameDB);

                    DoCommand();

                    break;

                case "out notes":

                    Console.WriteLine("\n       Enter name database");

                    Console.Write("\n Admin.Out_notes.Name_database> ");

                    string nameDateB = Convert.ToString(Console.ReadLine());

                    Base.OutNotes(nameDateB);

                    DoCommand();

                    break;

                case "replace note":

                    Console.WriteLine("\n       Enter name database");

                    Console.Write("\n Admin.Replace_notes.Name_database> ");

                    string nameDBS = Convert.ToString(Console.ReadLine());

                    Base.ReplaceNote(nameDBS);

                    DoCommand();

                    break;

                case "remove note":

                    Console.WriteLine("\n       Enter name database");

                    Console.Write("\n Admin.Remove_notes.Name_database> ");

                    string namedatebase = Convert.ToString(Console.ReadLine());

                    Base.RemoveNote(namedatebase);

                    DoCommand();

                    break;

                case "create db":

                    Console.WriteLine("\n       Enter name database");

                    Console.Write("\n Admin.Create_DB.Name_database> ");

                    string nameDBForCreate = Convert.ToString(Console.ReadLine());

                    Base.CreateDataBase(nameDBForCreate);

                    DoCommand();

                    break;

                case "delete db":

                    Console.WriteLine("\n       Enter the name of the database you want to delete");

                    Console.Write("\n Admin.Delete_db.Name_database> ");

                    string nameDBForDelete = Convert.ToString(Console.ReadLine());

                    Base.DeleteDataBase(nameDBForDelete);

                    DoCommand();

                    break;

                case "show dbs":

                    Base.ShowDataBases();

                    DoCommand();

                    break;

                case "exit":

                    break;

                case "uninstall":

                    Console.Write("\n       Do you really want to delete the working folder and all the files it contains? Y|N  Yes|No\n\n Uninstall.Yes|No> ");

                    string confirmation = Convert.ToString(Console.ReadLine());

                    switch (confirmation)
                    {
                        case "Yes":
                        case "Y":

                            Directory.Delete(dir, true);

                            Console.Write("\n       Ok, remove files");

                            Thread.Sleep(500);

                            Console.Write(".");

                            Thread.Sleep(500);

                            Console.Write(".");

                            Thread.Sleep(500);

                            Console.Write(".");

                            Thread.Sleep(500);

                            Console.WriteLine("\n\n       Done");

                            Thread.Sleep(500);

                            Console.WriteLine("\n       Attention, the next time you start the folder will be created automatically!");

                            break;

                        case "No":
                        case "N":

                            Console.Write("\n       Would you like to continue working? Y|N  Yes|No\n\n Continue.Yes|No> ");

                            string confirm = Convert.ToString(Console.ReadLine());

                            switch (confirm)
                            {
                                case "Yes":
                                case "Y":

                                    DoCommand();

                                    break;

                                case "No":
                                case "N":

                                    break;

                                default:

                                    Console.WriteLine("\n       There is no such command, so we will continue, and if you want to exit, enter the \"exit\" command");

                                    DoCommand();

                                    break;
                            }

                            break;

                        default:

                            Console.WriteLine("\n       There is no such command, so we will continue, and if you want to exit, enter the \"exit\" command");

                            DoCommand();

                            break;
                    }

                    break;

                default:

                    Console.WriteLine($"\n      !Error! Command {command} not found");

                    DoCommand();

                    break; 
            }
        }

        public const string dir = @"C:\\Program Files\\.My_DataBase";

        static void Main()
        {

            // Создание папки
            DirectoryInfo dirInfo = new DirectoryInfo(dir);

            if (!dirInfo.Exists)
            {
                //DirectoryInfo diInfo = Directory.CreateDirectory(dir);

                dirInfo = Directory.CreateDirectory(dir);

                dirInfo.Attributes = FileAttributes.Hidden;
            }

            Console.WriteLine("\n       Hi, this is a console management system for your own database");

            Console.WriteLine("\n       Enter the command (for reference, enter \"help\")");

            DoCommand();

            Thread.Sleep(500);

            Console.WriteLine("\n       GOOD LUCK!");

            Thread.Sleep(500);

            Console.ReadKey();
        }
    }
}
