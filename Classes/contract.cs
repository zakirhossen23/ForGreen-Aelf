using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AElf.Client.Service;
using AElf;
using AElf.Client.Dto;
using Google.Protobuf;
using Google.Protobuf.WellKnownTypes;
using AElf.CSharp.Core;
using AElf.Types;
using ForGreen;

namespace ForGreen_Aelf.Classes
{
    internal class contract
    {
        string tokenContractAddress = "2KRHY1oZv5S28YGRJ3adtMxfAh7WQP3wmMyoFq33oTc7Mt5Z1Y";
        string privatekey = "aabb7f566f8f7c2d9f6ca79c45a160d6f015cccca8d29fbb367d78c7e0111113";

        AElfClient client = new AElfClient("https://tdvw-test-node.aelf.io");
        #region "Main Important"
        public static string FromHexString(string hexString)
        {
            var bytes = new byte[hexString.Length / 2];
            for (var i = 0; i < bytes.Length; i++)
            {
                bytes[i] = Convert.ToByte(hexString.Substring(i * 2, 2), 16);
            }

            return Encoding.ASCII.GetString(bytes); // returns: "Hello world" for "48656C6C6F20776F726C64"
        }

        string MyDictionaryToJson(Dictionary<string, string> dict)
        {
            var entries = dict.Select(d =>
                string.Format("\"{0}\": \"{1}\"", d.Key, d.Value));
            return "{" + string.Join(",", entries) + "}";
        }

        #endregion

        public async Task<string> CallContract(string methodName, IMessage param)
        {

            var ownerAddress = client.GetAddressFromPrivateKey(privatekey);

            // Generate a transfer transaction.
            var transaction = await client.GenerateTransactionAsync(ownerAddress, tokenContractAddress, methodName, param);

            var txWithSign = client.SignTransaction(privatekey, transaction);


            // Send the transfer transaction to AElf chain node.
            var result = await client.ExecuteTransactionAsync(new ExecuteTransactionDto
            {
                RawTransaction = txWithSign.ToByteArray().ToHex()
            });
            return result.ToString();

        }

        public async Task<string> SendTransContract(string methodName, IMessage param)
        {

            var ownerAddress = client.GetAddressFromPrivateKey(privatekey);

            // Generate a transfer transaction.
            var transaction = await client.GenerateTransactionAsync(ownerAddress, tokenContractAddress, methodName, param);

            var txWithSign = client.SignTransaction(privatekey, transaction);


            // Send the transfer transaction to AElf chain node.
            var result = await client.SendTransactionAsync(new SendTransactionInput
            {
                RawTransaction = txWithSign.ToByteArray().ToHex()
            });
            // After the transaction is mined, query the execution results.
            await Task.Delay(3000);

            return result.ToString();

        }


        public async Task<string> GetWalletAddress()
        {
            var walletAddress = client.GetAddressFromPrivateKey(Properties.Settings.Default.PrivateKey);

            return walletAddress;
        }
        public async Task sendMoney(string wallet, double amount, string memo)
        {

            // Get token contract address.
            var tokenContractAddress = await client.GetContractAddressByNameAsync(HashHelper.ComputeFrom("AElf.ContractNames.Token"));

            var methodName = "Transfer";
            var param = new AElf.Client.MultiToken.TransferInput
            {
                To = new AElf.Client.Proto.Address { Value = Address.FromBase58(wallet).Value },//2epyMZVwqC2hCJNTaUDGuhgFoJ578TMnAcxkegy7WxxS2sWvpM
                Symbol = "ELF",
                Amount = (long)(amount * 100000000),
                Memo = memo                
            };
            var ownerAddress = client.GetAddressFromPrivateKey(Properties.Settings.Default.PrivateKey);

            // Generate a transfer transaction.
            var transaction = await client.GenerateTransactionAsync(ownerAddress, tokenContractAddress.ToBase58(), methodName, param);
            var txWithSign = client.SignTransaction(Properties.Settings.Default.PrivateKey, transaction);

            // Send the transfer transaction to AElf chain node.
            var result = await client.SendTransactionAsync(new SendTransactionInput
            {
                RawTransaction = txWithSign.ToByteArray().ToHex()
            });

            Console.WriteLine(result);
            await Task.Delay(4000);
        }

        public async Task<string> Testing()
        {
            string hexString = await CallContract("Hello", new Empty());
            string result = StringValue.Parser.ParseFrom(ByteArrayHelper.HexStringToByteArray(hexString)).Value;
            return result;
        }

        public async Task<string> CreateEvent(Dictionary<string, string> eventURI)
        {
            var inJsonFormat = MyDictionaryToJson(eventURI);
            return await SendTransContract("CreateEvent", new StringValue { Value = inJsonFormat.ToString() });
        }

        public async Task<string> CreateToken(string EventID, Dictionary<string, string> TokenURI)
        {
            var inJsonFormat = MyDictionaryToJson(TokenURI);
            InsertEventTokenInput Input = new InsertEventTokenInput
            {
                EventID = EventID,
                TokenURI = inJsonFormat
            };
            return await SendTransContract("InsertAllEventToken", Input);
        }


        public async Task<string> CreateBid(int TokenID, int EventID, Dictionary<string, string> BidURI, string TokenURI)
        {
            var inJsonFormat = MyDictionaryToJson(BidURI);
            var UpdatedURIinJsonFormat = TokenURI;
            InsertTokenBidInput Input = new InsertTokenBidInput
            {
                TokenID = TokenID,
                EventID = EventID,
                UpdatedURI = UpdatedURIinJsonFormat,
                BidURI = inJsonFormat
            };
            return await SendTransContract("InsertAllTokenBid", Input);
        }


        public async Task<List<ShortViews.EventDetails>> GetAllEvent()
        {
            List<ShortViews.EventDetails> all = new List<ShortViews.EventDetails>();
            string hexString = await CallContract("getTotalEvent", new Empty());
            string result = StringValue.Parser.ParseFrom(ByteArrayHelper.HexStringToByteArray(hexString)).Value;
            int allTotalEvent = int.Parse(result);
            for (int i = 0; i < allTotalEvent; i++)
            {
                string hexString2 = await CallContract("getOneEvent", new StringValue { Value = i.ToString() });
                string result2 = StringValue.Parser.ParseFrom(ByteArrayHelper.HexStringToByteArray(hexString2)).Value;
                ShortViews.EventDetails eventDetails = new ShortViews.EventDetails(result2, i);
                all.Add(eventDetails);
            }
            return all;
        }

        public async Task<List<ShortViews.NFTdetails>> GetAllNFTbyEventID(int EventID)
        {
            List<ShortViews.NFTdetails> all = new List<ShortViews.NFTdetails>();
            string hexString = await CallContract("SearchAllTokenByEventID", new StringValue { Value = EventID.ToString() });

        
            Google.Protobuf.Collections.RepeatedField<string> result = SearchedList.Parser.ParseFrom(ByteArrayHelper.HexStringToByteArray(hexString)).Tokens;

            for (int i = 0; i < result.Count; i++)
            {
                int TokenID = SearchedList.Parser.ParseFrom(ByteArrayHelper.HexStringToByteArray(hexString)).TokenID[i];
                string result2 = result[i];
                if (result2 != "")
                {
                    ShortViews.NFTdetails nftDetails = new ShortViews.NFTdetails(result2, TokenID);
                    all.Add(nftDetails);
                }

            }
            return all;
        }

        public async Task<List<ShortViews.BidDetails>> GetAllBidByTokenID(int tokenID)
        {
            List<ShortViews.BidDetails> all = new List<ShortViews.BidDetails>();
            string hexString = await CallContract("SearchAllBidByTokenID", new StringValue { Value = tokenID.ToString() });

            Google.Protobuf.Collections.RepeatedField<string> result = SearchedListBids.Parser.ParseFrom(ByteArrayHelper.HexStringToByteArray(hexString)).Bids;

            for (int i = 0; i < result.Count; i++)
            {
                string result2 = result[i];
                if (result2 != "")
                {
                    ShortViews.BidDetails bidDetails = new ShortViews.BidDetails(result2);
                    all.Add(bidDetails);
                }

            }
            return all;
        }

    }
}
