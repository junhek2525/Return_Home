using UnityEngine;

[CreateAssetMenu(fileName = "enemy_stat", menuName = "Scriptable Objects/enemy_stat")]
public class enemy_stat : ScriptableObject
{
    public float Health = 100f;
    public float attack = 10f;
    public float defense = 10f;
    public float speed = 1f;
}
