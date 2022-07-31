using UnityEngine;
using Data.ValueObject;
namespace Data.UnityObject
{
    [CreateAssetMenu(fileName = "CD_MiniGame", menuName = "ATM RUSH/CD_MiniGame", order = 0)]
    public class CD_MiniGame : ScriptableObject
    {
        public MiniGameData miniGameData;
    }
}

