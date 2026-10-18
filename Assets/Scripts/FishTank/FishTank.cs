using UnityEngine;

public class FishTank : MonoBehaviour
{
    int currCapacity = 0;
    public int maxCapacity = 5;
    public Transform tankBackground;
    public SpawnFish spawner;

    public static FishTank Instance;

    void Awake()
    {
        if (FishTank.Instance == null) FishTank.Instance = this;
        else Destroy(this);
    }


    int GetCurrCapacity() => currCapacity;
    int GetMaxCapacity() => maxCapacity;

    void SetCurrCapacity(int newCapacity)
    {
        currCapacity = newCapacity;
    }

    void SetMaxCapacity(int newCapacity)
    {
        maxCapacity = newCapacity;

        spawner.InitAvailableSpaces(newCapacity);
    }

    public float GetBackgroundLength()
    {
        return tankBackground.localScale.x;
    }



}
