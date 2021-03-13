using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayer.Models
{
    public class DataList
    {
        public static List<Item> Items { get; set; } = new List<Item>();
        public static List<Checkout> Checkout { get; set; } = new List<Checkout>();
    }
}
