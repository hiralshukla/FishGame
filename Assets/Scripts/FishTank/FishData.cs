using UnityEngine;


// scriptable object 
[CreateAssetMenu(fileName = "FishData", menuName = "Scriptable Objects/FishData")]
public class FishData : ScriptableObject
{
    public float speed = 1;
    public float rarity = 0.50f;

}
