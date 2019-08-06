using System.Collections.Generic;
using System.Windows.Forms;
using Parser.Types;

namespace PokeSheet
{
    public static class Static
    {

        public static List<Pokemon> Pokemon { get; set; }
        public static List<Move> Moves { get; set; }
        public static List<Ability> Abilities { get; set; }
        public static List<Capability> Capabilities { get; set; }

        public static List<object> PokemonCollection { get; set; }

        public static List<Environ> EnvironProperties { get; set; }
        public static List<Berry> Berries { get; set; }
        public static List<Keywords> Keywords { get; set; }

        public static void Load()
        {

            Pokemon = new List<Pokemon>();
            Moves = new List<Move>();
            Abilities = new List<Ability>();
            Capabilities = new List<Capability>();

            EnvironProperties = new List<Environ>();
            Berries = new List<Berry>();
            Keywords = new List<Keywords>();

            if(System.IO.File.Exists(System.IO.Path.Combine(System.Windows.Forms.Application.StartupPath, "Files", "pokemon.xml")))
            {
                var stream = new System.IO.StreamReader(System.IO.Path.Combine(System.Windows.Forms.Application.StartupPath, "Files", "pokemon.xml"));
                var reader = new System.Xml.Serialization.XmlSerializer(typeof (List<Pokemon>));
                Pokemon = (List<Pokemon>) reader.Deserialize(stream);
                stream.Close();
            }
            if (System.IO.File.Exists(System.IO.Path.Combine(System.Windows.Forms.Application.StartupPath, "Files", "abilities.xml")))
            {
                var stream = new System.IO.StreamReader(System.IO.Path.Combine(System.Windows.Forms.Application.StartupPath, "Files", "abilities.xml"));
                var reader = new System.Xml.Serialization.XmlSerializer(typeof(List<Ability>));
                Abilities = (List<Ability>)reader.Deserialize(stream);
                stream.Close();
            }
            if (System.IO.File.Exists(System.IO.Path.Combine(System.Windows.Forms.Application.StartupPath, "Files", "move.xml")))
            {
                var stream = new System.IO.StreamReader(System.IO.Path.Combine(System.Windows.Forms.Application.StartupPath, "Files", "move.xml"));
                var reader = new System.Xml.Serialization.XmlSerializer(typeof(List<Move>));
                Moves = (List<Move>)reader.Deserialize(stream);
                stream.Close();
            }
            if (System.IO.File.Exists(System.IO.Path.Combine(System.Windows.Forms.Application.StartupPath, "Files", "capabilities.xml")))
            {
                var stream = new System.IO.StreamReader(System.IO.Path.Combine(System.Windows.Forms.Application.StartupPath, "Files", "capabilities.xml"));
                var reader = new System.Xml.Serialization.XmlSerializer(typeof(List<Capability>));
                Capabilities = (List<Capability>)reader.Deserialize(stream);
                stream.Close();
            }

            PokemonCollection = new List<object>();
            foreach (var pokemon in Pokemon)
            {
                PokemonCollection.Add(pokemon.Name);
            }

        }

    }
}
