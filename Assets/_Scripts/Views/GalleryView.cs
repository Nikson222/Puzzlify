using System;
using DG.Tweening;
using Models;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace _Scripts.Views
{
    public class GalleryView : MonoBehaviour
    {
        [SerializeField] private Transform _galleryItemsParent;

        [SerializeField] private GetPuzzlePanelView _itemGetPuzzlePanel;
        [SerializeField] private float _durationAnimation;

        private Vector2 _startPosition;
        
        public GetPuzzlePanelView ItemGetPuzzlePanelView => _itemGetPuzzlePanel;
        public Transform GalleryItemsParent => _galleryItemsParent;

        private void Start()
        {
            _startPosition = _itemGetPuzzlePanel.PanelTransform.localPosition;
            _itemGetPuzzlePanel.PanelTransform.DOLocalMoveY(Screen.height * -1f, 0f);
            _itemGetPuzzlePanel.OnCloseClick += HideGetPuzzlePanel;
        }

        public void ShowGetPuzzlePanel()
        {
            _itemGetPuzzlePanel.gameObject.SetActive(true);
            _itemGetPuzzlePanel.PanelTransform.DOLocalMoveY(Screen.height * -1f, 0f);
            _itemGetPuzzlePanel.PanelTransform.transform.DOLocalMoveY(_startPosition.y, _durationAnimation);
        }
        
        
        public void HideGetPuzzlePanel()
        {
            _itemGetPuzzlePanel.PanelTransform.DOLocalMoveY(Screen.height * -1f, _durationAnimation)
                .OnComplete(() => _itemGetPuzzlePanel.gameObject.SetActive(false));
        }
    }
}