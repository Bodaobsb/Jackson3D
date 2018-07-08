using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

    public static Inventory instance;
    public int space = 20;

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallBack;

    private void Awake()
    {
        instance = this;
    }

    public List<GameObject> items = new List<GameObject>();


    public bool Add(GameObject item)
    {
        if (items.Count >= space)
        {
            Debug.Log("inventorio cheio");
            return false;
        }
        items.Add(item);
        if (onItemChangedCallBack != null)
        {
            onItemChangedCallBack.Invoke();
        }
        
        return true;
    }

    public void Remove(GameObject item)
    {
        items.Remove(item);
        if (onItemChangedCallBack != null)
        {
            onItemChangedCallBack.Invoke();
        }
    }
}
