using UnityEngine;

public class BaseFish : MonoBehaviour
{
    public Transform bubbleTransform;
    public SpriteRenderer fishy;

    public FishData data;

    public float speed = 1f;
    public float turnDistance = 0.05f;

    private int direction = 1;
    private float bubbleXOffset;

    public void Init(FishData input)
    {
        data = input;
        speed = data.speed;
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        bubbleXOffset = bubbleTransform.localPosition.x;
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
            fishy.flipX = !fishy.flipX;
        }

    }
}
