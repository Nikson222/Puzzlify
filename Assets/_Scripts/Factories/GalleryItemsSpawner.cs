using _Scripts.Controllers;
using _Scripts.ScriptableObjects;
using _Scripts.Views;
using Models;
using UnityEngine;
using Zenject;

namespace _Scripts.Factories
{
    public class GalleryItemsSpawner : PlaceholderFactory<GalleryItemModel, Transform, GalleryItemController>
    {
        private readonly GalleryItemView.ItemFactory _viewItemFactory;
        
        private readonly SignalBus _signalBus;
        
        public GalleryItemsSpawner(GalleryItemView.ItemFactory itemFactory, SignalBus signalBus)
        {
            _viewItemFactory = itemFactory;
            _signalBus = signalBus;
        }
        
        public override GalleryItemController Create(GalleryItemModel model, Transform parent)
        {
            var viewGO = _viewItemFactory.Create(parent);
            
            viewGO.InitSetItemStyle(model.PuzzleSprite, model.IsUnlocked, model.PuzzleCost);
            
            var controller = new GalleryItemController(viewGO, model, _signalBus);
            return controller;
        }
    }
}