using System.Collections.Generic;
using UnityEngine;
using System;
public class Store : MonoBehaviour
{
    /** Link to store item prefab */
    public Transform StoreItemPrefab;

    /** List of store items to render */
    public List<StoreItem> storeItems;

    /** Store name */
    public string storeName;

    /** Internal dictionary of item references for each store item */
    private Dictionary<string, Item> items = new Dictionary<string, Item>();

    // Start is called before the first frame update
    void Start()
    {
        // Create and instantiate prefab for each store item in menu
        this.storeItems.ForEach(item =>
        {
            Transform prefab = Instantiate(StoreItemPrefab);
            prefab.name = item.name;

            Item itemPrefab = prefab.gameObject.GetComponent<Item>();
            itemPrefab.displayText = item.name;
            itemPrefab.displayCost = item.cost;
            itemPrefab.displayCount = item.count;
            prefab.transform.SetParent(GameObject.Find("Content").transform, false);
            this.items.Add(item.name, itemPrefab);
        });
    }

    // Update is called once per frame
    void Update()
    {
        // Update all store item entry values
        this.storeItems.ForEach(item =>
        {
            Item listObject = this.items[item.name];
            listObject.displayCost = item.cost;
            listObject.displayCount = item.count;
        });
    }
}
