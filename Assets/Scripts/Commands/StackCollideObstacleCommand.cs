using System.Collections.Generic;
using DG.Tweening;
using Managers;
using Signals;
using UnityEngine;

namespace Commands
{
    public class StackCollideObstacleCommand : MonoBehaviour
    {
        public void StackCollideWithObstacle(GameObject gO, Vector3 obsPos, List<GameObject> stackMembers,GameObject collectables)
        {
            var siblingIndex = gO.transform.GetSiblingIndex();
            Destroy(gO);
            stackMembers.Remove(gO);
            stackMembers.TrimExcess();
            if (stackMembers.Count == 0)
            {
                return;
            }

            for (int i = 1; i <= stackMembers.Count - 1; i++)
            {
                stackMembers[i].transform.localPosition =
                    stackMembers[i - 1].transform.localPosition + Vector3.forward;
            }

            for (int i = siblingIndex; i < stackMembers.Count - 1; i++)
            {
                int value = (int)stackMembers[i].GetComponent<CollectableManager>().Data;
                ScoreSignals.Instance.onDecreasePlayerScore(value);
                stackMembers[i].transform.GetChild(1).tag = "Uncollected";
                var newPos = new Vector3(Random.Range(-5f, 5f), 0.5f, obsPos.z + Random.Range(5f, 20f));
                stackMembers[i].transform.GetChild(1).GetComponent<Rigidbody>().isKinematic = true;
                stackMembers[i].transform.SetParent(collectables.transform);
                stackMembers[i].transform.DOJump(newPos, 2f, 1, .2f, false);
                stackMembers.RemoveAt(i);
                stackMembers.TrimExcess();
            }
        }
    }
}