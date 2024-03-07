using Solnet.Programs.Abstract;
using Solnet.Programs.Utilities;
using Solnet.Rpc;
using Solnet.Rpc.Builders;
using Solnet.Rpc.Core.Http;
using Solnet.Rpc.Core.Sockets;
using Solnet.Rpc.Types;
using Solnet.Rpc.Models;
using Solnet.Wallet;
using Solnet.Raydium.Types;

namespace Solnet.Raydium.Client
{
    public static class RaydiumAmmProgram
    {
        public static TransactionInstruction Initialize(InitializeAccounts accounts, byte nonce, ulong openTime, PublicKey programId)
        {
            List<AccountMeta> keys = new()
                {AccountMeta.ReadOnly(accounts.TokenProgram, false), AccountMeta.ReadOnly(accounts.SystemProgram, false), AccountMeta.ReadOnly(accounts.Rent, false), AccountMeta.Writable(accounts.Amm, false), AccountMeta.ReadOnly(accounts.AmmAuthority, false), AccountMeta.Writable(accounts.AmmOpenOrders, false), AccountMeta.Writable(accounts.LpMintAddress, false), AccountMeta.ReadOnly(accounts.CoinMintAddress, false), AccountMeta.ReadOnly(accounts.PcMintAddress, false), AccountMeta.ReadOnly(accounts.PoolCoinTokenAccount, false), AccountMeta.ReadOnly(accounts.PoolPcTokenAccount, false), AccountMeta.Writable(accounts.PoolWithdrawQueue, false), AccountMeta.Writable(accounts.PoolTargetOrdersAccount, false), AccountMeta.Writable(accounts.UserLpTokenAccount, false), AccountMeta.ReadOnly(accounts.PoolTempLpTokenAccount, false), AccountMeta.ReadOnly(accounts.SerumProgram, false), AccountMeta.ReadOnly(accounts.SerumMarket, false), AccountMeta.Writable(accounts.UserWallet, true)};
            byte[] _data = new byte[1200];
            int offset = 0;
            _data.WriteU64(17121445590508351407UL, offset);
            offset += 8;
            _data.WriteU8(nonce, offset);
            offset += 1;
            _data.WriteU64(openTime, offset);
            offset += 8;
            byte[] resultData = new byte[offset];
            Array.Copy(_data, resultData, offset);
            return new TransactionInstruction { Keys = keys, ProgramId = programId.KeyBytes, Data = resultData };
        }

        public static TransactionInstruction Initialize2(Initialize2Accounts accounts, byte nonce, ulong openTime, ulong initPcAmount, ulong initCoinAmount, PublicKey programId)
        {
            List<AccountMeta> keys = new()
                {AccountMeta.ReadOnly(accounts.TokenProgram, false), AccountMeta.ReadOnly(accounts.SplAssociatedTokenAccount, false), AccountMeta.ReadOnly(accounts.SystemProgram, false), AccountMeta.ReadOnly(accounts.Rent, false), AccountMeta.Writable(accounts.Amm, false), AccountMeta.ReadOnly(accounts.AmmAuthority, false), AccountMeta.Writable(accounts.AmmOpenOrders, false), AccountMeta.Writable(accounts.LpMint, false), AccountMeta.ReadOnly(accounts.CoinMint, false), AccountMeta.ReadOnly(accounts.PcMint, false), AccountMeta.Writable(accounts.PoolCoinTokenAccount, false), AccountMeta.Writable(accounts.PoolPcTokenAccount, false), AccountMeta.Writable(accounts.PoolWithdrawQueue, false), AccountMeta.Writable(accounts.AmmTargetOrders, false), AccountMeta.Writable(accounts.PoolTempLp, false), AccountMeta.ReadOnly(accounts.SerumProgram, false), AccountMeta.ReadOnly(accounts.SerumMarket, false), AccountMeta.Writable(accounts.UserWallet, true), AccountMeta.Writable(accounts.UserTokenCoin, false), AccountMeta.Writable(accounts.UserTokenPc, false), AccountMeta.Writable(accounts.UserLpTokenAccount, false)};
            byte[] _data = new byte[1200];
            int offset = 0;
            _data.WriteU64(11507577040576367369UL, offset);
            offset += 8;
            _data.WriteU8(nonce, offset);
            offset += 1;
            _data.WriteU64(openTime, offset);
            offset += 8;
            _data.WriteU64(initPcAmount, offset);
            offset += 8;
            _data.WriteU64(initCoinAmount, offset);
            offset += 8;
            byte[] resultData = new byte[offset];
            Array.Copy(_data, resultData, offset);
            return new TransactionInstruction { Keys = keys, ProgramId = programId.KeyBytes, Data = resultData };
        }

        public static TransactionInstruction MonitorStep(MonitorStepAccounts accounts, ushort planOrderLimit, ushort placeOrderLimit, ushort cancelOrderLimit, PublicKey programId)
        {
            List<AccountMeta> keys = new()
                {AccountMeta.ReadOnly(accounts.TokenProgram, false), AccountMeta.ReadOnly(accounts.Rent, false), AccountMeta.ReadOnly(accounts.Clock, false), AccountMeta.Writable(accounts.Amm, false), AccountMeta.ReadOnly(accounts.AmmAuthority, false), AccountMeta.Writable(accounts.AmmOpenOrders, false), AccountMeta.Writable(accounts.AmmTargetOrders, false), AccountMeta.Writable(accounts.PoolCoinTokenAccount, false), AccountMeta.Writable(accounts.PoolPcTokenAccount, false), AccountMeta.Writable(accounts.PoolWithdrawQueue, false), AccountMeta.ReadOnly(accounts.SerumProgram, false), AccountMeta.Writable(accounts.SerumMarket, false), AccountMeta.Writable(accounts.SerumCoinVaultAccount, false), AccountMeta.Writable(accounts.SerumPcVaultAccount, false), AccountMeta.ReadOnly(accounts.SerumVaultSigner, false), AccountMeta.Writable(accounts.SerumReqQ, false), AccountMeta.Writable(accounts.SerumEventQ, false), AccountMeta.Writable(accounts.SerumBids, false), AccountMeta.Writable(accounts.SerumAsks, false)};
            byte[] _data = new byte[1200];
            int offset = 0;
            _data.WriteU64(11104389416331959292UL, offset);
            offset += 8;
            _data.WriteU16(planOrderLimit, offset);
            offset += 2;
            _data.WriteU16(placeOrderLimit, offset);
            offset += 2;
            _data.WriteU16(cancelOrderLimit, offset);
            offset += 2;
            byte[] resultData = new byte[offset];
            Array.Copy(_data, resultData, offset);
            return new TransactionInstruction { Keys = keys, ProgramId = programId.KeyBytes, Data = resultData };
        }

        public static TransactionInstruction Deposit(DepositAccounts accounts, ulong maxCoinAmount, ulong maxPcAmount, ulong baseSide, PublicKey programId)
        {
            List<AccountMeta> keys = new()
                {AccountMeta.ReadOnly(accounts.TokenProgram, false), AccountMeta.Writable(accounts.Amm, false), AccountMeta.ReadOnly(accounts.AmmAuthority, false), AccountMeta.ReadOnly(accounts.AmmOpenOrders, false), AccountMeta.Writable(accounts.AmmTargetOrders, false), AccountMeta.Writable(accounts.LpMintAddress, false), AccountMeta.Writable(accounts.PoolCoinTokenAccount, false), AccountMeta.Writable(accounts.PoolPcTokenAccount, false), AccountMeta.ReadOnly(accounts.SerumMarket, false), AccountMeta.Writable(accounts.UserCoinTokenAccount, false), AccountMeta.Writable(accounts.UserPcTokenAccount, false), AccountMeta.Writable(accounts.UserLpTokenAccount, false), AccountMeta.ReadOnly(accounts.UserOwner, true), AccountMeta.ReadOnly(accounts.SerumEventQueue, false)};
            byte[] _data = new byte[1200];
            int offset = 0;
            _data.WriteU64(13182846803881894898UL, offset);
            offset += 8;
            _data.WriteU64(maxCoinAmount, offset);
            offset += 8;
            _data.WriteU64(maxPcAmount, offset);
            offset += 8;
            _data.WriteU64(baseSide, offset);
            offset += 8;
            byte[] resultData = new byte[offset];
            Array.Copy(_data, resultData, offset);
            return new TransactionInstruction { Keys = keys, ProgramId = programId.KeyBytes, Data = resultData };
        }

        public static TransactionInstruction Withdraw(WithdrawAccounts accounts, ulong amount, PublicKey programId)
        {
            List<AccountMeta> keys = new()
                {AccountMeta.ReadOnly(accounts.TokenProgram, false), AccountMeta.Writable(accounts.Amm, false), AccountMeta.ReadOnly(accounts.AmmAuthority, false), AccountMeta.Writable(accounts.AmmOpenOrders, false), AccountMeta.Writable(accounts.AmmTargetOrders, false), AccountMeta.Writable(accounts.LpMintAddress, false), AccountMeta.Writable(accounts.PoolCoinTokenAccount, false), AccountMeta.Writable(accounts.PoolPcTokenAccount, false), AccountMeta.Writable(accounts.PoolWithdrawQueue, false), AccountMeta.Writable(accounts.PoolTempLpTokenAccount, false), AccountMeta.ReadOnly(accounts.SerumProgram, false), AccountMeta.Writable(accounts.SerumMarket, false), AccountMeta.Writable(accounts.SerumCoinVaultAccount, false), AccountMeta.Writable(accounts.SerumPcVaultAccount, false), AccountMeta.ReadOnly(accounts.SerumVaultSigner, false), AccountMeta.Writable(accounts.UserLpTokenAccount, false), AccountMeta.Writable(accounts.UerCoinTokenAccount, false), AccountMeta.Writable(accounts.UerPcTokenAccount, false), AccountMeta.ReadOnly(accounts.UserOwner, true), AccountMeta.Writable(accounts.SerumEventQ, false), AccountMeta.Writable(accounts.SerumBids, false), AccountMeta.Writable(accounts.SerumAsks, false)};
            byte[] _data = new byte[1200];
            int offset = 0;
            _data.WriteU64(2495396153584390839UL, offset);
            offset += 8;
            _data.WriteU64(amount, offset);
            offset += 8;
            byte[] resultData = new byte[offset];
            Array.Copy(_data, resultData, offset);
            return new TransactionInstruction { Keys = keys, ProgramId = programId.KeyBytes, Data = resultData };
        }

        public static TransactionInstruction MigrateToOpenBook(MigrateToOpenBookAccounts accounts, PublicKey programId)
        {
            List<AccountMeta> keys = new()
                {AccountMeta.ReadOnly(accounts.TokenProgram, false), AccountMeta.ReadOnly(accounts.SystemProgram, false), AccountMeta.ReadOnly(accounts.Rent, false), AccountMeta.Writable(accounts.Amm, false), AccountMeta.ReadOnly(accounts.AmmAuthority, false), AccountMeta.Writable(accounts.AmmOpenOrders, false), AccountMeta.Writable(accounts.AmmTokenCoin, false), AccountMeta.Writable(accounts.AmmTokenPc, false), AccountMeta.Writable(accounts.AmmTargetOrders, false), AccountMeta.ReadOnly(accounts.SerumProgram, false), AccountMeta.Writable(accounts.SerumMarket, false), AccountMeta.Writable(accounts.SerumBids, false), AccountMeta.Writable(accounts.SerumAsks, false), AccountMeta.Writable(accounts.SerumEventQueue, false), AccountMeta.Writable(accounts.SerumCoinVault, false), AccountMeta.Writable(accounts.SerumPcVault, false), AccountMeta.ReadOnly(accounts.SerumVaultSigner, false), AccountMeta.Writable(accounts.NewAmmOpenOrders, false), AccountMeta.ReadOnly(accounts.NewSerumProgram, false), AccountMeta.ReadOnly(accounts.NewSerumMarket, false), AccountMeta.Writable(accounts.Admin, true)};
            byte[] _data = new byte[1200];
            int offset = 0;
            _data.WriteU64(1499046057142870735UL, offset);
            offset += 8;
            byte[] resultData = new byte[offset];
            Array.Copy(_data, resultData, offset);
            return new TransactionInstruction { Keys = keys, ProgramId = programId.KeyBytes, Data = resultData };
        }


        public static TransactionInstruction WithdrawPnl(WithdrawPnlAccounts accounts, PublicKey programId)
        {
            List<AccountMeta> keys = new()
                {AccountMeta.ReadOnly(accounts.TokenProgram, false), AccountMeta.Writable(accounts.Amm, false), AccountMeta.ReadOnly(accounts.AmmConfig, false), AccountMeta.ReadOnly(accounts.AmmAuthority, false), AccountMeta.Writable(accounts.AmmOpenOrders, false), AccountMeta.Writable(accounts.PoolCoinTokenAccount, false), AccountMeta.Writable(accounts.PoolPcTokenAccount, false), AccountMeta.Writable(accounts.CoinPnlTokenAccount, false), AccountMeta.Writable(accounts.PcPnlTokenAccount, false), AccountMeta.ReadOnly(accounts.PnlOwnerAccount, true), AccountMeta.Writable(accounts.AmmTargetOrders, false), AccountMeta.ReadOnly(accounts.SerumProgram, false), AccountMeta.Writable(accounts.SerumMarket, false), AccountMeta.ReadOnly(accounts.SerumEventQueue, false), AccountMeta.Writable(accounts.SerumCoinVaultAccount, false), AccountMeta.Writable(accounts.SerumPcVaultAccount, false), AccountMeta.ReadOnly(accounts.SerumVaultSigner, false)};
            byte[] _data = new byte[1200];
            int offset = 0;
            _data.WriteU64(6844329438820050006UL, offset);
            offset += 8;
            byte[] resultData = new byte[offset];
            Array.Copy(_data, resultData, offset);
            return new TransactionInstruction { Keys = keys, ProgramId = programId.KeyBytes, Data = resultData };
        }

        public static TransactionInstruction WithdrawSrm(WithdrawSrmAccounts accounts, ulong amount, PublicKey programId)
        {
            List<AccountMeta> keys = new()
                {AccountMeta.ReadOnly(accounts.TokenProgram, false), AccountMeta.ReadOnly(accounts.Amm, false), AccountMeta.ReadOnly(accounts.AmmOwnerAccount, true), AccountMeta.ReadOnly(accounts.AmmAuthority, false), AccountMeta.Writable(accounts.SrmToken, false), AccountMeta.Writable(accounts.DestSrmToken, false)};
            byte[] _data = new byte[1200];
            int offset = 0;
            _data.WriteU64(2261737716267509185UL, offset);
            offset += 8;
            _data.WriteU64(amount, offset);
            offset += 8;
            byte[] resultData = new byte[offset];
            Array.Copy(_data, resultData, offset);
            return new TransactionInstruction { Keys = keys, ProgramId = programId.KeyBytes, Data = resultData };
        }

        public static TransactionInstruction SwapBaseIn(SwapBaseInAccounts accounts, ulong amountIn, ulong minimumAmountOut, PublicKey programId)
        {
            List<AccountMeta> keys = new()
                {AccountMeta.ReadOnly(accounts.TokenProgram, false), AccountMeta.Writable(accounts.Amm, false), AccountMeta.ReadOnly(accounts.AmmAuthority, false), AccountMeta.Writable(accounts.AmmOpenOrders, false), AccountMeta.Writable(accounts.AmmTargetOrders, false), AccountMeta.Writable(accounts.PoolCoinTokenAccount, false), AccountMeta.Writable(accounts.PoolPcTokenAccount, false), AccountMeta.ReadOnly(accounts.SerumProgram, false), AccountMeta.Writable(accounts.SerumMarket, false), AccountMeta.Writable(accounts.SerumBids, false), AccountMeta.Writable(accounts.SerumAsks, false), AccountMeta.Writable(accounts.SerumEventQueue, false), AccountMeta.Writable(accounts.SerumCoinVaultAccount, false), AccountMeta.Writable(accounts.SerumPcVaultAccount, false), AccountMeta.ReadOnly(accounts.SerumVaultSigner, false), AccountMeta.Writable(accounts.UerSourceTokenAccount, false), AccountMeta.Writable(accounts.UerDestinationTokenAccount, false), AccountMeta.ReadOnly(accounts.UserSourceOwner, true)};
            byte[] _data = new byte[1200];
            int offset = 0;
            _data.WriteU64(6063842853661502506UL, offset);
            offset += 8;
            _data.WriteU64(amountIn, offset);
            offset += 8;
            _data.WriteU64(minimumAmountOut, offset);
            offset += 8;
            byte[] resultData = new byte[offset];
            Array.Copy(_data, resultData, offset);
            return new TransactionInstruction { Keys = keys, ProgramId = programId.KeyBytes, Data = resultData };
        }

        public static TransactionInstruction PreInitialize(PreInitializeAccounts accounts, byte nonce, PublicKey programId)
        {
            List<AccountMeta> keys = new()
                {AccountMeta.ReadOnly(accounts.TokenProgram, false), AccountMeta.ReadOnly(accounts.SystemProgram, false), AccountMeta.ReadOnly(accounts.Rent, false), AccountMeta.Writable(accounts.AmmTargetOrders, false), AccountMeta.Writable(accounts.PoolWithdrawQueue, false), AccountMeta.ReadOnly(accounts.AmmAuthority, false), AccountMeta.Writable(accounts.LpMintAddress, false), AccountMeta.ReadOnly(accounts.CoinMintAddress, false), AccountMeta.ReadOnly(accounts.PcMintAddress, false), AccountMeta.Writable(accounts.PoolCoinTokenAccount, false), AccountMeta.Writable(accounts.PoolPcTokenAccount, false), AccountMeta.Writable(accounts.PoolTempLpTokenAccount, false), AccountMeta.ReadOnly(accounts.SerumMarket, false), AccountMeta.Writable(accounts.UserWallet, true)};
            byte[] _data = new byte[1200];
            int offset = 0;
            _data.WriteU64(210733249743772927UL, offset);
            offset += 8;
            _data.WriteU8(nonce, offset);
            offset += 1;
            byte[] resultData = new byte[offset];
            Array.Copy(_data, resultData, offset);
            return new TransactionInstruction { Keys = keys, ProgramId = programId.KeyBytes, Data = resultData };
        }

        public static TransactionInstruction SwapBaseOut(SwapBaseOutAccounts accounts, ulong maxAmountIn, ulong amountOut, PublicKey programId)
        {
            List<AccountMeta> keys = new()
                {AccountMeta.ReadOnly(accounts.TokenProgram, false), AccountMeta.Writable(accounts.Amm, false), AccountMeta.ReadOnly(accounts.AmmAuthority, false), AccountMeta.Writable(accounts.AmmOpenOrders, false), AccountMeta.Writable(accounts.AmmTargetOrders, false), AccountMeta.Writable(accounts.PoolCoinTokenAccount, false), AccountMeta.Writable(accounts.PoolPcTokenAccount, false), AccountMeta.ReadOnly(accounts.SerumProgram, false), AccountMeta.Writable(accounts.SerumMarket, false), AccountMeta.Writable(accounts.SerumBids, false), AccountMeta.Writable(accounts.SerumAsks, false), AccountMeta.Writable(accounts.SerumEventQueue, false), AccountMeta.Writable(accounts.SerumCoinVaultAccount, false), AccountMeta.Writable(accounts.SerumPcVaultAccount, false), AccountMeta.ReadOnly(accounts.SerumVaultSigner, false), AccountMeta.Writable(accounts.UserSourceTokenAccount, false), AccountMeta.Writable(accounts.UserDestinationTokenAccount, false), AccountMeta.ReadOnly(accounts.UserSourceOwner, true)};
            byte[] _data = new byte[1200];
            int offset = 0;
            _data.WriteU64(10868754559545365155UL, offset);
            offset += 8;
            _data.WriteU64(maxAmountIn, offset);
            offset += 8;
            _data.WriteU64(amountOut, offset);
            offset += 8;
            byte[] resultData = new byte[offset];
            Array.Copy(_data, resultData, offset);
            return new TransactionInstruction { Keys = keys, ProgramId = programId.KeyBytes, Data = resultData };
        }

        public static TransactionInstruction SimulateInfo(SimulateInfoAccounts accounts, byte param, SwapInstructionBaseIn swapBaseInValue, SwapInstructionBaseOut swapBaseOutValue, PublicKey programId)
        {
            List<AccountMeta> keys = new()
                {AccountMeta.ReadOnly(accounts.Amm, false), AccountMeta.ReadOnly(accounts.AmmAuthority, false), AccountMeta.ReadOnly(accounts.AmmOpenOrders, false), AccountMeta.ReadOnly(accounts.PoolCoinTokenAccount, false), AccountMeta.ReadOnly(accounts.PoolPcTokenAccount, false), AccountMeta.ReadOnly(accounts.LpMintAddress, false), AccountMeta.ReadOnly(accounts.SerumMarket, false), AccountMeta.ReadOnly(accounts.SerumEventQueue, false)};
            byte[] _data = new byte[1200];
            int offset = 0;
            _data.WriteU64(11580919568694528963UL, offset);
            offset += 8;
            _data.WriteU8(param, offset);
            offset += 1;
            if (swapBaseInValue != null)
            {
                _data.WriteU8(1, offset);
                offset += 1;
                offset += swapBaseInValue.Serialize(_data, offset);
            }
            else
            {
                _data.WriteU8(0, offset);
                offset += 1;
            }

            if (swapBaseOutValue != null)
            {
                _data.WriteU8(1, offset);
                offset += 1;
                offset += swapBaseOutValue.Serialize(_data, offset);
            }
            else
            {
                _data.WriteU8(0, offset);
                offset += 1;
            }

            byte[] resultData = new byte[offset];
            Array.Copy(_data, resultData, offset);
            return new TransactionInstruction { Keys = keys, ProgramId = programId.KeyBytes, Data = resultData };
        }

        public static TransactionInstruction AdminCancelOrders(AdminCancelOrdersAccounts accounts, ushort limit, PublicKey programId)
        {
            List<AccountMeta> keys = new()
                {AccountMeta.ReadOnly(accounts.TokenProgram, false), AccountMeta.ReadOnly(accounts.Amm, false), AccountMeta.ReadOnly(accounts.AmmAuthority, false), AccountMeta.Writable(accounts.AmmOpenOrders, false), AccountMeta.Writable(accounts.AmmTargetOrders, false), AccountMeta.Writable(accounts.PoolCoinTokenAccount, false), AccountMeta.Writable(accounts.PoolPcTokenAccount, false), AccountMeta.ReadOnly(accounts.AmmOwnerAccount, true), AccountMeta.Writable(accounts.AmmConfig, false), AccountMeta.ReadOnly(accounts.SerumProgram, false), AccountMeta.Writable(accounts.SerumMarket, false), AccountMeta.Writable(accounts.SerumCoinVaultAccount, false), AccountMeta.Writable(accounts.SerumPcVaultAccount, false), AccountMeta.ReadOnly(accounts.SerumVaultSigner, false), AccountMeta.Writable(accounts.SerumEventQ, false), AccountMeta.Writable(accounts.SerumBids, false), AccountMeta.Writable(accounts.SerumAsks, false)};
            byte[] _data = new byte[1200];
            int offset = 0;
            _data.WriteU64(6916367689312000663UL, offset);
            offset += 8;
            _data.WriteU16(limit, offset);
            offset += 2;
            byte[] resultData = new byte[offset];
            Array.Copy(_data, resultData, offset);
            return new TransactionInstruction { Keys = keys, ProgramId = programId.KeyBytes, Data = resultData };
        }

        public static TransactionInstruction CreateConfigAccount(CreateConfigAccountAccounts accounts, PublicKey programId)
        {
            List<AccountMeta> keys = new()
                {AccountMeta.Writable(accounts.Admin, true), AccountMeta.Writable(accounts.AmmConfig, false), AccountMeta.ReadOnly(accounts.Owner, false), AccountMeta.ReadOnly(accounts.SystemProgram, false), AccountMeta.ReadOnly(accounts.Rent, false)};
            byte[] _data = new byte[1200];
            int offset = 0;
            _data.WriteU64(7217201236741383102UL, offset);
            offset += 8;
            byte[] resultData = new byte[offset];
            Array.Copy(_data, resultData, offset);
            return new TransactionInstruction { Keys = keys, ProgramId = programId.KeyBytes, Data = resultData };
        }

        public static TransactionInstruction UpdateConfigAccount(UpdateConfigAccountAccounts accounts, byte param, PublicKey owner, PublicKey programId)
        {
            List<AccountMeta> keys = new()
                {AccountMeta.ReadOnly(accounts.Admin, true), AccountMeta.Writable(accounts.AmmConfig, false)};
            byte[] _data = new byte[1200];
            int offset = 0;
            _data.WriteU64(4203878292107436272UL, offset);
            offset += 8;
            _data.WriteU8(param, offset);
            offset += 1;
            _data.WritePubKey(owner, offset);
            offset += 32;
            byte[] resultData = new byte[offset];
            Array.Copy(_data, resultData, offset);
            return new TransactionInstruction { Keys = keys, ProgramId = programId.KeyBytes, Data = resultData };
        }
    }
}

