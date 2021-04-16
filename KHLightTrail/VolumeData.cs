using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace KHLightTrail
{
    public class VolumeData
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [JsonPropertyName("年")]
        public int Year { get; set; }

        [JsonPropertyName("月")]
        public int Month { get; set; }

        [JsonPropertyName("總運量")]
        public int TotalVolume { get; set; }

        [JsonPropertyName("日均運量")]
        public int AverangeDailyVolume { get; set; }

        [JsonPropertyName("假日均運量")]
        public int AvgHolidayVolume { get; set; }

        [JsonPropertyName("月台上刷卡日均筆數")]
        public float AvgBuyTicketWithCardOnPlatform { get; set; }

        [JsonPropertyName("車上刷卡日均筆數")]
        public float AvgBuyTicketWithCardOnTrain { get; set; }

        [JsonPropertyName("售票機日均筆數")]
        public float AvgBuyTicketFromTicketMachine { get; set; }

        [JsonPropertyName("補票日均筆數")]
        public float AvgRebuyTicket { get; set; }

        [JsonPropertyName("團體票日均筆數")]
        public float AvgBuyGroupTicket { get; set; }

        [JsonPropertyName("人工售票日均筆數")]
        public float AvgBuyTicketByManual { get; set; }

        [JsonPropertyName("備註")]
        public string Remark { get; set; }

        public VolumeData()
        {
        }

        public VolumeData(int year, int month, int totalVolume, int averangeDailyVolume, int avgHolidayVolume, float avgBuyTicketWithCardOnPlatform, float avgBuyTicketWithCardOnTrain, float avgBuyTicketFromTicketMachine, float avgBuyTicketByManual, string remark)
        {
            Year = year;
            Month = month;
            TotalVolume = totalVolume;
            AverangeDailyVolume = averangeDailyVolume;
            AvgHolidayVolume = avgHolidayVolume;
            AvgBuyTicketWithCardOnPlatform = avgBuyTicketWithCardOnPlatform;
            AvgBuyTicketWithCardOnTrain = avgBuyTicketWithCardOnTrain;
            AvgBuyTicketFromTicketMachine = avgBuyTicketFromTicketMachine;
            AvgBuyTicketByManual = avgBuyTicketByManual;
            Remark = remark;
        }
    }
}