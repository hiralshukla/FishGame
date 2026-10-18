using UnityEngine;
using System.Collections.Generic;

public class SpawnFish : MonoBehaviour
{
    public GameObject fishy;
    public Transform tankBackground;
    float fishTankHeight;

    List<float> availableSpaces = new ();

    public float tankDistance = 0.5f;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InitAvailableSpaces(5);
    }

    float GetFishTankHeight() => tankBackground.localScale.y;
    void PlaceFish()
    { 
        Vector2 position = Vector2.zero;
        int randomNumber = Random.Range(0, availableSpaces.Count-1);
        position.y = availableSpaces[randomNumber];
        availableSpaces.RemoveAt(randomNumber);
        GameObject tempFish = Instantiate(fishy, position, Quaternion.identity);
        tempFish.GetComponent<BaseFish>().speed = Random.Range(1f, 2f);
    }


    public void InitAvailableSpaces(int currCapacity)
    {
        fishTankHeight = GetFishTankHeight();
        for (int i = 0; i < fishTankHeight; i++)
        {
            float calcHeight = fishTankHeight - i;
            availableSpaces.Add((calcHeight - fishTankHeight / 2) - tankDistance);

        }

        print(availableSpaces.Count);

        for (int i = 0; i < currCapacity; i++)
        {
            PlaceFish();
        }
    }

}
