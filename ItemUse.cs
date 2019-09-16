using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemUse : MonoBehaviour {

    private GameObject[] slot;
    public GameObject slotholder;
    private int allslots;
    public int NeedItemCount;
    public string ItemName;
    public GameObject Lapis1;
    public GameObject Lapis2;
    public GameObject InventoryControl;
    public bool LapisSlotSetActive;

    void Start () {
		
	}
	
	void Update () {
		
	}

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Envanter" && Input.GetKeyDown(KeyCode.JoystickButton0))
        {
            allslots = 30;
            slot = new GameObject[allslots];
            for (int i = 0; i < allslots; i++)
            {
                slot[i] = slotholder.transform.GetChild(i).gameObject;

                if (slot[i].GetComponentInChildren<Text>().text == NeedItemCount.ToString() && slot[i].GetComponent<Slot>().itemname == ItemName)
                {
                    Lapis1.SetActive(true);
                    Lapis2.SetActive(true);
                    LapisSlotSetActive = true;
                    InventoryControl.GetComponent<PlayerInventory>().LapisLazuliRemove();
                    this.GetComponent<BoxCollider>().enabled = false;
                    return;
                }
                
            }
        }
    }
}
