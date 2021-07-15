using System;
using MongoDB.Bson.Serialization.Attributes;

namespace HttpClientConsole
{
    public class Store
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string id { get; set; }
        public int storeid { get; set; }
        public string refid { get; set; }
        public orderMenus[] orderMenus { get; set; }
    }

    public class orderMenus
    {
        public string startDate { get; set; }
        public string endDate { get; set; }
        public string taxCode { get; set; }
        public currency currency { get; set; }
        public string languageCode { get; set; }
        public menuSets[] menuSets { get; set; }
    }

    public class currency
    {
        public string code { get; set; }
        public string symbol { get; set; }
        public int exponent { get; set; }
    }

    [BsonIgnoreExtraElements]
    public class menuSets
    {
        public int id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public int seqNo { get; set; }
        public string[] menuTypes { get; set; }
        public servHours servHours { get; set; }
        public menuCatgs[] menuCatgs { get; set; }

    }

    public class servHours
    {
        public mon mon { get; set; }
        public tue tue { get; set; }
        public wed wed { get; set; }
        public thu thu { get; set; }
        public fri fri { get; set; }
        public sat sat { get; set; }
        public sun sun { get; set; }

    }

    public class mon
    {
        public string periodType { get; set; }
        public periods[] periods { get; set; }
    }

    public class tue
    {
        public string periodType { get; set; }
        public periods[] periods { get; set; }
    }

    public class wed
    {
        public string periodType { get; set; }
        public periods[] periods { get; set; }
    }

    public class thu
    {
        public string periodType { get; set; }
        public periods[] periods { get; set; }
    }

    public class fri
    {
        public string periodType { get; set; }
        public periods[] periods { get; set; }
    }

    public class sat
    {
        public string periodType { get; set; }
        public periods[] periods { get; set; }
    }

    public class sun
    {
        public string periodType { get; set; }
        public periods[] periods { get; set; }
    }

    public class periods
    {
        public string startTime { get; set; }
        public string endTime { get; set; }
    }

    public class menuCatgs
    {
        public string code { get; set; }
        public string title { get; set; }
        public int seqNo { get; set; }
        public string status { get; set; }
        public menuItems[] menuItems { get; set; }
    }

    public class menuItems
    {
        public string itemCode { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string htmlContent { get; set; }
        public int seqNo { get; set; }
        public string status { get; set; }
        public int origPrice { get; set; }
        public int dispPrice { get; set; }
        public int nextPrice { get; set; }
        public string nextPriceDate { get; set; }
        public string thumbnail { get; set; }
        public string[] photos { get; set; }
        public modifierGroups[] modifierGroups { get; set; }

    }

    public class modifierGroups
    {
        public string code { get; set; }
        public string title { get; set; }
        public int seqNo { get; set; }
        public string status { get; set; }
        public int minSelect { get; set; }
        public int maxSelect { get; set; }
        public modifiers[] modifiers { get; set; }
    }

    public class modifiers
    {
        public string itemCode { get; set; }
        public string title { get; set; }
        public int seqNo { get; set; }
        public string status { get; set; }
        public int price { get; set; }
        public int minSelect { get; set; }
        public int maxSelect { get; set; }
        public submodifierGroups[] submodifierGroups { get; set; }
    }

    public class submodifierGroups
    {
        public string code { get; set; }
        public string title { get; set; }
        public int seqNo { get; set; }
        public string status { get; set; }
        public int minSelect { get; set; }
        public int maxSelect { get; set; }
        public submodifiers[] submodifiers { get; set; }
    }

    public class submodifiers
    {
        public string itemCode { get; set; }
        public string title { get; set; }
        public int seqNo { get; set; }
        public string status { get; set; }
        public int price { get; set; }
        public int minSelect { get; set; }
        public int maxSelect { get; set; }
    }
}
