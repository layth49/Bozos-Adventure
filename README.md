# Bozo's Adventure

A 2D platformer about three bozos, made in Unity.

Each character moves in a way the others can't. 49 teleports to your cursor, Slime double-jumps, and AA was supposed to throw a hat. You swap between them mid-run with `E`, so the idea was that one gap could be crossed three different ways.

v0.1 and v0.2 shipped. v0.3 got as far as a third character and the start of a real map, then stalled out from a lack of interest across the team. The repo's still up and the build still runs.

Archived at v0.2. Nobody's working on it. There's more about the project, including the v0.2 showcase video and the title track, at [layth49.com/bozos](https://layth49.com/bozos).

## Controls

| Action | Input |
| --- | --- |
| Move | `A` / `D` (or arrow keys) |
| Jump | `Space` |
| Switch character | `E` |
| Teleport to cursor (49 only) | Right mouse button |
| Double jump (Slime only) | `Space` again, mid-air |
| Throw hat (AA only, unfinished) | `F` |

`E` cycles 49, then Slime, then AA, then back to 49.

## The roster

### 49

Right-click and he warps to the mouse cursor. Plays a sound, fires two particle systems, then sits on cooldown. The cooldown is `coolDownSeconds` on `l49Controller`, set to 1.5 in the Game scene. He was going to get an attack called Enderman's Breath, a purple poison cloud. That never got built.

[l49Controller.cs](Assets/Scripts/l49Controller.cs)

### Slime

Jump, then jump again in mid-air. Best of the three at crossing gaps. Every jump picks one of five slime sounds at random. The hammer-hand melee that was planned for him never happened either.

[SlimeController.cs](Assets/Scripts/SlimeController.cs)

### AA (never shipped)

The third roster slot for v0.3. Press `F` and he spawns a hat that flies right and deletes itself after half a second. That's as far as it got. His sprite frames are in `Assets/Animation/AA/`, but none of them were ever wired into an animator, and he never made it into a build.

[AAController.cs](Assets/Scripts/AAController.cs), [HatLogic.cs](Assets/Scripts/HatLogic.cs)

## Running it

There's a WebGL build in [`WebGL Builds/`](WebGL%20Builds). It has to be served over HTTP. Opening `index.html` off the filesystem won't work, because the Brotli-compressed `.br` files need the right `Content-Encoding` headers.

```bash
cd "WebGL Builds" && python -m http.server 8000
```

For the source, the project is on Unity 2022.3.5f1. Open the folder in Unity Hub and load `Assets/Scenes/MainMenu.unity`. The committed WebGL build is one editor version behind, on 2021.3.26f1.

## Project layout

```
Assets/
  Scenes/            MainMenu, SettingsMenu, Game
  Scripts/           character controllers, menus, hat logic
  Animation/         sprite art and animator controllers, one folder per character
  Prefabs/           Hat.prefab
  Music/             title screen theme
  SFX/               teleport sound, 5 slime jump sounds
  Misc/              game icon, title screen background
  Hidden Folders/    Hovl Studio particle pack (third-party)
WebGL Builds/        committed web build
```

All the gameplay code is C# in [`Assets/Scripts/`](Assets/Scripts). The project pulls in Unity's 2D packages plus TextMesh Pro and the Input System.

## Known issues

Three bugs were on the board when everything stopped. All three are still there.

49 can't teleport during a character switch. Swap to him mid-cooldown and the counter freezes. Giving the switcher its own cooldown would have sorted it.

Slime's double jump is scuffed. The input window is too tight, so about half the time it feels like a frame-perfect cancel instead of a jump. It wants coyote time and an input buffer.

Movement isn't smooth. Horizontal movement runs `transform.Translate` straight off the raw input axis, so velocity snaps whenever you change direction. Running the input through `Vector3.Lerp` or `SmoothDamp` fixes it.

Separately, [CharacterSwitcher.cs](Assets/Scripts/CharacterSwitcher.cs) is dead code. Its `else if` tests the same `KeyCode.E` as the `if` above it, so the second branch can never run. The switching that actually works is copy-pasted into each of the three character controllers instead.

## Dev log

### ~~Version 0.3~~ shelved

The Overlands. Never finished.

• Teleport balancing, so 49 couldn't break encounters

• AA, a third playable character

• The Overlands, the first proper map

Queued behind it on the Trello, none of it started: an animations pass, a teleport nerf, a switcher with its own cooldown, the two attacks, and a sweep through the bugs above.

### Version 0.2 is LIVE!
>At 5 am (again) 6/14/23
<details>
<summary>Version 0.2 featured:</summary>
ㅤ

  **Teleportation for 49 was added!**

        • Cooldown was added (1 second)

        • SFX was added

        • Particle was added

        ***49 CURRENTLY TELEPORTS TO MOUSE POSITION***
____________________________________________
**Slime was added!**

    • Double Jumping for Slime was added

    • 5 random SFX play every time you jump
____________________________________________
**A Character Switcher was added!**

    • Switch between 49 and Slime with 'E'
____________________________________________
The **_Unfinished_** features were:

    • Particle for double jumping
</details>

### Version 0.1 is LIVE!
>At 5 AM 5/30/23
<details>
<summary>Version 0.1 featured:</summary>

    • A Main Menu

    • A Settings Menu

    • Background Music that travels across certain scenes

    • A Floor

    • A few platforms to jump on

    • A working Player with a sprite
____________________________________________
The **_Unfinished_** features were:

    • Sprites with animations
</details>

## License

No license file, so default copyright applies. Ask before reusing the art or the audio.
