using System.Collections.Generic;
namespace ConsoleApp1
{
    class Specifications : Base
    {
        private float maxVal, minVal, curVal;

        #region Constructor
        public Specifications(float MaxValue, float MinValue, float CurrectValue)
        {
            if (MaxValue > MinValue)
            {
                maxVal = MaxValue;
                minVal = MinValue;
                curVal = CurrectValue;
            }
        }
        public Specifications(float MaxValue, float MinValue)
        {
            if (MaxValue > MinValue)
            {
                maxVal = MaxValue;
                minVal = MinValue;
                curVal = MinValue;
            }
        }
        public Specifications(float MaxValue)
        {
            if (MaxValue > 0)
            {
                maxVal = MaxValue;
                minVal = 0;
                curVal = 0;
            }
            else if (MaxValue == -1)
            {
                maxVal = -1;
                minVal = -1;
                curVal = -1;
            }

        }
        #endregion

        #region GetMethods
        public float GetMaxValue() => maxVal;
        public float GetMinValue() => minVal;
        public float GetCurrectValue() => curVal;
        #endregion

        #region SetMethods
        public void SetMaxValue(float Value, bool Change)
        {
            if (maxVal == -1) { }
            else if (Value > minVal)
            {
                if (Change == true)
                {
                    float procent = curVal / (maxVal / 100);
                    maxVal = Value;
                    curVal = procent * (maxVal / 100);
                }
                else if (curVal > Value)
                {
                    maxVal = Value; curVal = Value;
                }
                else
                {
                    maxVal = Value;
                }
            }
            else
            {
                maxVal = 100; curVal = 100;
            }
        }
        public void SetMinValue(float Value)
        {
            if (maxVal == -1) { }
            else if (Value < maxVal)
            {
                if (curVal < Value)
                {
                    minVal = Value; curVal = Value;
                }
                else
                {
                    minVal = Value;
                }
            }
            else
            {
                minVal = 0; curVal = 0;
            }
        }
        public void SetCurrectValue(float Value)
        {
            if (maxVal == -1) { }
            else if (Value > maxVal)
            {
                maxVal = Value; curVal = Value;
            }
            else if (Value < minVal)
            {
                minVal = Value; curVal = Value;
            }
            else
            {
                curVal = Value;
            }
        }
        #endregion
    }

    class Unit : Base
    {
        public Specifications Health { get; }
        public Specifications Mana { get; }
        /// <summary>
        /// Active effects on unit
        /// </summary>
        public List<Effect> Effects { get; protected set; }
        public Unit(float health, float mana)
        {
            Health = new Specifications(health);
            Mana = new Specifications(mana);
            // Doto add methots to special handler
        }
        /// <summary>
        /// His invoke HpRegenHendler
        /// </summary>
        private void HealthRegen()
        {
            /*/
            if (enable)
            {
            /*/
                float HpRegen = 0;


                //Modifaer
                if (Effects.Count > 0) for (int i = 0; i < Effects.Count; i++)
                {
                    for (int ii = 0; ii < Effects[i].Modifaers.Length; ii++)
                    {
                        if (Effects[i].Modifaers[ii] == Modifaer_Hp_Regen.ModifaerName)
                        {
                            HpRegen = (float)Effects[i].GetType().GetMethod(Modifaer_Hp_Regen.DelegateName).Invoke(Effects[i], new object[] { this, HpRegen });
                        }
                    }
                }
            /*/
            }
            //*/
        }
    }

}

