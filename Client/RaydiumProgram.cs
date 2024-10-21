using Solnet.Programs.Utilities;
using Solnet.Rpc.Models;
using Solnet.Wallet;
using Solnet.Raydium.Types;
using Solnet.Programs;

namespace Solnet.Raydium.Client
{
    public static class RaydiumAmmProgram
    {
        public static TransactionInstruction SetCUlimit(ulong units)
        {
            List<AccountMeta> keys = new List<AccountMeta>();
            byte[] data = new byte[9];
            data.WriteU8(2, 0);
            data.WriteU64(units, 1);
            return new TransactionInstruction
            {
                ProgramId = ComputeBudgetProgram.ProgramIdKey,
                Keys = keys,
                Data = data
            };
        }
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

        public static TransactionInstruction PerformSwap(SwapBaseInAccounts accounts, ulong amountIn, ulong minimumAmountOut, PublicKey programId)
        {
            List<AccountMeta> keys = new()
                {AccountMeta.ReadOnly(accounts.TokenProgram, false), AccountMeta.Writable(accounts.Amm, false), AccountMeta.ReadOnly(accounts.AmmAuthority, false), AccountMeta.Writable(accounts.AmmOpenOrders, false), AccountMeta.Writable(accounts.AmmTargetOrders, false), AccountMeta.Writable(accounts.BaseVaultAccount, false), AccountMeta.Writable(accounts.QuoteVaultAccount, false), AccountMeta.ReadOnly(accounts.SerumProgram, false), AccountMeta.Writable(accounts.SerumMarket, false), AccountMeta.Writable(accounts.SerumBids, false), AccountMeta.Writable(accounts.SerumAsks, false), AccountMeta.Writable(accounts.SerumEventQueue, false), AccountMeta.Writable(accounts.SerumCoinVaultAccount, false), AccountMeta.Writable(accounts.SerumPcVaultAccount, false), AccountMeta.ReadOnly(accounts.SerumVaultSigner, false), AccountMeta.Writable(accounts.UerSourceTokenAccount, false), AccountMeta.Writable(accounts.UerDestinationTokenAccount, false), AccountMeta.ReadOnly(accounts.UserSourceOwner, true)};
            byte[] _data = new byte[1200];
            int offset = 0;
            _data.WriteU8(9, offset);
            offset += 1;
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
    }
}

