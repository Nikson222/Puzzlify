using System;
using System.Collections.Generic;
using System.ComponentModel;
using Models;
using UnityEngine;
using UnityEngine.Serialization;

namespace _Scripts.ScriptableObjects
{
    [CreateAssetMenu(fileName = "GalleryItemsDB", menuName = "ScriptableObjects/GalleryItemsDB")]
    public class GalleryItemsDB : ScriptableObject
    {
        public List<GalleryItem> Items;

        private void OnValidate()
        {
            foreach (var item in Items)
            {
                item.Id = Items.IndexOf(item);
            }
        }
    }

    [Serializable]
    public class GalleryItem
    {
        [FormerlySerializedAs("_imageResourcePath")] [SerializeField]
        private Sprite _image;

        [SerializeField] private int _puzzleCost;
        [SerializeField] private int _id;

        public Sprite Image => _image;
        public int PuzzleCost => _puzzleCost;

        public bool IsSelected()
        {
            return PlayerPrefs.GetInt("SelectedID", 0) == _id;
        }

        public bool IsUnlocked()
        {
            return Convert.ToBoolean(PlayerPrefs.GetInt($"IsUnlocked{_id}", 0));
        }

        public int Id
        {
            get => _id;
            set => _id = value;
        }
    }
}