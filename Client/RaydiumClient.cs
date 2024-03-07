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
using Solnet.Wallet;

namespace Solnet.Raydium.Client
{
    public partial class RaydiumAmmClient : TransactionalBaseClient<RaydiumAmmErrorKind>
    {
        public RaydiumAmmClient(IRpcClient rpcClient, IStreamingRpcClient streamingRpcClient, PublicKey programId) : base(rpcClient, streamingRpcClient, programId)
        {
        }

        public async Task<ProgramAccountsResultWrapper<List<TargetOrders>>> GetTargetOrderssAsync(string programAddress, Commitment commitment = Commitment.Finalized)
        {
            var list = new List<Solnet.Rpc.Models.MemCmp> { new Solnet.Rpc.Models.MemCmp { Bytes = TargetOrders.ACCOUNT_DISCRIMINATOR_B58, Offset = 0 } };
            var res = await RpcClient.GetProgramAccountsAsync(programAddress, commitment, memCmpList: list);
            if (!res.WasSuccessful || !(res.Result?.Count > 0))
                return new ProgramAccountsResultWrapper<List<TargetOrders>>(res);
            List<TargetOrders> resultingAccounts = new List<TargetOrders>(res.Result.Count);
            resultingAccounts.AddRange(res.Result.Select(result => TargetOrders.Deserialize(Convert.FromBase64String(result.Account.Data[0]))));
            return new ProgramAccountsResultWrapper<List<TargetOrders>>(res, resultingAccounts);
        }

        public async Task<ProgramAccountsResultWrapper<List<Fees>>> GetFeessAsync(string programAddress, Commitment commitment = Commitment.Finalized)
        {
            var list = new List<Solnet.Rpc.Models.MemCmp> { new Solnet.Rpc.Models.MemCmp { Bytes = Fees.ACCOUNT_DISCRIMINATOR_B58, Offset = 0 } };
            var res = await RpcClient.GetProgramAccountsAsync(programAddress, commitment, memCmpList: list);
            if (!res.WasSuccessful || !(res.Result?.Count > 0))
                return new ProgramAccountsResultWrapper<List<Fees>>(res);
            List<Fees> resultingAccounts = new List<Fees>(res.Result.Count);
            resultingAccounts.AddRange(res.Result.Select(result => Fees.Deserialize(Convert.FromBase64String(result.Account.Data[0]))));
            return new ProgramAccountsResultWrapper<List<Fees>>(res, resultingAccounts);
        }

        public async Task<ProgramAccountsResultWrapper<List<AmmInfo>>> GetAmmInfosAsync(string programAddress, Commitment commitment = Commitment.Finalized)
        {
            var list = new List<Solnet.Rpc.Models.MemCmp> { new Solnet.Rpc.Models.MemCmp { Bytes = AmmInfo.ACCOUNT_DISCRIMINATOR_B58, Offset = 0 } };
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

        public async Task<SubscriptionState> SubscribeTargetOrdersAsync(string accountAddress, Action<SubscriptionState, Solnet.Rpc.Messages.ResponseValue<Solnet.Rpc.Models.AccountInfo>, TargetOrders> callback, Commitment commitment = Commitment.Finalized)
        {
            SubscriptionState res = await StreamingRpcClient.SubscribeAccountInfoAsync(accountAddress, (s, e) =>
            {
                TargetOrders parsingResult = null;
                if (e.Value?.Data?.Count > 0)
                    parsingResult = TargetOrders.Deserialize(Convert.FromBase64String(e.Value.Data[0]));
                callback(s, e, parsingResult);
            }, commitment);
            return res;
        }

        public async Task<SubscriptionState> SubscribeFeesAsync(string accountAddress, Action<SubscriptionState, Solnet.Rpc.Messages.ResponseValue<Solnet.Rpc.Models.AccountInfo>, Fees> callback, Commitment commitment = Commitment.Finalized)
        {
            SubscriptionState res = await StreamingRpcClient.SubscribeAccountInfoAsync(accountAddress, (s, e) =>
            {
                Fees parsingResult = null;
                if (e.Value?.Data?.Count > 0)
                    parsingResult = Fees.Deserialize(Convert.FromBase64String(e.Value.Data[0]));
                callback(s, e, parsingResult);
            }, commitment);
            return res;
        }

        public async Task<SubscriptionState> SubscribeAmmInfoAsync(string accountAddress, Action<SubscriptionState, Solnet.Rpc.Messages.ResponseValue<Solnet.Rpc.Models.AccountInfo>, AmmInfo> callback, Commitment commitment = Commitment.Finalized)
        {
            SubscriptionState res = await StreamingRpcClient.SubscribeAccountInfoAsync(accountAddress, (s, e) =>
            {
                AmmInfo parsingResult = null;
                if (e.Value?.Data?.Count > 0)
                    parsingResult = AmmInfo.Deserialize(Convert.FromBase64String(e.Value.Data[0]));
                callback(s, e, parsingResult);
            }, commitment);
            return res;
        }

        public async Task<RequestResult<string>> SendInitializeAsync(InitializeAccounts accounts, byte nonce, ulong openTime, PublicKey feePayer, Func<byte[], PublicKey, byte[]> signingCallback, PublicKey programId)
        {
            Solnet.Rpc.Models.TransactionInstruction instr = RaydiumAmmProgram.Initialize(accounts, nonce, openTime, programId);
            return await SignAndSendTransaction(instr, feePayer, signingCallback);
        }

        public async Task<RequestResult<string>> SendInitialize2Async(Initialize2Accounts accounts, byte nonce, ulong openTime, ulong initPcAmount, ulong initCoinAmount, PublicKey feePayer, Func<byte[], PublicKey, byte[]> signingCallback, PublicKey programId)
        {
            Solnet.Rpc.Models.TransactionInstruction instr = RaydiumAmmProgram.Initialize2(accounts, nonce, openTime, initPcAmount, initCoinAmount, programId);
            return await SignAndSendTransaction(instr, feePayer, signingCallback);
        }

        public async Task<RequestResult<string>> SendMonitorStepAsync(MonitorStepAccounts accounts, ushort planOrderLimit, ushort placeOrderLimit, ushort cancelOrderLimit, PublicKey feePayer, Func<byte[], PublicKey, byte[]> signingCallback, PublicKey programId)
        {
            Solnet.Rpc.Models.TransactionInstruction instr = RaydiumAmmProgram.MonitorStep(accounts, planOrderLimit, placeOrderLimit, cancelOrderLimit, programId);
            return await SignAndSendTransaction(instr, feePayer, signingCallback);
        }

        public async Task<RequestResult<string>> SendDepositAsync(DepositAccounts accounts, ulong maxCoinAmount, ulong maxPcAmount, ulong baseSide, PublicKey feePayer, Func<byte[], PublicKey, byte[]> signingCallback, PublicKey programId)
        {
            Solnet.Rpc.Models.TransactionInstruction instr = RaydiumAmmProgram.Deposit(accounts, maxCoinAmount, maxPcAmount, baseSide, programId);
            return await SignAndSendTransaction(instr, feePayer, signingCallback);
        }

        public async Task<RequestResult<string>> SendWithdrawAsync(WithdrawAccounts accounts, ulong amount, PublicKey feePayer, Func<byte[], PublicKey, byte[]> signingCallback, PublicKey programId)
        {
            Solnet.Rpc.Models.TransactionInstruction instr = RaydiumAmmProgram.Withdraw(accounts, amount, programId);
            return await SignAndSendTransaction(instr, feePayer, signingCallback);
        }

        public async Task<RequestResult<string>> SendMigrateToOpenBookAsync(MigrateToOpenBookAccounts accounts, PublicKey feePayer, Func<byte[], PublicKey, byte[]> signingCallback, PublicKey programId)
        {
            Solnet.Rpc.Models.TransactionInstruction instr = RaydiumAmmProgram.MigrateToOpenBook(accounts, programId);
            return await SignAndSendTransaction(instr, feePayer, signingCallback);
        }


        public async Task<RequestResult<string>> SendWithdrawPnlAsync(WithdrawPnlAccounts accounts, PublicKey feePayer, Func<byte[], PublicKey, byte[]> signingCallback, PublicKey programId)
        {
            Solnet.Rpc.Models.TransactionInstruction instr = RaydiumAmmProgram.WithdrawPnl(accounts, programId);
            return await SignAndSendTransaction(instr, feePayer, signingCallback);
        }

        public async Task<RequestResult<string>> SendWithdrawSrmAsync(WithdrawSrmAccounts accounts, ulong amount, PublicKey feePayer, Func<byte[], PublicKey, byte[]> signingCallback, PublicKey programId)
        {
            Solnet.Rpc.Models.TransactionInstruction instr = RaydiumAmmProgram.WithdrawSrm(accounts, amount, programId);
            return await SignAndSendTransaction(instr, feePayer, signingCallback);
        }

        public async Task<RequestResult<string>> SendSwapBaseInAsync(SwapBaseInAccounts accounts, ulong amountIn, ulong minimumAmountOut, PublicKey feePayer, Func<byte[], PublicKey, byte[]> signingCallback, PublicKey programId)
        {
            Solnet.Rpc.Models.TransactionInstruction instr = RaydiumAmmProgram.SwapBaseIn(accounts, amountIn, minimumAmountOut, programId);
            return await SignAndSendTransaction(instr, feePayer, signingCallback);
        }

        public async Task<RequestResult<string>> SendPreInitializeAsync(PreInitializeAccounts accounts, byte nonce, PublicKey feePayer, Func<byte[], PublicKey, byte[]> signingCallback, PublicKey programId)
        {
            Solnet.Rpc.Models.TransactionInstruction instr = RaydiumAmmProgram.PreInitialize(accounts, nonce, programId);
            return await SignAndSendTransaction(instr, feePayer, signingCallback);
        }

        public async Task<RequestResult<string>> SendSwapBaseOutAsync(SwapBaseOutAccounts accounts, ulong maxAmountIn, ulong amountOut, PublicKey feePayer, Func<byte[], PublicKey, byte[]> signingCallback, PublicKey programId)
        {
            Solnet.Rpc.Models.TransactionInstruction instr = RaydiumAmmProgram.SwapBaseOut(accounts, maxAmountIn, amountOut, programId);
            return await SignAndSendTransaction(instr, feePayer, signingCallback);
        }

        public async Task<RequestResult<string>> SendSimulateInfoAsync(SimulateInfoAccounts accounts, byte param, SwapInstructionBaseIn swapBaseInValue, SwapInstructionBaseOut swapBaseOutValue, PublicKey feePayer, Func<byte[], PublicKey, byte[]> signingCallback, PublicKey programId)
        {
            Solnet.Rpc.Models.TransactionInstruction instr = RaydiumAmmProgram.SimulateInfo(accounts, param, swapBaseInValue, swapBaseOutValue, programId);
            return await SignAndSendTransaction(instr, feePayer, signingCallback);
        }

        public async Task<RequestResult<string>> SendAdminCancelOrdersAsync(AdminCancelOrdersAccounts accounts, ushort limit, PublicKey feePayer, Func<byte[], PublicKey, byte[]> signingCallback, PublicKey programId)
        {
            Solnet.Rpc.Models.TransactionInstruction instr = RaydiumAmmProgram.AdminCancelOrders(accounts, limit, programId);
            return await SignAndSendTransaction(instr, feePayer, signingCallback);
        }

        public async Task<RequestResult<string>> SendCreateConfigAccountAsync(CreateConfigAccountAccounts accounts, PublicKey feePayer, Func<byte[], PublicKey, byte[]> signingCallback, PublicKey programId)
        {
            Solnet.Rpc.Models.TransactionInstruction instr = RaydiumAmmProgram.CreateConfigAccount(accounts, programId);
            return await SignAndSendTransaction(instr, feePayer, signingCallback);
        }

        public async Task<RequestResult<string>> SendUpdateConfigAccountAsync(UpdateConfigAccountAccounts accounts, byte param, PublicKey owner, PublicKey feePayer, Func<byte[], PublicKey, byte[]> signingCallback, PublicKey programId)
        {
            Solnet.Rpc.Models.TransactionInstruction instr = RaydiumAmmProgram.UpdateConfigAccount(accounts, param, owner, programId);
            return await SignAndSendTransaction(instr, feePayer, signingCallback);
        }

        protected override Dictionary<uint, ProgramError<RaydiumAmmErrorKind>> BuildErrorsDictionary()
        {
            throw new NotImplementedException();
        }
    }
}
