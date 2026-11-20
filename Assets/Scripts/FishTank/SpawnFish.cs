using UnityEngine;
using System.Collections.Generic;
using UnityEngine.InputSystem;

public class SpawnFish : MonoBehaviour
{
    public GameObject fishy;
    public Transform tankBackground;
    float fishTankHeight;

    List<float> availableSpaces = new ();

    public float tankDistance = 0.5f;

    //debug --
    InputAction interactAction;
    //--


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InitAvailableSpaces(5);

        // debug--
            interactAction = InputSystem.actions.FindAction("Interact");
        //
    }

    //for debug --
    private void Update()
    {
        bool ifInteract = interactAction.WasPressedThisFrame();

        if (ifInteract)
        {
            FishData newFishData = FishGenerator.Instance.OnSuccess(1f);
            SpawnFishRandomColor(newFishData);
        }
    }

    // --

    float GetFishTankHeight() => tankBackground.localScale.y;

    BaseFish PlaceFish(FishData newFishData)
    {
        Vector2 position = Vector2.zero;
        int randomNumber = Random.Range(0, availableSpaces.Count - 1);
        position.y = availableSpaces[randomNumber];
        availableSpaces.RemoveAt(randomNumber);


        GameObject tempFish = Instantiate(fishy, position, Quaternion.identity);

        //get fish data
        BaseFish tempFishComponent = tempFish.GetComponent<BaseFish>();
        tempFishComponent.Init(newFishData);
        FishTank.Instance.currFishList.Add(tempFishComponent);

        return tempFishComponent;
    }


    public void InitAvailableSpaces(int currCapacity)
    {
        fishTankHeight = GetFishTankHeight();
        for (int i = 0; i < fishTankHeight; i++)
        {
            float calcHeight = fishTankHeight - i;
            availableSpaces.Add((calcHeight - fishTankHeight / 2) - tankDistance);

        }
    }

    public void SpawnFishFromData(FishData newFishData)
    {
        if (availableSpaces.Count <= 0) return;
        BaseFish tmpFish = PlaceFish(newFishData);
        
    }

    public void SpawnFishRandomColor(FishData newFishData)
    {
        if (availableSpaces.Count <= 0) return;
        BaseFish tmpFish = PlaceFish(newFishData);
        tmpFish.SetColors(Random.ColorHSV(), Random.ColorHSV(), Random.ColorHSV());
    }
}
