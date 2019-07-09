using UnityEngine;

public class StoreItem : MonoBehaviour
{
    /** Store item name */
    public string name;

    /** Value */
    public float value = 0.1f;

    /** Cost of item */
    public int cost = 1;

    /** Number of items bought */
    public int count = 0;

/** The cost increase per purchase */
    public int costIncrease = 1;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("performAction", 0, 1.0f);
    }

    /**
     * Interval action
     */
    void performAction()
    {
        GameManager.Instance.points += (this.value * this.count);
    }


    /**
     * Handling buying items events.
     */
    public void BuyItem(string name)
    {
        if (name == this.name)
        {
            if (GameManager.Instance.points >= this.cost)
            {
                GameManager.Instance.points -= this.cost;
                count = count + 1;
                this.cost += (costIncrease * this.count);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
