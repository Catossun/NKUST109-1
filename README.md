# NKUST109-2

## Target Framework
- ASP.NET 5.0

## Feature
- 高雄輕軌月均運量統計
  資料來源：[高雄輕軌月均運量統計](https://data.kcg.gov.tw/dataset/6f29f6f4-2549-4473-aa90-bf60d10895dc/resource/30dfc2cf-17b5-4a40-8bb7-c511ea166bd3)

  - REST API Result
    ```json
    [
        {
            "id": Integer,
            "年": Integer,
            "月": Integer,
            "總運量": Integer,
            "日均運量": Integer,
            "假日均運量": Integer,
            "月台上刷卡日均筆數": Integer,
            "車上刷卡日均筆數": Integer,
            "售票機日均筆數": Integer,
            "補票日均筆數": Integer,
            "團體票日均筆數": Integer,
            "人工售票日均筆數": Integer,
            "備註": String
        }
    ]
    ```

## Screenshot
- Home
![Home Page Screenshot](https://github.com/Catossun/NKUST109-2/blob/master/Image/home.jpeg)
- Volume Data List
![Volume Data List Screenshot](https://github.com/Catossun/NKUST109-2/blob/master/Image/vd_list.jpeg)
- Volume Data Detail
![Volume Data Detail Screenshot](https://github.com/Catossun/NKUST109-2/blob/master/Image/vd_detail.jpeg)

