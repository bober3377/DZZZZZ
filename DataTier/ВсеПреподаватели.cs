﻿using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTier
{
    public class ВсеПреподаватели
    {
        public static List<Преподаватель> ПолучитьВсеПреподавателиИзФайла()
        {
            List<Преподаватель> list = new List<Преподаватель>();

            OpenFileDialog openFileDialog = new OpenFileDialog();

            if (openFileDialog.ShowDialog() == true)
            {
                string FilePath = openFileDialog.FileName;
                using (StreamReader sreader = new StreamReader(FilePath, Encoding.UTF8))
                {
                    while (!sreader.EndOfStream)
                    {
                        string[] line = sreader.ReadLine().Split('*');

                        Преподаватель преподаватель = new Преподаватель()
                        {
                            ФИО = line[0],
                            Группа = line[1],
                            Курс = int.Parse(line[2]),
                            КоличествоЗадолженностей = int.Parse(line[3])
                        };
                        list.Add(преподаватель);
                    }
                }
            }
            return list;
        }
    }
}