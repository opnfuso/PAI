using System;
using static System.Console;
using static System.IO.Directory;
using static System.IO.Path;
using static System.Environment;
using System.Xml;
namespace CH08
{
  static class Students
  {
    public static string[] students = new[] { "Alexis", "Isaac", "Luilui", "Mario", "Santos", "Sara" };
  }
  class Program
  {
    static void Main(string[] args)
    {
      // OutputFileSystemInfo();
      // WorkWithDrives();
      // WorkWithDirectories();
      // WorkWithFiles();
      WorkWithXml();
    }

    static void OutputFileSystemInfo()
    {
      WriteLine("{0, -33} {1}", arg0: "Path.PathSeparator", arg1: PathSeparator);
      WriteLine("{0, -33} {1}", arg0: "Path.DirectorySeparatorChar", arg1: DirectorySeparatorChar);
      WriteLine("{0, -33} {1}", arg0: "Directory.CurrentDirectory", arg1: CurrentDirectory);
      WriteLine("{0, -33} {1}", arg0: "Directory.GetCurrentDirectory", arg1: GetCurrentDirectory());
      WriteLine("{0, -33} {1}", arg0: "Directory SystemDirectory", arg1: GetTempPath());
      WriteLine("{0, -33} {1}", arg0: "GetFolderPath(SpecialFolder)", arg1: GetFolderPath(SpecialFolder.System));
      WriteLine("{0, -33} {1}", arg0: "GetFolderPath(ApplicationData)", arg1: GetFolderPath(SpecialFolder.ApplicationData));
      WriteLine("{0, -33} {1}", arg0: "GetFolderPath(MyDocuments)", arg1: GetFolderPath(SpecialFolder.MyDocuments));
      WriteLine("{0, -33} {1}", arg0: "GetFolderPath(Personal)", arg1: GetFolderPath(SpecialFolder.Personal));
    }

    static void WorkWithDrives()
    {
      WriteLine("{0,-30} | {1,-10} | {2,-7} | {3,18} | {4,18}", "NAME", "TYPE", "FORMAT", "SIZE(BYTES)", "FREE SPACE");
      foreach (var drive in DriveInfo.GetDrives())
      {
        // Always check if device is available
        if (drive.IsReady)
        {
          WriteLine("{0,-30} | {1,-10} | {2,-7} | {3,18:N0} | {4,18:N0}", drive.Name, drive.DriveType, drive.DriveFormat, drive.TotalSize, drive.AvailableFreeSpace);
        }
        else
        {
          WriteLine("{0,-30} / {1,-10}", drive.Name, drive.DriveType);
        }
      }
    }

    static void WorkWithDirectories()
    {
      //C:\Users\AngelBrambila\Documents\7B\Mario
      //C:\Users\AngelBrambila\Documents\7B\
      string newFolder = Combine(GetFolderPath(SpecialFolder.MyDocuments), "7B", "Mario");
      WriteLine($"Working With : {newFolder}");
      WriteLine($"Does it Exist? {Exists(newFolder)}");
      ReadLine();
      WriteLine("Creating it");
      CreateDirectory(newFolder);
      WriteLine($"Does it Exist? {Exists(newFolder)}");
    }

    static void WorkWithFiles()
    {
      string dir = Combine(GetFolderPath(SpecialFolder.Personal), "7B", "Andrik");
      CreateDirectory(dir);
      string textFile = Combine(dir, "Andrik.txt");
      string backupFile = Combine(dir, "BackUpAndrik.bak");
      WriteLine($"Working with {textFile}");
      WriteLine($"Does it exists? {File.Exists(textFile)}");
      // Streams
      StreamWriter textWriter = File.CreateText(textFile);
      textWriter.WriteLine("Hello Andrik!");
      // ALWAYS CLOSE THE F%&^%$$%ing Files
      textWriter.Close();
      WriteLine($"Does it exists? {File.Exists(textFile)}");
      ReadLine();
      WriteLine("Deleting it");
      File.Copy(sourceFileName: textFile, destFileName: backupFile, overwrite: true);
      WriteLine($"Does back Up File Exists? {Exists(backupFile)}");
      ReadLine();
      File.Delete(textFile);
      WriteLine($"Does it exists? {File.Exists(textFile)}");
      WriteLine("Reading BackUpFile");
      StreamReader textReader = File.OpenText(backupFile);
      WriteLine(textReader.ReadToEnd());
      // ALWAYS CLOSE THE F@!#@!$@!ing File
      textReader.Close();
    }

    static void WorkWithXml()
    {
      string xmlFile = Combine(CurrentDirectory, "streams.xml");
      FileStream xmlStreamFile = File.Create(xmlFile);
      // Working with real XML
      XmlWriter xml = XmlWriter.Create(xmlStreamFile, new XmlWriterSettings
      {
        Indent = true
      });

      xml.WriteStartDocument();
      xml.WriteStartElement("Students");
      foreach (string item in Students.students)
      {
        xml.WriteElementString("student", item);
      }
      xml.WriteEndElement();
      xml.Close();
      xmlStreamFile.Close();
    }
  }
}