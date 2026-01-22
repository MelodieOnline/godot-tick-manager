# godot_tick_manager

#[🇩🇪Deutsch]
---

Ein leichtes und effizientes Ticksystem für Godot 4.X (C#).


## Warum dieses System denn?
* **Optimiert für Performance** -> Reduziert den Engine-Overhead durch ein zentrales System.
* **Einfache Integration** -> Ein Interface wurde benutzt damit alle ohne Probleme nutzen können.
* **Singleton** -> das System wird mit einem Singleton-Schutz gestartet sodass kein zweites TickSystem ausgeführt wird.

---------------------------------------------------------------
## Benutzung

**WICHTIG!!** Vergiss nicht, das Skript 'tick_manager.cs' in den Godot-Einstellungen als Autoload (Singleton) hinzuzufügen!
Sonst wirkt dieses System nicht!


**1.** fügt 'i_tickable' zu deinem Skript:

```csharp
public partial class player : CharacterBody3D, i_tickable{
    // deinen Code hierher
}
```
---------------------------------------------------------------

2. Melde dein Skript im '_Ready()' an und im '_ExitTree()' ab:

```csharp
public override void _Ready(){
    tick_manager.instance.register_tickable(this); // hinzufügen
}

public override void _ExitTree(){
    tick_manager.instance.unregister_tickable(this); // entfernen
}
```
---------------------------------------------------------------

3. Ticks nutzen:

```csharp    
public void physics_tick(float delta){
    // Logik für 60 ticks pro sekunde (z.B Movement);
}

public void custom_tick(float delta){
    // Logik für 20 Ticks pro Sekunde (z.B KI, UI) (Einstellbar im Skript 'tick_manager');
}
```


**und das war's! Viel Spaß!**




----------------------------------------------------------------------------------------------------




#[🇺🇸English]
---

A lightweight and efficient tick system for Godot 4.X(C#).


## Why this system?
* **Optimized for Performance** -> Reduces engine overhead through a centralized management system.
* **Easy Integration** -> Uses a simple interface so anyone can implement it without Problems
* **Singleton** -> Built with a singleton guard to ensure only one Ticksystem runs at a time.

---------------------------------------------------------------
# Usage
**IMPORTANT!!** Don’t forget to add the script tick_manager.cs as an Autoload (Singleton) in the Godot settings!
Otherwise, this system won’t work!

**1.** Add 'i_tickable' to your script:

```csharp
public partial class player : CharacterBody3D, i_tickable{
    // your code here
}
```
---------------------------------------------------------------

**2.** Register your script in '_Ready()' and unregister in 'ExitTree()':

```csharp
public override void _Ready(){
    tick_manager.instance.register_tickable(this); // add to list
}

public override void _ExitTree(){
    tick_manager.instance.unregister_tickable(this); // remove from list
}
```
---------------------------------------------------------------

**3.** Using Ticks:

```csharp    
public void physics_tick(float delta){
    // Logic for 60 ticks per second (e.g. Movement)
}

public void custom_tick(float delta){
    // Logic for 20 ticks per second (e.g. AI, UI) (Adjustable in 'tick_manager' script)
}
```


**And that's it! Have fun!**


Entwickelt von melodie_online || Made by melodie_online
