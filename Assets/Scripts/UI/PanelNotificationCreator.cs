using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
using UnityEngine.EventSystems;

public class PanelNotificationCreator : MonoBehaviour
{
    [SerializeField] private GameObject _panelPrefab;
    [SerializeField] private GameObject _parent;

    [SerializeField] private TextMeshProUGUI _titleText;

    [SerializeField] private TextMeshProUGUI _contentText;
    // Update is called once per frame
    private bool isActive;
    private GameObject panelGO;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) && !isActive)
        {
            var title = "Placeholder";
            var content =
                "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.";

            CreatePanel(title, content);
        }
        else if(Input.GetKeyDown(KeyCode.P) && isActive)
        {
            DestroyPanel();
        }

    }

    private void DestroyPanel()
    {
        
        panelGO.transform.DOLocalMove(Vector3.left * 2000, 1).OnComplete(() =>
        {
            Destroy(panelGO);
            isActive = false;
        });
        
    }

    private void CreatePanel(string title, string content)
    {
        isActive = true;
        panelGO = Instantiate(_panelPrefab, _parent.transform);
        panelGO.transform.localPosition = Vector3.left * 2000;
        //_titleText.text = title;
        //_contentText.text = content;
        panelGO.transform.DOLocalMove(Vector3.zero, 1);
       
    }
    
}
