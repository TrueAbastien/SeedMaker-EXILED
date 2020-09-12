# SeedMaker - An SCP : Secret Laboratory plugin for EXILED v2.0

* Allows you to dynamically set/get the map seed.
* Setting the map seed will lock its value for all the following rounds until freed.

## Config

Just the **isEnabled** default boolean, you know the drill...

## Commands

No commands is limited to any permission, but they can only be called through the Remote Admin Console:

Name | Description
:---: | :---------
```seed.info``` | Display info related to the current state of Seed making.
```seed.set``` | Set the 'currentSeed' to the given value & lock the seed if need be.
```seed.lock``` | Lock the seed to be set on the 'currentSeed' (if different from -1).
```seed.free``` | Free the 'currentSeed' to be set randomly, as usual, for each round.

## Patch

To prevent HarmonyPatches from clashing, a **Prefix** patch has been made on the **RandomSeedSync** method (which will prevent the original if successful).

---

*Feel free to use or modify any of this project content.*
