//Changelog
// v1.0 First release


using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Threading;
using PixelMonkey.WoWChecks;
using PixelMonkey.Logs;
using PixelMonkey.ControlMethod;

namespace PixelMonkey.Rotation
{
    public class ClassSpecsmartie : CombatRoutine
    {
        private static readonly Stopwatch Jumpwatch = new Stopwatch();
        public override string Name
        {
            get 
			{ 
				return "Spec"; 
			}
        }
        public override string Class
        {
            get 
			{ 
				return "Class"; 
			}
        }
        public override int SINGLE 
		{
			get 
			{ 
				return 1; 
			} 
		}
		public override int CLEAVE 
		{ 
			get 
			{ 
				return 99;
			} 
		}
        public override int AOE 
		{ 
			get 
			{ 
				return 99; 
			} 
		}
		public override int AoE_Range  
		{
			get 
			{ 
				return 40; 
			} 
		}
        public override int Interrupt_Ability_Id 
		{ 
			get 
			{ 
				return 1; 
			}
		}
		public override Form SettingsForm 
		{ 
			get; 
			set; 
		}
		public override string RoutineName { get { return "AntiAfk-smartie"; } } //only for paid routines
        public override string Premium { get { return "false"; } }
        public override string Recurring { get { return "false"; } }
        public override void Initialize()
        {
            Log.Write("Welcome to Anti Afk by smartie", Color.Red);
	        Log.Write("Set your Jumpkey in Keybindings and activate the afk script by prssing P and stop it with O ", Color.Red);		
        }
        public override void Stop()
        {
        }
        public override void Pulse()
        {
            if (WoW.IsMacroPressed("Anti Afk start") && !Jumpwatch.IsRunning)
            {
                Jumpwatch.Start();
				Log.Write(".......................", Color.Green);
                Log.Write("Anti Afk script started", Color.Green);
                Log.Write(".......................", Color.Green);				
            }
			if (WoW.IsMacroPressed("Anti Afk stop") && Jumpwatch.IsRunning)
            {
                Jumpwatch.Reset();
				Log.Write(".......................", Color.Red);
                Log.Write("Anti Afk script stoped", Color.Red);
                Log.Write(".......................", Color.Red);				
            }
			if (Jumpwatch.ElapsedMilliseconds >= 120000 && Jumpwatch.IsRunning)
			{
				    WoW.CastSpell("MakeMeJump");
					Jumpwatch.Restart();
                    return;
			}
		}
	}
}
/*
[AddonDetails.db]
AddonAuthor=smartie
AddonName=smartie
WoWVersion=80300
[SpellBook.db]
Spell,123,MakeMeJump,Space
Buff,123,AuraName
Debuff,123,DebuffName
Charge,123,ChargeName
Range,123,Rangespellname
Macro,Anti Afk start,P
Macro,Anti Afk stop,O
*/
