public interface IOutputWriter
	{
    	void Write(string text);
	}
 
public sealed class SomeConsoleOutputWriter: IoutputWriter
{
    public void Write(string text)
    {
        Console.Write(text);
    }
}
/*
 	*  Extend SomeConsoleOutputWriter to output additional symbols to the console
 	*  Example: -------------- text --------------
 	*/
