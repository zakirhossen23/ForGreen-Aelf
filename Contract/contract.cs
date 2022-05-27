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
namespace DemeterGift_Aelf.Contract
{
    internal class contract
    {
        string tokenContractAddress = "2YcMiBaQg7huCJdSTFCCSpK4WtCaLeM7uj7wB4RwBQgriy8uVq";
        string privatekey = "aabb7f566f8f7c2d9f6ca79c45a160d6f015cccca8d29fbb367d78c7e0111113";

        AElfClient client = new AElfClient("https://tdvv-test-node.aelf.io");
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


        #endregion

        public async Task<string> CallContract(string methodName, IMessage param)
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
            var transactionResult = await client.GetTransactionResultAsync(result.TransactionId);
        var jsonFormat = FromHexString(transactionResult.ReturnValue);

            return jsonFormat.ToString();

        }


        public async Task<string>Testing()
        {
            return await CallContract("Hello", new Empty());
        }
    }
}
