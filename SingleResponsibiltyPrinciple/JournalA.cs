using System;
using System.Collections.Generic;
using System.Linq;
namespace SingleResponsibiltyPrinciple
{   
    /// <summary>
    /// Implementation of Journal that violates the Single Responsibility Principle  
    /// </summary>
    internal class JournalA
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

        // Addition responsibility apart from maintaining Journal itself 
        public void SaveJournal()
        {
            using StreamWriter sw = new(path: "journal_a.txt", append: true);
            sw.WriteLine(this);
        }
    }
}
