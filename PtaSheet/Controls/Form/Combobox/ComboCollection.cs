using System;
using System.Collections;
using System.Windows.Forms;

namespace ComboxExtended
{

    /// <summary>
    /// Collections of ComboBoxItem.
    /// </summary>
    /// <typeparam name="TComboBoxItem">ComboBoxItem.</typeparam>
    public class ComboCollection<TComboBoxItem> : CollectionBase
    {

        public EventHandler UpdateItems;
        public ComboBox.ObjectCollection ItemsBase { get; set; }
        public System.Collections.Generic.List<ComboBoxItem> Items { get; set; }


        public ComboBoxItem this[int index]
        {
            get
            {
                return (Items[index]);
            }
            set
            {
                Items[index] = value;
            }
        }

        
        public ComboCollection()
        {
            Items = new System.Collections.Generic.List<ComboBoxItem>();
        }
        public void Add(ComboBoxItem value)
        {
            Items.Add(value);
            ItemsBase.Add(value);
        }
        public int IndexOf(ComboBoxItem value)
        {
            return (Items.IndexOf(value));
        }
        public int IndexOf(string name)
        {
            int val = -1;
            for (int i = 0; i < Items.Count; i++)
            {
                var item = Items[i];
                if (item.Value as string == name)
                    val = i;
            }
            return val;
        }
        public void Insert(int index, ComboBoxItem value)
        {
            Items.Insert(index, value);
            ItemsBase.Insert(index, value);
        }
        public void Remove(ComboBoxItem value)
        {
            Items.Remove(value);
        }
        public new void RemoveAt(int index)
        {
            if (index > -1 && index <= Items.Count - 1)
            { Items.RemoveAt(index); ItemsBase.RemoveAt(index); }
        }
        public bool Contains(ComboBoxItem value)
        {
            return (Items.Contains(value));
        }
        public new int Count()
        {
            return Items.Count;
        }
        public new void Clear()
        {
            ItemsBase.Clear();
            Items.Clear();
        }

    }

}
