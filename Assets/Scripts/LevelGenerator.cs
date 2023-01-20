using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private float _maxOffset;
    [SerializeField] private GameObject _platforms;
    [SerializeField] private GameObject _diamonds;
    [SerializeField] private Transform _startPosition;
    [Range(0, 1)]
    [SerializeField] private float _spawnProbabilityDiamond;

    public List<GameObject> _listBlocks = new List<GameObject>();

    private GameObject _block;
    private float _blockNumber = 0;
    private float _offset = 0;

    void Start()
    {
        _block = Instantiate(_platforms, _startPosition.position, Quaternion.identity) as GameObject;
        _block.name = "Platform" + _blockNumber;
        _listBlocks.Add(_block);
    }

    void Update()
    {
        while (_listBlocks.Count < 50)
        {
            int randomDirection = Random.Range(0, 2);
            bool spawnPickup = (Random.Range(0f, 1f) < _spawnProbabilityDiamond) ? true : false;

            if (_offset == _maxOffset)
            {
                randomDirection = 0;
            }
            else if (_offset == -_maxOffset)
            {
                randomDirection = 1;
            }

            Vector3 newPosition = _block.transform.position;

            if (randomDirection == 1)
            {
                newPosition.x += 3f;
                _offset += 3f;
            }
            else
            {
                newPosition = _block.transform.position;
                newPosition.z += 3f;
                _offset -= 3f;
            }

            _block = Instantiate(_platforms, newPosition, Quaternion.Euler(0f, 0f, 0f)) as GameObject;

            if (spawnPickup)
            {
                Vector3 position = _block.transform.position + Vector3.up * 1.5f;
                GameObject pickup = Instantiate(_diamonds, position, Quaternion.Euler(90f, 0f, 0f)) as GameObject;
                pickup.transform.localScale = new Vector3(0.7f, 0.7f, 0.6f);
                pickup.transform.position = new Vector3(_block.transform.position.x, 3.4f, _block.transform.position.z);
                pickup.transform.SetParent(_block.transform);
            }

            _blockNumber++;
            _block.name = "Platform" + _blockNumber;
            _block.transform.SetParent(gameObject.transform);
            _listBlocks.Add(_block);
        }

        for (int i = 0; i < _listBlocks.Count; i++)
        {
            if (_listBlocks[i].activeSelf == false)
            {
                ActivePlatform(_listBlocks[i]);
                _listBlocks.RemoveAt(i);
            }
        }
    }

    private void ActivePlatform(GameObject platform)
    {
        int randomDirection = Random.Range(0, 2);
        bool spawnPickup = (Random.Range(0f, 1f) < _spawnProbabilityDiamond) ? true : false;

        if (_offset == _maxOffset)
        {
            randomDirection = 0;
        }
        else if (_offset == -_maxOffset)
        {
            randomDirection = 1;
        }

        Vector3 newPosition = _listBlocks[_listBlocks.Count - 1].transform.position;

        if (randomDirection == 1)
        {
            newPosition.x += 3f;
            _offset += 3f;
        }
        else
        {
            newPosition = _listBlocks[_listBlocks.Count - 1].transform.position;
            newPosition.z += 3f;
            _offset -= 3f;
        }

        platform.transform.position = newPosition;

        if (spawnPickup)
        {
            Vector3 position = newPosition + Vector3.up * 1.5f;
            GameObject pickup = Instantiate(_diamonds, position, Quaternion.Euler(90f, 0f, 0f)) as GameObject;
            pickup.transform.localScale = new Vector3(0.7f, 0.7f, 0.6f);
            pickup.transform.position = new Vector3(position.x, 3.4f, position.z);
            pickup.transform.SetParent(platform.transform);
        }

        _blockNumber++;
        platform.transform.rotation = new Quaternion(0f, 0f, 0f, 0f);
        platform.name = "Platform" + _blockNumber;
        platform.GetComponent<Rigidbody>().isKinematic = true;
        platform.SetActive(true);
        _listBlocks.Add(platform);
    }
}
