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
            used = true;
            coinAnimator.Play("Coin");
            GetComponent<Animator>().enabled = false;
            GetComponent<SpriteRenderer>().sprite = disabledSprite;
            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        }
    }
}