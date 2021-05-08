using System;
using Scripts;
using UnityEngine;

public sealed class EventService : Service
{
    public event Action<Vector3, int> OnApplyDamage;
    public event Action<int> OnChangeScore;

    public EventService()
    {
        OnApplyDamage += delegate { };
        OnChangeScore += delegate { };
    }

    public void ApplyDamage(Vector3 pos, int score) => OnApplyDamage?.Invoke(pos, score);
    public void ChangeScore(int score) => OnChangeScore?.Invoke(score);
}