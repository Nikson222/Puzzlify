using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GetPuzzlePanelView : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private Transform _panelTransform;
    
    [SerializeField] private Button _getPuzzleButton;

    [SerializeField] private Image _puzzleImage;

    [SerializeField] private Text _puzzleCostText;

    private string _puzzleCostTextTemplate;
    public Transform PanelTransform => _panelTransform;
    public Button GetPuzzleButton => _getPuzzleButton;

    
    public event Action OnCloseClick;

    private void Awake()
    {
        _puzzleCostTextTemplate = _puzzleCostText.text;
    }

    public void SetStyle(Sprite puzzlePreviewSprite, int puzzleCost)
    {
        _puzzleImage.sprite = puzzlePreviewSprite;
        _puzzleCostText.text = string.Format(_puzzleCostTextTemplate, puzzleCost);
        
        _getPuzzleButton.onClick.RemoveAllListeners();
        _getPuzzleButton.interactable = true;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        OnCloseClick?.Invoke();
    }
}
