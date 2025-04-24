using System.Collections;
using UnityEngine;

public class SpeedPowerUp : MonoBehaviour
{
    [SerializeField]
    private float FwdSpeedIncreaseAmount = 20;
    [SerializeField]
    private float _powerupduration = 3;

    [SerializeField]
    private GameObject _artToDisable = null;

    private Collider _collider;

    private void Awake()
    {
        _collider = GetComponent<Collider>();
    }


    private void OnTriggerEnter(Collider other)
    {
        Player player =
            other.GetComponent<Player>();
        if (player != null)
        {
            //powerup
            StartCoroutine(PowerUpSequence(player));
        }
    }

    public IEnumerator PowerUpSequence(Player player)
    {
        _collider.enabled = false;
        _artToDisable.SetActive(false);
        //activate
        ActivatePowerUp(player);

        yield return new WaitForSeconds(_powerupduration);

        DeactivatePowerUp(player);

        Destroy(gameObject);
    }

    private void ActivatePowerUp(Player player)
    {
        player.SetMoveSpeed(FwdSpeedIncreaseAmount);
    }


    private void DeactivatePowerUp(Player player)
    {
        player.SetMoveSpeed(-FwdSpeedIncreaseAmount);

    }

}
