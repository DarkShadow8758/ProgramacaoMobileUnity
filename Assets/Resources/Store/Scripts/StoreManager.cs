using System;
using UnityEngine;

public class StoreManager : MonoBehaviour
{
    public static event Action<StoreItemDto> OnPurchasedSucceded;
    public static event Action<StoreItemDto, string> OnPurchasedFailed;

    [SerializeField] private WalletService wallet;
    [SerializeField] private StoreDatabase db;

    public void TryPurchase(StoreItemDto item)
    {
        if (item == null)
        {
            OnPurchasedFailed?.Invoke(item, "Item inválido.");
            return;
        }
        if (item.purchased)
        {
            OnPurchasedFailed?.Invoke(item, "Item já comprado.");
            return;
        }
        if (!wallet.TryDebit(item.cost))
        {
            OnPurchasedFailed?.Invoke(item, "Falha ao debitar moedas.");
            return;
        }
        if (!wallet.CanAfford(item.cost))
        {
            OnPurchasedFailed?.Invoke(item, "Moedas Insuficientes.");
            return;
        }

        db.SavePurchased(item.id);
        item.purchased = true;

        //aqui iria o script de instancia o obj no jogo

        OnPurchasedSucceded?.Invoke(item);
    }
}
