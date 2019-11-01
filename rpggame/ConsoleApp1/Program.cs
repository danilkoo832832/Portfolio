using System;
using System.Collections.Generic;
using System.Reflection;

namespace ConsoleApp1
{
    class Program
    {
        public delegate void del(string s);
        static void Main(string[] args)
        {
            /*
            for (int i = 1; i <= 2; i++)
            {
                Console.WriteLine(i);
            }//*/
            
            

            Console.WriteLine("done");
            Console.ReadKey();//*/
        }
        /* REdo(maybe complite) Redo, create class Game and fill it
        public static List<Modifaer> ModifaersList = new List<Modifaer>
        {
            new Modifaer_Hp_Regen(),
        };//*/
    }

    abstract class Base
    {
        public dynamic Parent { get; }
        public void Destroy()
        {
            GC.SuppressFinalize(this);
        }
    }

    class Handler
    {
    }

    abstract class Effect
    {
        public string Name { get; }
        public string[] Modifaers { get; protected set; }
    }

    class TripleHPRegen : Effect// Custom class. Сan be created by creator of modifications
    {
        public TripleHPRegen()
        {
            Modifaers = new string[] { "MODIFAER_HP_REGEN" };
        }
        public float SetHpRegen(object[] keys)
        {
            Unit unit = (Unit)keys[0];
            float HpRegen = (int)keys[1];
            return HpRegen * 3;
        }
    }

    abstract class Modifaer
    {
        //public string DelegateName { get; protected set; }
        //public string ModifaerName { get; protected set; }
        public void Create(object obj)
        {
            this.AddToEvent(obj);
        }
        protected abstract void AddToEvent(object obj);
    }

    abstract class Modifaer_Hp_Regen : Modifaer
    {
        public static string DelegateName { get; } = "SetHpRegen";
        public static string ModifaerName { get; } = "MODIFAER_HP_REGEN";



        /*
        public delegate int effect_hp_regen();
        protected override void AddToEvent(object obj)
        {
            int i = (int)obj.GetType().GetMethod(DelegateName).Invoke(obj, new object[] { });
            effect_hp_regen delegat = (effect_hp_regen)obj.GetType().GetMethod(delegateName).CreateDelegate(typeof(effect_hp_regen),obj);
            delegat.Invoke(); // Very slow. Decrepesed or not?
        }
        //*/
    }






}

