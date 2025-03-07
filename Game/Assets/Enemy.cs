using UnityEngine;

public class Enemy : MonoBehaviour
{
	public GameObject player;
  public Rigidbody2D rigidBody;
  public float speed = 0.01f;
	public Vector2 boundary = Vector2.left;
  public float boundarySize = 5f;
	public Vector2 current_direction = Vector2.left;
  public Vector2 position;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
  void Start()
  {
    float left = transform.position.x - this.boundarySize;
    float right = transform.position.x + this.boundarySize;
    this.boundary = new Vector2(left, right);
  }

  // Update is called once per frame
  void Update()
  {
    this.position = transform.position;
    this.CheckToSwitch();
    this.Move();
  }

  void Move()
  {
    if (!this.IsOutOfBoundary())
    {
      float x = this.current_direction.x * this.speed * Time.deltaTime;
      this.transform.position = new Vector2(x + this.transform.position.x, this.transform.position.y);
    }
  }

  void CheckToSwitch()
  {
    if (this.IsLimitRight() && this.current_direction != Vector2.left)
    {
      this.current_direction = Vector2.left;
      this.transform.position = new Vector2(this.current_direction.x + this.transform.position.x, this.transform.position.y);
    }
    else if (this.IsLimitLeft() && this.current_direction != Vector2.right)
    {
      this.current_direction = Vector2.right;
      this.transform.position = new Vector2(this.current_direction.x + this.transform.position.x, this.transform.position.y);
    }
  }

  bool IsOutOfBoundary()
  {
    if (this.IsLimitRight() || this.IsLimitLeft())
      return true;
    return false;
  }

  bool IsLimitLeft()
  {
		if (this.transform.position.x <= this.boundary.x)	
			return true;
		return false;
  }

  bool IsLimitRight()
	{
		if (transform.position.x >= this.boundary.y)	
			return true;
		return false;
	} 

	bool IsInPlayerRange()
  {
    return true;
  }
}
