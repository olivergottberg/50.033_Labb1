using UnityEngine;
using UnityEngine.Events;

public class EnemyManager : MonoBehaviour
{
    public GameConstants gameConstants;
    public UnityEvent damagePlayer;
    public UnityEvent<int> increaseScore;

    void Awake()
    {
        //GameManager.instance.gameRestart.AddListener(GameRestart);
    }

    /*public void GameRestart()
    {
        foreach (Transform child in transform)
        {
            child.GetComponent<EnemyMovement>().GameRestart();
        }
    }*/

    public void GameRestart()
    {
        gameObject.SetActive(true);
        GetComponent<Collider2D>().enabled = true;
        GetComponent<Animator>().Play("GoombaIdle");
        GetComponent<EnemyMovement>().GameRestart();
    }
}

