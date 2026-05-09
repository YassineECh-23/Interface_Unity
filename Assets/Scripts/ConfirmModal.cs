using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class ConfirmModal : MonoBehaviour
{
    [Header("Références UI")]
    [SerializeField] private TextMeshProUGUI titleText;
    [SerializeField] private TextMeshProUGUI descriptionText;

    [Header("Événements")]
    public UnityEvent OnConfirm;
    public UnityEvent OnCancel;

    // Ouvre le modal avec un titre et une description
    public void Show(string title, string description)
    {
        titleText.text = title;
        descriptionText.text = description;
        gameObject.SetActive(true);
    }

    // Ferme le modal sans déclencher d'événement
    public void Hide()
    {
        gameObject.SetActive(false);
    }

    // Appelé par BtnConfirm (OnClick)
    public void OnClickConfirm()
    {
        Hide();
        OnConfirm?.Invoke();
    }

    // Appelé par BtnCancel (OnClick)
    public void OnClickCancel()
    {
        Hide();
        OnCancel?.Invoke();
    }
}