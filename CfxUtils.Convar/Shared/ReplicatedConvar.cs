using CitizenFX.Core.Native;

namespace CfxUtils.Convar.Shared
{
    /// <summary>
    /// Represents a replicated console variable
    /// </summary>
    /// <typeparam name="TConvarType">Type of the convar</typeparam>
    public class ReplicatedConvar<TConvarType> : Convar<TConvarType> where TConvarType : struct
    {
        public ReplicatedConvar(string varName, TConvarType defaultValue) 
            : base(varName, defaultValue) { }

#if SERVER
        protected override void SetConvar(TConvarType value)
        {
            API.SetConvarReplicated(VarName, value.ToString());
        }
#endif
    }
}