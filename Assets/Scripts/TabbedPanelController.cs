using UnityEngine;

public class TabbedPanelController : MonoBehaviour
{
    [Header("Liste des pages (Panels)")]
    public GameObject[] pages;

    void Start()
    {
        SwitchTab(0);
    }

    public void SwitchTab(int tabIndex)
    {
        for (int i = 0; i < pages.Length; i++)
        {
            pages[i].SetActive(i == tabIndex);
        }
    }
}