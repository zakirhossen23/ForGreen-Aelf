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
using DemeterGift;

namespace DemeterGift_Aelf.Classes
{
    internal class contract
    {
        string tokenContractAddress = "2KPGMPMgusmR4Vs9FbtHmvNuikpkUfCwrK5CTANv9N4gU9fTNx";
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
                string.Format("\"{0}\": \"{1}\"", d.Key,  d.Value));
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
            var walletAddress =  client.GetAddressFromPrivateKey(Properties.Settings.Default.PrivateKey);

            return walletAddress;
        }

        public async Task<string> Testing()
        {
            string hexString = await CallContract("Hello", new Empty());
            string result =  StringValue.Parser.ParseFrom(ByteArrayHelper.HexStringToByteArray(hexString)).Value;
            return result;
        }

        public async Task<string> CreateEvent(Dictionary<string,string> eventURI)
        {
            var inJsonFormat = MyDictionaryToJson(eventURI);
            return await SendTransContract("CreateEvent", new StringValue{ Value = inJsonFormat.ToString() });
        }

        public async Task<string> CreateToken(string EventID, string TokenURI)
        {

            InsertEventTokenInput Input = new InsertEventTokenInput
            {
                EventID = EventID,
                TokenURI = TokenURI
            };
            return await CallContract("InsertAllEventToken", Input);
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
    }
}
