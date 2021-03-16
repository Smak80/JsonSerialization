﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

namespace JsonSerialization
{
    class SavingObject
    {
        public int IntValue { get; set; }
        public string Text { get; set; }
        public List<String> TextList;

        public SavingObject(int intValue, string text, List<String> textList = null)
        {
            IntValue = intValue;
            Text = text;
            if (textList == null)
            {
                TextList = new List<string>();
                for (int i = 1; i <= intValue; i++)
                {
                    TextList.Add(Text + " " + i);
                }
            } else
                TextList = textList;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            SavingObject so = new SavingObject(3, "Число ");
            JsonSerializerOptions jso = new JsonSerializerOptions();
            jso.IncludeFields = true;

            using (StreamWriter sw = new StreamWriter("data.json", false, Encoding.UTF8))
            {
                sw.WriteLine(JsonSerializer.Serialize(so, jso));
            }

            using (StreamReader sr = new StreamReader("data.json", Encoding.ASCII))
            {
                var line = sr.ReadLine();
                SavingObject oo = JsonSerializer.Deserialize<SavingObject>(line, jso);
                Console.WriteLine("{0} {1}", oo.IntValue, oo.Text);
                foreach (var lv in oo.TextList)
                {
                    Console.WriteLine("{0}", lv);
                }
            }
        }
    }
}
