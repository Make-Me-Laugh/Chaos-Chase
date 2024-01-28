using UnityEngine;

public class GlobalSettings : Singleton<GlobalSettings>
{
    [Header("Timer")]
    [SerializeField] private float m_StartTime = 180f; // in seconds
    public static float StartTime => Instance.m_StartTime;
    [Header("Health values")]
    [SerializeField] private int m_PlayerHealthValue = 10;
    public static int PlayerHealthValue => Instance.m_PlayerHealthValue;

    [Header("Player values")]
    [SerializeField] private float m_PlayerReloadTime = 0.5f;
    public static float PlayerReloadTime => Instance.m_PlayerReloadTime;
    [SerializeField] private float m_PlayerInvulTime = 0.5f;
    public static float PlayerInvulTime => Instance.m_PlayerInvulTime;

    [Header("Enemy values")]
    [SerializeField] private float m_EnemyReloadTime = 2f;
    public static float EnemyReloadTime => Instance.m_EnemyReloadTime;
}