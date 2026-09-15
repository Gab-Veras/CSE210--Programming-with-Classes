using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Resumes Project.\n");

        Job job1 = new Job();
        job1._jobTitle = "QA & Support";
        job1._company = "FIVE";
        job1._startYear = "2025/Nov";
        job1._endYear = "current";

        Job job2 = new Job();
        job2._jobTitle = "English Teacher";
        job2._company = "KNN";
        job2._startYear = "2025/Mar";
        job2._endYear = "2025/Nov";

        Resume myResume = new Resume();
        myResume._personName = "Gabriel Veras";
        myResume._jobsList.Add(job1);
        myResume._jobsList.Add(job2);

        myResume.DisplayResume();
    }
}