using Entities;
using ScheduleDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleBL
{
    public class ScheduleBL
    {
        FileConnection fileCoonnection;
        List<Subject> subjectsArr;
        public List<Subject> GetAllSubjects()
        {
            subjectsArr = new List<Subject>();
            fileCoonnection = new FileConnection();
            string[] arr;
            fileCoonnection.ReadFromFile(out arr);

            for (int i = 0; i < arr.Length; i++)
            {
                var detailsAsString = arr[i].Split(',');
                Subject subject = new Subject()
                {
                    Name = detailsAsString[0],
                    NumberOfHours = int.Parse(detailsAsString[1])
                };
                subjectsArr.Add(subject);
            }
            return subjectsArr;
        }
        public void InsertNewSubjectAndSave(string name, int numberOfHours)
        {
            string[] subjectsArrStr = new string[subjectsArr.Count+1];
            Subject subject = new Subject();
            subject.Name = name;
            subject.NumberOfHours = numberOfHours;
            fileCoonnection = new FileConnection();

            subjectsArr.Add(subject);
            for (int i = 0; i < subjectsArr.Count; i++)
            {
                string subjectStr = subjectsArr[i].Name + "," + subjectsArr[i].NumberOfHours;
                subjectsArrStr[i] = subjectStr;
            }
            
            fileCoonnection.WriteToFile(subjectsArrStr);
        }
    }
}
