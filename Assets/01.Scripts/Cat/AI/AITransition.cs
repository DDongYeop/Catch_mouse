using UnityEngine;

public class AITransition : MonoBehaviour
{
    [Header("AI")]
    public AIState PositiveState; //참이면 이동
    public AIState NegativeState; //하나라도 거짓이면 이동
}
