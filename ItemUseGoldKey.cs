using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemUseGoldKey : MonoBehaviour {

    private GameObject[] slot;
    public GameObject slotholder;
    private int allslots;
    public int NeedItemCount;
    public string ItemName;
    public GameObject GoldenKey;
    public GameObject InventoryControl;
    public bool GoldKeySlot;
    public GameObject Scene5Table;
    public AudioClip KeyInSlot;
    public AudioClip FinalDoorOpen;
    public GameObject FinalDoor;
    public int KeyPartsCount;

    void Start()
    {
        KeyPartsCount = 0;
    }

    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Envanter")
        {
            allslots = 30;
            slot = new GameObject[allslots];
            for (int i = 0; i < allslots; i++)
            {
                slot[i] = slotholder.transform.GetChild(i).gameObject;

                if (/*slot[i].GetComponentInChildren<Text>().text == NeedItemCount.ToString() && */slot[i].GetComponent<Slot>().itemname == ItemName)
                {
                    KeyPartsCount++;
                    
                        //return;

                }
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Envanter")
        {
            KeyPartsCount = 0;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag=="Envanter")
        {
            if (KeyPartsCount == 2 && GoldKeySlot == false && Input.GetKeyDown(KeyCode.JoystickButton0))
            {
                Scene5Table.GetComponent<AudioSource>().PlayOneShot(KeyInSlot);
                GoldenKey.SetActive(true);
                GoldKeySlot = true;
                InventoryControl.GetComponent<PlayerInventory>().GoldenKeyRemove();
                FinalDoor.GetComponent<Animation>().Play("Door5OpenAnim");
                Scene5Table.GetComponent<AudioSource>().PlayOneShot(FinalDoorOpen);
                KeyPartsCount = 0;
            }
        }
    }
}
