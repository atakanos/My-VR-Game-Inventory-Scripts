using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour,/* IPointerDownHandler,*/ IPointerEnterHandler, IPointerExitHandler
{

    public GameObject item;
    public int itemid, itemcount;
    public string itemname, iteminfo;
    public bool empty;
    public Sprite icon;
    public Transform SlotIconGO;
    HealthIncrease HP;

    private bool _equipItem = false;

    //public void OnPointerDown(PointerEventData pointerEventData)
    //{
    void Start()
    {
        SlotIconGO = this.transform.GetChild(0);
    }

    void Update()
    {
        if (_equipItem == true)
        {
            if (Input.GetKeyDown(KeyCode.JoystickButton0))
            {

                if (this.GetComponent<Slot>().item != null && itemname == "Torch")
                {
                    UseItem();
                    _equipItem = false;
                }
                if (this.GetComponent<Slot>().item != null && itemname == "Big Aid Pack")
                {
                    FindObjectOfType<HealthIncrease>().BighpUp();
                    _equipItem = false;
                }
                if (this.GetComponent<Slot>().item != null && itemname == "Small Aid Pack")
                {
                    FindObjectOfType<HealthIncrease>().SmallhpUp();
                    _equipItem = false;
                }
            }
        }
    }

    //}
    public void OnPointerEnter(PointerEventData pointerEventData)
    {

        if (this.GetComponent<Slot>().item != null)
        {
            GameObject.FindWithTag("ItemInfoPanel").GetComponent<Text>().text = this.itemname + " : " + this.iteminfo;
            _equipItem = true;
        }
        else
        {
            GameObject.FindWithTag("ItemInfoPanel").GetComponent<Text>().text = null;
        }

    }
    public void OnPointerExit(PointerEventData pointerEventData)
    {
        GameObject.FindWithTag("ItemInfoPanel").GetComponent<Text>().text = null;
        _equipItem = false;
    }
    

    public void UpdateSlot()
    {
        SlotIconGO.GetComponent<Image>().sprite = icon;
        if (itemname == "Torch")
        {
            UseItem();
        }
    }

    public void UseItem()
    {
        item.GetComponent<Item>().ItemUsage();

    }
}
