
using System.Text;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Azure Blob Storage exercise\n");

        // Run the examples asynchronously, wait for the results before proceeding
        ProcessAsync().GetAwaiter().GetResult();

        Console.WriteLine("Press enter to exit the sample application.");
        Console.ReadLine();

        static async Task ProcessAsync()
        {
            // Copy the connection string from the portal in the variable below.
            string storageConnectionString = "<<storage connection string here>>";

            // Create a client that can authenticate with a connection string
            BlobServiceClient blobServiceClient = new BlobServiceClient(storageConnectionString);

            // COPY EXAMPLE CODEß BELOW HERE
            //Create a unique name for the container
            // string containerName = "wtblob" + Guid.NewGuid().ToString();

            // Create the container and return a container client object
            // BlobContainerClient containerClient = await blobServiceClient.CreateBlobContainerAsync(containerName);
            // Console.WriteLine("A container named '" + containerName + "' has been created. " +
            //     "\nTake a minute and verify in the portal." +
            //     "\nNext a file will be created and uploaded to the container.");
            // Console.WriteLine("Press 'Enter' to continue.");
            // Console.ReadLine();

            var createdContainerName = "wtblob77f597a2-3d23-4740-b2ac-1b3b71010185";
            var container = blobServiceClient.GetBlobContainers(BlobContainerTraits.None, prefix: "wtblob")
                .FirstOrDefault(a => a.Name.Equals(createdContainerName, StringComparison.InvariantCultureIgnoreCase));

            var containerClient = blobServiceClient.GetBlobContainerClient(createdContainerName);
            await using FileStream uploadFileStream = File.OpenRead("../../../data/wtblob-upload.txt");
            var blobInfo = await containerClient.UploadBlobAsync($"wtblob{Guid.NewGuid()}".ToLower(), await BinaryData.FromStreamAsync(uploadFileStream));
            Console.Write(blobInfo.Value.BlobSequenceNumber);

        }
    }
}