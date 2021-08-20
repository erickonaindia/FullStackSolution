using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.SeedData
{
    public static class DbInit
    {
        //public static void Initialize(EfContext context)
        //{
        //    try
        //    {

        //        var conn = "Server=localhost;Database=hiberus;Trusted_Connection=True;MultipleActiveResultSets=true;";

        //        ConfigVM urlConfig = new ConfigVM
        //        {
        //            UrlConfigList = new List<UrlConfig>
        //            {
        //                new UrlConfig()
        //                {
        //                    TableTransaction = "TRUNCATE TABLE [SkuTransactions]",
        //                    UrlTransaction =  "http://quiet-stone-2094.herokuapp.com/transactions.json",
        //                    TableName = "SkuTransactions",
        //                    IsTransaction = true,

        //                },
        //                new UrlConfig()
        //                {
        //                    TableTransaction = "TRUNCATE TABLE [Rates]",
        //                    UrlTransaction =  "http://quiet-stone-2094.herokuapp.com/rates.json",
        //                    TableName = "Rates",
        //                    IsTransaction = false,
        //                }
        //            }
        //        };


        //        string json;

        //        foreach (var item in urlConfig.UrlConfigList)
        //        {
        //            using (var webClient = new System.Net.WebClient())
        //                json = webClient.DownloadString(item.UrlTransaction);

        //            context.Database.ExecuteSqlCommand(item.TableTransaction);

        //            dynamic jsonParsed;
        //            if (item.IsTransaction)
        //                jsonParsed = JsonConvert.DeserializeObject<List<TransactionVM>>(json);
        //            else
        //                jsonParsed = JsonConvert.DeserializeObject<List<RatesVM>>(json);

        //            var dataTable = DataUrlHelper.ToDataTable(jsonParsed);
        //            var result = DataUrlHelper.DataInsert(conn, dataTable, item.TableName);
        //        }

        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

    }
}
