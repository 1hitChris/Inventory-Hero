using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewStats", menuName = "Character/Stats", order = 1)]
public class CharacterStat_SO : ScriptableObject
{
    [System.Serializable]
    public class CharacterLevelUps
    {
        public int maxHealth;
        public int maxMana;
        public int basePhysicalDamage;
        public int baseMagicDamage;
        public int baseArmor;
        public int baseMagicResistance;
    }
    #region Fields

    public bool setManually = false;
    public bool saveDataOnClose = false;

    public ItemPickUp weapon { get; private set; }
    public ItemPickUp shield { get; private set; }
    public ItemPickUp helmet { get; private set; }
    public ItemPickUp shoulder { get; private set; }
    public ItemPickUp chestArmor { get; private set; }
    public ItemPickUp gloves { get; private set; }
    public ItemPickUp belt { get; private set; }
    public ItemPickUp legArmor { get; private set; }
    public ItemPickUp boots { get; private set; }
    public ItemPickUp misc1 { get; private set; }
    public ItemPickUp misc2 { get; private set; }


    public int maxHealth = 0;
    public int currentHealth = 0;

    public int maxMana = 0;
    public int currentMana = 0;

    public int maxWealth = 0;
    public int currentWealth = 0;

    public int basePhysicalDamage = 0;
    public int currentPhysicalDamage = 0;

    public int baseMagicDamage = 0;
    public int currentMagicDamage = 0;

    public int baseArmor = 0;
    public int currentArmor = 0;

    public int baseMagicResistance = 0;
    public int currentMagicResistance = 0;

    public int charExperience = 0;
    public int neededExperienceToLevel = 100;
    public int charLevel = 0;

    public CharacterLevelUps[] charLevelUps;

    #endregion

    #region Stat Increasers

    public void ApplyHealth(int healthAmount)
    {
        if (currentHealth + healthAmount > maxHealth)
        {
            currentHealth = maxHealth;
        }
        else
        {
            currentHealth += healthAmount;
        }
    }

    public void ApplyMana(int manaAmount)
    {
        if (currentMana + manaAmount > maxMana)
        {
            currentMana = maxMana;
        }
        else
        {
            currentMana += manaAmount;
        }
    }

    public void GiveWealth(int wealthAmount)
    {
        currentWealth += wealthAmount;
    }

    public void ApplyExperience(int experienceAmount)
    {
        if (charExperience + experienceAmount >= neededExperienceToLevel)
        {
            //CharacterLevelUp();
            charLevel += 1;
        }
        else
        {
            charExperience += experienceAmount;
        }
    }

    /*   public void EquipWeapon(ItemPickUp weaponPickUp, Inventory charInventory, GameObject weaponSlot)
       {
           weapon = weaponPickUp;
           currentPhysicalDamage = basePhysicalDamage + weapon.itemDefinition.itemAmount;
           currentMagicDamage = baseMagicDamage + weapon.itemDefinition.itemAmount;
       }
    */
    /* public void EquipArmor(ItemPickUp armorPickUp, Inventory charInventory)
     {
         switch (armorPickUp.itemDefinition.itemArmorSubType)
         {
             case ItemArmorSubType.NONE:
                 break;
             case ItemArmorSubType.HELMET:
                 helmet = armorPickUp;
                 currentArmor += armorPickUp.itemDefinition.itemAmount;
                 currentMagicResistance += armorPickUp.itemDefinition.itemAmount;
                 break;
             case ItemArmorSubType.CHEST:
                 chestArmor = armorPickUp;
                 currentArmor += armorPickUp.itemDefinition.itemAmount;
                 currentMagicResistance += armorPickUp.itemDefinition.itemAmount;
                 break;
             case ItemArmorSubType.SHOULDER:
                 shoulder = armorPickUp;
                 currentArmor += armorPickUp.itemDefinition.itemAmount;
                 currentMagicResistance += armorPickUp.itemDefinition.itemAmount;
                 break;
             case ItemArmorSubType.GLOVES:
                 gloves = armorPickUp;
                 currentArmor += armorPickUp.itemDefinition.itemAmount;
                 currentMagicResistance += armorPickUp.itemDefinition.itemAmount;
                 break;
             case ItemArmorSubType.BELT:
                 belt = armorPickUp;
                 currentArmor += armorPickUp.itemDefinition.itemAmount;
                 currentMagicResistance += armorPickUp.itemDefinition.itemAmount;
                 break;
             case ItemArmorSubType.LEGS:
                 legArmor = armorPickUp;
                 currentArmor += armorPickUp.itemDefinition.itemAmount;
                 currentMagicResistance += armorPickUp.itemDefinition.itemAmount;
                 break;
             case ItemArmorSubType.BOOTS:
                 boots = armorPickUp;
                 currentArmor += armorPickUp.itemDefinition.itemAmount;
                 currentMagicResistance += armorPickUp.itemDefinition.itemAmount;
                 break;
             default:
                 break;
         }
     }*/

    #endregion

    #region Stat Decreasers

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;

        if (currentHealth <= 0)
        {
            //Player dies
            //Death();
        }
    }

    public void UseMana(int manaCost)
    {
        currentMana -= manaCost;

        if (currentMana <= 0)
        {
            currentMana = 0;
        }
    }

    public void TakeWealth(int wealthAmount)
    {
        currentWealth -= wealthAmount;

        if (currentWealth <= 0)
        {
            currentWealth = 0;
        }

        if (currentWealth < wealthAmount)
        {
            //Incase of buying things, you wont be able to buy if the cost is more than your current wealth
        }
    }

    public bool UnEquipWeapon(ItemPickUp weaponPickUp, Inventory charInventory, GameObject weaponSlot)
    {
        bool previousWeaponSame = false;

        if (weapon != null)
        {
            if (weapon == weaponPickUp)
            {
                previousWeaponSame = true;
            }

            Destroy(weaponSlot.transform.GetChild(0).gameObject);
            weapon = null;
            currentPhysicalDamage = basePhysicalDamage;
            currentMagicDamage = baseMagicDamage;
        }
        return previousWeaponSame;
    }

    /* public bool UnEquipArmor(ItemPickUp armorPickUp, Inventory charInventory)
     {
         bool previousArmorSame = false;

         switch (armorPickUp.itemDefinition.itemArmorSubType)
         {
             case ItemArmorSubType.NONE:
                 break;
             case ItemArmorSubType.HELMET:
                 if (helmet != null)
                 {
                     if (helmet == armorPickUp)
                     {
                         previousArmorSame = true;
                     }

                     currentPhysicalDamage -= armorPickUp.itemDefinition.itemAmount;
                     currentMagicResistance -= armorPickUp.itemDefinition.itemAmount;
                     helmet = null;
                 }
                 break;
             case ItemArmorSubType.CHEST:
                 if (chestArmor != null)
                 {
                     if (chestArmor == armorPickUp)
                     {
                         previousArmorSame = true;
                     }

                     currentPhysicalDamage -= armorPickUp.itemDefinition.itemAmount;
                     currentMagicResistance -= armorPickUp.itemDefinition.itemAmount;
                     chestArmor = null;
                 }
                 break;
             case ItemArmorSubType.SHOULDER:

                 if (shoulder != null)
                 {
                     if (shoulder == armorPickUp)
                     {
                         previousArmorSame = true;
                     }

                     currentPhysicalDamage -= armorPickUp.itemDefinition.itemAmount;
                     currentMagicResistance -= armorPickUp.itemDefinition.itemAmount;
                     shoulder = null;
                 }
                 break;
             case ItemArmorSubType.GLOVES:
                 if (gloves != null)
                 {
                     if (gloves == armorPickUp)
                     {
                         previousArmorSame = true;
                     }

                     currentPhysicalDamage -= armorPickUp.itemDefinition.itemAmount;
                     currentMagicResistance -= armorPickUp.itemDefinition.itemAmount;
                     gloves = null;
                 }
                 break;
             case ItemArmorSubType.BELT:
                 if (belt != null)
                 {
                     if (belt == armorPickUp)
                     {
                         previousArmorSame = true;
                     }

                     currentPhysicalDamage -= armorPickUp.itemDefinition.itemAmount;
                     currentMagicResistance -= armorPickUp.itemDefinition.itemAmount;
                     belt = null;
                 }
                 break;
             case ItemArmorSubType.LEGS:
                 if (legArmor != null)
                 {
                     if (legArmor == armorPickUp)
                     {
                         previousArmorSame = true;
                     }

                     currentPhysicalDamage -= armorPickUp.itemDefinition.itemAmount;
                     currentMagicResistance -= armorPickUp.itemDefinition.itemAmount;
                     legArmor = null;
                 }
                 break;
             case ItemArmorSubType.BOOTS:
                 if (boots != null)
                 {
                     if (boots == armorPickUp)
                     {
                         previousArmorSame = true;
                     }

                     currentPhysicalDamage -= armorPickUp.itemDefinition.itemAmount;
                     currentMagicResistance -= armorPickUp.itemDefinition.itemAmount;
                     boots = null;
                 }
                 break;
             default:
                 break;
         }
         return previousArmorSame;
     }*/

    #endregion

    #region Character Level Up and Death

    public void Death()
    {
        Debug.Log("You're Dead");
        //Call to Game manager for death state
        //Die animation (if any)
        //Death sound/mission failed
    }

    private void LevelUp()
    {
        charLevel += 1;
        //Display level up animation (if any)
        //Play level up sound

        maxHealth = charLevelUps[charLevel - 1].maxHealth;
        maxMana = charLevelUps[charLevel - 1].maxMana;
        basePhysicalDamage = charLevelUps[charLevel - 1].basePhysicalDamage;
        baseMagicDamage = charLevelUps[charLevel - 1].baseMagicDamage;
        baseArmor = charLevelUps[charLevel - 1].baseArmor;
        baseMagicResistance = charLevelUps[charLevel - 1].baseMagicResistance;
    }

    #endregion

    #region Save Character Data

    /*public void SaveCharacterData()
    {
        saveDataOnClose = true;
        EditorUtility.SetDirty(this);
    }*/

    #endregion
}
