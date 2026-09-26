public class ScriptureLibrary
{
    private List<Scripture> _scriptures;

    public ScriptureLibrary()
    {
        _scriptures = new List<Scripture>();

        Reference johnReference = new Reference("John", 3, 16);
        string johnText = "For God so loved the world, that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life.";
        _scriptures.Add(new Scripture(johnReference, johnText));

        Reference proverbsReference = new Reference("Proverbs", 3, 5, 6);
        string proverbsText = "Trust in the Lord with all thine heart; and lean not unto thine own understanding. In all thy ways acknowledge him, and he shall direct thy paths.";
        _scriptures.Add(new Scripture(proverbsReference, proverbsText));
    }

    public Scripture GetRandomScripture()
    {
        Random random = new Random();
        int index = random.Next(_scriptures.Count);
        return _scriptures[index];
    }
}
