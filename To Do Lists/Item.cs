namespace To_Do_Lists
{
    public class Item
    {
        private static int itemID = 1;
        public int ID { get; }
        public string Text { get; set; }

        public Item(string text)
        {
            ID = itemID;
            itemID++;
            this.Text = text;
        }
    }
}