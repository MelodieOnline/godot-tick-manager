using System.Collections.Generic;
using Godot;

public partial class tick_manager : Node
{
    public static tick_manager instance {get; private set;}

    private readonly List<i_tickable> _tickables = new();

    private const float TICK_RATE = 0.05f; // das nach Bedarf anpassen (z.B 0.05f = 20 ticks pro sekunde)
    private float _timer = 0f;

    public void register_tickable(i_tickable obj){
        if(_tickables.Contains(obj) || obj == null) return;

        _tickables.Add(obj);
    }

    public void unregister_tickable(i_tickable obj){
        if(!_tickables.Contains(obj)) return;

        _tickables.Remove(obj);
    }



    public override void _PhysicsProcess(double delta)
    {
        if(_tickables.Count == 0) return;

        float f_delta = (float)delta;
        _timer += f_delta;

        int i;
        int p;
        int _tickables_count = _tickables.Count - 1;
        
        for(p = _tickables_count; p >= 0; p--)
            _tickables[p].physics_tick(f_delta); // Physics Tick hier


        if(_timer >= TICK_RATE){
            _timer -= TICK_RATE;

            for(i = _tickables_count; i >= 0; i--)
                _tickables[i].custom_tick(f_delta);       
        }
        
        
    }


    public override void _Ready()
    {
        if(instance != null && instance != this){
            // GD.Print("ERR: 2 tick_manager instance gefunden! (objekt zerstört)"); // nur für debug
            QueueFree();
            return;
        }

        instance = this;
    }

    public override void _ExitTree()
    {
        instance = null;
    }
}
