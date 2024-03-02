using System;
using _Scripts.ScriptableObjects;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Zenject;

namespace _Scripts.Views
{
    public class GalleryItemView : MonoBehaviour, IDragHandler, IPointerClickHandler
    {
        [Header("Puzzle Image")] [SerializeField]
        private Image _puzzlePreviewImage;

        [Header("Status Images")] 
        [SerializeField] private Image _freeIconImage; 
        [SerializeField] private Image _costImage;

        [SerializeField] private Text _costText;

        public event Action OnClick;
        
        
        public void InitSetItemStyle(Sprite puzzlePreviewSprite, bool isUnlocked, int puzzleCost)
        {
            UpdateIsUnlocked(isUnlocked);
            
            _costText.text = puzzleCost.ToString();

            _puzzlePreviewImage.sprite = puzzlePreviewSprite;
        }

        public void UpdateIsUnlocked(bool isUnlocked)
        {
            _freeIconImage.gameObject.SetActive(isUnlocked);
            _costImage.gameObject.SetActive(!isUnlocked);
        }
        
        
        public class ItemFactory : PlaceholderFactory<Transform, GalleryItemView>
        {
            private readonly DiContainer _container;

            public ItemFactory(DiContainer container)
            {
                _container = container;
            }

            public override GalleryItemView Create(Transform param)
            {
                var view = _container.Resolve<GalleryItemView>();

                view.transform.parent = param;

                view.transform.localScale = Vector3.one;
                view.transform.localPosition = new Vector3(view.transform.localPosition.x, view.transform.localPosition.y, 0);
                return view;
            }
        }

        public void OnDrag(PointerEventData eventData)
        {
            GetComponent<RectTransform>().anchoredPosition += eventData.delta / GetComponentInParent<Canvas>().scaleFactor;
            GetComponent<Image>().raycastTarget = false;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            OnClick?.Invoke();
        }
    }
}