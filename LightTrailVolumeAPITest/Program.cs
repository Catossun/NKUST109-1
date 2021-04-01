using KHLightTrail;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;

namespace LightTrailVolumeAPITest
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("高雄輕軌月均運量統計");
            string dataUrl = "https://data.kcg.gov.tw/dataset/6f29f6f4-2549-4473-aa90-bf60d10895dc/resource/30dfc2cf-17b5-4a40-8bb7-c511ea166bd3/download/lightrailtraffic.json";
            Console.WriteLine("資料來源：{0}\n", dataUrl);

            List<VolumeData> dataList = Repository.GetAllVolumes().Result;
            Console.WriteLine(
                "統計範圍：{0}/{1:D2} ~ {2}/{3:D2}",
                dataList[0].Year,
                dataList[0].Month,
                dataList[^1].Year,
                dataList[^1].Month
            );
            Console.WriteLine();

            List<VolumeData> sortByTotalVolume = new List<VolumeData>(dataList);
            sortByTotalVolume.Sort((VolumeData a, VolumeData b) =>
            {
                if (a == b) return 0;
                else return b.TotalVolume - a.TotalVolume;
            });
            Console.Write("總運量最高年月份：");
            Console.WriteLine(
                "{0}/{1:D2} -> {2,10}",
                sortByTotalVolume[0].Year,
                sortByTotalVolume[0].Month,
                sortByTotalVolume[0].TotalVolume
            );
            Console.Write("總運量最低年月份：");
            Console.WriteLine(
                "{0}/{1:D2} -> {2,10}",
                sortByTotalVolume[^1].Year,
                sortByTotalVolume[^1].Month,
                sortByTotalVolume[^1].TotalVolume
            );
            Console.WriteLine();

            Console.WriteLine("最新運量統計 ({0}/{1:D2})", dataList[^1].Year, dataList[^1].Month);
            Console.WriteLine("總運量：\t\t{0,10}", dataList[^1].TotalVolume);
            Console.WriteLine("日均運量：\t\t{0,10}", dataList[^1].AverangeDailyVolume);
            Console.WriteLine("假日均運量：\t\t{0,10}", dataList[^1].AvgHolidayVolume);
            Console.WriteLine("月台上刷卡日均筆數：\t{0,10}", dataList[^1].AvgBuyTicketWithCardOnPlatform);
            Console.WriteLine("車上刷卡日均筆數：\t{0,10}", dataList[^1].AvgBuyTicketWithCardOnTrain);
            Console.WriteLine("售票機日均筆數：\t{0,10}", dataList[^1].AvgBuyTicketFromTicketMachine);
            Console.WriteLine("補票日均筆數：\t\t{0,10}", dataList[^1].AvgRebuyTicket);
            Console.WriteLine("團體票日均筆數：\t{0,10}", dataList[^1].AvgBuyGroupTicket);
            Console.WriteLine("人工售票日均筆數：\t{0,10}", dataList[^1].AvgBuyTicketByManual);
            Console.WriteLine("備註：{0}", dataList[^1].Remark);
        }
    }
}