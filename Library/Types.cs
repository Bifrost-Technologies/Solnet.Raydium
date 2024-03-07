using System;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;
using Solnet;
using Solnet.Programs.Abstract;
using Solnet.Programs.Utilities;
using Solnet.Rpc;
using Solnet.Rpc.Builders;
using Solnet.Rpc.Core.Http;
using Solnet.Rpc.Core.Sockets;
using Solnet.Rpc.Types;
using Solnet.Wallet;

namespace Solnet.Raydium.Types
{
    public class InitializeAccounts
    {
        public PublicKey TokenProgram { get; set; }

        public PublicKey SystemProgram { get; set; }

        public PublicKey Rent { get; set; }

        public PublicKey Amm { get; set; }

        public PublicKey AmmAuthority { get; set; }

        public PublicKey AmmOpenOrders { get; set; }

        public PublicKey LpMintAddress { get; set; }

        public PublicKey CoinMintAddress { get; set; }

        public PublicKey PcMintAddress { get; set; }

        public PublicKey PoolCoinTokenAccount { get; set; }

        public PublicKey PoolPcTokenAccount { get; set; }

        public PublicKey PoolWithdrawQueue { get; set; }

        public PublicKey PoolTargetOrdersAccount { get; set; }

        public PublicKey UserLpTokenAccount { get; set; }

        public PublicKey PoolTempLpTokenAccount { get; set; }

        public PublicKey SerumProgram { get; set; }

        public PublicKey SerumMarket { get; set; }

        public PublicKey UserWallet { get; set; }
    }

    public class Initialize2Accounts
    {
        public PublicKey TokenProgram { get; set; }

        public PublicKey SplAssociatedTokenAccount { get; set; }

        public PublicKey SystemProgram { get; set; }

        public PublicKey Rent { get; set; }

        public PublicKey Amm { get; set; }

        public PublicKey AmmAuthority { get; set; }

        public PublicKey AmmOpenOrders { get; set; }

        public PublicKey LpMint { get; set; }

        public PublicKey CoinMint { get; set; }

        public PublicKey PcMint { get; set; }

        public PublicKey PoolCoinTokenAccount { get; set; }

        public PublicKey PoolPcTokenAccount { get; set; }

        public PublicKey PoolWithdrawQueue { get; set; }

        public PublicKey AmmTargetOrders { get; set; }

        public PublicKey PoolTempLp { get; set; }

        public PublicKey SerumProgram { get; set; }

        public PublicKey SerumMarket { get; set; }

        public PublicKey UserWallet { get; set; }

        public PublicKey UserTokenCoin { get; set; }

        public PublicKey UserTokenPc { get; set; }

        public PublicKey UserLpTokenAccount { get; set; }
    }

    public class MonitorStepAccounts
    {
        public PublicKey TokenProgram { get; set; }

        public PublicKey Rent { get; set; }

        public PublicKey Clock { get; set; }

        public PublicKey Amm { get; set; }

        public PublicKey AmmAuthority { get; set; }

        public PublicKey AmmOpenOrders { get; set; }

        public PublicKey AmmTargetOrders { get; set; }

        public PublicKey PoolCoinTokenAccount { get; set; }

        public PublicKey PoolPcTokenAccount { get; set; }

        public PublicKey PoolWithdrawQueue { get; set; }

        public PublicKey SerumProgram { get; set; }

        public PublicKey SerumMarket { get; set; }

        public PublicKey SerumCoinVaultAccount { get; set; }

        public PublicKey SerumPcVaultAccount { get; set; }

        public PublicKey SerumVaultSigner { get; set; }

        public PublicKey SerumReqQ { get; set; }

        public PublicKey SerumEventQ { get; set; }

        public PublicKey SerumBids { get; set; }

        public PublicKey SerumAsks { get; set; }
    }

    public class DepositAccounts
    {
        public PublicKey TokenProgram { get; set; }

        public PublicKey Amm { get; set; }

        public PublicKey AmmAuthority { get; set; }

        public PublicKey AmmOpenOrders { get; set; }

        public PublicKey AmmTargetOrders { get; set; }

        public PublicKey LpMintAddress { get; set; }

        public PublicKey PoolCoinTokenAccount { get; set; }

        public PublicKey PoolPcTokenAccount { get; set; }

        public PublicKey SerumMarket { get; set; }

        public PublicKey UserCoinTokenAccount { get; set; }

        public PublicKey UserPcTokenAccount { get; set; }

        public PublicKey UserLpTokenAccount { get; set; }

        public PublicKey UserOwner { get; set; }

        public PublicKey SerumEventQueue { get; set; }
    }

    public class WithdrawAccounts
    {
        public PublicKey TokenProgram { get; set; }

        public PublicKey Amm { get; set; }

        public PublicKey AmmAuthority { get; set; }

        public PublicKey AmmOpenOrders { get; set; }

        public PublicKey AmmTargetOrders { get; set; }

        public PublicKey LpMintAddress { get; set; }

        public PublicKey PoolCoinTokenAccount { get; set; }

        public PublicKey PoolPcTokenAccount { get; set; }

        public PublicKey PoolWithdrawQueue { get; set; }

        public PublicKey PoolTempLpTokenAccount { get; set; }

        public PublicKey SerumProgram { get; set; }

        public PublicKey SerumMarket { get; set; }

        public PublicKey SerumCoinVaultAccount { get; set; }

        public PublicKey SerumPcVaultAccount { get; set; }

        public PublicKey SerumVaultSigner { get; set; }

        public PublicKey UserLpTokenAccount { get; set; }

        public PublicKey UerCoinTokenAccount { get; set; }

        public PublicKey UerPcTokenAccount { get; set; }

        public PublicKey UserOwner { get; set; }

        public PublicKey SerumEventQ { get; set; }

        public PublicKey SerumBids { get; set; }

        public PublicKey SerumAsks { get; set; }
    }

    public class MigrateToOpenBookAccounts
    {
        public PublicKey TokenProgram { get; set; }

        public PublicKey SystemProgram { get; set; }

        public PublicKey Rent { get; set; }

        public PublicKey Amm { get; set; }

        public PublicKey AmmAuthority { get; set; }

        public PublicKey AmmOpenOrders { get; set; }

        public PublicKey AmmTokenCoin { get; set; }

        public PublicKey AmmTokenPc { get; set; }

        public PublicKey AmmTargetOrders { get; set; }

        public PublicKey SerumProgram { get; set; }

        public PublicKey SerumMarket { get; set; }

        public PublicKey SerumBids { get; set; }

        public PublicKey SerumAsks { get; set; }

        public PublicKey SerumEventQueue { get; set; }

        public PublicKey SerumCoinVault { get; set; }

        public PublicKey SerumPcVault { get; set; }

        public PublicKey SerumVaultSigner { get; set; }

        public PublicKey NewAmmOpenOrders { get; set; }

        public PublicKey NewSerumProgram { get; set; }

        public PublicKey NewSerumMarket { get; set; }

        public PublicKey Admin { get; set; }
    }

    public class SetParamsAccounts
    {
        public PublicKey TokenProgram { get; set; }

        public PublicKey Amm { get; set; }

        public PublicKey AmmAuthority { get; set; }

        public PublicKey AmmOpenOrders { get; set; }

        public PublicKey AmmTargetOrders { get; set; }

        public PublicKey AmmCoinVault { get; set; }

        public PublicKey AmmPcVault { get; set; }

        public PublicKey SerumProgram { get; set; }

        public PublicKey SerumMarket { get; set; }

        public PublicKey SerumCoinVault { get; set; }

        public PublicKey SerumPcVault { get; set; }

        public PublicKey SerumVaultSigner { get; set; }

        public PublicKey SerumEventQueue { get; set; }

        public PublicKey SerumBids { get; set; }

        public PublicKey SerumAsks { get; set; }

        public PublicKey AmmAdminAccount { get; set; }
    }

    public class WithdrawPnlAccounts
    {
        public PublicKey TokenProgram { get; set; }

        public PublicKey Amm { get; set; }

        public PublicKey AmmConfig { get; set; }

        public PublicKey AmmAuthority { get; set; }

        public PublicKey AmmOpenOrders { get; set; }

        public PublicKey PoolCoinTokenAccount { get; set; }

        public PublicKey PoolPcTokenAccount { get; set; }

        public PublicKey CoinPnlTokenAccount { get; set; }

        public PublicKey PcPnlTokenAccount { get; set; }

        public PublicKey PnlOwnerAccount { get; set; }

        public PublicKey AmmTargetOrders { get; set; }

        public PublicKey SerumProgram { get; set; }

        public PublicKey SerumMarket { get; set; }

        public PublicKey SerumEventQueue { get; set; }

        public PublicKey SerumCoinVaultAccount { get; set; }

        public PublicKey SerumPcVaultAccount { get; set; }

        public PublicKey SerumVaultSigner { get; set; }
    }

    public class WithdrawSrmAccounts
    {
        public PublicKey TokenProgram { get; set; }

        public PublicKey Amm { get; set; }

        public PublicKey AmmOwnerAccount { get; set; }

        public PublicKey AmmAuthority { get; set; }

        public PublicKey SrmToken { get; set; }

        public PublicKey DestSrmToken { get; set; }
    }

    public class SwapBaseInAccounts
    {
        public PublicKey TokenProgram { get; set; }

        public PublicKey Amm { get; set; }

        public PublicKey AmmAuthority { get; set; }

        public PublicKey AmmOpenOrders { get; set; }

        public PublicKey AmmTargetOrders { get; set; }

        public PublicKey PoolCoinTokenAccount { get; set; }

        public PublicKey PoolPcTokenAccount { get; set; }

        public PublicKey SerumProgram { get; set; }

        public PublicKey SerumMarket { get; set; }

        public PublicKey SerumBids { get; set; }

        public PublicKey SerumAsks { get; set; }

        public PublicKey SerumEventQueue { get; set; }

        public PublicKey SerumCoinVaultAccount { get; set; }

        public PublicKey SerumPcVaultAccount { get; set; }

        public PublicKey SerumVaultSigner { get; set; }

        public PublicKey UerSourceTokenAccount { get; set; }

        public PublicKey UerDestinationTokenAccount { get; set; }

        public PublicKey UserSourceOwner { get; set; }
    }

    public class PreInitializeAccounts
    {
        public PublicKey TokenProgram { get; set; }

        public PublicKey SystemProgram { get; set; }

        public PublicKey Rent { get; set; }

        public PublicKey AmmTargetOrders { get; set; }

        public PublicKey PoolWithdrawQueue { get; set; }

        public PublicKey AmmAuthority { get; set; }

        public PublicKey LpMintAddress { get; set; }

        public PublicKey CoinMintAddress { get; set; }

        public PublicKey PcMintAddress { get; set; }

        public PublicKey PoolCoinTokenAccount { get; set; }

        public PublicKey PoolPcTokenAccount { get; set; }

        public PublicKey PoolTempLpTokenAccount { get; set; }

        public PublicKey SerumMarket { get; set; }

        public PublicKey UserWallet { get; set; }
    }

    public class SwapBaseOutAccounts
    {
        public PublicKey TokenProgram { get; set; }

        public PublicKey Amm { get; set; }

        public PublicKey AmmAuthority { get; set; }

        public PublicKey AmmOpenOrders { get; set; }

        public PublicKey AmmTargetOrders { get; set; }

        public PublicKey PoolCoinTokenAccount { get; set; }

        public PublicKey PoolPcTokenAccount { get; set; }

        public PublicKey SerumProgram { get; set; }

        public PublicKey SerumMarket { get; set; }

        public PublicKey SerumBids { get; set; }

        public PublicKey SerumAsks { get; set; }

        public PublicKey SerumEventQueue { get; set; }

        public PublicKey SerumCoinVaultAccount { get; set; }

        public PublicKey SerumPcVaultAccount { get; set; }

        public PublicKey SerumVaultSigner { get; set; }

        public PublicKey UserSourceTokenAccount { get; set; }

        public PublicKey UserDestinationTokenAccount { get; set; }

        public PublicKey UserSourceOwner { get; set; }
    }

    public class SimulateInfoAccounts
    {
        public PublicKey Amm { get; set; }

        public PublicKey AmmAuthority { get; set; }

        public PublicKey AmmOpenOrders { get; set; }

        public PublicKey PoolCoinTokenAccount { get; set; }

        public PublicKey PoolPcTokenAccount { get; set; }

        public PublicKey LpMintAddress { get; set; }

        public PublicKey SerumMarket { get; set; }

        public PublicKey SerumEventQueue { get; set; }
    }

    public class AdminCancelOrdersAccounts
    {
        public PublicKey TokenProgram { get; set; }

        public PublicKey Amm { get; set; }

        public PublicKey AmmAuthority { get; set; }

        public PublicKey AmmOpenOrders { get; set; }

        public PublicKey AmmTargetOrders { get; set; }

        public PublicKey PoolCoinTokenAccount { get; set; }

        public PublicKey PoolPcTokenAccount { get; set; }

        public PublicKey AmmOwnerAccount { get; set; }

        public PublicKey AmmConfig { get; set; }

        public PublicKey SerumProgram { get; set; }

        public PublicKey SerumMarket { get; set; }

        public PublicKey SerumCoinVaultAccount { get; set; }

        public PublicKey SerumPcVaultAccount { get; set; }

        public PublicKey SerumVaultSigner { get; set; }

        public PublicKey SerumEventQ { get; set; }

        public PublicKey SerumBids { get; set; }

        public PublicKey SerumAsks { get; set; }
    }

    public class CreateConfigAccountAccounts
    {
        public PublicKey Admin { get; set; }

        public PublicKey AmmConfig { get; set; }

        public PublicKey Owner { get; set; }

        public PublicKey SystemProgram { get; set; }

        public PublicKey Rent { get; set; }
    }

    public class UpdateConfigAccountAccounts
    {
        public PublicKey Admin { get; set; }

        public PublicKey AmmConfig { get; set; }
    }
    public partial class WithdrawDestToken
    {
        public ulong WithdrawAmount { get; set; }

        public ulong CoinAmount { get; set; }

        public ulong PcAmount { get; set; }

        public PublicKey DestTokenCoin { get; set; }

        public PublicKey DestTokenPc { get; set; }

        public int Serialize(byte[] _data, int initialOffset)
        {
            int offset = initialOffset;
            _data.WriteU64(WithdrawAmount, offset);
            offset += 8;
            _data.WriteU64(CoinAmount, offset);
            offset += 8;
            _data.WriteU64(PcAmount, offset);
            offset += 8;
            _data.WritePubKey(DestTokenCoin, offset);
            offset += 32;
            _data.WritePubKey(DestTokenPc, offset);
            offset += 32;
            return offset - initialOffset;
        }

        public static int Deserialize(ReadOnlySpan<byte> _data, int initialOffset, out WithdrawDestToken result)
        {
            int offset = initialOffset;
            result = new WithdrawDestToken();
            result.WithdrawAmount = _data.GetU64(offset);
            offset += 8;
            result.CoinAmount = _data.GetU64(offset);
            offset += 8;
            result.PcAmount = _data.GetU64(offset);
            offset += 8;
            result.DestTokenCoin = _data.GetPubKey(offset);
            offset += 32;
            result.DestTokenPc = _data.GetPubKey(offset);
            offset += 32;
            return offset - initialOffset;
        }
    }

    public partial class TargetOrder
    {
        public ulong Price { get; set; }

        public ulong Vol { get; set; }

        public int Serialize(byte[] _data, int initialOffset)
        {
            int offset = initialOffset;
            _data.WriteU64(Price, offset);
            offset += 8;
            _data.WriteU64(Vol, offset);
            offset += 8;
            return offset - initialOffset;
        }

        public static int Deserialize(ReadOnlySpan<byte> _data, int initialOffset, out TargetOrder result)
        {
            int offset = initialOffset;
            result = new TargetOrder();
            result.Price = _data.GetU64(offset);
            offset += 8;
            result.Vol = _data.GetU64(offset);
            offset += 8;
            return offset - initialOffset;
        }
    }

    public partial class OutPutData
    {
        public ulong NeedTakePnlCoin { get; set; }

        public ulong NeedTakePnlPc { get; set; }

        public ulong TotalPnlPc { get; set; }

        public ulong TotalPnlCoin { get; set; }

        public ulong PoolOpenTime { get; set; }

        public ulong PunishPcAmount { get; set; }

        public ulong PunishCoinAmount { get; set; }

        public ulong OrderbookToInitTime { get; set; }

        public BigInteger SwapCoinInAmount { get; set; }

        public BigInteger SwapPcOutAmount { get; set; }

        public ulong SwapTakePcFee { get; set; }

        public BigInteger SwapPcInAmount { get; set; }

        public BigInteger SwapCoinOutAmount { get; set; }

        public ulong SwapTakeCoinFee { get; set; }

        public int Serialize(byte[] _data, int initialOffset)
        {
            int offset = initialOffset;
            _data.WriteU64(NeedTakePnlCoin, offset);
            offset += 8;
            _data.WriteU64(NeedTakePnlPc, offset);
            offset += 8;
            _data.WriteU64(TotalPnlPc, offset);
            offset += 8;
            _data.WriteU64(TotalPnlCoin, offset);
            offset += 8;
            _data.WriteU64(PoolOpenTime, offset);
            offset += 8;
            _data.WriteU64(PunishPcAmount, offset);
            offset += 8;
            _data.WriteU64(PunishCoinAmount, offset);
            offset += 8;
            _data.WriteU64(OrderbookToInitTime, offset);
            offset += 8;
            _data.WriteBigInt(SwapCoinInAmount, offset, 16, true);
            offset += 16;
            _data.WriteBigInt(SwapPcOutAmount, offset, 16, true);
            offset += 16;
            _data.WriteU64(SwapTakePcFee, offset);
            offset += 8;
            _data.WriteBigInt(SwapPcInAmount, offset, 16, true);
            offset += 16;
            _data.WriteBigInt(SwapCoinOutAmount, offset, 16, true);
            offset += 16;
            _data.WriteU64(SwapTakeCoinFee, offset);
            offset += 8;
            return offset - initialOffset;
        }

        public static int Deserialize(ReadOnlySpan<byte> _data, int initialOffset, out OutPutData result)
        {
            int offset = initialOffset;
            result = new OutPutData();
            result.NeedTakePnlCoin = _data.GetU64(offset);
            offset += 8;
            result.NeedTakePnlPc = _data.GetU64(offset);
            offset += 8;
            result.TotalPnlPc = _data.GetU64(offset);
            offset += 8;
            result.TotalPnlCoin = _data.GetU64(offset);
            offset += 8;
            result.PoolOpenTime = _data.GetU64(offset);
            offset += 8;
            result.PunishPcAmount = _data.GetU64(offset);
            offset += 8;
            result.PunishCoinAmount = _data.GetU64(offset);
            offset += 8;
            result.OrderbookToInitTime = _data.GetU64(offset);
            offset += 8;
            result.SwapCoinInAmount = _data.GetBigInt(offset, 16, false);
            offset += 16;
            result.SwapPcOutAmount = _data.GetBigInt(offset, 16, false);
            offset += 16;
            result.SwapTakePcFee = _data.GetU64(offset);
            offset += 8;
            result.SwapPcInAmount = _data.GetBigInt(offset, 16, false);
            offset += 16;
            result.SwapCoinOutAmount = _data.GetBigInt(offset, 16, false);
            offset += 16;
            result.SwapTakeCoinFee = _data.GetU64(offset);
            offset += 8;
            return offset - initialOffset;
        }
    }

    public partial class LastOrderDistance
    {
        public ulong LastOrderNumerator { get; set; }

        public ulong LastOrderDenominator { get; set; }

        public int Serialize(byte[] _data, int initialOffset)
        {
            int offset = initialOffset;
            _data.WriteU64(LastOrderNumerator, offset);
            offset += 8;
            _data.WriteU64(LastOrderDenominator, offset);
            offset += 8;
            return offset - initialOffset;
        }

        public static int Deserialize(ReadOnlySpan<byte> _data, int initialOffset, out LastOrderDistance result)
        {
            int offset = initialOffset;
            result = new LastOrderDistance();
            result.LastOrderNumerator = _data.GetU64(offset);
            offset += 8;
            result.LastOrderDenominator = _data.GetU64(offset);
            offset += 8;
            return offset - initialOffset;
        }
    }

    public partial class NeedTake
    {
        public ulong NeedTakePc { get; set; }

        public ulong NeedTakeCoin { get; set; }

        public int Serialize(byte[] _data, int initialOffset)
        {
            int offset = initialOffset;
            _data.WriteU64(NeedTakePc, offset);
            offset += 8;
            _data.WriteU64(NeedTakeCoin, offset);
            offset += 8;
            return offset - initialOffset;
        }

        public static int Deserialize(ReadOnlySpan<byte> _data, int initialOffset, out NeedTake result)
        {
            int offset = initialOffset;
            result = new NeedTake();
            result.NeedTakePc = _data.GetU64(offset);
            offset += 8;
            result.NeedTakeCoin = _data.GetU64(offset);
            offset += 8;
            return offset - initialOffset;
        }
    }

    public partial class SwapInstructionBaseIn
    {
        public ulong AmountIn { get; set; }

        public ulong MinimumAmountOut { get; set; }

        public int Serialize(byte[] _data, int initialOffset)
        {
            int offset = initialOffset;
            _data.WriteU64(AmountIn, offset);
            offset += 8;
            _data.WriteU64(MinimumAmountOut, offset);
            offset += 8;
            return offset - initialOffset;
        }

        public static int Deserialize(ReadOnlySpan<byte> _data, int initialOffset, out SwapInstructionBaseIn result)
        {
            int offset = initialOffset;
            result = new SwapInstructionBaseIn();
            result.AmountIn = _data.GetU64(offset);
            offset += 8;
            result.MinimumAmountOut = _data.GetU64(offset);
            offset += 8;
            return offset - initialOffset;
        }
    }

    public partial class SwapInstructionBaseOut
    {
        public ulong MaxAmountIn { get; set; }

        public ulong AmountOut { get; set; }

        public int Serialize(byte[] _data, int initialOffset)
        {
            int offset = initialOffset;
            _data.WriteU64(MaxAmountIn, offset);
            offset += 8;
            _data.WriteU64(AmountOut, offset);
            offset += 8;
            return offset - initialOffset;
        }

        public static int Deserialize(ReadOnlySpan<byte> _data, int initialOffset, out SwapInstructionBaseOut result)
        {
            int offset = initialOffset;
            result = new SwapInstructionBaseOut();
            result.MaxAmountIn = _data.GetU64(offset);
            offset += 8;
            result.AmountOut = _data.GetU64(offset);
            offset += 8;
            return offset - initialOffset;
        }
    }
}
