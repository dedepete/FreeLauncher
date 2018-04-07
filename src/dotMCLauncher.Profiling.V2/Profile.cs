using System;
using Newtonsoft.Json;

namespace dotMCLauncher.Profiling.V2
{
    public class Profile
    {
        [JsonIgnore]
        public string AssociatedId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("icon")]
        private string _icon { get; set; }

        [JsonIgnore]
        public ProfileIcon Icon
        {
            get {
                switch (_icon) {
                    case "Bedrock":
                        return ProfileIcon.BEDROCK;
                    case "Bookshelf":
                        return ProfileIcon.BOOKSHELF;
                    case "Chest":
                        return ProfileIcon.CHEST;
                    case "Clay":
                        return ProfileIcon.CLAY;
                    case "Coal_Block":
                        return ProfileIcon.COAL_BLOCK;
                    case "Coal_Ore":
                        return ProfileIcon.COAL_ORE;
                    case "Cobblestone":
                        return ProfileIcon.COBBLESTONE;
                    case "Diamond_Block":
                        return ProfileIcon.DIAMOND_BLOCK;
                    case "Diamond_Ore":
                        return ProfileIcon.DIAMOND_ORE;
                    case "Dirt":
                        return ProfileIcon.DIRT;
                    case "Dirt_Podzol":
                        return ProfileIcon.DIRT_PODZOL;
                    case "Dirt_Snow":
                        return ProfileIcon.DIRT_SNOW;
                    case "Emerald_Block":
                        return ProfileIcon.EMERALD_BLOCK;
                    case "Emerald_Ore":
                        return ProfileIcon.EMERALD_ORE;
                    case "End_Stone":
                        return ProfileIcon.END_STONE;
                    case "Farmland":
                        return ProfileIcon.FARMLAND;
                    case "Furnace_On":
                        return ProfileIcon.FURNACE_ON;
                    case "Glass":
                        return ProfileIcon.GLASS;
                    case "Glowstone":
                        return ProfileIcon.GLOWSTONE;
                    case "Gold_Block":
                        return ProfileIcon.GOLD_BLOCK;
                    case "Gold_Ore":
                        return ProfileIcon.GOLD_ORE;
                    case "Gravel":
                        return ProfileIcon.GRAVEL;
                    case "Hardened_Clay":
                        return ProfileIcon.HARDENED_CLAY;
                    case "Ice_Packed":
                        return ProfileIcon.ICE_PACKED;
                    case "Iron_Block":
                        return ProfileIcon.IRON_BLOCK;
                    case "Iron_Ore":
                        return ProfileIcon.IRON_ORE;
                    case "Lapis_Ore":
                        return ProfileIcon.LAPIS_ORE;
                    case "Leaves_Birch":
                        return ProfileIcon.LEAVES_BIRCH;
                    case "Leaves_Jungle":
                        return ProfileIcon.LEAVES_JUNGLE;
                    case "Leaves_Oak":
                        return ProfileIcon.LEAVES_OAK;
                    case "Leaves_Spruce":
                        return ProfileIcon.LEAVES_SPRUCE;
                    case "Log_Acacia":
                        return ProfileIcon.LOG_ACACIA;
                    case "Log_Birch":
                        return ProfileIcon.LOG_BIRCH;
                    case "Log_DarkOak":
                        return ProfileIcon.LOG_DARK_OAK;
                    case "Log_Jungle":
                        return ProfileIcon.LOG_JUNGLE;
                    case "Log_Oak":
                        return ProfileIcon.LOG_OAK;
                    case "Log_Spruce":
                        return ProfileIcon.LOG_SPRUCE;
                    case "Mycelium":
                        return ProfileIcon.MYCELIUM;
                    case "Nether_Brick":
                        return ProfileIcon.NETHER_BRICK;
                    case "Netherrack":
                        return ProfileIcon.NETHERRACK;
                    case "Obsidian":
                        return ProfileIcon.OBSIDIAN;
                    case "Planks_Acacia":
                        return ProfileIcon.PLANKS_ACACIA;
                    case "Planks_Birch":
                        return ProfileIcon.PLANKS_BIRCH;
                    case "Planks_DarkOak":
                        return ProfileIcon.PLANKS_DARK_OAK;
                    case "Planks_Jungle":
                        return ProfileIcon.PLANKS_JUNGLE;
                    case "Planks_Oak":
                        return ProfileIcon.PLANKS_OAK;
                    case "Planks_Spruce":
                        return ProfileIcon.PLANKS_SPRUCE;
                    case "Quartz_Ore":
                        return ProfileIcon.QUARTZ_ORE;
                    case "Red_Sand":
                        return ProfileIcon.RED_SAND;
                    case "Red_Sandstone":
                        return ProfileIcon.RED_SANDSTONE;
                    case "Redstone_Block":
                        return ProfileIcon.REDSTONE_BLOCK;
                    case "Redstone_Ore":
                        return ProfileIcon.REDSTONE_ORE;
                    case "Sand":
                        return ProfileIcon.SAND;
                    case "Sandstone":
                        return ProfileIcon.SANDSTONE;
                    case "Snow":
                        return ProfileIcon.SNOW;
                    case "Soul_Sand":
                        return ProfileIcon.SOUL_SAND;
                    case "Stone":
                        return ProfileIcon.STONE;
                    case "Stone_Andesite":
                        return ProfileIcon.STONE_ANDESITE;
                    case "Stone_Diorite":
                        return ProfileIcon.STONE_DIORITE;
                    case "Stone_Granite":
                        return ProfileIcon.STONE_GRANITE;
                    case "TNT":
                        return ProfileIcon.TNT;
                    case "Wool":
                        return ProfileIcon.WOOL;
                    default:
                        return ProfileIcon.FURNACE;
                }
            }
            set {
                switch (value) {
                    case ProfileIcon.BEDROCK:
                        _icon = "Bedrock";
                        break;
                    case ProfileIcon.BOOKSHELF:
                        _icon = "Bookshelf";
                        break;
                    case ProfileIcon.CHEST:
                        _icon = "Chest";
                        break;
                    case ProfileIcon.CLAY:
                        _icon = "Clay";
                        break;
                    case ProfileIcon.COAL_BLOCK:
                        _icon = "Coal_Block";
                        break;
                    case ProfileIcon.COAL_ORE:
                        _icon = "Coal_Ore";
                        break;
                    case ProfileIcon.COBBLESTONE:
                        _icon = "Cobblestone";
                        break;
                    case ProfileIcon.DIAMOND_BLOCK:
                        _icon = "Diamond_Block";
                        break;
                    case ProfileIcon.DIAMOND_ORE:
                        _icon = "Diamond_Ore";
                        break;
                    case ProfileIcon.DIRT:
                        _icon = "Dirt";
                        break;
                    case ProfileIcon.DIRT_PODZOL:
                        _icon = "Dirt_Podzol";
                        break;
                    case ProfileIcon.DIRT_SNOW:
                        _icon = "Dirt_Snow";
                        break;
                    case ProfileIcon.EMERALD_BLOCK:
                        _icon = "Emerald_Block";
                        break;
                    case ProfileIcon.EMERALD_ORE:
                        _icon = "Emerald_Ore";
                        break;
                    case ProfileIcon.END_STONE:
                        _icon = "End_Stone";
                        break;
                    case ProfileIcon.FARMLAND:
                        _icon = "Farmland";
                        break;
                    case ProfileIcon.FURNACE:
                        _icon = null;
                        break;
                    case ProfileIcon.FURNACE_ON:
                        _icon = "Furnace_On";
                        break;
                    case ProfileIcon.GLASS:
                        _icon = "Glass";
                        break;
                    case ProfileIcon.GLOWSTONE:
                        _icon = "Glowstone";
                        break;
                    case ProfileIcon.GOLD_BLOCK:
                        _icon = "Gold_Block";
                        break;
                    case ProfileIcon.GOLD_ORE:
                        _icon = "Gold_Ore";
                        break;
                    case ProfileIcon.GRAVEL:
                        _icon = "Gravel";
                        break;
                    case ProfileIcon.HARDENED_CLAY:
                        _icon = "Hardened_Clay";
                        break;
                    case ProfileIcon.ICE_PACKED:
                        _icon = "Ice_Packed";
                        break;
                    case ProfileIcon.IRON_BLOCK:
                        _icon = "Iron_Block";
                        break;
                    case ProfileIcon.IRON_ORE:
                        _icon = "Iron_Ore";
                        break;
                    case ProfileIcon.LAPIS_ORE:
                        _icon = "Lapis_Ore";
                        break;
                    case ProfileIcon.LEAVES_BIRCH:
                        _icon = "Leaves_Birch";
                        break;
                    case ProfileIcon.LEAVES_JUNGLE:
                        _icon = "Leaves_Jungle";
                        break;
                    case ProfileIcon.LEAVES_OAK:
                        _icon = "Leaves_Oak";
                        break;
                    case ProfileIcon.LEAVES_SPRUCE:
                        _icon = "Leaves_Spruce";
                        break;
                    case ProfileIcon.LOG_ACACIA:
                        _icon = "Log_Acacia";
                        break;
                    case ProfileIcon.LOG_BIRCH:
                        _icon = "Log_Birch";
                        break;
                    case ProfileIcon.LOG_DARK_OAK:
                        _icon = "Log_DarkOak";
                        break;
                    case ProfileIcon.LOG_JUNGLE:
                        _icon = "Log_Jungle";
                        break;
                    case ProfileIcon.LOG_OAK:
                        _icon = "Log_Oak";
                        break;
                    case ProfileIcon.LOG_SPRUCE:
                        _icon = "Log_Spruce";
                        break;
                    case ProfileIcon.MYCELIUM:
                        _icon = "Mycelium";
                        break;
                    case ProfileIcon.NETHER_BRICK:
                        _icon = "Nether_Brick";
                        break;
                    case ProfileIcon.NETHERRACK:
                        _icon = "Netherrack";
                        break;
                    case ProfileIcon.OBSIDIAN:
                        _icon = "Obsidian";
                        break;
                    case ProfileIcon.PLANKS_ACACIA:
                        _icon = "Planks_Acacia";
                        break;
                    case ProfileIcon.PLANKS_BIRCH:
                        _icon = "Planks_Birch";
                        break;
                    case ProfileIcon.PLANKS_DARK_OAK:
                        _icon = "Planks_DarkOak";
                        break;
                    case ProfileIcon.PLANKS_JUNGLE:
                        _icon = "Planks_Jungle";
                        break;
                    case ProfileIcon.PLANKS_OAK:
                        _icon = "Planks_Oak";
                        break;
                    case ProfileIcon.PLANKS_SPRUCE:
                        _icon = "Planks_Spruce";
                        break;
                    case ProfileIcon.QUARTZ_ORE:
                        _icon = "Quartz_Ore";
                        break;
                    case ProfileIcon.RED_SAND:
                        _icon = "Red_Sand";
                        break;
                    case ProfileIcon.RED_SANDSTONE:
                        _icon = "Red_Sandstone";
                        break;
                    case ProfileIcon.REDSTONE_BLOCK:
                        _icon = "Redstone_Block";
                        break;
                    case ProfileIcon.REDSTONE_ORE:
                        _icon = "Redstone_Ore";
                        break;
                    case ProfileIcon.SAND:
                        _icon = "Sand";
                        break;
                    case ProfileIcon.SANDSTONE:
                        _icon = "Sandstone";
                        break;
                    case ProfileIcon.SNOW:
                        _icon = "Snow";
                        break;
                    case ProfileIcon.SOUL_SAND:
                        _icon = "Soul_Sand";
                        break;
                    case ProfileIcon.STONE:
                        _icon = "Stone";
                        break;
                    case ProfileIcon.STONE_ANDESITE:
                        _icon = "Stone_Andesite";
                        break;
                    case ProfileIcon.STONE_DIORITE:
                        _icon = "Stone_Diorite";
                        break;
                    case ProfileIcon.STONE_GRANITE:
                        _icon = "Stone_Granite";
                        break;
                    case ProfileIcon.TNT:
                        _icon = "TNT";
                        break;
                    case ProfileIcon.WOOL:
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
        public ProfileType Type
        {
            get {
                switch (_type)
                {
                    case "latest-release":
                        return ProfileType.LATEST_RELEASE;
                    case "latest-snapshot":
                        return ProfileType.LATEST_SNAPSHOT;
                    default:
                        return ProfileType.CUSTOM;
                }
            }
            set {
                switch (value)
                {
                    case ProfileType.LATEST_RELEASE:
                        _type = "latest-release";
                        break;
                    case ProfileType.LATEST_SNAPSHOT:
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
    }
}
