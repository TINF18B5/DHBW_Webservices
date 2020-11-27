using System;
using System.Collections.Generic;

namespace Customer.Hypermedia
{
    public class Siren
    {
        public Siren()
        {
            Class = new List<string>();
            Properties = new List<Property>();
            Entities = new List<Entity>();
            Links = new List<Link>();
            Actions = new List<Action>();
        }

        public List<Action> Actions { get; set; }

        public List<Entity> Entities { get; set; }

        public List<string> Class { get; set; }
        public List<Property> Properties { get; set; }
        public List<Link> Links { get; set; }

    }

    public class Action
    {
        public Action()
        {
            Fields = new List<Object>();
        }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Method { get; set; }
        public string Href { get; set; }
        public string Type { get; set; }
        public List<Object> Fields { get; set; }
    }


    public abstract class Entity
    {
        protected Entity()
        {
            Class = new List<string>();
            Relation = new List<string>();

        }

        public List<string> Relation { get; set; }

        public List<string> Class { get; set; }
    }

    public class EmbeddedLink : Entity
    {
        public string Href { get; set; }
    }

    public class EmbeddedRepresentation : Entity
    {
        public EmbeddedRepresentation()
        {
            Properties = new List<Property>();
            Links = new List<Link>();
        }

        public List<Link> Links { get; set; }

        public List<Property> Properties { get; set; }
    }

    public class Link
    {
        public Link()
        {
            Relation = new List<string>();
        }
        public List<string> Relation { get; set; }
        public string Href { get; set; }
    }



    public class Property
    {
        public string Name { get; set; }
        public object Value { get; set; }
    }
}