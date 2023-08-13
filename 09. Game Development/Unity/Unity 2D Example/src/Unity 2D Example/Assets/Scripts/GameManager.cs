using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int totalPoint;
    public int stagePoint;
    public int stageIndex;
    public int health;
    public PlayerMove player;

    public GameObject[] Stages;

    public void NextStage()
    {
        if(stageIndex < Stages.Length -1)
        {
            Stages[stageIndex].SetActive(false);
            stageIndex++;
            Stages[stageIndex].SetActive(true);
            PlayerReposition();
        }
        else
        {
            Time.timeScale = 0;
            Debug.Log("Game Clear!");
        }



        totalPoint = stagePoint;
        stagePoint= 0;

    }

    public void HealthDown()
    {
        if(health > 1) health--;
        else
        {
            player.OnDie();
            Debug.Log("플레이어가 죽었습니다.");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (health > 1)
            {
                PlayerReposition();
            }

            HealthDown();
        }
    }

    private void PlayerReposition()
    {
        player.transform.position = new Vector3(-9, 2, 0);
        player.VelocityZero();
    }

}
