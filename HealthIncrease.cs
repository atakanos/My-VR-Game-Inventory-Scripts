using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthIncrease : MonoBehaviour {

    private GameObject[] slot;
    public GameObject slotholder;
    private int allslots;
    public int NeedItemCount = 1;
    public GameObject HP;
    public GameObject InventoryControl;

    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void BighpUp()
    {
        allslots = 30;
        slot = new GameObject[allslots];
        for (int i = 0; i < allslots; i++)
        {
            slot[i] = slotholder.transform.GetChild(i).gameObject;
            //int havecount = int.Parse(slot[i].GetComponentInChildren<Text>().text);

            if (slot[i].GetComponent<Slot>().itemcount >= NeedItemCount && HP.GetComponent<PlayerStats>().currentHealth < 100)
            {
                float hpbigup = 100 - HP.GetComponent<PlayerStats>().currentHealth;
                HP.GetComponent<PlayerStats>().HealtIncrease(hpbigup);
                InventoryControl.GetComponent<PlayerInventory>().BigAidPackRemove();
                return;
            }
        }
    }
    public void SmallhpUp()
    {
        allslots = 30;
        slot = new GameObject[allslots];
        for (int i = 0; i < allslots; i++)
        {
            slot[i] = slotholder.transform.GetChild(i).gameObject;
            //int havecount = int.Parse(slot[i].GetComponentInChildren<Text>().text);

            if (slot[i].GetComponent<Slot>().itemcount >= NeedItemCount && HP.GetComponent<PlayerStats>().currentHealth < 100)
            {
                float hpsmallup = 100 - HP.GetComponent<PlayerStats>().currentHealth;
                if (hpsmallup > 30)
                {
                    HP.GetComponent<PlayerStats>().HealtIncrease(30);
                    InventoryControl.GetComponent<PlayerInventory>().SmallAidPackRemove();
                    return;
                }
                else if (hpsmallup <= 30)
                {
                    HP.GetComponent<PlayerStats>().HealtIncrease(hpsmallup);
                    InventoryControl.GetComponent<PlayerInventory>().SmallAidPackRemove();
                    return;
                }
                
            }
        }
    }
}
