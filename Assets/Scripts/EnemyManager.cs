using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    void Awake()
    {
        GameManager.instance.gameRestart.AddListener(GameRestart);
    }

    public void GameRestart()
    {
        foreach (Transform child in transform)
        {
            child.GetComponent<EnemyMovement>().GameRestart();
        }
    }
}