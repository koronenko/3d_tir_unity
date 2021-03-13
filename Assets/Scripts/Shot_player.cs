using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Shot_player : MonoBehaviour
{
    //рахунок
    private int score;

    // відображення рахунку
    public Text text;

    // для зберігання позиції, де він заспавнився
    private float startX;

    // змінна щоб знати чи рухається кошеня
    private bool isgo;

    // Start is called before the first frame update
    void Start()
    {
        startX = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        text.text = score.ToString();

        //запускаємо, якщо летить 0 , то рух є(вправо), якщо не летить то стрибає
        if (Input.GetMouseButtonDown(0))
        {
            isgo = true;
        }
        if (isgo)
        {
            if (transform.position.x < 7)
            {
                transform.Translate(Time.deltaTime * 13, 0, 0);
            }
        }
        else
        {
            transform.position = new Vector3(startX, Mathf.Sin(Time.time * 2) * 2f);
        }

        // якщо ми вийшли за екран то
        //if (transform.position.x > 10)
        //{
        //    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        //}
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //якщо не летимо, то програємо, якщо летимо то ловимо сніжинку
        if (!isgo)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        }
        else
        {
            Destroy(collision.gameObject);

            isgo = false;

            score++;
        }
    }
}