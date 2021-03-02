using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirDropSpawn : MonoBehaviour
{
    public List<Item> itemsSpawnList;
    public List<GameObject> spawnPointDrop;
    
    private List<Item> _dropBoxItems;

    public GameObject airDropBoxObject;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
            Spawn();
    }

    public void Spawn()
    {
	    var rndPos = Random.Range(0, spawnPointDrop.Count);

	    var airDropBox = airDropBoxObject.GetComponent<AirDropInventory>();
	    var capacity = airDropBox.GenerateInventoryCapacity();                      //Вызов генерации размера инвентаря в ящике
        var itemsList = GenerateItems(capacity);                                    //Генерация определенного количества случайных предметов.
        airDropBox.AddItemsToBoxInventory(itemsList);                               //Добавление предметов в инвентарь ящика.
        Instantiate(airDropBoxObject, spawnPointDrop[rndPos].transform.position, Quaternion.identity); //Спавн ящика в определенном месте
        airDropBox.UpdateAirDropUi(itemsList);
    }

    private List<Item> GenerateItems(int capacity)
    {
	    _dropBoxItems = new List<Item>();
	    for (int i = 0; i < capacity; i++)
	    {
		    var rndItemIndex = Random.Range(0, itemsSpawnList.Count);
		    _dropBoxItems.Add(itemsSpawnList[rndItemIndex]);
	    }

	    return _dropBoxItems;
    }
}
