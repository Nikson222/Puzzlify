using _Scripts.Signals;
using _Scripts.Views;
using Models;
using Zenject;

namespace _Scripts.Controllers
{
    public class GalleryController
    {
        private readonly SignalBus _signalBus;
        
        private readonly GalleryModel _model;
        private readonly GalleryView _view;

        public GalleryController(GalleryModel model, GalleryView view, SignalBus signalBus)
        {
            _model = model;
            _view = view;
            _signalBus = signalBus;
            
            _signalBus.Subscribe<ClickItemGallerySignal>(HandleItemClick);
        }

        private void HandleItemClick(ClickItemGallerySignal signal)
        {
            if (!signal.Model.IsUnlocked)
            {
                _view.ShowGetPuzzlePanel();
                _view.ItemGetPuzzlePanelView.SetStyle(signal.Model.PuzzleSprite, signal.Model.PuzzleCost);
                
                _view.ItemGetPuzzlePanelView.GetPuzzleButton.onClick.AddListener(() => HandleBuyClick(signal.Model.Id));
            }
        }

        private void HandleBuyClick(int ID)
        {
            var isUnlocked = _model.RequestUnlock(ID);
            
            _view.ItemGetPuzzlePanelView.GetPuzzleButton.onClick.RemoveListener(() => HandleBuyClick(ID));

            if (isUnlocked)
            {
                _view.ItemGetPuzzlePanelView.GetPuzzleButton.interactable = false;
            }
        }
    }
}