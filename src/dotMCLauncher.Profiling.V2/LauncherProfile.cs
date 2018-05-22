using System;
using Newtonsoft.Json;

namespace dotMCLauncher.Profiling.V2
{
    public class LauncherProfile : Serializable
    {
        [JsonIgnore]
        public string AssociatedId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("icon")]
        private string _icon { get; set; }

        [JsonIgnore]
        public LauncherProfileIcon Icon
        {
            get {
                switch (_icon) {
                    case "Bedrock":
                        return LauncherProfileIcon.BEDROCK;
                    case "Bookshelf":
                        return LauncherProfileIcon.BOOKSHELF;
                    case "Chest":
                        return LauncherProfileIcon.CHEST;
                    case "Clay":
                        return LauncherProfileIcon.CLAY;
                    case "Coal_Block":
                        return LauncherProfileIcon.COAL_BLOCK;
                    case "Coal_Ore":
                        return LauncherProfileIcon.COAL_ORE;
                    case "Cobblestone":
                        return LauncherProfileIcon.COBBLESTONE;
                    case "Diamond_Block":
                        return LauncherProfileIcon.DIAMOND_BLOCK;
                    case "Diamond_Ore":
                        return LauncherProfileIcon.DIAMOND_ORE;
                    case "Dirt":
                        return LauncherProfileIcon.DIRT;
                    case "Dirt_Podzol":
                        return LauncherProfileIcon.DIRT_PODZOL;
                    case "Dirt_Snow":
                        return LauncherProfileIcon.DIRT_SNOW;
                    case "Emerald_Block":
                        return LauncherProfileIcon.EMERALD_BLOCK;
                    case "Emerald_Ore":
                        return LauncherProfileIcon.EMERALD_ORE;
                    case "End_Stone":
                        return LauncherProfileIcon.END_STONE;
                    case "Farmland":
                        return LauncherProfileIcon.FARMLAND;
                    case "Furnace_On":
                        return LauncherProfileIcon.FURNACE_ON;
                    case "Glass":
                        return LauncherProfileIcon.GLASS;
                    case "Glowstone":
                        return LauncherProfileIcon.GLOWSTONE;
                    case "Gold_Block":
                        return LauncherProfileIcon.GOLD_BLOCK;
                    case "Gold_Ore":
                        return LauncherProfileIcon.GOLD_ORE;
                    case "Gravel":
                        return LauncherProfileIcon.GRAVEL;
                    case "Hardened_Clay":
                        return LauncherProfileIcon.HARDENED_CLAY;
                    case "Ice_Packed":
                        return LauncherProfileIcon.ICE_PACKED;
                    case "Iron_Block":
                        return LauncherProfileIcon.IRON_BLOCK;
                    case "Iron_Ore":
                        return LauncherProfileIcon.IRON_ORE;
                    case "Lapis_Ore":
                        return LauncherProfileIcon.LAPIS_ORE;
                    case "Leaves_Birch":
                        return LauncherProfileIcon.LEAVES_BIRCH;
                    case "Leaves_Jungle":
                        return LauncherProfileIcon.LEAVES_JUNGLE;
                    case "Leaves_Oak":
                        return LauncherProfileIcon.LEAVES_OAK;
                    case "Leaves_Spruce":
                        return LauncherProfileIcon.LEAVES_SPRUCE;
                    case "Log_Acacia":
                        return LauncherProfileIcon.LOG_ACACIA;
                    case "Log_Birch":
                        return LauncherProfileIcon.LOG_BIRCH;
                    case "Log_DarkOak":
                        return LauncherProfileIcon.LOG_DARK_OAK;
                    case "Log_Jungle":
                        return LauncherProfileIcon.LOG_JUNGLE;
                    case "Log_Oak":
                        return LauncherProfileIcon.LOG_OAK;
                    case "Log_Spruce":
                        return LauncherProfileIcon.LOG_SPRUCE;
                    case "Mycelium":
                        return LauncherProfileIcon.MYCELIUM;
                    case "Nether_Brick":
                        return LauncherProfileIcon.NETHER_BRICK;
                    case "Netherrack":
                        return LauncherProfileIcon.NETHERRACK;
                    case "Obsidian":
                        return LauncherProfileIcon.OBSIDIAN;
                    case "Planks_Acacia":
                        return LauncherProfileIcon.PLANKS_ACACIA;
                    case "Planks_Birch":
                        return LauncherProfileIcon.PLANKS_BIRCH;
                    case "Planks_DarkOak":
                        return LauncherProfileIcon.PLANKS_DARK_OAK;
                    case "Planks_Jungle":
                        return LauncherProfileIcon.PLANKS_JUNGLE;
                    case "Planks_Oak":
                        return LauncherProfileIcon.PLANKS_OAK;
                    case "Planks_Spruce":
                        return LauncherProfileIcon.PLANKS_SPRUCE;
                    case "Quartz_Ore":
                        return LauncherProfileIcon.QUARTZ_ORE;
                    case "Red_Sand":
                        return LauncherProfileIcon.RED_SAND;
                    case "Red_Sandstone":
                        return LauncherProfileIcon.RED_SANDSTONE;
                    case "Redstone_Block":
                        return LauncherProfileIcon.REDSTONE_BLOCK;
                    case "Redstone_Ore":
                        return LauncherProfileIcon.REDSTONE_ORE;
                    case "Sand":
                        return LauncherProfileIcon.SAND;
                    case "Sandstone":
                        return LauncherProfileIcon.SANDSTONE;
                    case "Snow":
                        return LauncherProfileIcon.SNOW;
                    case "Soul_Sand":
                        return LauncherProfileIcon.SOUL_SAND;
                    case "Stone":
                        return LauncherProfileIcon.STONE;
                    case "Stone_Andesite":
                        return LauncherProfileIcon.STONE_ANDESITE;
                    case "Stone_Diorite":
                        return LauncherProfileIcon.STONE_DIORITE;
                    case "Stone_Granite":
                        return LauncherProfileIcon.STONE_GRANITE;
                    case "TNT":
                        return LauncherProfileIcon.TNT;
                    case "Wool":
                        return LauncherProfileIcon.WOOL;
                    default:
                        return LauncherProfileIcon.FURNACE;
                }
            }
            set {
                switch (value) {
                    case LauncherProfileIcon.BEDROCK:
                        _icon = "Bedrock";
                        break;
                    case LauncherProfileIcon.BOOKSHELF:
                        _icon = "Bookshelf";
                        break;
                    case LauncherProfileIcon.CHEST:
                        _icon = "Chest";
                        break;
                    case LauncherProfileIcon.CLAY:
                        _icon = "Clay";
                        break;
                    case LauncherProfileIcon.COAL_BLOCK:
                        _icon = "Coal_Block";
                        break;
                    case LauncherProfileIcon.COAL_ORE:
                        _icon = "Coal_Ore";
                        break;
                    case LauncherProfileIcon.COBBLESTONE:
                        _icon = "Cobblestone";
                        break;
                    case LauncherProfileIcon.DIAMOND_BLOCK:
                        _icon = "Diamond_Block";
                        break;
                    case LauncherProfileIcon.DIAMOND_ORE:
                        _icon = "Diamond_Ore";
                        break;
                    case LauncherProfileIcon.DIRT:
                        _icon = "Dirt";
                        break;
                    case LauncherProfileIcon.DIRT_PODZOL:
                        _icon = "Dirt_Podzol";
                        break;
                    case LauncherProfileIcon.DIRT_SNOW:
                        _icon = "Dirt_Snow";
                        break;
                    case LauncherProfileIcon.EMERALD_BLOCK:
                        _icon = "Emerald_Block";
                        break;
                    case LauncherProfileIcon.EMERALD_ORE:
                        _icon = "Emerald_Ore";
                        break;
                    case LauncherProfileIcon.END_STONE:
                        _icon = "End_Stone";
                        break;
                    case LauncherProfileIcon.FARMLAND:
                        _icon = "Farmland";
                        break;
                    // LauncherProfileIcon.FURNACE icon as null.
                    case LauncherProfileIcon.FURNACE_ON:
                        _icon = "Furnace_On";
                        break;
                    case LauncherProfileIcon.GLASS:
                        _icon = "Glass";
                        break;
                    case LauncherProfileIcon.GLOWSTONE:
                        _icon = "Glowstone";
                        break;
                    case LauncherProfileIcon.GOLD_BLOCK:
                        _icon = "Gold_Block";
                        break;
                    case LauncherProfileIcon.GOLD_ORE:
                        _icon = "Gold_Ore";
                        break;
                    case LauncherProfileIcon.GRAVEL:
                        _icon = "Gravel";
                        break;
                    case LauncherProfileIcon.HARDENED_CLAY:
                        _icon = "Hardened_Clay";
                        break;
                    case LauncherProfileIcon.ICE_PACKED:
                        _icon = "Ice_Packed";
                        break;
                    case LauncherProfileIcon.IRON_BLOCK:
                        _icon = "Iron_Block";
                        break;
                    case LauncherProfileIcon.IRON_ORE:
                        _icon = "Iron_Ore";
                        break;
                    case LauncherProfileIcon.LAPIS_ORE:
                        _icon = "Lapis_Ore";
                        break;
                    case LauncherProfileIcon.LEAVES_BIRCH:
                        _icon = "Leaves_Birch";
                        break;
                    case LauncherProfileIcon.LEAVES_JUNGLE:
                        _icon = "Leaves_Jungle";
                        break;
                    case LauncherProfileIcon.LEAVES_OAK:
                        _icon = "Leaves_Oak";
                        break;
                    case LauncherProfileIcon.LEAVES_SPRUCE:
                        _icon = "Leaves_Spruce";
                        break;
                    case LauncherProfileIcon.LOG_ACACIA:
                        _icon = "Log_Acacia";
                        break;
                    case LauncherProfileIcon.LOG_BIRCH:
                        _icon = "Log_Birch";
                        break;
                    case LauncherProfileIcon.LOG_DARK_OAK:
                        _icon = "Log_DarkOak";
                        break;
                    case LauncherProfileIcon.LOG_JUNGLE:
                        _icon = "Log_Jungle";
                        break;
                    case LauncherProfileIcon.LOG_OAK:
                        _icon = "Log_Oak";
                        break;
                    case LauncherProfileIcon.LOG_SPRUCE:
                        _icon = "Log_Spruce";
                        break;
                    case LauncherProfileIcon.MYCELIUM:
                        _icon = "Mycelium";
                        break;
                    case LauncherProfileIcon.NETHER_BRICK:
                        _icon = "Nether_Brick";
                        break;
                    case LauncherProfileIcon.NETHERRACK:
                        _icon = "Netherrack";
                        break;
                    case LauncherProfileIcon.OBSIDIAN:
                        _icon = "Obsidian";
                        break;
                    case LauncherProfileIcon.PLANKS_ACACIA:
                        _icon = "Planks_Acacia";
                        break;
                    case LauncherProfileIcon.PLANKS_BIRCH:
                        _icon = "Planks_Birch";
                        break;
                    case LauncherProfileIcon.PLANKS_DARK_OAK:
                        _icon = "Planks_DarkOak";
                        break;
                    case LauncherProfileIcon.PLANKS_JUNGLE:
                        _icon = "Planks_Jungle";
                        break;
                    case LauncherProfileIcon.PLANKS_OAK:
                        _icon = "Planks_Oak";
                        break;
                    case LauncherProfileIcon.PLANKS_SPRUCE:
                        _icon = "Planks_Spruce";
                        break;
                    case LauncherProfileIcon.QUARTZ_ORE:
                        _icon = "Quartz_Ore";
                        break;
                    case LauncherProfileIcon.RED_SAND:
                        _icon = "Red_Sand";
                        break;
                    case LauncherProfileIcon.RED_SANDSTONE:
                        _icon = "Red_Sandstone";
                        break;
                    case LauncherProfileIcon.REDSTONE_BLOCK:
                        _icon = "Redstone_Block";
                        break;
                    case LauncherProfileIcon.REDSTONE_ORE:
                        _icon = "Redstone_Ore";
                        break;
                    case LauncherProfileIcon.SAND:
                        _icon = "Sand";
                        break;
                    case LauncherProfileIcon.SANDSTONE:
                        _icon = "Sandstone";
                        break;
                    case LauncherProfileIcon.SNOW:
                        _icon = "Snow";
                        break;
                    case LauncherProfileIcon.SOUL_SAND:
                        _icon = "Soul_Sand";
                        break;
                    case LauncherProfileIcon.STONE:
                        _icon = "Stone";
                        break;
                    case LauncherProfileIcon.STONE_ANDESITE:
                        _icon = "Stone_Andesite";
                        break;
                    case LauncherProfileIcon.STONE_DIORITE:
                        _icon = "Stone_Diorite";
                        break;
                    case LauncherProfileIcon.STONE_GRANITE:
                        _icon = "Stone_Granite";
                        break;
                    case LauncherProfileIcon.TNT:
                        _icon = "TNT";
                        break;
                    case LauncherProfileIcon.WOOL:
                        _icon = "Wool";
                        break;
                    default:
                        _icon = null;
                        break;
                }
            }
        }

        [JsonProperty("type")]
        private string _type { get; set; }

        [JsonIgnore]
        public LauncherProfileType Type
        {
            get {
                switch (_type)
                {
                    case "latest-release":
                        return LauncherProfileType.LATEST_RELEASE;
                    case "latest-snapshot":
                        return LauncherProfileType.LATEST_SNAPSHOT;
                    default:
                        return LauncherProfileType.CUSTOM;
                }
            }
            set {
                switch (value)
                {
                    case LauncherProfileType.LATEST_RELEASE:
                        _type = "latest-release";
                        break;
                    case LauncherProfileType.LATEST_SNAPSHOT:
                        _type = "latest-snapshot";
                        break;
                    default:
                        _type = "custom";
                        break;
                }
            }
        }

        [JsonProperty("lastVersionId")]
        public string SelectedVersion { get; set; }

        [JsonProperty("resolution")]
        public LauncherProfileResolution Resolution { get; set; }

        [JsonProperty("created")]
        public DateTime Created { get; set; } = new DateTime(1970, 1, 1, 0, 0, 0);

        [JsonProperty("lastUsed")]
        public DateTime LastUsed { get; set; } = new DateTime(1970, 1, 1, 0, 0, 0);

        [JsonProperty("gameDir")]
        public string GameDirectory { get; set; }

        [JsonProperty("javaDir")]
        public string JavaDirectory { get; set; }

        [JsonProperty("javaArgs")]
        public string JavaArguments { get; set; }

        [JsonProperty("logConfig")]
        public string LogConfiguration { get; set; }

        [JsonProperty("logConfigIsXML", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool IsLogConfigurationXml { get; set; }
    }
}
