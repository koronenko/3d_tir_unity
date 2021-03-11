using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class main_Menu : MonoBehaviour
{
    public GameObject Main_Menu;

    public static bool isOpened = false;

    public void StartTheGame()
    {
        Debug.Log("Start");

        SceneManager.LoadScene("Level_game");
    }

    public void TOPTheGame()
    {

        SceneManager.LoadScene("TopTable");
    }
    public void MenuTheGame()
    {

        SceneManager.LoadScene("Menu");
    }
    public void QuitTheGame()
    {

        Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
    }

    public void Start()
    {

        EventSystem.current.SetSelectedGameObject(null);

    }


    public void Update()
    {



    }

}