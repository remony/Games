using UnityEngine;
using UnityEngine.UI;

/**
 * Store item prefab object script.
 */
public class Item : MonoBehaviour
{
    /** Name of item */
    public string displayText;

    /** Cost */
    public int displayCost;

    /** Number owned */
    public int displayCount;

    /** Reference to display text element */
    public Text displayTextElement;

    /** Reference to display cost element */
    public Text displayCostElement;


    /** Reference to display count element */
    public Text displayCountElement;

    /** Reference to button element */
    public Button buttomElement;


    // Start is called before the first frame update
    void Start()
    {

    }

    /** On mouse click handling */
    public void OnMouseDown()
    {
        SendMessageUpwards("BuyItem", this.displayText);
    }


    // Update is called once per frame
    void Update()
    {
        ColorBlock buttonColours = this.buttomElement.colors;

        if (GameManager.Instance.points < this.displayCost)
        {
            buttonColours.normalColor = Color.grey;
        }
        else
        {
            buttonColours.normalColor = Color.white;
        }

        this.buttomElement.colors = buttonColours;
        displayTextElement.text = this.displayText;
        displayCostElement.text = "Cost: " + this.displayCost;
        displayCountElement.text = "" + this.displayCount;
    }
}
