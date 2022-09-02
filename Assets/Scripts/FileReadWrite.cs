using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CsvHelper;
using System.IO;
using System.Globalization;

public class FileReadWrite : MonoBehaviour
{
    public static string _path;
    public static List<string> _eventList = new List<string>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public static void WriteToCSV(string path)
    {
        //using (var writer = new StreamWriter(path))
        //using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
        //{
        //    csv.WriteRecords(_events);
        //}
        //_events.Clear();

        
            var csv = string.Join(',', _eventList);
            File.WriteAllText(path, csv);
        
    }

    public static void AddEvent(string eventString)
    {
        _eventList.Add(eventString);
    }
}
