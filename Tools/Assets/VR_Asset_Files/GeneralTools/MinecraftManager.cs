using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinecraftManager : MonoBehaviour
{

    public List<GameObject> PossibleAddOns;

    private List<GameObject> AddedItems;

    public Transform ParentContainer;

    public Transform PositionOfNewPlaceables;

    public void AddNewObject(int positionList)
    {
        AddedItems.Add(PossibleAddOns[positionList]);

        Instantiate(PossibleAddOns[positionList], PositionOfNewPlaceables.position, PositionOfNewPlaceables.rotation, ParentContainer);
    }

    private GameObject NewItemHeld;
    public void AddNewObjectHold(int positionList)
    {
        AddedItems.Add(PossibleAddOns[positionList]);

        NewItemHeld = Instantiate(PossibleAddOns[positionList], PositionOfNewPlaceables.position, PositionOfNewPlaceables.rotation, ParentContainer);
    }

    // Start is called before the first frame update
    void Start()
    {
        AddedItems = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
}
