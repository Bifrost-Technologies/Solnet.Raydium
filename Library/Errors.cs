using System;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;
using Solnet.Programs.Abstract;
using Solnet.Programs.Utilities;
using Solnet.Rpc;
using Solnet.Rpc.Builders;
using Solnet.Rpc.Core.Http;
using Solnet.Rpc.Core.Sockets;
using Solnet.Rpc.Types;
using Solnet.Wallet;

namespace Solnet.Raydium.Library
{
    public enum RaydiumAmmErrorKind : uint
    {
        AlreadyInUse = 0U,
        InvalidProgramAddress = 1U,
        ExpectedMint = 2U,
        ExpectedAccount = 3U,
        InvalidCoinVault = 4U,
        InvalidPCVault = 5U,
        InvalidTokenLP = 6U,
        InvalidDestTokenCoin = 7U,
        InvalidDestTokenPC = 8U,
        InvalidPoolMint = 9U,
        InvalidOpenOrders = 10U,
        InvalidSerumMarket = 11U,
        InvalidSerumProgram = 12U,
        InvalidTargetOrders = 13U,
        InvalidWithdrawQueue = 14U,
        InvalidTempLp = 15U,
        InvalidCoinMint = 16U,
        InvalidPCMint = 17U,
        InvalidOwner = 18U,
        InvalidSupply = 19U,
        InvalidDelegate = 20U,
        InvalidSignAccount = 21U,
        InvalidStatus = 22U,
        InvalidInstruction = 23U,
        WrongAccountsNumber = 24U,
        WithdrawTransferBusy = 25U,
        WithdrawQueueFull = 26U,
        WithdrawQueueEmpty = 27U,
        InvalidParamsSet = 28U,
        InvalidInput = 29U,
        ExceededSlippage = 30U,
        CalculationExRateFailure = 31U,
        CheckedSubOverflow = 32U,
        CheckedAddOverflow = 33U,
        CheckedMulOverflow = 34U,
        CheckedDivOverflow = 35U,
        CheckedEmptyFunds = 36U,
        CalcPnlError = 37U,
        InvalidSplTokenProgram = 38U,
        TakePnlError = 39U,
        InsufficientFunds = 40U,
        ConversionFailure = 41U,
        InvalidUserToken = 42U,
        InvalidSrmMint = 43U,
        InvalidSrmToken = 44U,
        TooManyOpenOrders = 45U,
        OrderAtSlotIsPlaced = 46U,
        InvalidSysProgramAddress = 47U,
        InvalidFee = 48U,
        RepeatCreateAmm = 49U,
        NotAllowZeroLP = 50U,
        InvalidCloseAuthority = 51U,
        InvalidFreezeAuthority = 52U,
        InvalidReferPCMint = 53U,
        InvalidConfigAccount = 54U,
        RepeatCreateConfigAccount = 55U,
        UnknownAmmError = 56U
    }
}
