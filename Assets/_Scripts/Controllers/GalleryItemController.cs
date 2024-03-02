using _Scripts.Signals;
using _Scripts.Views;
using Models;
using Zenject;

namespace _Scripts.Controllers
{
    public class GalleryItemController
    {
        private readonly SignalBus _signalBus;
        
        private readonly GalleryItemView _view;
        private readonly GalleryItemModel _model;
        
        public bool IsUnlocked => _model.IsUnlocked;

        public GalleryItemController(GalleryItemView view, GalleryItemModel model, SignalBus signalBus)
        {
            _view = view;
            _model = model;
            _signalBus = signalBus;

            _view.OnClick += HandleItemClick;
            
            _model.OnUnlockingUpdated += _view.UpdateIsUnlocked;
        }

        private void HandleItemClick()
        {
            _signalBus.Fire(new ClickItemGallerySignal(_model));
        }
        
        public void HandleBuyClick()
        {
            _signalBus.Subscribe<BalanceSpendResponseSignal>(HandleResponseBuy);
            _signalBus.Fire(new BalanceSpendRequestSignal(_model.PuzzleCost));
        }

        private void HandleResponseBuy(BalanceSpendResponseSignal signal)
        {
            _signalBus.Unsubscribe<BalanceSpendResponseSignal>(HandleResponseBuy);
            
            if (signal.Success)
                _model.IsUnlocked = true;
        }
    }
}