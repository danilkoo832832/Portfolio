using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    interface IUsable
    {
        public void Use();
    }

    interface IEquippable
    {
        public EquippedSlot Type { get; }

        public void Equip();
    }
    abstract class Item : Base
    {
    }
    class Armor : Item, IEquippable
    {
        public EquippedSlot Type { get; }
        public Armor(int slot)
        {
            Type = new EquippedSlot(slot);
        }
        public Armor(EquippedSlot slot)
        {
            Type = slot;
        }
        public void Equip()
        { 
        }
    }
    class Potion : Item, IUsable
    {
        public void Use()
        {
            throw new NotImplementedException();
        }
    }
}
