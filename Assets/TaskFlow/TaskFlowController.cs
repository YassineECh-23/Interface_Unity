using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;
using System.Linq;

public class TaskFlowController : MonoBehaviour
{
    [Header("Widgets")]
    public SearchableDropdown projectFilter;
    public AccordionController accordion;
    public ConfirmModal confirmModal;

    [Header("Sections de l'Accordion")]
    public Transform todoContent;
    public Transform inProgressContent;
    public Transform doneContent;

    [Header("Headers de l'Accordion")]
    public TextMeshProUGUI todoHeader;
    public TextMeshProUGUI inProgressHeader;
    public TextMeshProUGUI doneHeader;

    [Header("Prefab")]
    public GameObject taskItemPrefab;

    private string currentProject = "Tous les projets";

    void Start()
    {
        projectFilter.SetItems(MockData.Projects);
        projectFilter.OnItemSelected.AddListener(OnProjectSelected);
        RefreshTasks("Tous les projets");
    }

    void OnProjectSelected(string project)
    {
        currentProject = project;
        RefreshTasks(project);
    }

    void RefreshTasks(string project)
    {
        // Vider les 3 sections
        foreach (Transform child in todoContent) Destroy(child.gameObject);
        foreach (Transform child in inProgressContent) Destroy(child.gameObject);
        foreach (Transform child in doneContent) Destroy(child.gameObject);

        // Filtrer
        var filtered = project == "Tous les projets"
            ? MockData.Tasks
            : MockData.Tasks.Where(t => t.Project == project).ToList();

        // Distribuer dans les sections
        foreach (var task in filtered)
        {
            Transform parent = task.Status == Status.ToDo ? todoContent
                             : task.Status == Status.InProgress ? inProgressContent
                             : doneContent;

            GameObject go = Instantiate(taskItemPrefab, parent);
            var tmp = go.GetComponentInChildren<TextMeshProUGUI>();
            if (tmp != null)
                tmp.text = $"{task.Title}  [{task.Assignee}]";
        }

        // Mettre à jour les compteurs
        int todoCount = filtered.Count(t => t.Status == Status.ToDo);
        int inProgressCount = filtered.Count(t => t.Status == Status.InProgress);
        int doneCount = filtered.Count(t => t.Status == Status.Done);

        if (todoHeader) todoHeader.text = $"À faire ({todoCount})";
        if (inProgressHeader) inProgressHeader.text = $"En cours ({inProgressCount})";
        if (doneHeader) doneHeader.text = $"Terminé ({doneCount})";
    }

    public void OnViderClicked()
    {
        confirmModal.Show("Vider le projet", $"Supprimer toutes les tâches de \"{currentProject}\" ?");
        confirmModal.OnConfirm.AddListener(ViderProjet);
    }

    void ViderProjet()
    {
        if (currentProject == "Tous les projets")
            MockData.Tasks.Clear();
        else
            MockData.Tasks.RemoveAll(t => t.Project == currentProject);

        confirmModal.OnConfirm.RemoveListener(ViderProjet);
        RefreshTasks(currentProject);
    }
}