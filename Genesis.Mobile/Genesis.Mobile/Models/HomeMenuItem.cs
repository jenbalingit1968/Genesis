using System;
using System.Collections.Generic;
using System.Text;

namespace Genesis.Mobile.Models
{
    public enum MenuItemType
    {
        Home,
        Books,
        Browse,
        About,
        BookContent,
        BookChapter
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}
