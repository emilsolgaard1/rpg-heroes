# RPG Heroes

## Info:
The RPG Heros App includes methods for creating different heroes, weapons and armors.

### Hero
Heroes are given a name and are created as either a warrior, mage, ranger or rogue class.</br>
Heroes also gain different starting and level-up attributes, aswell as different sets of valid weapon and armor types, based on their class.</br>
A hero can have a single weapon equipped and three pieces of armor (head, body and legs).

A "Level Up" function increments the hero's level and increases their attributes allowing them to use items with higher level requirements.</br>
An "Equip" function lets the hero use items of different types valid for their class, if the level requirement is met.</br>
(Exceptions are thrown if items are neither valid or level appropriate.)</br>
A "Damage" function calculates the damage done by the hero based on their equipped weapon and the total sum of their class specific "damage attribute".

All information about the hero can be returned as a string and written to console with the "Display" function.

### Item
Items are either a Weapon or piece of Armor.</br>
Items have an associated "slot", that indicates which slot they get added to when equipped by a hero.</br>
(Only one item can fit in a slot and equipping a new item with the same slot-type will replace the current item in that slot.)

Both weapons and armor have specific types which can only be used by certain hero classes.</br>
Weapons have a specific "damage" which increases damage done by the hero, if equipped.</br>
Armor pieces have additional attributes that gets added to the hero's total attributes, if equipped.

## Tests:
A RPG Heroes Tests project is also included with the app.</br>
Various unit-testing are performed on every aspect of the RPG Heroes App.
