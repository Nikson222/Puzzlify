using UnityEngine;
using UnityEngine.UI;

namespace _Scripts.Views
{
    public class PlayerView : MonoBehaviour
    {
        [SerializeField] private Text _coinsValue;
        
        public void SetCoinsValue(int coinsValue) => _coinsValue.text = coinsValue.ToString();
    }
}