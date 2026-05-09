using UnityEngine;
using TMPro;

public class EquipeTabController : MonoBehaviour
{
    public Transform membersContainer;
    public GameObject memberCardPrefab;
    public TextMeshProUGUI headerLabel;

    void Start()
    {
        RefreshTeam();
    }

    void RefreshTeam()
    {
        foreach (Transform child in membersContainer)
            Destroy(child.gameObject);

        foreach (var member in MockData.Team)
        {
            var card = Instantiate(memberCardPrefab, membersContainer);
            card.GetComponent<MemberCardController>().Setup(member);
        }

        headerLabel.text = $"Équipe · {MockData.Team.Count} membres";
    }
}