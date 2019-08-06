using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PtaSheet.Classes
{

    /// <summary>
    /// This is a name class; responsible for keeping track of the name, obviously.
    /// </summary>
    public class Name
    {

        public Name()
        {
            First = string.Empty;
            Middle = string.Empty;
            Last = string.Empty;
            Salutation = string.Empty;
            Suffix = string.Empty;
        }

        /// <summary>
        /// This is the first name.
        /// </summary>
        public string First { get; set; }

        /// <summary>
        /// This is the middle initial.
        /// </summary>
        public string Middle { get; set; }

        /// <summary>
        /// This is the last name.
        /// </summary>
        public string Last { get; set; }

        /// <summary>
        /// This is the salutation.
        /// </summary>
        public string Salutation { get; set; }

        /// <summary>
        /// This is the suffix.
        /// </summary>
        public string Suffix { get; set; }

        /// <summary>
        /// Returns a formatted name string.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("{0} {1} {2} {3} {4}", Salutation, First, Middle, Last, Suffix);
        }

    }

    /// <summary>
    /// This is a trainer class. It is responsible for keeping track
    /// of the various Pokemon that a trainer can have.
    /// 
    /// It should eventually allow for full on character sheet management
    /// for a trainer.
    /// </summary>
    public class Trainer
    {

        /// <summary>
        /// This is the name of the trainer.
        /// </summary>
        public Name Name { get; set; }

        /// <summary>
        /// This is the owner.
        /// </summary>
        public string Owner { get; set; }

        /// <summary>
        /// This is the weight of the trainer in kilograms.
        /// </summary>
        public double Weight { get; set; }

        /// <summary>
        /// This is the height of the trainer in meters.
        /// </summary>
        public double Height { get; set; }

        /// <summary>
        /// This is the age of your character.
        /// </summary>
        public int Age { get; set; }


        /// <summary>
        /// Create a new trainer class.
        /// </summary>
        public Trainer()
        {
            Name = new Name { First = string.Empty, Middle = string.Empty, Last = string.Empty, Salutation = string.Empty, Suffix = string.Empty };
            Weight = 0.0;
            Height = 0.0;
        }


        /// <summary>
        /// This will save the Trainer to file.
        /// </summary>
        public void Save()
        {

            // Create variables
            var path = System.IO.Path.Combine(System.Windows.Forms.Application.StartupPath, "Data", Owner, Name.First, string.Format("{0}.xml", Name.First));
            var xml = new ManagedXml.Writer("Trainer");

            // Create attributes
            xml.Root.Attributes.Add(ManagedXml.Attribute.Create("Weight", Weight.ToString()));
            xml.Root.Attributes.Add(ManagedXml.Attribute.Create("Height", Height.ToString()));
            xml.Root.Attributes.Add(ManagedXml.Attribute.Create("Age", Age.ToString()));
            xml.Root.Attributes.Add(ManagedXml.Attribute.Create("Owner", Owner));

            // Create a name element
            var name = ManagedXml.Element.Create("Name");

            // Add the attributes.
            name.Attributes.Add(ManagedXml.Attribute.Create("First", Name.First));
            name.Attributes.Add(ManagedXml.Attribute.Create("Middle", Name.Middle));
            name.Attributes.Add(ManagedXml.Attribute.Create("Last", Name.Last));
            name.Attributes.Add(ManagedXml.Attribute.Create("Salutation", Name.Salutation));
            name.Attributes.Add(ManagedXml.Attribute.Create("Suffix", Name.Suffix));
            
            // Add back
            xml.AddElement(name);

            // Save
            System.IO.File.WriteAllText(path, xml.ToXML());

        }

        /// <summary>
        /// Load a Trainer from file.
        /// </summary>
        /// <param name="name"></param>
        public void Load(string name)
        {

            // Create the path.
            var path = System.IO.Path.Combine(System.Windows.Forms.Application.StartupPath, "Data", name, string.Format("{0}.xml", name));
            var xml = new ManagedXml.Reader(System.IO.File.ReadAllText(path)).Xml;
            var nElement = xml.GetElement("Name");
            var n = new Name();

            // Set root values
            Age = Convert.ToInt32(xml.GetAttributeValue("Age"));
            Weight = Convert.ToDouble(xml.GetAttributeValue("Weight"));
            Height = Convert.ToDouble(xml.GetAttributeValue("Height"));
            Owner = xml.GetAttributeValue("Owner");

            // Set name values
            n.First = nElement.GetAttributeValue("First");
            n.Middle = nElement.GetAttributeValue("Middle");
            n.Last = nElement.GetAttributeValue("Last");
            n.Salutation = nElement.GetAttributeValue("Salutation");
            n.Suffix = nElement.GetAttributeValue("Suffix");

            // Set name to root
            Name = n;

        }

    }

    /// <summary>
    /// The user class allows for the creation of trainers.
    /// </summary>
    public class User
    {

        /// <summary>
        /// This is the username.
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// This is the password.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// This property defines if a user is in fact a game master.
        /// </summary>
        public bool GameMaster { get; set; }

        /// <summary>
        /// This will save the Trainer to file.
        /// </summary>
        public void Save()
        {

            // Create variables
            var path = System.IO.Path.Combine(System.Windows.Forms.Application.StartupPath, "Data", Username, string.Format("{0}.xml", Username));
            var xml = new ManagedXml.Writer("User");

            // Create attributes
            xml.Root.Attributes.Add(ManagedXml.Attribute.Create("Username", Username));
            xml.Root.Attributes.Add(ManagedXml.Attribute.Create("Password", Password));
            xml.Root.Attributes.Add(ManagedXml.Attribute.Create("GameMaster", GameMaster.ToString()));

            // Save
            System.IO.File.WriteAllText(path, xml.ToXML());

        }

        /// <summary>
        /// Load a Trainer from file.
        /// </summary>
        /// <param name="name"></param>
        public void Load(string name)
        {

            // Create the path.
            var path = System.IO.Path.Combine(System.Windows.Forms.Application.StartupPath, "Data", name, string.Format("{0}.xml", name));
            var xml = new ManagedXml.Reader(System.IO.File.ReadAllText(path)).Xml;
            
            // Set name values
            Username = xml.GetAttributeValue("Username");
            Password = xml.GetAttributeValue("Password");
            GameMaster = Convert.ToBoolean(xml.GetAttributeValue("GameMaster"));

        }

    }

}
