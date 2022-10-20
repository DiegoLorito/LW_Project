using UnityEngine;
using UnityEngine.Events;

public class HorizontalMove : MonoBehaviour
{
    public bool move;
    public float speed;
    public float posMinX;

    public UnityEvent onComplete;

    private void Update()
    {
        if (move)
        {
            if (transform.position.x > posMinX)
            {
                transform.position = (Vector2)transform.position + Vector2.left * speed * Time.deltaTime;
            }
            else
            {
                move = false;
                onComplete?.Invoke();
            }
        }
    }
}
