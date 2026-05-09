using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MemberCardController : MonoBehaviour
{
    public Image avatarBackground;
    public TextMeshProUGUI initialeText;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI roleText;
    public TextMeshProUGUI tasksText;

    public void Setup(TeamMember member)
    {
        initialeText.text = member.Initiale;
        nameText.text     = member.Name;
        roleText.text     = member.Role;
        tasksText.text    = $"{member.ActiveTasks} tâche(s) active(s)";

        if (ColorUtility.TryParseHtmlString(member.AvatarColor, out Color c))
            avatarBackground.color = c;
    }
}