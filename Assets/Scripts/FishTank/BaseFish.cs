using JetBrains.Annotations;
using Unity.Collections;
using UnityEngine;

public class BaseFish : MonoBehaviour
{
    public Transform bubbleTransform;
    public SpriteRenderer fishy;
    public ParticleSystem ps;

    public float speed = 1f;
    public float turnDistance = 0.05f;
    public float turnSpeed = 0.05f;

    private int direction = 1;
    private float bubbleXOffset;

    private Quaternion targetSR_Rot;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        bubbleXOffset = bubbleTransform.localPosition.x;
        targetSR_Rot = Quaternion.identity;

        if (FishTank.Instance.bubblePopCol != null) ps.trigger.AddCollider(FishTank.Instance.bubblePopCol);
    }


    void Update()
    {
        transform.position += Vector3.right * direction * speed * Time.deltaTime;

        float fishHalfSize = transform.localScale.x/2 + turnDistance;
        float tankWidth = FishTank.Instance.GetBackgroundLength();
        float leftEdge = -tankWidth/2 + fishHalfSize;
        float rightEdge = tankWidth/2 - fishHalfSize;

        if ((transform.position.x > rightEdge && direction > 0) || (transform.position.x < leftEdge && direction < 0))
        {
            Vector3 modifiedBubblePosition = bubbleTransform.localPosition;
            modifiedBubblePosition.x = bubbleXOffset * -direction;
            bubbleTransform.localPosition = modifiedBubblePosition; 


            direction = direction * -1;
        }

        if ((transform.position.x > (rightEdge * 0.95f) && direction > 0) || (transform.position.x < (leftEdge * 0.95f) && direction < 0))
        {
            float srRot = (-direction > 0) ? 0 : 180;
            targetSR_Rot = Quaternion.Euler(0, srRot, 0);
        }

        fishy.transform.rotation = Quaternion.Lerp(fishy.transform.rotation, targetSR_Rot, turnSpeed);
    }
}
