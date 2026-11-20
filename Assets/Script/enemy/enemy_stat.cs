using UnityEngine;

[CreateAssetMenu(fileName = "enemy_stat", menuName = "Scriptable Objects/enemy_stat")]
public class enemy_stat : ScriptableObject
{
    public float Health = 100f;
    public float Attack = 10f;
    public float collisioning_delay = 3f;
    public float Attack_Speed = 1.0f;
    public float Defense = 10f;
    public float speed = 1f;

    

}
