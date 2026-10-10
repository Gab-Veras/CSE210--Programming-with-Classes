using System;

class ReflectionActivity : Activity
{
    private readonly string[] _prompts =
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private readonly string[] _questions =
    {
        "Why was this experience meaningful to you?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    public ReflectionActivity()
        : base("Reflection Activity", "This activity will help you reflect on times in your life when you have shown strength and resilience.")
    {
    }

    protected override void PerformActivity()
    {
        Random random = new Random();

        Console.WriteLine("Consider the following prompt:");
        Console.WriteLine($"--- {_prompts[random.Next(_prompts.Length)]} ---");
        Console.WriteLine("When you have something in mind, press enter to continue.");
        Console.ReadLine();
        DateTime endTime = DateTime.Now.AddSeconds(Duration);

        while (DateTime.Now < endTime)
        {
            Console.Write($" > {_questions[random.Next(_questions.Length)]} ");
            ShowSpinner(5);
            Console.WriteLine();
        }
    }
}
