using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class HpBarBehaviour : MonoBehaviour
{
    public enum HpBarMode
    {
        Scale,
        FixedLength,
    }

    public HpBarMode mode;

    public float duration = 0.6f;
    public RectTransform bar;
    public RectTransform bar_shadow;

    public CanvasGroup cg;
    public bool hideIfFull;
    public float powerScaleValue = 1;
    public float length;
    public float delay;

    Image _bar_img;
    Image _bar_shadow_img;

    private void Awake()
    {
        _bar_img = bar.GetComponent<Image>();
        if (bar_shadow != null)
            _bar_shadow_img = bar_shadow.GetComponent<Image>();
    }

    public void Hide() { cg.alpha = 0; }

    public void Show() { cg.alpha = 1; }

    public void Set(float percentage, bool instant = false)
    {
        if (float.IsNaN(percentage)) percentage = 0;
        var endValue = Mathf.Max(0f, Mathf.Min(percentage, 1f));
        if (powerScaleValue != 1)
            endValue = Mathf.Pow(percentage, powerScaleValue);
        if (float.IsNaN(endValue)) endValue = 0;
        var barSize = new Vector2(length * endValue, bar.sizeDelta.y);
        if (bar_shadow != null)
        {
            if (!instant && duration > 0)
            {
                switch (mode)
                {
                    case HpBarMode.FixedLength:
                        bar_shadow.DOKill();
                        bar_shadow.DOSizeDelta(barSize, duration).SetEase(Ease.OutCubic).SetDelay(delay);
                        break;
                    case HpBarMode.Scale:
                        _bar_shadow_img.DOKill();
                        _bar_shadow_img.DOFillAmount(endValue, duration).SetEase(Ease.OutCubic).SetDelay(delay);
                        break;
                }

            }
            else
            {
                switch (mode)
                {
                    case HpBarMode.FixedLength:
                        bar_shadow.DOKill();
                        bar_shadow.sizeDelta = barSize;
                        break;
                    case HpBarMode.Scale:
                        _bar_shadow_img.DOKill();
                        _bar_shadow_img.fillAmount = endValue;
                        break;
                }
            }
        }

        switch (mode)
        {
            case HpBarMode.FixedLength:
                bar.sizeDelta = barSize;
                break;
            case HpBarMode.Scale:
                _bar_img.fillAmount = endValue;
                break;
        }

        if (percentage == 1 && hideIfFull)
        {
            Hide();
            return;
        }

        Show();
    }
}