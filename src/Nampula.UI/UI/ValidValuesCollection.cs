using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nampula.UI
{

    public class ManagerCollectionEventHargs<t> : EventArgs
    {
        public t Item { get; set; }
        public int Index { get; set; }
    }

    public delegate void CollectionEventHandler(object sender, ManagerCollectionEventHargs<ValidValue> e);

    public class ValidValuesCollection : List<ValidValue>
    {
        public event CollectionEventHandler OnAdd;
        public event CollectionEventHandler OnRemove;
        public event CollectionEventHandler OnClear;

        private enum EventType
        {
            Add,
            Remove,
            Insert,
            Clear
        }

        public new void Add(ValidValue Item)
        {
            base.Add(Item);
            RaiseEvent(EventType.Add, Item, base.Count - 1);
        }

        public new void RemoveAt(int Item)
        {
            ValidValue myItem = this[Item];
            base.RemoveAt(Item);
            RaiseEvent(EventType.Remove, myItem, Item);
        }

        public new void Clear()
        {
            base.Clear();
            RaiseEvent(EventType.Clear, null, base.Count - 1);
        }

        private void RaiseEvent(EventType e, ValidValue Item, int Index)
        {

            var eventArgs = new ManagerCollectionEventHargs<ValidValue>();
            eventArgs.Item = Item;

            switch (e)
            {
                case EventType.Add:
                    if (OnAdd != null)
                    {
                        OnAdd(this, eventArgs);
                    }
                    break;
                case EventType.Remove:
                    if (OnRemove != null)
                    {
                        OnRemove(this, eventArgs);
                    }
                    break;
                case EventType.Insert:
                    break;
                case EventType.Clear:
                    if (OnClear != null)
                    {
                        OnClear(this, eventArgs);
                    }
                    break;
                default:
                    break;
            }
        }
    }

}
