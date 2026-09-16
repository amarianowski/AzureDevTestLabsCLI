// Search images and store in some way for creation of the VM
// Create Lab VM
// Start/Stop Lab VM
// Delete Lab VM
// Browse Lab VMs

using Azure.Identity;
using Azure.ResourceManager;
using Azure.ResourceManager.Resources;

public class LabsManager(ArmClient client)
{
    public async Task<List<Lab>> GetLabList()
    {
        var resourceQuery = "resourceType eq 'Microsoft.DevTestLab/labs'";
        var subscription = await client.GetDefaultSubscriptionAsync();
        var resources = subscription.GetGenericResources(resourceQuery);          
        var labs = new List<Lab>();

        foreach(var resource in resources)
        {
            var lab = new Lab
            {
                ResourceGroupName = resource.Id.ResourceGroupName,
                Name = resource.Data.Name
            };
            labs.Add(lab);
        }  
        return labs;
    }

    public async Task<List<VirtualMachine>> ListLabVirtualMachines()
    {
        var resourceQuery = $"resourceType eq 'Microsoft.DevTestLab/labs/virtualMachines'";
        var subscription = await client.GetDefaultSubscriptionAsync();
        var resources = subscription.GetGenericResources(resourceQuery);          
        var virtualMachines = new List<VirtualMachine>();

        foreach(var resource in resources)
        {
            var name = resource.Data.Name.Split("/");
            var virtualMachine = new VirtualMachine
            {
                LabName = name[0],
                Name = name[1],
                ResourceGroupName = resource.Id.ResourceGroupName
            };
            virtualMachines.Add(virtualMachine);
        }

        return virtualMachines;
    }
}