using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class UIController : MonoBehaviour
{
    public Image _SearchPanel;
    private bool IsHide = true;
    public Ease _hideEase;
    public Ease _showEase;
    public ARController _ar;
    public CreatePath _createPath;

    void Start()
    {
        ARInterface.onStartPointChange += SetStartPoint;
        ARInterface.onEndPointChange += SetEndPoint;
    }

    public void OnViewTap()
    {
        if (IsHide)
        {
            _SearchPanel.rectTransform.DOMoveY(0, 1f).SetEase(_showEase);
            IsHide = false;
        }
        else
        {
            DOTween.To(() => _SearchPanel.rectTransform.anchoredPosition,
                x => _SearchPanel.rectTransform.anchoredPosition = x, new Vector2(0, -2200f), 1).SetEase(_hideEase);
            IsHide = true;
        }
    }

    public void SetStartPoint()
    {
        ARInterface.StartPointChange(_createPath._setPoint);
        UIDebug.Log("startPointUI");
    }
    public void SetStartPoint(Vector3 pos)
    {
        _createPath.transform.position = pos;
    }
    public void SetEndPoint()
    {
        ARInterface.EndPointChange(_createPath._setPoint);
        _createPath._endPoint._pointPosition = _createPath._setPoint;
    }
    public void SetEndPoint(Vector3 pos)
    {
        _createPath._endPoint._pointPosition = pos;
    }
    public void OpenSession(){
    }
}
