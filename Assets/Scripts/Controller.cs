using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class Controller : MonoBehaviour
{
    // екземпляри спавна
    public GameObject pref; //змінна префабу сфери
    public GameObject _target; //змінна мішені кубу
    private GameObject inst_target; //ініціалізація мішені
    public AudioClip shot; //звук вистрілу
    AudioSource audioSource;
    public Camera cam; // головна камера

    private void Start()
    {
        inst_target = Instantiate(_target, _target.transform.position, Quaternion.identity); //вивід префабу
        inst_target.transform.position = new Vector3(-9.82f, 4.22f, -6.32f); //точка спавна
        audioSource = GetComponent<AudioSource>();

    }
    private void Update()
    {
        Spawn(); //стрільба по мішені


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
                    Instantiate(pref, hit.point, Quaternion.identity); // відображаємо сферу
                    audioSource.PlayOneShot(shot, 1f);

                }
            }
        }

    }
}
