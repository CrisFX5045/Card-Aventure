using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPause : MonoBehaviour
{
    public GameObject menuPause;
    public static bool GameIsPause = false;

     void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPause)
            {
                Continuar();

            }
            else
            {
                Pause();
            }
        }
    }

    public void Continuar()
    {
        menuPause.SetActive(false);
        Time.timeScale = 1f;
        GameIsPause = false;
    }

    void Pause()
    {
        menuPause.SetActive(true);
        Time.timeScale = 0f;
        GameIsPause = true;
    }

   

    }
