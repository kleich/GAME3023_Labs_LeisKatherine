using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
/// <summary>
/// FileManager - Static class that handles file path management, reading from files, and saving to files.
/// 
/// - For FileManager I am using code that I have written for GAME2014, which is a modified version of code 
/// written for GAME3110 (this is the class where we learned how to use the stream reader/writer in C#).
/// </summary>
public static class FileManager
{
    private static string _filePath = Application.dataPath + Path.DirectorySeparatorChar;

    public static bool DoesFileExist(string file_name)
    {
        if (File.Exists(_filePath + file_name))
            return true;
        return false;
    }

    public static bool ReadFromFile(string file_name, out string[] raw_data)
    {
        List<string> message_data_list = new List<string>();
        if (File.Exists(_filePath + file_name))
        {
            StreamReader reader = new StreamReader(_filePath + file_name);
            while (!reader.EndOfStream)
            {
                message_data_list.Add(reader.ReadLine());
            }
            reader.Close();
            raw_data = message_data_list.ToArray();
            Debug.Log("Finished reading from file.");
            return true;
        }
        else
        {
            Debug.Log("File did not exist.");
        }
        raw_data = message_data_list.ToArray();
        return false;
    }

    public static void SaveToFile(string file_name, string[] data)
    {
        StreamWriter writer = new StreamWriter(_filePath + file_name);

        foreach (var item in data)
        {
            writer.WriteLine(item);
        }
        writer.Dispose();
        writer.Close();

        Debug.Log("Finished saving to file.");
    }

    public static void DeleteFile(string file_name)
    {
        if(File.Exists(_filePath + file_name))
        {
            File.Delete(_filePath + file_name);
            File.Delete(_filePath + file_name + ".meta");
            Debug.Log("The file '" + file_name + "' at path '" + _filePath + "' was successfully deleted.");
        }
        else
            Debug.Log("The file '" + file_name + "' at path '" + _filePath + "' was not found.");
    }

}
