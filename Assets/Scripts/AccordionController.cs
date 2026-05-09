using UnityEngine;

public class AccordionController : MonoBehaviour
{
    [Header("Glissez ici les ContentArea de vos sections")]
    public GameObject[] sectionContents;

    // Fonction appelée quand on clique sur le bouton d'une section
    public void ToggleSection(int sectionIndex)
    {
        for (int i = 0; i < sectionContents.Length; i++)
        {
            if (i == sectionIndex)
            {
                // Si c'est la section cliquée, on inverse son état (ouvert/fermé)
                bool isCurrentlyActive = sectionContents[i].activeSelf;
                sectionContents[i].SetActive(!isCurrentlyActive);
            }
            else
            {
                // MODE EXCLUSIF : On force la fermeture de toutes les autres sections
                sectionContents[i].SetActive(false);
            }
        }
    }
}