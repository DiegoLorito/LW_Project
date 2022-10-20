using UnityEngine;

public class BounceWhenContact : MonoBehaviour
{
    public string collisionTag;
    public float bounceForce;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(collisionTag))
        {
            if (collision.gameObject.TryGetComponent(out Rigidbody2D col))
            {
                col.AddForce(collision.contacts[0].normal * bounceForce * -1, ForceMode2D.Impulse);
            }
        }
    }
}
