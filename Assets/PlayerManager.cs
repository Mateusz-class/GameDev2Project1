using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{
    public GameManager gameManager;
    public Rigidbody2D rb;
    public float Speed = 5;

    // Update is called once per frame
    void Update()
    {
        if (gameManager.MatchOver == false)
        {
        //Basic movement from professors example
        Vector2 vel = new Vector2(0,0);
        if(Keyboard.current.rightArrowKey.isPressed) {vel.x = Speed;}
        if(Keyboard.current.leftArrowKey.isPressed) {vel.x = -Speed;}
        if(Keyboard.current.upArrowKey.isPressed) {vel.y = Speed;}
        if(Keyboard.current.downArrowKey.isPressed) {vel.y = -Speed;}
        rb.linearVelocity = vel;
        }
        else
        {
            rb.linearVelocity = Vector2.zero;
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PointObjectManager>().IsBadPoint == false)
        {
            gameManager.AddPoint();
        }
        else
        {
            gameManager.SubtractPoint();
        }
        Destroy(collision.gameObject);
    }
}
