using UnityEngine;
using DG.Tweening;

public class TestOfPushToObjects : MonoBehaviour
{
    public bool puzzleFinished;
    [SerializeField] Transform car1, car2;

    [SerializeField] Vector3 position1, position2;

    public void StartTest()
    {
        car1.DOMove(new Vector3(car1.position.x, car1.position.y, car1.position.z+27),1);
        car2.DOMove(new Vector3(car2.position.x, car2.position.y, car2.position.z + 27), 2).OnComplete(()=> puzzleFinished = true);
    }
}
