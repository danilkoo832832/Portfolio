using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class EquippedSlot : Base
    {
        public enum EqupSlot
        {
            buffer = 0,
            helmet = 1,
            cuirass = 2,
            pants = 4,
            boots = 8,
            bracelet = 16,
            gloves = 32,
            ring = 64,
        }
        public int Slot { get; protected set; }
        public EquippedSlot(EqupSlot[] slots)
        {
            for (int i = 0; i < slots.Length; i++)
            {
                Slot = Slot | (int)slots[i];
            }
        }
        public EquippedSlot(int slots)
        {
            Slot = slots;
        }
        /*
        /// <summary>
        /// Undesirable to use.
        /// </summary>
        /// <param name="v"></param>
        public static implicit operator EquippedSlot(int v)
        {
            return new EquippedSlot(v);
        }
        //*/
        
    }

    class Inventory
    {
        public Slot[] Slots { get; protected set; }
        public Inventory(int num)
        {
            Slots = new Slot[num];
            for (int i = 0; i < Slots.Length; i++)
            {
                Slots[i] = new Slot();
            }
        }
        public Inventory() { }
    }

    class Slot : Base
    {
        public Amount Amount { get; set; }
        public Item Item { get; protected set; }
        public EquippedSlot Type { get; protected set; }

        public Slot() { }
        public Slot(EquippedSlot slots)
        {
            Type = slots;
        }
        public Slot(int slots)
        {
            Type = new EquippedSlot(slots);
        }
    }

    class Amount : Base
    {
        private int number { get; set; }

        public Amount(int i)
        {
            number = i;
        }

        public void Increase(int i)
        {
            number += i;
        }

        public void Decrease(int i)
        {
            number -= i;
        }
        
        public static implicit operator Amount(int v)
        {
            return new Amount(v);
        }

        public static implicit operator int(Amount v)
        {
            return v.number;
        }
    }
}
