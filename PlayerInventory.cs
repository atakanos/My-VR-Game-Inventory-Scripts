using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class PlayerInventory : MonoBehaviour {
    
    public GameObject Inventory;
    public GameObject PauseMenu;
    private int allslots;
    private int enabledslots;
    private GameObject[] slot;
    public GameObject slotholder;
    private bool SilverCoinAllready = false;
    private bool LapisAllready = false;
    private bool BigAidAllready = false;
    private bool SmallAidAllready = false;
    private GameObject InventoryItems;
    public Sprite EmptyIcon;
    //public Stats loadstats;

    void Start()
    {

        allslots = 30;
        slot = new GameObject[allslots];
        for (int i = 0; i < allslots; i++)
        {
            slot[i] = slotholder.transform.GetChild(i).gameObject;

            if (slot[i].GetComponent<Slot>().item == null)
            {
                slot[i].GetComponent<Slot>().empty = true;
            }
        }
        Inventory.SetActive(false);
    }
    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.I))
        //{
        //    InventoryEnabled = !InventoryEnabled;
        //}
        if (Inventory.activeSelf == false && Input.GetKeyDown(KeyCode.JoystickButton2) && PauseMenu.activeSelf == false)
        {
            
            Inventory.SetActive(true);
        }
        else if(Inventory.activeSelf == true && Input.GetKeyDown(KeyCode.JoystickButton2))
        {
            Inventory.SetActive(false);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "SilverCoin" && Input.GetKeyDown(KeyCode.JoystickButton0))
        {
            if (SilverCoinAllready == false)
            {
                GameObject ItemPickedUp = other.gameObject;
                Item item = ItemPickedUp.GetComponent<Item>();

                AddItem(ItemPickedUp, item.itemid, item.itemcount, item.itemname, item.iteminfo, item.itemicon);
                SilverCoinAllready = true;
            }
            else if (SilverCoinAllready == true)
            {
                GameObject ItemPickedUp = other.gameObject;
                Item item = ItemPickedUp.GetComponent<Item>();

                AllreadySilverCoin(ItemPickedUp);
            }
        }
        if (other.tag == "LapisLazuli" && Input.GetKeyDown(KeyCode.JoystickButton0))
        {
            if (LapisAllready == false)
            {
                GameObject ItemPickedUp = other.gameObject;
                Item item = ItemPickedUp.GetComponent<Item>();

                AddItem(ItemPickedUp, item.itemid, item.itemcount, item.itemname, item.iteminfo, item.itemicon);
                LapisAllready = true;
            }
            else if (LapisAllready == true)
            {
                GameObject ItemPickedUp = other.gameObject;
                Item item = ItemPickedUp.GetComponent<Item>();

                AllreadyLapisLazuli(ItemPickedUp);
            }
        }
        if (other.tag == "SmallAidPack" && Input.GetKeyDown(KeyCode.JoystickButton0))
        {
            if (SmallAidAllready == false)
            {
                GameObject ItemPickedUp = other.gameObject;
                Item item = ItemPickedUp.GetComponent<Item>();

                AddItem(ItemPickedUp, item.itemid, item.itemcount, item.itemname, item.iteminfo, item.itemicon);
                SmallAidAllready = true;
            }
            else if (SmallAidAllready == true)
            {
                GameObject ItemPickedUp = other.gameObject;
                Item item = ItemPickedUp.GetComponent<Item>();

                AllreadySmallAidPack(ItemPickedUp);
            }
        }
        if (other.tag == "BigAidPack" && Input.GetKeyDown(KeyCode.JoystickButton0))
        {
            if (BigAidAllready == false)
            {
                GameObject ItemPickedUp = other.gameObject;
                Item item = ItemPickedUp.GetComponent<Item>();

                AddItem(ItemPickedUp, item.itemid, item.itemcount, item.itemname, item.iteminfo, item.itemicon);
                BigAidAllready = true;
            }
            else if (BigAidAllready == true)
            {
                GameObject ItemPickedUp = other.gameObject;
                Item item = ItemPickedUp.GetComponent<Item>();

                AllreadyBigAidPack(ItemPickedUp);
            }
        }
        if (other.tag == "CollectableTorch" && Input.GetKeyDown(KeyCode.JoystickButton0))
        {
            GameObject ItemPickedUp = other.gameObject;
            Item item = ItemPickedUp.GetComponent<Item>();

            AddItem(ItemPickedUp, item.itemid, item.itemcount, item.itemname, item.iteminfo, item.itemicon);
        }
        if (other.tag == "GoldKeyParts" && Input.GetKeyDown(KeyCode.JoystickButton0))
        {
            GameObject ItemPickedUp = other.gameObject;
            Item item = ItemPickedUp.GetComponent<Item>();

            AddItem(ItemPickedUp, item.itemid, item.itemcount, item.itemname, item.iteminfo, item.itemicon);
        }
        if (other.tag == "WeaponParts" && Input.GetKeyDown(KeyCode.JoystickButton0))
        {
            GameObject ItemPickedUp = other.gameObject;
            Item item = ItemPickedUp.GetComponent<Item>();

            AddItem(ItemPickedUp, item.itemid, item.itemcount, item.itemname, item.iteminfo, item.itemicon);
        }
    }

    void AddItem(GameObject ItemObject, int Itemid, int Itemcount, string Itemname, string Iteminfo, Sprite Itemicon)
    {
        for (int i = 0; i < allslots; i++)
        {
            if (slot[i].GetComponent<Slot>().empty)
            {
                ItemObject.GetComponent<Item>().PickedUp = true;
                slot[i].GetComponent<Slot>().item = ItemObject;
                slot[i].GetComponent<Slot>().icon = Itemicon;
                slot[i].GetComponent<Slot>().itemid = Itemid;
                slot[i].GetComponent<Slot>().itemcount = Itemcount;
                slot[i].GetComponent<Slot>().itemname = Itemname;
                slot[i].GetComponent<Slot>().iteminfo = Iteminfo;

                ItemObject.transform.parent = slot[i].transform;
                ItemObject.SetActive(false);
                slot[i].GetComponent<Slot>().UpdateSlot();
                slot[i].GetComponentInChildren<Text>().text = slot[i].GetComponent<Slot>().itemcount.ToString();
                slot[i].GetComponent<Slot>().empty = false;
                return;
            }
        }
    }
    void AddLoadItem()
    {
        for (int i = 0; i < allslots; i++)
        {
            if (slot[i].GetComponent<Slot>().empty)
            {
                //Destroy(slot[i].transform.GetChild(2).gameObject);
                slot[i].GetComponent<Slot>().item = null;
                slot[i].GetComponent<Slot>().itemid = 0;
                slot[i].GetComponent<Slot>().itemcount = 0;
                slot[i].GetComponent<Slot>().itemname = null;
                slot[i].GetComponent<Slot>().iteminfo = null;
                slot[i].GetComponent<Slot>().icon = EmptyIcon;
                slot[i].GetComponent<Slot>().empty = true;
                //slot[i].transform.GetChild(0).GetComponent<Image>().sprite = EmptyIcon;
                slot[i].GetComponentInChildren<Text>().text = null;
                slot[i].GetComponent<Slot>().UpdateSlot();
                return;
            }
        }
    }
    void AllreadySilverCoin(GameObject ItemObject)
    {
        for (int i = 0; i < allslots; i++)
        {
            if (slot[i].GetComponent<Slot>().itemname == "Silver Coin" && slot[i].GetComponent<Slot>().empty == false)
            {
                slot[i].GetComponent<Slot>().itemcount += 1;
                ItemObject.SetActive(false);
                slot[i].GetComponent<Slot>().UpdateSlot();
                slot[i].GetComponentInChildren<Text>().text = slot[i].GetComponent<Slot>().itemcount.ToString();
                return;
            }
        }
    }
    void AllreadyLapisLazuli(GameObject ItemObject)
    {
        for (int i = 0; i < allslots; i++)
        {
            if (slot[i].GetComponent<Slot>().itemname == "Lapis Lazuli" && slot[i].GetComponent<Slot>().empty == false)
            {
                slot[i].GetComponent<Slot>().itemcount += 1;
                ItemObject.SetActive(false);
                slot[i].GetComponent<Slot>().UpdateSlot();
                slot[i].GetComponentInChildren<Text>().text = slot[i].GetComponent<Slot>().itemcount.ToString();
                return;
            }
        }
    }
    void AllreadySmallAidPack(GameObject ItemObject)
    {
        for (int i = 0; i < allslots; i++)
        {
            if (slot[i].GetComponent<Slot>().itemname == "Small Aid Pack" && slot[i].GetComponent<Slot>().empty == false)
            {
                slot[i].GetComponent<Slot>().itemcount += 1;
                ItemObject.SetActive(false);
                slot[i].GetComponent<Slot>().UpdateSlot();
                slot[i].GetComponentInChildren<Text>().text = slot[i].GetComponent<Slot>().itemcount.ToString();
                return;
            }
        }
    }
    void AllreadyBigAidPack(GameObject ItemObject)
    {
        for (int i = 0; i < allslots; i++)
        {
            if (slot[i].GetComponent<Slot>().itemname == "Big Aid Pack" && slot[i].GetComponent<Slot>().empty == false)
            {
                slot[i].GetComponent<Slot>().itemcount += 1;
                ItemObject.SetActive(false);
                slot[i].GetComponent<Slot>().UpdateSlot();
                slot[i].GetComponentInChildren<Text>().text = slot[i].GetComponent<Slot>().itemcount.ToString();
                return;
            }
        }
    }
    public void LapisLazuliRemove()
    {
        for (int i = 0; i < allslots; i++)
        {
            if (slot[i].GetComponent<Slot>().itemname == "Lapis Lazuli" && slot[i].GetComponent<Slot>().empty == false)
            {
                //Destroy(slot[i].transform.GetChild(2).gameObject);
                slot[i].GetComponent<Slot>().item = null;
                slot[i].GetComponent<Slot>().itemid = 0;
                slot[i].GetComponent<Slot>().itemcount = 0;
                slot[i].GetComponent<Slot>().itemname = null;
                slot[i].GetComponent<Slot>().iteminfo = null;
                slot[i].GetComponent<Slot>().icon = EmptyIcon;
                slot[i].GetComponent<Slot>().empty = true;
                //slot[i].transform.GetChild(0).GetComponent<Image>().sprite = EmptyIcon;
                slot[i].GetComponentInChildren<Text>().text = null;
                slot[i].GetComponent<Slot>().UpdateSlot();
                LapisAllready = false;
                return;
            }
        }
    }
    public void GoldenKeyRemove()
    {
        for (int i = 0; i < allslots; i++)
        {
            if (slot[i].GetComponent<Slot>().itemname == "Gold Key Parts" && slot[i].GetComponent<Slot>().empty == false)
            {
                //Destroy(slot[i].transform.GetChild(2).gameObject);
                slot[i].GetComponent<Slot>().item = null;
                slot[i].GetComponent<Slot>().itemid = 0;
                slot[i].GetComponent<Slot>().itemcount = 0;
                slot[i].GetComponent<Slot>().itemname = null;
                slot[i].GetComponent<Slot>().iteminfo = null;
                slot[i].GetComponent<Slot>().icon = EmptyIcon;
                slot[i].GetComponent<Slot>().empty = true;
                //slot[i].transform.GetChild(0).GetComponent<Image>().sprite = EmptyIcon;
                slot[i].GetComponent<Slot>().UpdateSlot();
                slot[i].GetComponentInChildren<Text>().text = null;
                //return;
            }
        }
    }
    public void BigAidPackRemove()
    {
        for (int i = 0; i < allslots; i++)
        {
            if (slot[i].GetComponent<Slot>().itemname == "Big Aid Pack" && slot[i].GetComponent<Slot>().empty == false)
            {
                
                if (slot[i].GetComponent<Slot>().itemcount > 1)
                {
                    slot[i].GetComponent<Slot>().itemcount -= 1;
                    slot[i].GetComponent<Slot>().UpdateSlot();
                    slot[i].GetComponentInChildren<Text>().text = slot[i].GetComponent<Slot>().itemcount.ToString();
                    return;
                }
                else if (slot[i].GetComponent<Slot>().itemcount == 1)
                {
                    //Destroy(slot[i].transform.GetChild(2).gameObject);
                    slot[i].GetComponent<Slot>().item = null;
                    slot[i].GetComponent<Slot>().itemid = 0;
                    slot[i].GetComponent<Slot>().itemcount = 0;
                    slot[i].GetComponent<Slot>().itemname = null;
                    slot[i].GetComponent<Slot>().iteminfo = null;
                    slot[i].GetComponent<Slot>().icon = EmptyIcon;
                    slot[i].GetComponent<Slot>().empty = true;
                    //slot[i].transform.GetChild(0).GetComponent<Image>().sprite = EmptyIcon;
                    slot[i].GetComponentInChildren<Text>().text = null;
                    slot[i].GetComponent<Slot>().UpdateSlot();
                    BigAidAllready = false;
                    return;
                }
            }
        }
    }
    public void SmallAidPackRemove()
    {
        for (int i = 0; i < allslots; i++)
        {
            if (slot[i].GetComponent<Slot>().itemname == "Small Aid Pack" && slot[i].GetComponent<Slot>().empty == false)
            {
                //Destroy(slot[i].transform.GetChild(2).gameObject);
                if (slot[i].GetComponent<Slot>().itemcount > 1)
                {
                    slot[i].GetComponent<Slot>().itemcount -= 1;
                    slot[i].GetComponent<Slot>().UpdateSlot();
                    slot[i].GetComponentInChildren<Text>().text = slot[i].GetComponent<Slot>().itemcount.ToString();
                    slot[i].GetComponent<Slot>().UpdateSlot();
                    return;
                }
                else if (slot[i].GetComponent<Slot>().itemcount == 1)
                {
                    //Destroy(slot[i].transform.GetChild(2).gameObject);
                    slot[i].GetComponent<Slot>().item = null;
                    slot[i].GetComponent<Slot>().itemid = 0;
                    slot[i].GetComponent<Slot>().itemcount = 0;
                    slot[i].GetComponent<Slot>().itemname = null;
                    slot[i].GetComponent<Slot>().iteminfo = null;
                    slot[i].GetComponent<Slot>().icon = EmptyIcon;
                    slot[i].GetComponent<Slot>().empty = true;
                    //slot[i].transform.GetChild(0).GetComponent<Image>().sprite = EmptyIcon;
                    slot[i].GetComponentInChildren<Text>().text = null;
                    slot[i].GetComponent<Slot>().UpdateSlot();
                    SmallAidAllready = false;
                    return;
                }
            }
        }
    }

    public void LoadingItemData(int[] Envanter, int[] itemcounttext)
    {
        for (int c = 0; c < itemcounttext.Length; c++)
        {
            for (int i = 0; i < Envanter.Length; i++)
            {
                if (Envanter[i] == 0)
                {
                    AddLoadItem();
                    c++;
                }
                if (Envanter[i] == 1)
                {
                    if (SilverCoinAllready == false)
                    {
                        GameObject ItemPickedUp = GameObject.FindWithTag("SilverCoinInventory");
                        Item item = ItemPickedUp.GetComponent<Item>();

                        AddItem(ItemPickedUp, item.itemid, itemcounttext[c], item.itemname, item.iteminfo, item.itemicon);
                        SilverCoinAllready = true;
                        //i++;
                        c++;
                    }

                }
                if (Envanter[i] == 3)
                {
                    if (BigAidAllready == false)
                    {
                        GameObject ItemPickedUp = GameObject.FindWithTag("BigAidPackInventory");
                        Item item = ItemPickedUp.GetComponent<Item>();

                        AddItem(ItemPickedUp, item.itemid, itemcounttext[c], item.itemname, item.iteminfo, item.itemicon);
                        BigAidAllready = true;
                        //i++;
                        c++;
                    }
                }
                if (Envanter[i] == 2)
                {
                    if (LapisAllready == false)
                    {
                        GameObject ItemPickedUp = GameObject.FindWithTag("LapisInventory");
                        Item item = ItemPickedUp.GetComponent<Item>();

                        AddItem(ItemPickedUp, item.itemid, itemcounttext[c], item.itemname, item.iteminfo, item.itemicon);
                        LapisAllready = true;
                        //i++;
                        c++;
                    }
                }
                if (Envanter[i] == 4)
                {
                    if (SmallAidAllready == false)
                    {
                        GameObject ItemPickedUp = GameObject.FindWithTag("SmallAidPackInventory");
                        Item item = ItemPickedUp.GetComponent<Item>();

                        AddItem(ItemPickedUp, item.itemid, itemcounttext[c], item.itemname, item.iteminfo, item.itemicon);
                        SmallAidAllready = true;
                        //i++;
                        c++;
                    }
                }
                if (Envanter[i] == 5)
                {

                    GameObject ItemPickedUp = GameObject.FindWithTag("GoldKeyPartsInventory");
                    Item item = ItemPickedUp.GetComponent<Item>();

                    AddItem(ItemPickedUp, item.itemid, itemcounttext[c], item.itemname, item.iteminfo, item.itemicon);
                    //i++;
                    c++;
                }
                if (Envanter[i] == 6)
                {

                    GameObject ItemPickedUp = GameObject.FindWithTag("CollectableTorchInventory");
                    Item item = ItemPickedUp.GetComponent<Item>();

                    AddItem(ItemPickedUp, item.itemid, itemcounttext[c], item.itemname, item.iteminfo, item.itemicon);
                    //i++;
                    c++;
                }
                if (Envanter[i] == 7)
                {

                    GameObject ItemPickedUp = GameObject.FindWithTag("WeaponPartsInventory");
                    Item item = ItemPickedUp.GetComponent<Item>();

                    AddItem(ItemPickedUp, item.itemid, itemcounttext[c], item.itemname, item.iteminfo, item.itemicon);
                    //i++;
                    c++;
                }




                //if (other.tag == "LapisLazuli" && Input.GetKey(KeyCode.E))
                //{
                //    if (LapisAllready == false)
                //    {
                //        GameObject ItemPickedUp = other.gameObject;
                //        Item item = ItemPickedUp.GetComponent<Item>();

                //        AddItem(ItemPickedUp, item.itemid, item.itemcount, item.itemname, item.iteminfo, item.itemicon);
                //        LapisAllready = true;
                //    }
                //    else if (LapisAllready == true)
                //    {
                //        GameObject ItemPickedUp = other.gameObject;
                //        Item item = ItemPickedUp.GetComponent<Item>();

                //        AllreadyLapisLazuli(ItemPickedUp);
                //    }
                //}
                //if (other.tag == "SmallAidPack" && Input.GetKey(KeyCode.E))
                //{
                //    if (SmallAidAllready == false)
                //    {
                //        GameObject ItemPickedUp = other.gameObject;
                //        Item item = ItemPickedUp.GetComponent<Item>();

                //        AddItem(ItemPickedUp, item.itemid, item.itemcount, item.itemname, item.iteminfo, item.itemicon);
                //        SmallAidAllready = true;
                //    }
                //    else if (SmallAidAllready == true)
                //    {
                //        GameObject ItemPickedUp = other.gameObject;
                //        Item item = ItemPickedUp.GetComponent<Item>();

                //        AllreadySmallAidPack(ItemPickedUp);
                //    }
                //}
                //if (other.tag == "BigAidPack" && Input.GetKey(KeyCode.E))
                //{
                //    if (BigAidAllready == false)
                //    {
                //        GameObject ItemPickedUp = other.gameObject;
                //        Item item = ItemPickedUp.GetComponent<Item>();

                //        AddItem(ItemPickedUp, item.itemid, item.itemcount, item.itemname, item.iteminfo, item.itemicon);
                //        BigAidAllready = true;
                //    }
                //    else if (BigAidAllready == true)
                //    {
                //        GameObject ItemPickedUp = other.gameObject;
                //        Item item = ItemPickedUp.GetComponent<Item>();

                //        AllreadyBigAidPack(ItemPickedUp);
                //    }
                //}
                //if (other.tag == "CollectableTorch" && Input.GetKey(KeyCode.E))
                //{
                //    GameObject ItemPickedUp = other.gameObject;
                //    Item item = ItemPickedUp.GetComponent<Item>();

                //    AddItem(ItemPickedUp, item.itemid, item.itemcount, item.itemname, item.iteminfo, item.itemicon);
                //}
                //if (other.tag == "GoldKeyParts" && Input.GetKey(KeyCode.E))
                //{
                //    GameObject ItemPickedUp = other.gameObject;
                //    Item item = ItemPickedUp.GetComponent<Item>();

                //    AddItem(ItemPickedUp, item.itemid, item.itemcount, item.itemname, item.iteminfo, item.itemicon);
                //}
                //if (other.tag == "WeaponParts" && Input.GetKey(KeyCode.E))
                //{
                //    GameObject ItemPickedUp = other.gameObject;
                //    Item item = ItemPickedUp.GetComponent<Item>();

                //    AddItem(ItemPickedUp, item.itemid, item.itemcount, item.itemname, item.iteminfo, item.itemicon);
                //}
            }
        }
    }
}
