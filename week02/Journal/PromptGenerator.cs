public class PromptGenerator
{
    public List<string> _prompts =
    [
        "Who did you talk to today?",
        "What made you smile today?",
        "What was the best part of your day?",
        "What did you learn today?",
        "How are you feeling right now?"
    ];

    public string RandomPrompt()
    {
        Random number = new Random();
        int index = number.Next(_prompts.Count);
        string prompt = _prompts[index];

        return prompt;
    }
}