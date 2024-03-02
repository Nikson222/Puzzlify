using System.Collections.Generic;
using _Scripts.Controllers;
using _Scripts.Factories;
using _Scripts.ScriptableObjects;
using _Scripts.Signals;
using _Scripts.Views;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Models
{
    public sealed class GalleryModel
    {
        private readonly SignalBus _signalBus;
        
        private readonly GalleryItemsDB _itemsDB;
        private readonly GalleryItemsSpawner _itemsSpawner;
        private List<GalleryItemController> _items = new List<GalleryItemController>();

        public GalleryModel(GalleryItemsDB itemsDB, GalleryItemsSpawner itemsSpawner, GalleryView galleryView, SignalBus signalBus)
        {
            _itemsDB = itemsDB;
            _itemsSpawner = itemsSpawner;
            _signalBus = signalBus;
            
            foreach (var item in _itemsDB.Items)
            {
                GalleryItemModel itemModel = new GalleryItemModel(item.Image, item.PuzzleCost, item.IsUnlocked(), item.Id);
                var controller = _itemsSpawner.Create(itemModel, galleryView.GalleryItemsParent);
                AddItem(controller);
            }
        }

        private void AddItem(GalleryItemController item)
        {
            _items.Add(item);
        }

        public bool RequestUnlock(int ID)
        {
            _items[ID].HandleBuyClick();
            
            return _items[ID].IsUnlocked;
        }
    }
}
