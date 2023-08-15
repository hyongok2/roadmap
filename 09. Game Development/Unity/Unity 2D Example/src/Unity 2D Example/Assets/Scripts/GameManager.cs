using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int totalPoint;
    public int stagePoint;
    public int stageIndex;
    public int health;
    public PlayerMove player;

    public GameObject[] Stages;

    public Image[] UIHealth;
    public TextMeshProUGUI UIPoint;
    public TextMeshProUGUI UIStage;
    public GameObject UIRestartButton;

    private void Update()
    {
        UIPoint.text = (totalPoint + stagePoint).ToString();
    }

    public void NextStage()
    {
        if(stageIndex < Stages.Length -1)
        {
            Stages[stageIndex].SetActive(false);
            stageIndex++;
            Stages[stageIndex].SetActive(true);
            PlayerReposition();

            UIStage.text = "STAGE " + (stageIndex + 1).ToString();
        }
        else
        {
            Time.timeScale = 0;
            Debug.Log("Game Clear!");

            TextMeshProUGUI btnText = UIRestartButton.GetComponentInChildren<TextMeshProUGUI>();
            btnText.text = "Game Clear!";
            UIRestartButton.SetActive(true);
        }



        totalPoint += stagePoint;
        stagePoint= 0;

    }

    public void HealthDown()
    {
        if (health > 1)
        {
            health--;
            UIHealth[health].color = new Color(1, 0, 0, 0.2f);
        }
        else
        {
            UIHealth[0].color = new Color(1, 0, 0, 0.2f);
            player.OnDie();
            Debug.Log("플레이어가 죽었습니다.");
            TextMeshProUGUI btnText = UIRestartButton.GetComponentInChildren<TextMeshProUGUI>();
            btnText.text = "Retry?";
            UIRestartButton.SetActive(true);
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

    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}
