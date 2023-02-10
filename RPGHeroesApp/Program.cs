using RPGHeroesApp.Heroes;
using RPGHeroesApp.Heroes.Base;
using RPGHeroesApp.Items;
using RPGHeroesApp.Items.Base;

internal class Program
{
    private static void Main(string[] args)
    {
        Hero hero = new Warrior("George");
        Console.WriteLine(hero.Display());

        hero.LevelUp();
        Console.WriteLine(hero.Display());

        hero.Equip(new Weapon(WeaponType.Axe, "BoneSplitter", 2));
        hero.Equip(new Armor(ArmorType.Plate, Slot.Head, "Upside-down bucket", 2));
        //hero.Equip(new Armor(ArmorType.Cloth, Slot.Head, "Weird bandana", 3));
        hero.Equip(new Armor(ArmorType.Mail, Slot.Legs, "Chain pants", 1));
        Console.WriteLine(hero.Display());

        Console.WriteLine("\nPress any key to exit.");
        Console.ReadKey();
    }
}