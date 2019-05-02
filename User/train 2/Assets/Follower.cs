using UnityEngine;

namespace PathCreation.Examples
{
    // Moves along a path at constant speed.
    // Depending on the end of path instruction, will either loop, reverse, or stop at the end of the path.
    public class Follower : MonoBehaviour
    {
        public PathCreator pathCreator;
        public float speed = 5;
        float distanceTravelled;

        void Update()
        {
            
                distanceTravelled += speed * Time.deltaTime;
                transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled);
            
        }
    }
}