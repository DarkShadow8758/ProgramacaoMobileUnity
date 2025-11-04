using System;
using System.Collections.Generic;
using UnityEngine;

public class StoreDatabase : MonoBehaviour
{
    [SerializeField] private string jsonResourcePatch = "Store/store_items";

    private Dictionary<string, StoreItemDto> map;

    //limpa os registros para fins de teste
    [SerializeField] private bool clearOnStart = false;
    const string PurchasedKey = "STORE_PURCHASED_IDS";

    void Awake()
    {
        if (clearOnStart)
        {
            PlayerPrefs.DeleteKey(PurchasedKey);
            PlayerPrefs.Save();
        }
    }

    public IReadOnlyList<StoreItemDto> LoadAll()
    {
        TextAsset ta = Resources.Load<TextAsset>(jsonResourcePatch);
        if (ta == null)
        {
            Debug.LogError("Store JSON nn eno=cintrado");
            return new List<StoreItemDto>();
        }
        var wrapper = JsonUtility.FromJson<StoreItemsWrapper>(ta.text);

        if (wrapper?.items == null)
        {
            wrapper = new StoreItemsWrapper { items = new List<StoreItemDto>() };
        }
        //marca os itens comprados com base no player prefs7
        var purchaseCsv = PlayerPrefs.GetString(PurchasedKey, "");
        var purchasedSet = new HashSet<string>(purchaseCsv.Split(',', System.StringSplitOptions.RemoveEmptyEntries));
        foreach (var item in wrapper.items)
        {
            item.purchased = purchasedSet.Contains(item.id);
        }
        return wrapper.items;
    }

    public void SavePurchased (string id)
    {
        var purchaseCsv = PlayerPrefs.GetString(PurchasedKey, "");
        var set = new HashSet<string>(purchaseCsv.Split(',', System.StringSplitOptions.RemoveEmptyEntries));
        if (set.Add(id))
        {
            PlayerPrefs.SetString(PurchasedKey, string.Join(",", set));
            PlayerPrefs.Save();
        }
       
    }
}

