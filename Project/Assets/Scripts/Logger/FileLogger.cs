using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class FileLogger
{
    static string path = Application.streamingAssetsPath + "/log.txt";

    public static void LogData(string data) {
        using StreamWriter outputFile = new(path, true);
        outputFile.WriteLine(data);
    }
}
