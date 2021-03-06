namespace NWN.Events {
    public class LevellingEvent : NWNXEvent {
        public delegate void EventDelegate(LevellingEvent e);

        public const string BEFORE_LEVEL_UP = "NWNX_ON_LEVEL_UP_BEFORE";
        public const string AFTER_LEVEL_UP = "NWNX_ON_LEVEL_UP_AFTER";
        public const string BEFORE_LEVEL_UP_AUTOMATIC = "NWNX_ON_LEVEL_UP_AUTOMATIC_BEFORE";
        public const string AFTER_LEVEL_UP_AUTOMATIC = "NWNX_ON_LEVEL_UP_AUTOMATIC_AFTER";
        public const string BEFORE_LEVEL_DOWN = "NWNX_ON_LEVEL_DOWN_BEFORE";
        public const string AFTER_LEVEL_DOWN = "NWNX_ON_LEVEL_DOWN_AFTER";

        public static EventDelegate BeforeLevelUp = delegate { };
        public static EventDelegate AfterLevelUp = delegate { };
        public static EventDelegate BeforeLevelUpAutomatic = delegate { };
        public static EventDelegate AfterLevelUpAutomatic = delegate { };
        public static EventDelegate BeforeLevelDown = delegate { };
        public static EventDelegate AfterLevelDown = delegate { };

        public LevellingEvent(string script) {
            EventType = script;
        }

        public NWCreature Creature => Internal.OBJECT_SELF.AsCreature();

        [NWNEventHandler(BEFORE_LEVEL_UP)]
        [NWNEventHandler(AFTER_LEVEL_UP)]
        [NWNEventHandler(BEFORE_LEVEL_UP_AUTOMATIC)]
        [NWNEventHandler(AFTER_LEVEL_UP_AUTOMATIC)]
        [NWNEventHandler(BEFORE_LEVEL_DOWN)]
        [NWNEventHandler(AFTER_LEVEL_DOWN)]
        public static void EventHandler(string script) {
            var e = new LevellingEvent(script);
            switch (script) {
                case BEFORE_LEVEL_UP:
                    BeforeLevelUp(e);
                    break;
                case AFTER_LEVEL_UP:
                    AfterLevelUp(e);
                    break;
                case BEFORE_LEVEL_UP_AUTOMATIC:
                    BeforeLevelUpAutomatic(e);
                    break;
                case AFTER_LEVEL_UP_AUTOMATIC:
                    AfterLevelUpAutomatic(e);
                    break;
                case BEFORE_LEVEL_DOWN:
                    BeforeLevelDown(e);
                    break;
                case AFTER_LEVEL_DOWN:
                    AfterLevelDown(e);
                    break;
            }
        }
    }
}