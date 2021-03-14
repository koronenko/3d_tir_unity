using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Shot_player : MonoBehaviour
{
    //рахунок
    private int score;

    // відображення рахунку
    public Text text;


    void Start()
    {

    }


    void Update()
    {
        text.text = score.ToString();


    }

   }