namespace InterfaceSegregationPrinciple;


public record Document(Guid Id, byte[] Data);


/// <summary>
/// This violates Interface Segregation Principle as it forces 
/// the SimplePrinter to implement Fax and Scan functionalities
/// </summary>

internal interface IDocumentMachine
{
    void Print(Document document);
    void Fax(Document document);
    void Scan(Document document);
}
internal class SimplePrinter : IDocumentMachine
{
    public void Fax(Document document)
    {
        throw new NotImplementedException();
    }

    public void Print(Document document)
    {
        Console.WriteLine("Printing..");
    }

    public void Scan(Document document)
    {
        throw new NotImplementedException();
    }
} 

internal interface IFax
{
    void Fax(Document document);
}
internal interface IPrint
{
    void Print(Document document);
}

internal interface IScan
{
    void Scan(Document document);
}

internal class Scanner : IScan
{
    public void Scan(Document document)
    {
        Console.WriteLine($"Scanning the document {document.Id}");
    }
}

internal interface IMultiPurposeDocumentMachine: IFax, IScan, IPrint
{

}

internal class CanonMultiPurposePrinter : IMultiPurposeDocumentMachine
{
    public void Fax(Document document)
    {
        Console.WriteLine($"Faxing the document {document.Id}");
    }

    public void Print(Document document)
    {
        Console.WriteLine($"Printing the document {document.Id}");
    }

    public void Scan(Document document)
    {
        Console.WriteLine($"Scanning the document {document.Id}");
    }
}
