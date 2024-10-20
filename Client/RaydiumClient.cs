using System;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;
using Solnet.Programs.Abstract;
using Solnet.Programs.Utilities;
using Solnet.Raydium.Types;
using Solnet.Rpc;
using Solnet.Rpc.Builders;
using Solnet.Programs.Models;
using Solnet.Rpc.Core.Http;
using Solnet.Rpc.Core.Sockets;
using Solnet.Rpc.Types;
using Solnet.Rpc.Models;
using Solnet.Wallet;
using Solnet.Raydium.Library;
using System.Diagnostics;

namespace Solnet.Raydium.Client
{
    public class RaydiumAmmClient
    {
        public IRpcClient RpcClient { get; set; }
        public RaydiumAmmClient(IRpcClient rpcClient)
        {
            RpcClient = rpcClient;
        }

        public async Task<RequestResult<string>> BuildSignSend(Account trader, PublicKey feePayer, TransactionInstruction instr)
        {
            try
            {
                var blockhash = await RpcClient.GetLatestBlockHashAsync();
                TransactionBuilder builder = new TransactionBuilder();
                builder.SetFeePayer(feePayer);
                builder.SetRecentBlockHash(blockhash.Result.Value.Blockhash);
                builder.AddInstruction(instr);
                var tx = builder.Build(trader);

                return await RpcClient.SendTransactionAsync(tx);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);

                return new RequestResult<string>() {Result = ex.Message };
            }

        }
        public async Task<ProgramAccountsResultWrapper<List<TargetOrders>>> GetTargetOrderssAsync(string programAddress, Commitment commitment = Commitment.Finalized)
        {
            var list = new List<MemCmp> { new MemCmp { Bytes = TargetOrders.ACCOUNT_DISCRIMINATOR_B58, Offset = 0 } };
            var res = await RpcClient.GetProgramAccountsAsync(programAddress, commitment, memCmpList: list);
            if (!res.WasSuccessful || !(res.Result?.Count > 0))
                return new ProgramAccountsResultWrapper<List<TargetOrders>>(res);
            List<TargetOrders> resultingAccounts = new List<TargetOrders>(res.Result.Count);
            resultingAccounts.AddRange(res.Result.Select(result => TargetOrders.Deserialize(Convert.FromBase64String(result.Account.Data[0]))));
            return new ProgramAccountsResultWrapper<List<TargetOrders>>(res, resultingAccounts);
        }

        public async Task<ProgramAccountsResultWrapper<List<Fees>>> GetFeessAsync(string programAddress, Commitment commitment = Commitment.Finalized)
        {
            var list = new List<MemCmp> { new MemCmp { Bytes = Fees.ACCOUNT_DISCRIMINATOR_B58, Offset = 0 } };
            var res = await RpcClient.GetProgramAccountsAsync(programAddress, commitment, memCmpList: list);
            if (!res.WasSuccessful || !(res.Result?.Count > 0))
                return new ProgramAccountsResultWrapper<List<Fees>>(res);
            List<Fees> resultingAccounts = new List<Fees>(res.Result.Count);
            resultingAccounts.AddRange(res.Result.Select(result => Fees.Deserialize(Convert.FromBase64String(result.Account.Data[0]))));
            return new ProgramAccountsResultWrapper<List<Fees>>(res, resultingAccounts);
        }

        public async Task<ProgramAccountsResultWrapper<List<AmmInfo>>> GetAmmInfosAsync(string programAddress, Commitment commitment = Commitment.Finalized)
        {
            var list = new List<MemCmp> { new MemCmp { Bytes = AmmInfo.ACCOUNT_DISCRIMINATOR_B58, Offset = 0 } };
            var res = await RpcClient.GetProgramAccountsAsync(programAddress, commitment, memCmpList: list);
            if (!res.WasSuccessful || !(res.Result?.Count > 0))
                return new ProgramAccountsResultWrapper<List<AmmInfo>>(res);
            List<AmmInfo> resultingAccounts = new List<AmmInfo>(res.Result.Count);
            resultingAccounts.AddRange(res.Result.Select(result => AmmInfo.Deserialize(Convert.FromBase64String(result.Account.Data[0]))));
            return new ProgramAccountsResultWrapper<List<AmmInfo>>(res, resultingAccounts);
        }

        public async Task<AccountResultWrapper<TargetOrders>> GetTargetOrdersAsync(string accountAddress, Commitment commitment = Commitment.Finalized)
        {
            var res = await RpcClient.GetAccountInfoAsync(accountAddress, commitment);
            if (!res.WasSuccessful)
                return new AccountResultWrapper<TargetOrders>(res);
            var resultingAccount = TargetOrders.Deserialize(Convert.FromBase64String(res.Result.Value.Data[0]));
            return new AccountResultWrapper<TargetOrders>(res, resultingAccount);
        }

        public async Task<AccountResultWrapper<Fees>> GetFeesAsync(string accountAddress, Commitment commitment = Commitment.Finalized)
        {
            var res = await RpcClient.GetAccountInfoAsync(accountAddress, commitment);
            if (!res.WasSuccessful)
                return new AccountResultWrapper<Fees>(res);
            var resultingAccount = Fees.Deserialize(Convert.FromBase64String(res.Result.Value.Data[0]));
            return new AccountResultWrapper<Fees>(res, resultingAccount);
        }

        public async Task<AccountResultWrapper<AmmInfo>> GetAmmInfoAsync(string poolAddress, Commitment commitment = Commitment.Finalized)
        {
            var res = await RpcClient.GetAccountInfoAsync(poolAddress, commitment);
            if (!res.WasSuccessful)
                return new AccountResultWrapper<AmmInfo>(res);
            var resultingAccount = AmmInfo.Deserialize(Convert.FromBase64String(res.Result.Value.Data[0]));
            return new AccountResultWrapper<AmmInfo>(res, resultingAccount);
        }

        public async Task<RequestResult<string>> SendInitializeAsync(InitializeAccounts accounts, byte nonce, ulong openTime, PublicKey feePayer, Account trader, PublicKey programId)
        {
            TransactionInstruction instr = RaydiumAmmProgram.Initialize(accounts, nonce, openTime, programId);      
            return await BuildSignSend(trader, feePayer, instr);
        }

        public async Task<RequestResult<string>> SendInitialize2Async(Initialize2Accounts accounts, byte nonce, ulong openTime, ulong initPcAmount, ulong initCoinAmount, PublicKey feePayer, Account trader, PublicKey programId)
        {
            TransactionInstruction instr = RaydiumAmmProgram.Initialize2(accounts, nonce, openTime, initPcAmount, initCoinAmount, programId);
            return await BuildSignSend(trader, feePayer, instr);
        }

        public async Task<RequestResult<string>> SendDepositAsync(DepositAccounts accounts, ulong maxCoinAmount, ulong maxPcAmount, ulong baseSide, PublicKey feePayer, Account trader, PublicKey programId)
        {
            TransactionInstruction instr = RaydiumAmmProgram.Deposit(accounts, maxCoinAmount, maxPcAmount, baseSide, programId);
            return await BuildSignSend(trader, feePayer, instr);
        }

        public async Task<RequestResult<string>> SendWithdrawAsync(WithdrawAccounts accounts, ulong amount, PublicKey feePayer, Account trader, PublicKey programId)
        {
            TransactionInstruction instr = RaydiumAmmProgram.Withdraw(accounts, amount, programId);
            return await BuildSignSend(trader, feePayer, instr);
        }

        public async Task<RequestResult<string>> SendWithdrawPnlAsync(WithdrawPnlAccounts accounts, PublicKey feePayer, Account trader, PublicKey programId)
        {
            TransactionInstruction instr = RaydiumAmmProgram.WithdrawPnl(accounts, programId);
            return await BuildSignSend(trader, feePayer, instr);
        }

        public async Task<RequestResult<string>> SendWithdrawSrmAsync(WithdrawSrmAccounts accounts, ulong amount, PublicKey feePayer, Account trader, PublicKey programId)
        {
            TransactionInstruction instr = RaydiumAmmProgram.WithdrawSrm(accounts, amount, programId);
            return await BuildSignSend(trader, feePayer, instr);
        }

        public async Task<RequestResult<string>> SendSwapAsync(SwapBaseInAccounts accounts, ulong amountIn, ulong minimumAmountOut, PublicKey feePayer, Account trader, PublicKey programId)
        {
            TransactionInstruction instr = RaydiumAmmProgram.PerformSwap(accounts, amountIn, minimumAmountOut, programId);
            return await BuildSignSend(trader, feePayer, instr);
        }

    }
}
