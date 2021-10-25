using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Progress Tracker", menuName = "ScriptableObjects/Progress Tracker")]
public class ProgressTracker : ScriptableObject
{
    public int levelsUnlocked;

    public int enemiesKilled;
    public int goldEarned;
    public int wavesSurvived;
    public int turretsBought;

    public int totalEnemiesKilled;
    public int totalGoldEarned;
    public int totalWavesSurvived;
    public int totalTurretsBought;
}
