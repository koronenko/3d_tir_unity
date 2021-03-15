using UnityEngine;
using UnityEngine.UI;

using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class Controller : MonoBehaviour
{
    public float timeStart = 59; // кількість секунд раунду
    public Text Txt_sek; // вивід таймеру в змінну
    public Text Txt_score; // вивід поцілених мішеней
    private int score = 0; // рахунок

    // екземпляри спавна
    public GameObject pref; //змінна префабу сфери
    public GameObject _target; //змінна мішені кубу
    public GameObject _player; //змінна гравця
    private GameObject inst_player; //ініціалізація мішені
    private GameObject inst_sfera; //ініціалізація сфери
    public AudioClip shot; //звук вистрілу
    AudioSource audioSource;
    public Camera cam; // головна камера
    public int pool_count = 9; // кількість мішеней
    private int active_target_count; // кількість активних мішеней
    public GameObject[] pool_AR; // масив мішеней
    private Vector3[] cubePosition = {
        new Vector3(-5.72f, 1.37f, -8.28f),
        new Vector3(-6.8f, 2.64f, -7.44f),
        new Vector3(-8.35f, 3.63f, -6.76f),
        new Vector3(-9.82f, 4.22f, -6.32f),
        new Vector3(-11.2f, 4.40f, -6.0f),
        new Vector3(-12.71f, 4.22f, -6.76f),
        new Vector3(-13.9f, 3.63f, -6.76f),
        new Vector3(-15.28f, 2.64f, -7.44f),
        new Vector3(-16.32f, 1.37f, -8.28f)
    };

    private void Start()
    {
        Time.timeScale = 1f;
        Txt_sek.text = "Time:" + timeStart.ToString();

        audioSource = GetComponent<AudioSource>();

        active_target_count = pool_count; // задаємо кількість активних мішеней
        pool_AR = new GameObject[pool_count];
        for (int i = 0; i < pool_count; i++)
        {
            pool_AR[i] = Instantiate(_target, _target.transform.position, Quaternion.identity); //вивід префабу
            pool_AR[i].transform.position = cubePosition[i]; //точка спавна
        }


        inst_player = Instantiate(_player, _player.transform.position, Quaternion.identity); //вивід префабу гравця
        inst_player.transform.position = new Vector3(-10.59f, 0f, -3.14f); //точка спавна
    }
    private void Update()
    {


        timeStart -= Time.deltaTime;
        Txt_sek.text = "Time: " + Mathf.Round(timeStart).ToString();
        if (timeStart <= 0)
        {
            Txt_sek.text = "the end";
            Time.timeScale = 0f; //зупиняємо плин часу в грі
        }
        else
        {
            Txt_score.text = "Target: " + score;

            Spawn(); //стрільба по мішені
        }
    }

    public void Spawn()
    {
        if (Input.GetMouseButton(0))
        {
            RaycastHit hit;
            Ray ray = cam.ScreenPointToRay(Input.mousePosition); //в точці позиції курсору

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.tag == "target")
                {
                    inst_sfera = Instantiate(pref, hit.point + hit.normal *  0.01f, Quaternion.identity); // відображаємо сферу
                    audioSource.PlayOneShot(shot, 1f);
                    score++;
                    for (int i = 0; i < pool_count; i++)
                    {
                        if (pool_AR[i].active && pool_AR[i].transform == hit.transform)
                        {
                            pool_AR[i].SetActive(false); // приховування мішеней
                            active_target_count--;


                                Invoke("Respawn", 5f);

                        }
                    }
                }
            }

            toTargetKill();

        }

    }

    public void toTargetKill()
    {

        Destroy(inst_sfera, .1f);


    }
    public void targets()
    {
       // Destroy(inst_target, .1f);
    }
    void Respawn()
    {
        if (active_target_count < pool_count) // поки всі активні не виконуємо
        {
            int index;
            do
            {
                index = Random.Range(0, pool_count);
            }
            while (pool_AR[index].active); // берем рендомно мішень поки вона не активна, якщо активна не беремо

            pool_AR[index].SetActive(true);
            active_target_count++;
        }
    }
}
