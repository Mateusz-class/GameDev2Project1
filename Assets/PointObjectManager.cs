using UnityEngine;

public class PointObjectManager : MonoBehaviour
{
    public float ObjectTimer = 2;
    public bool IsBadPoint;
    public SpriteRenderer spriteRenderer;

    // Update is called once per frame
    void Update()
    {
        if(ObjectTimer > 0)
        {
            ObjectTimer -= Time.deltaTime;
            //If player takes too long to get object then it "spoils" and decreases points when touched.
            if (ObjectTimer <= 0)
            {
                IsBadPoint = true;
                spriteRenderer.color = Color.red;
            }
        }
    }
}
