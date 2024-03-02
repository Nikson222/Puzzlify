using _Scripts.Views;
using Models;

namespace _Scripts.Controllers
{
    public class PlayerController
    {
        private readonly PlayerModel _model;
        private readonly PlayerView _view;

        public PlayerController(PlayerModel model, PlayerView view)
        {
            _model = model;
            _view = view;
            
            _model.OnBalanceChanged += _view.SetCoinsValue;

            _model.SendUpdateSignal();
        }
    }
}