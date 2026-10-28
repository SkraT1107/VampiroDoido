using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "SeekPlayer", story: "Agent seeks Player at [speed]", category: "Action", id: "cdfbc771f2cfa6154f2318d6e21222c2")]
public partial class SeekPlayerAction : Action
{
    [SerializeReference] public BlackboardVariable<float> Speed;

    private Transform target;
    private Transform self;
    protected override Status OnStart()
    {
        target = PlayerControler.Instance.transform;
        self = GameObject.transform;

        if(target == null)
        {
            return Status.Failure;
        }
        else
        {
            return Status.Running;
        }
    }

    protected override Status OnUpdate()
    {
        if (target == null)
        {
            return Status.Failure;
        }

        Vector3 direcao = (target.position - self.position).normalized;
        self.position += direcao * Speed * Time.deltaTime;

        return Status.Running;

    }

    protected override void OnEnd()
    {
    }
}

