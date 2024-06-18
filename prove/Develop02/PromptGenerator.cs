using System;
using System.Collections.Generic;

public class PromptGenerator
{
    private List<string> _prompts = new List<string>
    {
        "What is something good that happened today?",
        "What are you grateful for today?",
        "Who did you talk to today?",
        "How did you feel today?",
        "Where did you go today?"
    };

    public string GetRandomPrompt()
    {
        Random rand = new Random();
        return _prompts[rand.Next(_prompts.Count)];
    }
}
