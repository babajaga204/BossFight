
namespace BossFight
{
    internal class Item
    {
        public string ItemType { get; private set; }

        public Item(string itemType)
        {
            ItemType = itemType;
        }
    }
}
