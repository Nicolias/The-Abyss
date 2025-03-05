using System.Collections.Generic;
using Scripts.Menu.ShopSystem.Items;
using UnityEngine;

namespace Scripts.Menu.ShopSystem
{
    public class ItemsViewFactory : MonoBehaviour
    {
        [SerializeField] private ItemView _template;
        [SerializeField] private Transform _container;

        public void Initialize(IEnumerable<ItemModel> itemModels, BuyPanel buyPanel)
        {
            foreach (ItemModel item in itemModels)
            {
                ItemView itemView = Instantiate(_template, _container);

                itemView.Initialize(buyPanel, item);
            }
        }
    }
}