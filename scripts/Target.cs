using UnityEngine.UI;
using DG.Tweening;

public class Target : MonoBehaviour
{
    Transform player;

    [SerializeField] Image fill;
    [SerializeField] float chargeTime;
    float t = 0;
    bool charging, selected, onPosition;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        DoTween.Init(false, true, LogBehaviour.Default);

        if(Vector3.Distance(transform.position, player.position) < 0.1f)
        {
            selected(true);
            onPosition = true; 
        }
    }
}