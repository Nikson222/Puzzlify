using System;
using UnityEngine;

namespace Models
{
    public sealed class GalleryItemModel
    {
        private Sprite _puzzleSprite;
        private int _puzzleCost;
        private bool _isUnlocked;

        private readonly int _id;
        
        public event Action<bool> OnUnlockingUpdated;
        
        public Sprite PuzzleSprite => _puzzleSprite;
        public int PuzzleCost => _puzzleCost;
        
        
        public bool IsUnlocked
        {
            get => _isUnlocked;
            set
            {
                _isUnlocked = value;
                OnUnlockingUpdated?.Invoke(value);
            }
        }
        
        public int Id => _id;
        
        public GalleryItemModel(Sprite puzzleSprite, int puzzleCost, bool isUnlocked, int id)
        {
            _puzzleSprite = puzzleSprite;
            _puzzleCost = puzzleCost;
            _isUnlocked = isUnlocked;
            
            _id = id;
        }
    }
}