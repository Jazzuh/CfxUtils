using CitizenFX.Core.Native;
using System;
using CfxUtils.Shared.Logging;

namespace CfxUtils.Shared.Convar
{
    /// <summary>
    /// Represents a console variable
    /// </summary>
    /// <typeparam name="TConvarType">The type of the stored convar value</typeparam>
    public class Convar<TConvarType> where TConvarType : struct
    {
        /// <summary>
        /// The name of the convar
        /// </summary>
        public string VarName { get; }

        /// <summary>
        /// Gets or sets the value of the convar
        /// </summary>
        public TConvarType Value
        {
            get => GetConvar();
#if SERVER
            set => SetConvar(value);
#endif
        }

        /// <summary>
        /// The default value of the convar that will be returned if it doesn't exist
        /// </summary>
        public TConvarType DefaultValue { get; }

        public Convar(string varName, TConvarType defaultValue)
        {
            VarName = varName;
            DefaultValue = defaultValue;

#if SERVER
            // If the current value of the convar is the default value it may not have been used before so we set it so that it can be used like a command in the console
            if (Value.Equals(defaultValue))
            {
                Value = defaultValue;
            }
#endif
        }

#if SERVER
        /// <summary>
        /// Sets the value of this <see cref="Convar{TConvarType}"/>
        /// </summary>
        /// <param name="value">Value to set the convar to</param>
        protected virtual void SetConvar(TConvarType value)
        {
            API.SetConvar(VarName, value.ToString());
        }
#endif

        /// <summary>
        /// Gets the value of this <see cref="Convar{TConvarType}"/>
        /// </summary>
        /// <returns>The value of this convar or <see cref="DefaultValue"/> if getting the value wasn't successful</returns>
        protected TConvarType GetConvar()
        {
            var returnValue = DefaultValue;

            try
            {
                var type = typeof(TConvarType);
                var convarValue = API.GetConvar(VarName, DefaultValue.ToString());

                if (type == typeof(int) || type == typeof(float))
                {
                    returnValue = (TConvarType)Convert.ChangeType(convarValue, typeof(TConvarType));
                }
                else if (type == typeof(bool))
                {
                    returnValue = (TConvarType)Convert.ChangeType(convarValue is "True" or "true" or "1", typeof(TConvarType));
                }
                else if (type.IsEnum)
                {
                    if (!Enum.TryParse(convarValue, out TConvarType enumValue))
                    {
                        enumValue = DefaultValue;
                    }

                    returnValue = enumValue;
                }
                else
                {
                    returnValue = (TConvarType)Convert.ChangeType(API.GetConvar(VarName, DefaultValue.ToString()), typeof(TConvarType));
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }

            return returnValue;
        }
    }
}