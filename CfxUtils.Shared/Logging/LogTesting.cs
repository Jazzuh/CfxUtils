#if false
using System;
using CitizenFX.Core;

namespace CfxUtils.Shared.Logging
{
    public class TestCommand : BaseScript
    {
        [Command("log_test")]
        private void test()
        {
            Log.Trace("Trace log");
            Log.Debug("Debug log");
            Log.Information("Information log");
            Log.Warning("Warning log");
            Log.Error("Error log");
            Log.Error(new Exception("fake error"));
        }
    }
}
#endif