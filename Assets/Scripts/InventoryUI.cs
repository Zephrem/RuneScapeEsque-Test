using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    Inventory inventory;

    public Transform slotsParent;

    InventorySlot[] slots;

    bool isActive;

    // Start is called before the first frame update
    void Start()
    {
        inventory = Inventory.instance;

        inventory.OnItemChangedCallback += UpdateUI;

        slots = slotsParent.GetComponentsInChildren<InventorySlot>();

        isActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            ToggleUI();
        }
    }

    void UpdateUI()
    {
        for(int i = 0; i < slots.Length; i++)
        {
            if (i < inventory.items.Count)
            {
                slots[i].AddItem(inventory.items[i]);
            }
            else
            {
                slots[i].ClearSlot();
            }
        }
    }

    void ToggleUI()
    {
        if (isActive)
        {
            transform.localScale = new Vector3(0, 0, 0);
            isActive = false;
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 1);
            isActive = true;
        }

    }
}
