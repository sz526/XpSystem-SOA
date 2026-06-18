focus on an MVP (Minimum Viable Product)—keeping the core flow as naive, simple, and functional as possible without over-engineering technical details like databases or Web APIs.

Hypothesis 1: A new player starts at Level 1 with 0 XP
RED: Write the test checking default values. It fails to compile because the Player class doesn't exist yet.

GREEN: Create a naked Player.cs class initialized with Level = 1 and Xp = 0.

Hypothesis 2: A player can accumulate XP over time
RED: Write a test calling player.GainXp(40); and assert that player.Xp == 40. It fails because the method isn't declared.

GREEN: Implement public void GainXp(int amount) containing basic logic: Xp += amount;.

Hypothesis 3: Reaching the 100 XP threshold triggers a Level Up
RED: Write a test feeding the player exactly 100 XP. Assert player.Level == 2 and remaining player.Xp == 0. It fails (remains Level 1).

GREEN: Add a simple condition: if (Xp >= 100) { Level++; Xp -= 100; }.

Hypothesis 4: Multiple levels can be gained at once if massive XP is acquired
RED: Write an edge-case test dropping 250 XP at once. The player should advance to Level 3 with 50 XP remaining. The previous single if check will fail this requirement.

GREEN: Refactor the conditional check into a dynamic tracking loop: while (Xp >= 100).