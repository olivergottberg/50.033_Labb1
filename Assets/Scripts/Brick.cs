using UnityEngine;

public class Brick : MonoBehaviour
{
    public Animator brickAnimator;
    public Animator coinAnimator;
    public string bounceAnimation = "BrickBounce";

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (collision.transform.position.y < transform.position.y)
            {
                brickAnimator.Play(bounceAnimation);
                if (coinAnimator != null)
                {
                    coinAnimator.Play("Coin_brick");
                }
            }

        }
    }
}