using System;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;
using Solnet;
using Solnet.Programs.Abstract;
using Solnet.Programs.Utilities;
using Solnet.Raydium.Types;
using Solnet.Rpc;
using Solnet.Rpc.Builders;
using Solnet.Rpc.Core.Http;
using Solnet.Rpc.Core.Sockets;
using Solnet.Rpc.Types;
using Solnet.Wallet;

namespace Solnet.Raydium
{
    public partial class TargetOrders
    {
        public static ulong ACCOUNT_DISCRIMINATOR => 16712735355329896817UL;
        public static ReadOnlySpan<byte> ACCOUNT_DISCRIMINATOR_BYTES => new byte[] { 113, 225, 140, 255, 65, 144, 239, 231 };
        public static string ACCOUNT_DISCRIMINATOR_B58 => "L3nkuN7DJxn";
        public ulong[]? Owner { get; set; }

        public TargetOrder[]? BuyOrders { get; set; }

        public ulong[]? Padding1 { get; set; }

        public BigInteger TargetX { get; set; }

        public BigInteger TargetY { get; set; }

        public BigInteger PlanXBuy { get; set; }

        public BigInteger PlanYBuy { get; set; }

        public BigInteger PlanXSell { get; set; }

        public BigInteger PlanYSell { get; set; }

        public BigInteger PlacedX { get; set; }

        public BigInteger PlacedY { get; set; }

        public BigInteger CalcPnlX { get; set; }

        public BigInteger CalcPnlY { get; set; }

        public TargetOrder[]? SellOrders { get; set; }

        public ulong[]? Padding2 { get; set; }

        public ulong[]? ReplaceBuyClientId { get; set; }

        public ulong[]? ReplaceSellClientId { get; set; }

        public ulong LastOrderNumerator { get; set; }

        public ulong LastOrderDenominator { get; set; }

        public ulong PlanOrdersCur { get; set; }

        public ulong PlaceOrdersCur { get; set; }

        public ulong ValidBuyOrderNum { get; set; }

        public ulong ValidSellOrderNum { get; set; }

        public ulong[]? Padding3 { get; set; }

        public BigInteger FreeSlotBits { get; set; }

        public static TargetOrders Deserialize(ReadOnlySpan<byte> _data)
        {
            int offset = 0;
            ulong accountHashValue = _data.GetU64(offset);
            offset += 8;
            if (accountHashValue != ACCOUNT_DISCRIMINATOR)
            {
                return null;
            }

            TargetOrders result = new TargetOrders();
            result.Owner = new ulong[4];
            for (uint resultOwnerIdx = 0; resultOwnerIdx < 4; resultOwnerIdx++)
            {
                result.Owner[resultOwnerIdx] = _data.GetU64(offset);
                offset += 8;
            }

            result.BuyOrders = new TargetOrder[50];
            for (uint resultBuyOrdersIdx = 0; resultBuyOrdersIdx < 50; resultBuyOrdersIdx++)
            {
                offset += TargetOrder.Deserialize(_data, offset, out var resultBuyOrdersresultBuyOrdersIdx);
                result.BuyOrders[resultBuyOrdersIdx] = resultBuyOrdersresultBuyOrdersIdx;
            }

            result.Padding1 = new ulong[8];
            for (uint resultPadding1Idx = 0; resultPadding1Idx < 8; resultPadding1Idx++)
            {
                result.Padding1[resultPadding1Idx] = _data.GetU64(offset);
                offset += 8;
            }

            result.TargetX = _data.GetBigInt(offset, 16, false);
            offset += 16;
            result.TargetY = _data.GetBigInt(offset, 16, false);
            offset += 16;
            result.PlanXBuy = _data.GetBigInt(offset, 16, false);
            offset += 16;
            result.PlanYBuy = _data.GetBigInt(offset, 16, false);
            offset += 16;
            result.PlanXSell = _data.GetBigInt(offset, 16, false);
            offset += 16;
            result.PlanYSell = _data.GetBigInt(offset, 16, false);
            offset += 16;
            result.PlacedX = _data.GetBigInt(offset, 16, false);
            offset += 16;
            result.PlacedY = _data.GetBigInt(offset, 16, false);
            offset += 16;
            result.CalcPnlX = _data.GetBigInt(offset, 16, false);
            offset += 16;
            result.CalcPnlY = _data.GetBigInt(offset, 16, false);
            offset += 16;
            result.SellOrders = new TargetOrder[50];
            for (uint resultSellOrdersIdx = 0; resultSellOrdersIdx < 50; resultSellOrdersIdx++)
            {
                offset += TargetOrder.Deserialize(_data, offset, out var resultSellOrdersresultSellOrdersIdx);
                result.SellOrders[resultSellOrdersIdx] = resultSellOrdersresultSellOrdersIdx;
            }

            result.Padding2 = new ulong[6];
            for (uint resultPadding2Idx = 0; resultPadding2Idx < 6; resultPadding2Idx++)
            {
                result.Padding2[resultPadding2Idx] = _data.GetU64(offset);
                offset += 8;
            }

            result.ReplaceBuyClientId = new ulong[10];
            for (uint resultReplaceBuyClientIdIdx = 0; resultReplaceBuyClientIdIdx < 10; resultReplaceBuyClientIdIdx++)
            {
                result.ReplaceBuyClientId[resultReplaceBuyClientIdIdx] = _data.GetU64(offset);
                offset += 8;
            }

            result.ReplaceSellClientId = new ulong[10];
            for (uint resultReplaceSellClientIdIdx = 0; resultReplaceSellClientIdIdx < 10; resultReplaceSellClientIdIdx++)
            {
                result.ReplaceSellClientId[resultReplaceSellClientIdIdx] = _data.GetU64(offset);
                offset += 8;
            }

            result.LastOrderNumerator = _data.GetU64(offset);
            offset += 8;
            result.LastOrderDenominator = _data.GetU64(offset);
            offset += 8;
            result.PlanOrdersCur = _data.GetU64(offset);
            offset += 8;
            result.PlaceOrdersCur = _data.GetU64(offset);
            offset += 8;
            result.ValidBuyOrderNum = _data.GetU64(offset);
            offset += 8;
            result.ValidSellOrderNum = _data.GetU64(offset);
            offset += 8;
            result.Padding3 = new ulong[10];
            for (uint resultPadding3Idx = 0; resultPadding3Idx < 10; resultPadding3Idx++)
            {
                result.Padding3[resultPadding3Idx] = _data.GetU64(offset);
                offset += 8;
            }

            result.FreeSlotBits = _data.GetBigInt(offset, 16, false);
            offset += 16;
            return result;
        }
    }

    public partial class Fees
    {
        public static ulong ACCOUNT_DISCRIMINATOR => 2644537131312258455UL;
        public static ReadOnlySpan<byte> ACCOUNT_DISCRIMINATOR_BYTES => new byte[] { 151, 157, 50, 115, 130, 72, 179, 36 };
        public static string ACCOUNT_DISCRIMINATOR_B58 => "SMr5fgWLZEB";
        public ulong MinSeparateNumerator { get; set; }

        public ulong MinSeparateDenominator { get; set; }

        public ulong TradeFeeNumerator { get; set; }

        public ulong TradeFeeDenominator { get; set; }

        public ulong PnlNumerator { get; set; }

        public ulong PnlDenominator { get; set; }

        public ulong SwapFeeNumerator { get; set; }

        public ulong SwapFeeDenominator { get; set; }
        public static Fees? Deserialize(ReadOnlySpan<byte> _data)
        {
            int offset = 0;
            offset += 8;
            ulong accountHashValue = _data.GetU64(offset);
            var result = new Fees();


            result.MinSeparateNumerator = _data.GetU64(offset);
            offset += 8;
            result.MinSeparateDenominator = _data.GetU64(offset);
            offset += 8;
            result.TradeFeeNumerator = _data.GetU64(offset);
            offset += 8;
            result.TradeFeeDenominator = _data.GetU64(offset);
            offset += 8;
            result.PnlNumerator = _data.GetU64(offset);
            offset += 8;
            result.PnlDenominator = _data.GetU64(offset);
            offset += 8;
            result.SwapFeeNumerator = _data.GetU64(offset);
            offset += 8;
            result.SwapFeeDenominator = _data.GetU64(offset);
            offset += 8;
            return result;
        }
        public static int Deserialize(ReadOnlySpan<byte> _data, out Fees result,int initialOffset = 0)
        {
            int offset = initialOffset;
            result = new Fees();
            result.MinSeparateNumerator = _data.GetU64(offset);
            offset += 8;
            result.MinSeparateDenominator = _data.GetU64(offset);
            offset += 8;
            result.TradeFeeNumerator = _data.GetU64(offset);
            offset += 8;
            result.TradeFeeDenominator = _data.GetU64(offset);
            offset += 8;
            result.PnlNumerator = _data.GetU64(offset);
            offset += 8;
            result.PnlDenominator = _data.GetU64(offset);
            offset += 8;
            result.SwapFeeNumerator = _data.GetU64(offset);
            offset += 8;
            result.SwapFeeDenominator = _data.GetU64(offset);
            offset += 8;
            return offset - initialOffset;
        }
    }

    public partial class AmmInfo
    {
        public static ulong ACCOUNT_DISCRIMINATOR => 6623479730123495713UL;
        public static ReadOnlySpan<byte> ACCOUNT_DISCRIMINATOR_BYTES => new byte[] { 33, 217, 2, 203, 184, 83, 235, 91 };
        public static string ACCOUNT_DISCRIMINATOR_B58 => "6fNB8FYtKsQ";
        public ulong Status { get; set; }

        public ulong Nonce { get; set; }

        public ulong OrderNum { get; set; }

        public ulong Depth { get; set; }

        public ulong CoinDecimals { get; set; }

        public ulong PcDecimals { get; set; }

        public ulong State { get; set; }

        public ulong ResetFlag { get; set; }

        public ulong MinSize { get; set; }

        public ulong VolMaxCutRatio { get; set; }

        public ulong AmountWave { get; set; }

        public ulong CoinLotSize { get; set; }

        public ulong PcLotSize { get; set; }

        public ulong MinPriceMultiplier { get; set; }

        public ulong MaxPriceMultiplier { get; set; }

        public ulong SysDecimalValue { get; set; }

        public Fees? Fees { get; set; }

        public OutPutData? OutPut { get; set; }

        public PublicKey? BaseVault { get; set; }

        public PublicKey? QuoteVault { get; set; }

        public PublicKey? BaseMint { get; set; }

        public PublicKey? QuoteMint { get; set; }

        public PublicKey? LpMint { get; set; }

        public PublicKey? OpenOrders { get; set; }

        public PublicKey? Market { get; set; }

        public PublicKey? SerumDex { get; set; }

        public PublicKey? TargetOrders { get; set; }

        public PublicKey? WithdrawQueue { get; set; }

        public PublicKey? TokenTempLp { get; set; }

        public PublicKey? AmmOwner { get; set; }

        public ulong LpAmount { get; set; }

        public ulong ClientOrderId { get; set; }

        public ulong[]? Padding { get; set; }

        public static AmmInfo Deserialize(ReadOnlySpan<byte> _data)
        {
            int offset = 0;
            AmmInfo result = new AmmInfo();
            result.Status = _data.GetU64(offset);
            offset += 8;
            result.Nonce = _data.GetU64(offset);
            offset += 8;
            result.OrderNum = _data.GetU64(offset);
            offset += 8;
            result.Depth = _data.GetU64(offset);
            offset += 8;
            result.CoinDecimals = _data.GetU64(offset);
            offset += 8;
            result.PcDecimals = _data.GetU64(offset);
            offset += 8;
            result.State = _data.GetU64(offset);
            offset += 8;
            result.ResetFlag = _data.GetU64(offset);
            offset += 8;
            result.MinSize = _data.GetU64(offset);
            offset += 8;
            result.VolMaxCutRatio = _data.GetU64(offset);
            offset += 8;
            result.AmountWave = _data.GetU64(offset);
            offset += 8;
            result.CoinLotSize = _data.GetU64(offset);
            offset += 8;
            result.PcLotSize = _data.GetU64(offset);
            offset += 8;
            result.MinPriceMultiplier = _data.GetU64(offset);
            offset += 8;
            result.MaxPriceMultiplier = _data.GetU64(offset);
            offset += 8;
            result.SysDecimalValue = _data.GetU64(offset);
            offset += 8;
            offset += Fees.Deserialize(_data, out var resultFees, offset);
            result.Fees = resultFees;
            offset += OutPutData.Deserialize(_data, offset, out var resultOutPut);
            result.OutPut = resultOutPut;
            result.BaseVault = _data.GetPubKey(offset);
            offset += 32;
            result.QuoteVault = _data.GetPubKey(offset);
            offset += 32;
            result.BaseMint = _data.GetPubKey(offset);
            offset += 32;
            result.QuoteMint = _data.GetPubKey(offset);
            offset += 32;
            result.LpMint = _data.GetPubKey(offset);
            offset += 32;
            result.OpenOrders = _data.GetPubKey(offset);
            offset += 32;
            result.Market = _data.GetPubKey(offset);
            offset += 32;
            result.SerumDex = _data.GetPubKey(offset);
            offset += 32;
            result.TargetOrders = _data.GetPubKey(offset);
            offset += 32;
            result.WithdrawQueue = _data.GetPubKey(offset);
            offset += 32;
            result.TokenTempLp = _data.GetPubKey(offset);
            offset += 32;
            result.AmmOwner = _data.GetPubKey(offset);
            offset += 32;
            result.LpAmount = _data.GetU64(offset);
            offset += 8;
            result.ClientOrderId = _data.GetU64(offset);
            offset += 8;
            result.Padding = new ulong[2];
            for (uint resultPaddingIdx = 0; resultPaddingIdx < 2; resultPaddingIdx++)
            {
                result.Padding[resultPaddingIdx] = _data.GetU64(offset);
                offset += 8;
            }
            Console.WriteLine(offset);
            Console.WriteLine(_data.Length.ToString());
            return result;
        }
    }
}
