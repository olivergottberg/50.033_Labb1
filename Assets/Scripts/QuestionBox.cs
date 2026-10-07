using UnityEngine;

public class QuestionBox : MonoBehaviour
{
    public Animator coinAnimator;
    public Sprite disabledSprite;

    private bool used = false;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (used)
            return;

        if (collision.gameObject.CompareTag("Player"))
        {
            if (collision.transform.position.y < transform.position.y)
            {
                used = true;
                coinAnimator.Play("Coin");
                GetComponent<Animator>().enabled = false;
                //TODO: Improve animation so it doesnt get disabled mid-air
                GetComponent<SpriteRenderer>().sprite = disabledSprite;
                GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            }
        }
    }
}