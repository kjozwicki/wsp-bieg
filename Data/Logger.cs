using System;
using System.Globalization;
using System.IO;
using System.Text.RegularExpressions;

namespace Data;

internal class Logger
{

    private Logger() { }

    private static Logger _instance;

    public static Logger GetInstance()
    {
        if (_instance == null)
        {
            _instance = new Logger();
        }
        return _instance;
    }
    public void SaveDateAsTxt(int xP, int yP, int xS, int yS, int Hash)
    {
        using StreamWriter file = new($"{Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName}/ballData.txt", append: true);
        string toWrite = "ball:" + "\n";
        toWrite += "  - Hash: " + Hash + "\n";
        toWrite += "  - XPos: " + xP + "\n";
        toWrite += "  - Ypos: " + yP + "\n";
        toWrite += "  - XSpeed: " + xS + "\n";
        toWrite += "  - YSpeed: " + yS + "\n";
        toWrite += "  - Date: " + DateTime.Now.ToString(Regex.Replace(
            DateTimeFormatInfo.CurrentInfo.FullDateTimePattern, "(:ss|:s)",
            $"$1{$"{NumberFormatInfo.CurrentInfo.NumberDecimalSeparator}fff"}")) + "\n";
        file.Write(toWrite);
        file.Close();
    }
    public void SaveDateAsYaml(int xP, int yP, int xS, int yS, int Hash)
    {
        using StreamWriter file = new($"{Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName}/ballData.yaml", append: true);
        string toWrite = "ball:" + "\n";
        toWrite += "  - Hash: " + Hash + "\n";
        toWrite += "  - XPos: " + xP + "\n";
        toWrite += "  - Ypos: " + yP + "\n";
        toWrite += "  - XSpeed: " + xS + "\n";
        toWrite += "  - YSpeed: " + yS + "\n";
        toWrite += "  - Date: " + DateTime.Now.ToString(Regex.Replace(
            DateTimeFormatInfo.CurrentInfo.FullDateTimePattern, "(:ss|:s)",
            $"$1{$"{NumberFormatInfo.CurrentInfo.NumberDecimalSeparator}fff"}")) + "\n";
        file.Write(toWrite);
        file.Close();
    }
}