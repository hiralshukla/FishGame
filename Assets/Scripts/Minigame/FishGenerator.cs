using JetBrains.Annotations;
using NUnit.Framework;
using NUnit.Framework.Constraints;
using System.Collections.Generic;
using UnityEngine;

public class FishGenerator : MonoBehaviour
{
    public List<FishData> myFishies = new();
    public static FishGenerator Instance;

    void Awake() // singleton 
    {
        if (FishGenerator.Instance == null) FishGenerator.Instance = this;
        else Destroy(this);
    }


    public FishData OnSuccess(float successLevel)
    {
        // 1 add all the probabilities of each fish together = total
        // 250 = total 100, 100, 25, 25 
        // Random number generator (0-total) = 150 
        // 100 < 150, but not greater than 200 then output fish 0

        float total = 0;

        for (int i = 0; i < myFishies.Count; i++)
        {
            total += myFishies[i].rarity;
        }

        float result = Random.Range(0f, total);
        float curr = myFishies[0].rarity;
        
        for (int i = 0; i < myFishies.Count; i++)
        {
            if (result > curr) {
                curr += myFishies[i+1].rarity;
            } else {
                return myFishies[i];
            }

        }

        return null;



    }
}
