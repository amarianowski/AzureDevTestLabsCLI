using Azure.Identity;
using Azure.ResourceManager;
using Microsoft.Extensions.Configuration;

var armClient = new ArmClient(new AzurePowerShellCredential());
var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false)
    .Build();

var labsManager = new LabsManager(armClient);

await labsManager.GetLabList();