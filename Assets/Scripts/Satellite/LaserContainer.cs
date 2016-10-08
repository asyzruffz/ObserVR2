using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LaserContainer : MonoBehaviour
{
    public GameObject laserSource;

    private List<LaserUnit> lasers = new List<LaserUnit>();

    void Start()
    {

    }

    void Update()
    {
        // Update lasers
        foreach (var laser in lasers)
        {
            if (!laser.Update())
            {
                lasers.Remove(laser);
                break;
            }
        }

        // Stop shooting if not connected
        if(!GetComponent<Selectable>().connected)
        {
            StopShooting();
        }
    }

    public void StartShooting(GameObject target)
    {
        GameObject laser = (GameObject)Instantiate(laserSource, transform.position, Quaternion.identity);
        laser.transform.parent = transform;
        laser.name = "Laser";

        lasers.Add(new LaserUnit(laser, target));
    }

    public bool IsShooting(GameObject target)
    {
        foreach (var laser in lasers)
        {
            if (laser.target == target)
            {
                return true;
            }
        }
        return false;
    }

    void StopShooting()
    {
        foreach(var laser in lasers)
        {
            laser.Destroy();
        }
        lasers.Clear();
    }

    class LaserUnit
    {
        public GameObject laser;
        public GameObject target;

        public LaserUnit(GameObject _laser, GameObject _target)
        {
            laser = _laser;
            target = _target;
        }

        public bool Update()
        {
            // No more meteor to shoot
            if (target == null)
            {
                Destroy();
                return false;
            }

            // Update laser direction
            Vector3 towards = (target.transform.position - laser.transform.position).normalized;
            Vector3 laserForward = laser.transform.forward;

            Quaternion targetRotation = Quaternion.FromToRotation(laserForward, towards) * laser.transform.rotation;
            laser.transform.rotation = Quaternion.Slerp(laser.transform.rotation, targetRotation, 50 * Time.deltaTime);

            return true;
        }

        public void Destroy()
        {
            GameObject.Destroy(laser);
        }
    }
}
