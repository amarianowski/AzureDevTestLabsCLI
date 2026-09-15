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

    // public async Task ListLabVirtualMachines(string labName)
    // {
        
    // }
}