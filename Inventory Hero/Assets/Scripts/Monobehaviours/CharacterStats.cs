using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public CharacterStat_SO characterDefinition;
    public Inventory charInv;
    public GameObject characterWeaponSlot;

    #region Constructors

    public CharacterStats()
    {
        charInv = Inventory.instance;
    }

    #endregion

    #region Initalizations

    private void Start()
    {
        if (!characterDefinition.setManually)
        {
            characterDefinition.maxHealth = 100;
            characterDefinition.currentHealth = 100;

            characterDefinition.maxMana = 50;
            characterDefinition.currentMana = 50;

            characterDefinition.maxWealth = 9999999;
            characterDefinition.currentWealth = 0;

            characterDefinition.baseArmor = 0;
            characterDefinition.currentArmor = 0;

            characterDefinition.baseMagicResistance = 0;
            characterDefinition.currentMagicResistance = 0;

            characterDefinition.charExperience = 0;
            characterDefinition.charLevel = 1;
        }
    }
    #endregion

    #region Updates

    private void Update()
    {
        /* if (Input.GetMouseButtonDown(2))
             characterDefinition.saveCharacterData();*/
    }

    #endregion

    #region Stat Increasers

    public void ApplyHealth(int healthAmount)
    {
        characterDefinition.ApplyHealth(healthAmount);
    }

    public void ApplyMana(int manaAmount)
    {
        characterDefinition.ApplyMana(manaAmount);
    }

    public void GiveWealth(int wealthAmount)
    {
        characterDefinition.GiveWealth(wealthAmount);
    }

    public void ApplyExperience(int experienceAmount)
    {
        characterDefinition.ApplyExperience(experienceAmount);
    }

    #endregion

    #region Stat Decreasers

    public void TakeDamage(int amount)
    {
        characterDefinition.TakeDamage(amount);
        amount = characterDefinition.currentHealth;
        if (characterDefinition.currentHealth <= 0)
        {
            characterDefinition.Death();
        }

    }

    public void UseMana(int manaCost)
    {
        characterDefinition.UseMana(manaCost);
    }

    public void TakeWealth(int wealthAmount)
    {
        characterDefinition.TakeWealth(wealthAmount);
    }

    #endregion

    #region Weapon and Armor Change

    public void ChangeWeapon(ItemPickUp weaponPickUp)
    {
        if (!characterDefinition.UnEquipWeapon(weaponPickUp, charInv, characterWeaponSlot))
        {
            // characterDefinition.EquipWeapon(weaponPickUp, charInv, characterWeaponSlot);
        }
    }

    public void ChangeArmor(ItemPickUp armorPickUp)
    {
        /*  if (!characterDefinition.UnEquipArmor(armorPickUp, charInv))
          {
              characterDefinition.EquipArmor(armorPickUp, charInv);
          }*/
    }

    #endregion

    #region Reporters

    public int GetHealth()
    {
        return characterDefinition.currentHealth;
    }

    public int GetMana()
    {
        return characterDefinition.currentMana;
    }

    public int GetWealth()
    {
        return characterDefinition.currentWealth;
    }

    public ItemPickUp GetCurrentWeapon()
    {
        return characterDefinition.weapon;
    }

    #endregion



}
