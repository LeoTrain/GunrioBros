using UnityEngine;

public class GoombaScript : MonoBehaviour
{
  public float speed = 0.01f;
	public Vector2 current_direction = Vector2.left;
	public Vector2 boundary = Vector2.left;
  public float boundarySize = 5f;
  public float playerFindRadius = 7f;
  public int lifePoints = 3;
  private float _playerToGoombaDifference = 0.2f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
  void Start()
  {
    this.boundary = this.CalculateBoundaries();
  }

  // Update is called once per frame
  void Update()
  {
    if (this.IsPlayerinRadius()) this.MoveToPlayer();
    else
    {
        this.CheckToSwitch();
        this.Move();
    }
  }

  void Move()
  {
      float x = this.current_direction.x * this.speed * Time.deltaTime;
      this.transform.Translate(x, 0, 0);
  }

  void OnCollisionEnter2D(Collision2D collision)
  {
      if (collision.gameObject.tag == "Player")
      {
        float playerY = collision.gameObject.transform.position.y - _playerToGoombaDifference;
        if (ComesFromAbove(playerY)) 
            Destroy(this.gameObject);
        else 
            collision.gameObject.GetComponent<PlayerHealthScript>().TakeDamage(1);
      }
  }

  public void TakeDamage(int damageIncome)
  {
    this.lifePoints -= damageIncome;
    if (this.lifePoints <= 0)
    {
      Destroy(this.gameObject);
    }
  }

  bool IsPlayerinRadius()
  {
        float difference = this.transform.position.x - GameObject.Find("Player").transform.position.x;
        if (difference < this.playerFindRadius && difference > -this.playerFindRadius)
            return true;
        return false;
  }

    void MoveToPlayer()
    {
        float difference = this.transform.position.x - GameObject.Find("Player").transform.position.x;
        if (difference > 0)
            this.current_direction = Vector2.left;
        else
            this.current_direction = Vector2.right;
        this.Move();
    }

  Vector2 CalculateBoundaries()
  {
    float left = transform.position.x - this.boundarySize;
    float right = transform.position.x + this.boundarySize;
    return (new Vector2(left, right));
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

  bool ComesFromAbove(float y1)
  {
    if (y1 > this.transform.position.y)
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
}
