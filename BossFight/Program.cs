using BossFight;

var boss = new GameCharacter("Boss", 400, 30, 10, true);
var hero = new GameCharacter("Jake", 100, 20, 40, false);
var randomItems = new List<Item>();
PopulateWithRandomItems(randomItems);
boss.Show();
hero.Show(); 
Console.WriteLine();

var dropChance = new Random().Next(0, 101);
var gamePhase = 1;
while (true)
{
    if (CheckGamePhaseAndDropChance(gamePhase, dropChance))
    {
        if (hero.Health <= 30)
        {
            var healthPotion = randomItems.First(item => item.ItemType == "HealthPotion");
            randomItems.Remove(healthPotion);
            hero.TakePotion(healthPotion, boss);
        }
        else
        {
            var random = new Random();
            var randomIndex = random.Next(0, randomItems.Count);
            var item = randomItems[randomIndex];
            randomItems.RemoveAt(randomIndex);
            hero.TakePotion(item, boss);
        }

    }
    if (!CheckGamePhaseAndDropChance(gamePhase, dropChance)) hero.Fight(boss);
    boss.Fight(hero);
    Console.WriteLine();
    if (hero.Health <= 0 || boss.Health <= 0)
    {
        if (hero.Health <= 0)
        {
            Console.WriteLine("Boss wins the game!");
            break;
        } 
        Console.WriteLine("Hero wins the game!");
        break;
    }
    gamePhase++;
}
static void PopulateWithRandomItems(List<Item> randomItems)
{
    for (var i = 0; i < 10; i++)
    {
        var random = new Random();

        switch (random.Next(0, 3))
        {
            case 0: randomItems.Add(new Item("StaminaPotion")); break;
            case 1: randomItems.Add(new Item("HealthPotion")); break;
            case 2: randomItems.Add(new Item("StrengthPotion")); break;
        }
    }
}

static bool CheckGamePhaseAndDropChance(int gamePhase, int dropChance)
{
    return gamePhase % 3 == 0 && dropChance >= 30;
}
