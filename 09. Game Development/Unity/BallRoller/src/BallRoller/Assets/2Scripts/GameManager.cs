using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int totalItemCount;
    public int stage;
    public Text stageText;
    public Text totalItemText;
    public Text playerItemText;

    private void Awake()
    {
        stageText.text = (stage+1).ToString();
        totalItemText.text = (totalItemCount).ToString();
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.name=="Player")
        {
            SceneManager.LoadScene(stage);
        }
    }
}
