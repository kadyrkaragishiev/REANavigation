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
    public void OnViewTap()
    {
        if (IsHide)
        {
            _SearchPanel.rectTransform.DOMoveY(0, 1f).SetEase(_showEase);
            IsHide = false;
        }
        else
        {
            DOTween.To(() => _SearchPanel.rectTransform.anchoredPosition, x => _SearchPanel.rectTransform.anchoredPosition= x, new Vector2(0,-3600f), 1).SetEase(_hideEase);
            IsHide = true;
        }
    }
    public void SetStartPoint()
    {
        _createPath.transform.position = _createPath._setPoint;
    }
    public void SetEndPoint()
    {
        _createPath._endPoint._pointPosition = _createPath._setPoint;
        _createPath.SetPath();
    }
    public void OpenSession(){
    }
}
