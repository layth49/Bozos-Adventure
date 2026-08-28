# Bozo's Adventure

A 2D platformer about three bozos, built in Unity.

Three characters, three incompatible ways to move. **49** teleports to your cursor. **Slime** double-jumps. **AA** throws a hat. You swap between them mid-run with `E`, and the idea was that the same level could be solved three different ways — teleport over the gap, or chain a double-jump across it.

Two builds shipped (v0.1 and v0.2). v0.3 got as far as a third character and a first real map before the team moved on. The repo's still here and the build still runs.

> **Status:** Archived at v0.2. Not in active development.
> More on the project (including the v0.2 showcase video and the OST): **[layth49.com/bozos](https://layth49.com/bozos)**

---

## Controls

| Action | Input |
| --- | --- |
| Move | `A` / `D` (or arrow keys) |
| Jump | `Space` |
| Switch character | `E` |
| Teleport to cursor (**49** only) | Right mouse button |
| Double jump (**Slime** only) | `Space` again, mid-air |
| Throw hat (**AA** only, unfinished) | `F` |

`E` cycles the roster: 49 → Slime → AA → 49.

---

## The Roster

### 49 — the teleporter
Right-click to warp to the mouse cursor. Fires an SFX and a two-part particle burst on use, then goes on cooldown (`coolDownSeconds` on `l49Controller`, set to 1.5s in the Game scene). Its planned attack, "Enderman's Breath" — a purple poison cloud — was never built.

Script: [l49Controller.cs](Assets/Scripts/l49Controller.cs)

### Slime — the double-jumper
Two consecutive jumps off the ground. Smoothest character for crossing gaps. Every jump plays one of five random slime SFX. A hammer-hand melee was planned and never built.

Script: [SlimeController.cs](Assets/Scripts/SlimeController.cs)

### AA — the hat-thrower *(never shipped)*
The intended third roster slot for v0.3. Got as far as sprite frames and a working hat-throw prototype (`F` spawns a hat that travels right and despawns after half a second). Never made it into a shipped build, and the sprite frames never made it into an animator.

Scripts: [AAController.cs](Assets/Scripts/AAController.cs), [HatLogic.cs](Assets/Scripts/HatLogic.cs)

---

## Running it

**Play the build:** a WebGL build lives in [`WebGL Builds/`](WebGL%20Builds). It needs to be served over HTTP — opening `index.html` from the filesystem won't work, since the Brotli-compressed `.br` files require proper `Content-Encoding` headers.

```bash
cd "WebGL Builds" && python -m http.server 8000
```

**Open the source:** the project targets **Unity 2022.3.5f1**. Clone it, open the folder in Unity Hub, and load `Assets/Scenes/MainMenu.unity`.

> The committed WebGL build was made with 2021.3.26f1, one editor version behind the project files.

---

## Project layout

```
Assets/
  Scenes/            MainMenu, SettingsMenu, Game
  Scripts/           character controllers, menus, hat logic
  Animation/         sprite art + animator controllers, one folder per character (49, AA, Slime)
  Prefabs/           Hat.prefab
  Music/             title screen theme
  SFX/               teleport + 5 slime jump sounds
  Misc/              game icon, title screen background
  Hidden Folders/    Hovl Studio particle pack (third-party)
WebGL Builds/        committed web build
```

Built with Unity's 2D feature set, TextMesh Pro, and the Input System package. All gameplay code is C#, in [`Assets/Scripts/`](Assets/Scripts).

---

## Known issues

These were still on the board when the project wrapped. None of them were fixed.

**49 can't teleport during a character switch.** Swapping to 49 mid-cooldown freezes the cooldown counter. The fix was to give the switcher its own cooldown so the two couldn't desync.

**Slime's double jump is scuffed.** Input timing is too strict — it feels like a frame-perfect cancel about half the time. Wants a coyote-time window and an input buffer.

**Movement isn't smooth.** Velocity flips abruptly on direction changes, because horizontal movement goes through `transform.Translate` on raw axis input. Routing input-to-velocity through `Vector3.Lerp` or `SmoothDamp` would fix it.

There's also dead code: [CharacterSwitcher.cs](Assets/Scripts/CharacterSwitcher.cs) has an unreachable `else if` branch on the same `KeyCode.E` condition. The switching that actually works is duplicated across each of the three character controllers.

---

## Dev log

### ~~Version 0.3~~ — shelved
*The Overlands. Cancelled.*

- Teleport balancing (keeping 49 from soft-breaking encounters)
- AA, the third playable character
- The Overlands, the first proper map

Queued behind it, never started: an animations pass, a nerf to teleporting, an upgraded character switcher with its own cooldown, the two planned attacks, and a bug-fix pass on the issues above.

<details>
<summary><b>Version 0.2</b> — shipped 6/14/23, at 5 AM (again)</summary>

**Teleportation for 49 was added!**
- Cooldown was added (1 second)
- SFX was added
- Particle was added
- *49 currently teleports to mouse position*

**Slime was added!**
- Double jumping for Slime was added
- 5 random SFX play every time you jump

**A character switcher was added!**
- Switch between 49 and Slime with `E`

*Unfinished:* particle for double jumping.
</details>

<details>
<summary><b>Version 0.1</b> — shipped 5/30/23, at 5 AM</summary>

- A main menu
- A settings menu
- Background music that travels across certain scenes
- A floor
- A few platforms to jump on
- A working player with a sprite

*Unfinished:* sprites with animations.
</details>

---

## License

No license file. All rights reserved by default — ask before reusing the assets.
