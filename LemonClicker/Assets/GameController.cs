using UnityEngine;

/** Game Controller class */
public class GameController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.points += 1;
    }

    // Update is called once per frame
    void Update()
    {
        // Handling on click
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit targetGameObject;

            // If the click action catches a gameObject
            if (Physics.Raycast(ray, out targetGameObject, 1000))
            {
                GameObject target = targetGameObject.transform.gameObject;

                // When the gameObject has a enemy tag 
                if (target.tag == "Enemy")
                {
                    GameManager.Instance.points += 1;
                    GameManager.Instance.clickAction.onClick(System.DateTime.Now);
                }
            }
        };
    }
}
