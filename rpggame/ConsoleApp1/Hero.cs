using System;

namespace ConsoleApp1
{
    class Hero : Unit
    {
        public Hero(float health, float mana) : base(health, mana)
        {
        }
    }

    class HeroInventory : Inventory
    {
        private int[] NumSpecialSlots = new int[7] { 1, 1, 1, 1, 2, 2, 10 };
        private int SizeInventory = 10;
        /// <summary>
        /// Don't use. Use default constructor.
        /// </summary>
        /// <param name="num">Nothing</param>
        public HeroInventory(int num) : this()
        {
            Console.WriteLine("Todo error handler and write it messege on handler");
        }// same default constructor, but 
        public HeroInventory()
        {
            int TotalSize = SizeInventory+1;//+1 its buffer
            for (int i = 0; i < NumSpecialSlots.Length; i++)
            {
                TotalSize += NumSpecialSlots[i];
            }
            
            Slots = new Slot[TotalSize];

            Slots[0] = new Slot(0);// Slots[0] Always buffer
            for (int i = 1, index=0, num=0; i <= TotalSize-(SizeInventory+1); i++) //Equp Slots
            {
                if (num == NumSpecialSlots[index])
                {
                    index++;
                    num = 0;
                }
                num++;
                Slots[i] = new Slot((int)Math.Pow(2, index));
            }
            for(int i = TotalSize - SizeInventory; i < TotalSize; i++) //Common Slots
            {
                Slots[i] = new Slot();
            }
        }
    }


}

