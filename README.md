
![raydium-small](https://github.com/user-attachments/assets/4cc1bc3d-6f0c-4a52-bc59-4466ddc68c9f)


# Solnet.Raydium
A C# SDK & Client for Rayium's V4 Amm program on Solana

### Dependencies
- NET8
- Solnet.Rpc
- Solnet.Wallet
- Solnet.Programs

#### Search for the NET8 tag on nuget to find the latest versions of Solnet

### Quickstart

```
using Solnet.Programs.Utilities;
using Solnet.Raydium.Client;
using Solnet.Raydium.Types;
using Solnet.Rpc;
using Solnet.Wallet;

IRpcClient connection = ClientFactory.GetClient("RPC LINK HERE");
RaydiumAmmClient raydiumAmmClient = new RaydiumAmmClient(connection);

Account trader = Account.FromSecretKey("SECRET KEY HERE");

//amountIn must be in lamports
//Minimum out can be 0 to always execute no matter what or set it specifically to apply a fixed slippage rate
var swap_test = await raydiumAmmClient.SendSwapAsync(new PublicKey("POOL ADDRESS HERE"), SolHelper.ConvertToLamports(0.01m), 0, OrderSide.Buy, trader, trader);

Console.WriteLine(swap_test.RawRpcResponse.ToString());
Console.ReadKey();
```
