public abstract class Entity
{
    public string entityName { get; set; }
    protected string entityType { get; set; }
}

public interface IDamagable
{
    int MaxHealth { get; }
    int CurrentHealth { get; }

    public void GetDamage(int damage);
}

public class MyEntity : Entity
{
    public int age;

    public MyEntity(string entityName, string entityType, int age)
    {
        this.entityName = entityName;
        this.entityType = entityType;
        this.age = age;

        Console.WriteLine($"Создана сущность с параметрами: \n\tName: {entityName}\n\tType: {entityType}\n\tAge: {age}");
    }

    public virtual void MyMethod()
    {
        Console.WriteLine("Выполнен MyMethod класса MyEntity");
    }
}

public class MyDamagableEntity : MyEntity, IDamagable
{
    public MyDamagableEntity(string entityName, string entityType, int age, int maxHealth) : base(entityName, entityType, age)
    {
        this.MaxHealth = maxHealth;

        Console.WriteLine($"\tMaxHealth: {maxHealth}");
    }

    public int MaxHealth
    {
        get => maxHealth;
        set
        {
            maxHealth = value;
            currentHealth = value;
        }
    }
    private int maxHealth;

    public int CurrentHealth => currentHealth;
    private int currentHealth;


    public void GetDamage(int damage)
    {
        currentHealth -= damage;
        Console.WriteLine($"Сущность получила урон: {damage}, текущее здоровье: {CurrentHealth}");
    }

    public override void MyMethod()
    {
        Console.WriteLine("Выполнен MyMethod класса MyDamagableEntity");
    }
}