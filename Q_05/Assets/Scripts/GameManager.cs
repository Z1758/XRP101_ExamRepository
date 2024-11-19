using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : SingletonBehaviour<GameManager>
{

    //EvenSystem�� ��� ui�� �۵����� ����
    public float Score { get; set; }

    private void Awake()
    {
        SingletonInit();
        Score = 0.1f;
    }

    public void Pause()
    {
       
      
        Time.timeScale = 0f;
    }

    public void LoadScene(int buildIndex)
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(buildIndex);
    }
}
