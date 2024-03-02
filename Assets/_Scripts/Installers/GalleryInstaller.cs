using _Scripts.Controllers;
using _Scripts.Factories;
using _Scripts.ScriptableObjects;
using _Scripts.Views;
using Models;
using UnityEngine;
using Zenject;

namespace _Scripts.Installers
{
    public class GalleryInstaller : MonoInstaller
    {
        [SerializeField] private GalleryItemsDB _itemsDB;
        [SerializeField] private GalleryItemView _itemViewPrefab;
        [SerializeField] private GalleryView _galleryView;

        public override void InstallBindings()
        {
            Container.Bind<GalleryItemsDB>().FromInstance(_itemsDB).AsSingle();
            Container.Bind<GalleryItemView>().FromComponentInNewPrefab(_itemViewPrefab).AsTransient();
            Container.Bind<GalleryView>().FromInstance(_galleryView).AsSingle();
            Container.BindFactory<Transform, GalleryItemView, GalleryItemView.ItemFactory>();
            Container.BindFactory<GalleryItemModel, Transform, GalleryItemController, GalleryItemsSpawner>();
            
            Container.Bind<GalleryModel>().AsSingle().NonLazy(); 
            Container.Bind<GalleryController>().AsSingle().NonLazy(); 
        }
    }
}