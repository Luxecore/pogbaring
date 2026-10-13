using UnityEngine;

[CreateAssetMenu(fileName = "ProjectileData", menuName = "Scriptable Objects/ProjectileData")]
public class ProjectileData : ScriptableObject
{
    public float damage;

    public float projectileSpeed;

    public int projectileRate;

    public int projectileLifetime;

    public int range;

    
}
