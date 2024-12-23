using SingleResponsibiltyPrinciple;

JournalA journalA = new();

journalA.AddEntry("I learned about Streams in C#");
journalA.AddEntry("I went to Gym");
journalA.AddEntry("I learned about SRP in SOLID Princiles in C#");

journalA.SaveJournal();


JournalB journalB = new();

journalB.AddEntry("I learned about Streams in C#");
journalB.AddEntry("I went to Gym");
journalB.AddEntry("I learned about SRP in SOLID Princiles in C#");

IPersistJournal journalPersistence = new JournalFilePersistence();

journalPersistence.Save(journalB);