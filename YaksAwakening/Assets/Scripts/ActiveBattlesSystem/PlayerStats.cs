using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : ScriptableObject
{

    [Header("Health")]

    [Tooltip("The Max Health of the character")]
    [SerializeField] private float maxHealth;

    [Tooltip("The Current health of the player")]
    [SerializeField] private float currentHealth;

    [Space(20)]
    [Header("Speed")]

    [Tooltip("The base speed stat of the player. Only increases with level")]
    [SerializeField] private float baseSpeed;



    [Space(20)]
    [Header("Item Stats")]
    //Whenever we equip or unequip an item, we should edit these values


    [Tooltip("The Speed increase from items")]
    [SerializeField] private float itemSpeed;

    //[Space(20)]
    //[Header("Active Effects")]


    public void EquipItem()
    {

    }

    public void UnEquipItem()
    {

    }


}
