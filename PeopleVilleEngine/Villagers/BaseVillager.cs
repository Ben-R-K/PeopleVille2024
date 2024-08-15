﻿using LocationsEngine;
using Items;
using Items.Interfaces;
using PeopleVilleEngine;
using PeopleVilleBankSystem;

public abstract class BaseVillager
{
    public int Age { get; protected set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public bool IsMale { get; set; }
    private Village _village;
    public ILocation? CurrentLocation { get; set; } = null;
    public ResidentialBuilding? Home { get; set; }
    public bool IsBusy;
    public Hunger hunger;
    private Inventory _inventory;
    private string _accountNumber;

    protected BaseVillager(Village village)
    {
        _village = village;
        IsMale = RNG.GetInstance().Next(0, 2) == 0;
        (FirstName, LastName) = village.VillagerNameLibrary.GetRandomNames(IsMale);
        IsBusy = false;
        hunger = new Hunger(this);
        _inventory = new Inventory(Age);
    }

    public IItem GetItemByName(string name)
    {
        return _inventory.GetItemByName(name);
    }

    public IItem GetItemByType(string type)
    {
        return _inventory.getItemByType(type);
    }

    public void RemoveItem(IItem item)
    {
        _inventory.RemoveItem(item);
    }

    public void SetAccountNumber(string accountNumber)
    {
        _accountNumber = accountNumber;
    }

    public string GetAccountNumber()
    {
        return _accountNumber;
    }

    public override string ToString()
    {
        return $"{FirstName} {LastName} ({Age} years)";
    }
}