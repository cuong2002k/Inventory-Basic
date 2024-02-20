using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    [SerializeField] private GameObject InventoryPanelPrefabs;
    [SerializeField] private InventoryModel _model;
    [SerializeField] private InventoryPanel _panel;
    [SerializeField] private int size = 25;

    // container item, ex: stone, wood, ...
    [SerializeField] private List<Item> Items = new List<Item>();

    private void Start()
    {
        if (InventoryPanelPrefabs == null) Debug.Log("inventory prefabs is null");

        _model = new InventoryModel(size);
        _panel = new InventoryPanel(size);

        // init inventory UI 
        StartCoroutine(Initialized(size));

        Items.Add(new WoodItem());
        Items.Add(new Stone());
        Items.Add(new ChestAmor());
    }

    public IEnumerator Initialized(int size)
    {
        for (int i = 0; i < size; i++)
        {
            GameObject slotUISpawn = Object.Instantiate(_panel.SlotUIPrefabs, InventoryPanelPrefabs.transform);
            SlotUI slotUi = slotUISpawn.GetComponent<SlotUI>();
            // set Id slot
            slotUi.ID = i;
            // subcriber event handlerslot
            slotUi.OnDropSlot += HandlerSlot;
            _panel.SlotUIContainer.Add(slotUi);
        }
        yield return null;
        // subscribe event
        _model.OnModelChange += _panel.RefestUI;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            int index = Random.Range(1, Items.Count + 1);
            int stack = Random.Range(1, 10);
            Debug.Log(index);
            ItemStack itemToAdd = new ItemStack(Items[index - 1], Mathf.Min(stack, Items[index - 1].GetMaxStack()));

            if (_model.AddItem(itemToAdd))
            {
                Debug.Log("Insert item");
            }
            else
            {
                Debug.Log("Full");
            }
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            this._model.Clear();
            Debug.Log("Clear Inventory");
        }
    }

    private void HandlerSlot(SlotUI source, SlotUI target)
    {
        int idSource = source.ID;
        int idtarget = target.ID;

        if (idSource != idtarget)
        {
            if (!_model.CombileItem(idSource, idtarget))
            {
                _model.Swap(idSource, idtarget);
                Debug.Log("Swap item");
            }

        }
    }
}
