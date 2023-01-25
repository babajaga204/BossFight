using BossFight;

var boss = new GameCharacter("Boss",400, 30, 10, true);
var hero = new GameCharacter("Jake", 100, 20, 40, false);
boss.Show();
hero.Show();
while (true)
{
    hero.Fight(boss);
    boss.Fight(hero);
    Console.WriteLine();
    if (hero._health <= 0 || boss._health <= 0)
    {
        if (hero._health <= 0)
        {
            Console.WriteLine("Boss wins the game!");
            break;
        } 
        Console.WriteLine("Hero wins the game!");
        break;
    }
}