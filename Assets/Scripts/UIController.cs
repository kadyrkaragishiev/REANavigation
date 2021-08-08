using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System;
public class UIController : MonoBehaviour
{
    public Image _SearchPanel;
    private bool IsHide = true;
    public Ease _hideEase;
    public Ease _showEase;
    public CreatePath _createPath;
    

    void Start()
    {
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

    #region WorkWithPoints
    public void SetStartPoint()
    {
        _createPath.transform.position = _createPath._setPoint;
        _createPath.SetPath();

        Debug.Log("changed");
    }
    public void SetEndPoint()
    {
        _createPath._endPoint._pointPosition = _createPath._setPoint;
        _createPath.SetPath();
    }
    #endregion
}
