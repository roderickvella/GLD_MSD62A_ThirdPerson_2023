using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class InventoryManager : MonoBehaviour
{
    [Tooltip("Number of items")]
    public int numberOfItems = 5;

    [Tooltip("Items selection panel")]
    public GameObject itemsSelectionPanel;

    [Tooltip("List of Items")]
    public List<ItemScriptableObject> itemsAvailable;

    private List<InventoryItem> itemsForPlayer;

    // Start is called before the first frame update
    void Start()
    {
        itemsForPlayer = new List<InventoryItem>();

        PopulateInventorySpawn();
    }

    private void PopulateInventorySpawn()
    {
        for(int i=0; i<numberOfItems; i++)
        {
            //pick random object from itemsAvailable
            ItemScriptableObject objItem = itemsAvailable[Random.Range(0, itemsAvailable.Count)];
            print(objItem.title);

            //check whether objItem exists in itemsForPlayer. So basically we need to count how many items
            //we've got if type objItem inside itemsForPlayer
            int countItems = itemsForPlayer.Where(x => x.item == objItem).ToList().Count;
            if(countItems == 0)
            {
                //add objItem with quantity 1 because it is the first type inside itemsForPlayer
                itemsForPlayer.Add(new InventoryItem() { item = objItem, quantity = 1 });
            }
            else
            {
                //we find the first occurance of this type (like objItem)
                var item = itemsForPlayer.First(x => x.item == objItem);
                //we update the quantity by increasing 1
                item.quantity += 1;
            }


        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public class InventoryItem
    {
        public ItemScriptableObject item;
        public int quantity;
    }
}
