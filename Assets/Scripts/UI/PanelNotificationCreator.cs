using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
using UnityEditor.VersionControl;
using UnityEngine.EventSystems;

public class PanelNotificationCreator : MonoBehaviour
{
    [SerializeField] private GameObject _panelPrefab;
    [SerializeField] private GameObject _parent;

    [SerializeField] private TextMeshProUGUI _titleText;

    [SerializeField] private TextMeshProUGUI _contentText;

     private UIEventController _uiEventController;
    // Update is called once per frame
    private bool isActive;
    private GameObject panelGO;
    
    #region Animation

    private const float SHOW_PANEL_ANIMATION_DURATION = 1;
    private const float HIDE_PANEL_ANIMATION_DURATION = 1;
    private readonly Vector3 PANEL_FINAL_POSTION_WITH_OFFSET = Vector3.left * 2000;

    #endregion

    private void Start()
    {

        _uiEventController.OnShowPanel += CreatePanel;
        _uiEventController.OnHidePanel += DestroyPanel;
    }

    private void OnDestroy()
    {
        _uiEventController.OnShowPanel -= CreatePanel;
        _uiEventController.OnHidePanel -= DestroyPanel;
    }

    private void DestroyPanel()
    {
        
        panelGO.transform.DOLocalMove(PANEL_FINAL_POSTION_WITH_OFFSET, SHOW_PANEL_ANIMATION_DURATION).OnComplete(() =>
        {
            Destroy(panelGO);
            isActive = false;
        });
        
    }

    private void CreatePanel(string title, string content)
    {
        isActive = true;
        panelGO = Instantiate(_panelPrefab, _parent.transform);
        panelGO.transform.localPosition = PANEL_FINAL_POSTION_WITH_OFFSET;
        _titleText.text = title;
        _contentText.text = content;
        panelGO.transform.DOLocalMove(Vector3.zero, HIDE_PANEL_ANIMATION_DURATION);
       
    }
    
}