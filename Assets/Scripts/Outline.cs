using UnityEngine;

public class Outline : MonoBehaviour
{
    public Transform Pointer; // вказівник
    public Selectible CurrentSelectible;
    private void LateUpdate()
    {
        //  Ray ray = new Ray(); // промінь
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
          ray.origin = transform.position; // початок променя в позиції обєкта
        ray.direction = transform.forward; // напрямок відповідає осі forvard(z)
        Debug.DrawRay(transform.position, transform.forward * 100f,Color.yellow); // жовтий промінь довжина 100

        RaycastHit hit; //змінна для запису інформації куди втрапив промінь
        if (Physics.Raycast(ray, out hit)) // щоб визначити чи було потрапляння булеве значення
        {
            Pointer.position = hit.point; //зберігаємо точку попадання променя на обєкт
                                          //hit.collider.gameObject.GetComponent<Renderer>().material.color = Color.yellow;
            Selectible selectible = hit.collider.gameObject.GetComponent<Selectible>();
            if (selectible)
            {
                if (CurrentSelectible && CurrentSelectible != selectible)
                {
                    CurrentSelectible.Deselect();
                    // CurrentSelectible = null;
                }
                CurrentSelectible = selectible;
                selectible.Select();
            }

            else
            {
                if (CurrentSelectible)
                {
                    CurrentSelectible.Deselect();
                    CurrentSelectible = null;

                }
            }
        }
        else
        {
            if (CurrentSelectible)
            {
                CurrentSelectible.Deselect();
                CurrentSelectible = null;

            }
        }

    }

}
