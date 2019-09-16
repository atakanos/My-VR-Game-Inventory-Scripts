using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Item : MonoBehaviour
{
    public int itemid;
    public int itemcount = 1;
    public string itemname, iteminfo;
    public Sprite itemicon;
    public bool PickedUp;

    [HideInInspector]
    public bool equipped;
    [HideInInspector]
    public GameObject item;
    [HideInInspector]
    public GameObject Envanter;

    public bool playersTorch;

    public void Start()
    {
        Envanter = GameObject.FindWithTag("Envanter");
        if (!playersTorch)
        {
            int allitems = Envanter.transform.childCount;
            for (int i = 0; i < allitems; i++)
            {
                if (Envanter.transform.GetChild(i).gameObject.GetComponent<Item>().itemid == itemid)
                {
                    item = Envanter.transform.GetChild(i).gameObject;
                }
            }
        }
    }
    public void Update()
    {
        if (equipped)
        {
            if (Input.GetKey(KeyCode.JoystickButton4))
                equipped = false;
            if (equipped == false)
                this.gameObject.SetActive(false);
        }
    }

    public void ItemUsage()
    {
        //Torch
        if (itemname == "Torch" && equipped == false)
        {
            item.SetActive(true);
            item.GetComponent<Item>().equipped = true;
        }

        //if (itemname == "Big Aid Pack")
        //{
        //    item.GetComponent<Item>().equipped = false;
        //}


        //beverage


    }
}
