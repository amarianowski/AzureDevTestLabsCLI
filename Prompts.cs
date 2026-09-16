using ConsoleTables;

public class Prompt()
{

    public static string PromptForAction()
    {
        Console.WriteLine("[1] - List virtual machines");
        Console.WriteLine("[2] - Create virtual machine");
        Console.WriteLine("[3] - Delete virtual machine");
        Console.WriteLine("[4] - Start virtual machine");
        Console.WriteLine("[5] - Stop virtual machine");
        Console.WriteLine("[0] - Exit");
        Console.Write("Selection: ");

        var selection = Console.ReadLine();

        return selection;
    }

    public static string PromptForVirtualMachine(List<VirtualMachine> virtualMachines)
    {
        Console.WriteLine("Please select lab: ");

        for(var i = 0; i<labs.Count; i++)
        {
            Console.WriteLine($"{i} - {labs[i].Name}");
        }

        Console.Write("Virtual Machine: ");
        Console.ReadLine()
    }

    public static void PromptForLab(List<Lab> labs)
    {
        Console.WriteLine("Please select lab: ");

        for(var i = 0; i<labs.Count; i++)
        {
            Console.WriteLine($"{i} - {labs[i].Name}");
        }
    }

    public static void PromptListOfVirtualMachines(List<VirtualMachine> virtualMachines) =>
        ConsoleTable.From<VirtualMachine>(virtualMachines).Write();
}