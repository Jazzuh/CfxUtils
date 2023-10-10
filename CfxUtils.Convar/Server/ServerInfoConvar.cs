using CfxUtils.Convar.Shared;
using CitizenFX.Server.Native;

namespace CfxUtils.Convar.Server
{
    /// <summary>
    /// Represents a server info console variable. This convar will be visible on the display page of a server
    /// </summary>
    /// <typeparam name="TConvarType">Type of the convar</typeparam>
    public class ServerInfoConvar<TConvarType> : Convar<TConvarType> where TConvarType : struct
    {
        public ServerInfoConvar(string varName, TConvarType defaultValue) 
            : base(varName, defaultValue) { }

        protected override void SetConvar(TConvarType value)
        {
            Natives.SetConvarServerInfo(VarName, value.ToString());
        }
    }
}
