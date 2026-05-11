using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Linq;

public class StatsTabController : MonoBehaviour
{
    [Header("Stat Cards")]
    public TextMeshProUGUI activeValue;
    public TextMeshProUGUI doneValue;
    public TextMeshProUGUI completionValue;

    [Header("Bar Chart")]
    public RectTransform barToDo;
    public RectTransform barInProgress;
    public RectTransform barDone;

    public float maxBarHeight = 120f;

    void Start()
    {
        RefreshStats();
    }

    void RefreshStats()
    {
        int total      = MockData.Tasks.Count;
        int todo       = MockData.Tasks.Count(t => t.Status == Status.ToDo);
        int inProgress = MockData.Tasks.Count(t => t.Status == Status.InProgress);
        int done       = MockData.Tasks.Count(t => t.Status == Status.Done);
        int active     = todo + inProgress;

        float completion = total > 0 ? (done / (float)total) * 100f : 0f;

        // Chiffres
        activeValue.text     = active.ToString();
        doneValue.text       = done.ToString();
        completionValue.text = Mathf.RoundToInt(completion) + "%";

        // Barres
        float max = Mathf.Max(todo, inProgress, done, 1);
        SetBarHeight(barToDo,       todo       / max);
        SetBarHeight(barInProgress, inProgress / max);
        SetBarHeight(barDone,       done       / max);
    }

    void SetBarHeight(RectTransform bar, float ratio)
{
    bar.sizeDelta = new Vector2(bar.sizeDelta.x, ratio * maxBarHeight);
}
}