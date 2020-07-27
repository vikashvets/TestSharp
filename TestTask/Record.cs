using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;

namespace TestTask
{
    class Record
    {
        private string employeeName;
        private DateTime date;
        private double workHours;

        public Record(string name, DateTime Date, double hours)
        {
            employeeName = name;
            date = Date;
            workHours = hours;
        }
        public string EmployeeName
        {
            get
            {
                return employeeName;
            }

            set
            {
                employeeName = value;
            }
        }

        public DateTime Date
        {
            get
            {
                return date;
            }

            set
            {
                date = value;
            }
        }

        public double WorkHours
        {
            get
            {
                return workHours;
            }

            set
            {
                workHours = value;
            }
        }
        /*public int CompareTo(Record r)
        {
            return this.employeeName.CompareTo(r.employeeName);
        }*/

        public static ArrayList ConvertFileToRecords(string pathToInputFile)
        {
            
            StreamReader streamReader = new StreamReader(pathToInputFile);
            ArrayList recordsList = new ArrayList();
            bool isHeader = true;
            while (!streamReader.EndOfStream)
            {
                if (isHeader)
                {
                    isHeader = false;
                    streamReader.ReadLine();
                }
                else
                {
                    string line = streamReader.ReadLine();
                    string[] lineValues = line.Split(',');
                    Record newRecord = new Record(lineValues[0], Convert.ToDateTime(lineValues[1]), Convert.ToDouble(lineValues[2].Replace('.', ',')));
                    recordsList.Add(newRecord);
                    
                }

            }
            return recordsList;
        }
    }
}
