using System.Collections.Generic;
using UnityEngine;

public class FishTank : MonoBehaviour
{
    int currCapacity = 0;
    public int maxCapacity = 5;
    public Transform tankBackground;
    public SpawnFish spawner;
    public Collider2D bubblePopCol;


    public List <BaseFish> currFishList= new();

    public static FishTank Instance;

    void Awake() // singleton 
    {
        if (FishTank.Instance == null) FishTank.Instance = this;
        else Destroy(this);
    }


    int GetCurrCapacity() => currCapacity;
    int GetMaxCapacity() => maxCapacity;


    public void SetCurrCapacity(int newCapacity)
    {
        if (maxCapacity! > newCapacity)
        {
            currCapacity = newCapacity;
        }
    }

    public void SetMaxCapacity(int newCapacity)
    {
        maxCapacity = newCapacity;
        tankBackground.localScale *= 2;
        spawner.InitAvailableSpaces(newCapacity);
    }

    public float GetBackgroundLength()
    {
        return tankBackground.localScale.x;
    }

}
