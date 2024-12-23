namespace SingleResponsibiltyPrinciple;

/// <summary>
/// Implementation of Journal that follows the Single Responsibility Principle  
/// </summary>
internal class JournalB
{
    private readonly List<string> entries = new();

    private int count = 0;

    public void AddEntry(string entry)
    {
        entries.Add($"{++count} - {entry}");
    }

    public override string ToString()
    {
        return string.Join(Environment.NewLine, entries);
    }
}
internal interface IPersistJournal
{
   void Save(JournalB journal);
}

internal class JournalFilePersistence : IPersistJournal
{
    public void Save(JournalB journal)
    {
        using StreamWriter sw = new(path: "journal_b.txt", append: true);
        sw.WriteLine(journal);
    }
}
