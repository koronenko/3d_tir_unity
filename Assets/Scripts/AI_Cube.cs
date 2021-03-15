using UnityEngine;
using UnityEngine.SceneManagement;
public class AI_Cube : MonoBehaviour
{
    private float speed;
    public float StartTime; //з якої секунди починати
    public float EndTime; // через скільки приховувати мішень


    void FixedUpdate()
    {
        StartTime += 1f * Time.deltaTime; // відраховуємо секунди

        if (StartTime >= EndTime) // при завершенні часу
        {
            gameObject.SetActive(false); // приховуємо
            //Destroy(gameObject);
        }

    }
}
