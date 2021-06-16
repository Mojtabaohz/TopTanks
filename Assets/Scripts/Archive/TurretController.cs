using UnityEngine;

public class TurretController : MonoBehaviour
{
    [SerializeField] private TurretAim TurretAim = null;

    public Transform TargetPoint = null;

    private bool isIdle = false;

    private void Awake()
    {
        if (TurretAim == null)
            Debug.LogError(name + ": TurretController not assigned a TurretAim!");
    }

    private void Update()
    {
        if (!TurretAim)
            return;

        if (!TargetPoint)
            TurretAim.isIdle = TargetPoint == null;
        else
            TurretAim.aimPosition = TargetPoint.position;

        if (Input.GetMouseButtonDown(0))
            TurretAim.isIdle = !TurretAim.isIdle;
    }
}