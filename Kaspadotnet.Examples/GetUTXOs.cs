using Grpc.Core;
using Kaspadontnet.Clients;
using Protowire;

namespace Kaspadotnet.Examples;

public partial class RpcExamples
{
    public async Task GetUTXOsByAddressExample()
    {
        // Using port 16610 for devnet. Use 16210 for testnet, or don't pass a url for mainnet
        using var kaspadClient = new KaspadClient("http://localhost:16610");
        using var messageStream = kaspadClient.Client.MessageStream();
        var getUTXOsRequest = new KaspadMessage
        {
            GetUtxosByAddressesRequest = new GetUtxosByAddressesRequestMessage
            {
                Addresses = { "kaspa:qpd85et9uptasjzt4cmvglvklrqfxuqn3nrqpsryghegmrgall0sc8vfcnrlj" } // change this to your address
            }
        };
        await messageStream.RequestStream.WriteAsync(getUTXOsRequest);
        await messageStream.ResponseStream.MoveNext();
        var response = messageStream.ResponseStream.Current;
        Console.WriteLine("UTXOs by address: (Printing only 1 for clarity)");
        Console.WriteLine(response.GetUtxosByAddressesResponse.Entries.FirstOrDefault());
    }
}