using UnityEngine;
using UnityEngine.SceneManagement;
public class AI_Cube : MonoBehaviour
{
    private float speed;
     void Start()
    {
        // позиція рандомна,
      //  transform.localPosition = new Vector3(transform.localPosition.x, Random.Range(-1f, 1f));

        // швидкість рандомна
        speed = Random.Range(1, 2);

        // розмір рандомний
        //transform.localScale = Vector3.one * Random.Range(0.1f, 1f);
    }


    void Update()
    {
        // просто переміщаємо вліво
     //   transform.Translate(-speed * Time.deltaTime, 0, 0);

        //перевірка і перезагрузка сцени
        if (transform.localPosition.x < -10)
        {
        //    transform.Translate(speed * Time.deltaTime, 0, 0);
            //  SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

    }
}
