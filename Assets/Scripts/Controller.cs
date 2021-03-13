using UnityEngine;
public class Controller : MonoBehaviour
{
    // екземпляр спавна
    public GameObject pref;
    public GameObject _target;
    private GameObject inst_target;
    public Camera cam;

    private void Start()
    {
        inst_target = Instantiate(_target, _target.transform.position, Quaternion.identity);
        inst_target.transform.position = new Vector3(-9.82f, 4.22f, -6.32f);

    }
    private void Update()
    {
        Spawn();

    }
    public void Spawn()
    {
        if (Input.GetMouseButton(0))
        {
            RaycastHit hit;
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.tag == "target")
                {
                    Instantiate(pref, hit.point, Quaternion.identity);
                }
            }
        }

    }
}
