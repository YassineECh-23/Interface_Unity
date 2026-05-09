using UnityEngine;

public class AccordionController : MonoBehaviour
{
    [Header("Glissez ici les ContentArea de vos sections")]
    public GameObject[] sectionContents;

    // Cette fonction s'exécute automatiquement au lancement du jeu
    void Start()
    {
        // On initialise l'accordéon pour que seule la 1ère section soit ouverte
        if (sectionContents != null && sectionContents.Length > 0)
        {
            for (int i = 0; i < sectionContents.Length; i++)
            {
                // Active la section 0 (À faire), désactive les autres
                sectionContents[i].SetActive(i == 0);
            }
        }
    }

    // Fonction appelée quand on clique sur le bouton d'une section
    public void ToggleSection(int sectionIndex)
    {
        for (int i = 0; i < sectionContents.Length; i++)
        {
            if (i == sectionIndex)
            {
                // On inverse l'état de la section cliquée (Toggle)
                bool isCurrentlyActive = sectionContents[i].activeSelf;
                sectionContents[i].SetActive(!isCurrentlyActive);
            }
            else
            {
                // MODE EXCLUSIF : On ferme obligatoirement toutes les autres
                sectionContents[i].SetActive(false);
            }
        }
    }
}