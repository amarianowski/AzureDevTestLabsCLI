using Azure.Identity;
using Azure.ResourceManager;
using Microsoft.Extensions.Configuration;

var armClient = new ArmClient(new AzurePowerShellCredential());
var labsManager = new LabsManager(armClient);

// var configuration = new ConfigurationBuilder()
//     .SetBasePath(Directory.GetCurrentDirectory())
//     .AddJsonFile("appsettings.json", optional: false)
//     .Build();

var isRunning = true;

while(isRunning == true)
{
    var action = Prompt.PromptForAction();

    switch (action)
    {
        case "0":
            isRunning = false;
            return;

        case "1":
            var virtualMachines = await labsManager.ListLabVirtualMachines();
            Prompt.PromptListOfVirtualMachines(virtualMachines);
            return;

        case "4":

        default: 
            Console.WriteLine("Default");
            return;
    }
}


