using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace _Scripts
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField] private GameObject _mainMenuPanel;
        [SerializeField] private GameObject _loadingPanel;
        
        [SerializeField] private Button _startGameButton;
        [SerializeField] private Button _musicButton;
        
        [SerializeField] private Image _loadingBarFillImage;
        [SerializeField] private Image _fadeImage;
        
        [SerializeField] private Animator _fadeAnimator;

        [SerializeField] private float _loadingTime = 1f;
        private void Start()
        {
            _fadeImage.gameObject.SetActive(false);
            _startGameButton.onClick.AddListener(FillLoadingBar);
        }
        
        private async void LoadGameScene()
        {
            _fadeImage.gameObject.SetActive(true);
            _fadeAnimator.SetTrigger("IsFadeStart");

            await System.Threading.Tasks.Task.Delay(1000);
            var t = SceneManager.LoadSceneAsync(sceneBuildIndex: 1);

        }

        private IEnumerator LoadingCoroutine()
        {
            float timer = 0f;

            while (timer < _loadingTime)
            {
                _loadingBarFillImage.fillAmount = timer / _loadingTime;
                timer += Time.deltaTime;
                yield return null;
            }
            
            LoadGameScene();
        }

        private void FillLoadingBar()
        {
            _loadingPanel.SetActive(true);
            _mainMenuPanel.SetActive(false);
            
            _loadingBarFillImage.fillAmount = 0;
            
            StartCoroutine(LoadingCoroutine());
        }
    }
}
