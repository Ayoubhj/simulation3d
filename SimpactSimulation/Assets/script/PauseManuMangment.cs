using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManuMangment : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject PauseMenu;
    [HideInInspector]  public static bool GameisPaused = false;
    public void openMenu()
    {
        PauseMenu.SetActive(true);
        Time.timeScale = 0f;
        GameisPaused = true;
    }
    public void closeMenu()
    {
        PauseMenu.SetActive(false);
        Time.timeScale = 1f;
        GameisPaused = false;
    }
}
