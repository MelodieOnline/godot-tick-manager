using Godot;

public partial class example_tickable : Node, i_tickable
{
	public void physics_tick(float delta){
		// Eure Logik hierher (z.B player-movement)
		// (60 ticks pro sekunde)
	}


	public void custom_tick(float delta){
		// Euer Custom-Tick z.B 20 mal pro sekunde statt 60 aufgerufen
		// (Wert im Skript 'tick_manager' anpassen)
	}


    public override void _Ready()
    {
		// das Skript zur Tickable-Liste hinzufügen
        tick_manager.instance.register_tickable(this);
    }

    public override void _ExitTree()
    {
		// beim Verlassen aus der Liste entfernen
        tick_manager.instance.unregister_tickable(this);
    }
}
