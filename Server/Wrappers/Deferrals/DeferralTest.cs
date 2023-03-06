#if false
using CitizenFX.Core;

namespace CfxUtils.Wrappers.Deferrals
{
    public class DeferralTest : BaseScript
    {
        [EventHandler("playerConnecting")]
        private async void test([FromSource] Player source, string playerName, dynamic setKickReason, dynamic deferralsObj)
        {
            var deferrals = new Deferrals(deferralsObj);

            deferrals.Defer();

            await BaseScript.Delay(0);

            Debug.WriteLine("hello");

            await BaseScript.Delay(500);

            deferrals.PresentCard(@"{""type"":""AdaptiveCard"",""body"":[{""type"":""TextBlock"",""size"":""ExtraLarge"",""weight"":""Bolder"",""text"":""Server password?!""},{""type"":""TextBlock"",""text"":""That's right, motherfucker! You have to enter a goddamn PASSWORD to connect to this server..."",""wrap"":true},{""type"":""Input.Text"",""id"":""password"",""title"":"""",""placeholder"":""better enter one now""},{""type"":""Image"",""url"":""http://images.amcnetworks.com/ifccenter.com/wp-content/uploads/2019/04/pulpfic_1280.jpg"",""altText"":""""},{""type"":""ActionSet"",""actions"":[{""type"":""Action.Submit"",""title"":""Sure...""},{""type"":""Action.ShowCard"",""title"":""YOU WISH!!!!!!"",""card"":{""type"":""AdaptiveCard"",""body"":[{""type"":""Image"",""url"":""https://i.imgur.com/YjMR0E6.jpg"",""altText"":""""}],""$schema"":""http://adaptivecards.io/schemas/adaptive-card.json""}}]}],""$schema"":""http://adaptivecards.io/schemas/adaptive-card.json"",""version"":""1.0""}", (data, rawData) =>
            {
                Debug.WriteLine(rawData);
                foreach(var kvp in data)
                {
                    Debug.WriteLine($"{kvp.Key}: {kvp.Value}");
                }

                deferrals.Done();
            });
        }
    }
}
#endif
