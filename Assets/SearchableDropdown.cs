using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;
using System.Collections.Generic;

public class SearchableDropdown : MonoBehaviour
{
    [Header("Références UI")]
    [SerializeField] private GameObject panel;
    [SerializeField] private TMP_InputField inputField;
    [SerializeField] private Transform content;
    [SerializeField] private GameObject itemPrefab;
    [SerializeField] private TextMeshProUGUI buttonLabel;

    [Header("Données")]
    [SerializeField] private List<string> items = new List<string>();

    [Header("Événement")]
    public UnityEvent<string> OnItemSelected;

    private bool isOpen = false;
    private bool isRefreshing = false; // 🔑 verrou anti-double déclenchement

    private void Awake()
    {
        // Connexion par code = plus fiable que l'Inspector
        inputField.onValueChanged.AddListener(OnSearchChanged);
        panel.SetActive(false);
    }

    public void TogglePanel()
    {
        isOpen = !isOpen;
        panel.SetActive(isOpen);

        if (isOpen)
        {
            isRefreshing = true;          // 🔒 verrouille
            inputField.text = "";         // ne déclenche PAS RefreshList
            isRefreshing = false;         // 🔓 déverrouille

            RefreshList("");              // appel unique et propre
            inputField.ActivateInputField();
        }
    }

    public void OnSearchChanged(string search)
    {
        if (isRefreshing) return;         // 🛡️ ignore si on est en train de reset
        RefreshList(search);
    }

    private void RefreshList(string search)
    {
        foreach (Transform child in content)
            Destroy(child.gameObject);

        foreach (string item in items)
        {
            if (item.ToLower().Contains(search.ToLower()))
            {
                GameObject go = Instantiate(itemPrefab, content);
                go.GetComponentInChildren<TextMeshProUGUI>().text = item;
                string captured = item;
                go.GetComponent<Button>().onClick.AddListener(() => SelectItem(captured));
            }
        }
    }

    private void SelectItem(string item)
    {
        buttonLabel.text = item;
        panel.SetActive(false);
        isOpen = false;
        OnItemSelected?.Invoke(item);
    }

    public void SetItems(List<string> newItems)
    {
        items = newItems;
    }
}