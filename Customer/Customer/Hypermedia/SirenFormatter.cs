using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Formatters;

namespace Customer.Hypermedia
{
    public class SirenFormatter : OutputFormatter
    {
        public SirenFormatter()
        {
            SupportedMediaTypes.Add("application/vnd.siren+json");
        }
        protected override bool CanWriteType(Type type)
        {
            if (typeof(Siren).IsAssignableFrom(type))
            {
                return base.CanWriteType(type);
            }
            return false;
        }
        public override async Task WriteResponseBodyAsync(OutputFormatterWriteContext context)
        {
            var response = context.HttpContext.Response;
            var s = context.Object as Siren;
            var json = ToJson(s);
            byte[] buf = Encoding.UTF8.GetBytes(json);
            await response.Body.WriteAsync(buf, 0, buf.Length);
        }

        private string ToJson(Siren s)
        {
            var sb = new StringBuilder();
            sb.Append("{");
            SerializeClass(sb, s.Class);
            sb.Append(",");
            SerializeProperties(sb, s.Properties);
            sb.Append(",");
            SerializeEntities(sb, s.Entities);
            sb.Append(",");
            SerializeActions(sb, s.Actions);
            sb.Append(",");
            SerializeLinks(sb, s.Links);
            sb.Append("}");

            return sb.ToString();
        }

        private void SerializeLinks(StringBuilder sb, List<Link> links)
        {
            sb.Append("\"links\":[");
            for (int i = 0; i < links.Count; i++)
            {
                var link = links[i];
                sb.Append("{");
                sb.Append("\"rel\"");
                sb.Append(":");

                SerializeRelation(sb, link.Relation);
                sb.Append(",");
                sb.Append("\"href\":\"").Append(link.Href).Append("\"");
                sb.Append("}");
                if (i < links.Count - 1)
                {
                    sb.Append(",");
                }

            }
            sb.Append("]");
        }

        private static void SerializeRelation(StringBuilder sb, List<string> relation)
        {
            sb.Append("[");
            for (int j = 0; j < relation.Count; j++)
            {
                var rel = relation[j];
                sb.Append("\"");
                sb.Append(rel);
                sb.Append("\"");
                if (j < relation.Count - 1)
                {
                    sb.Append(",");
                }
            }
            sb.Append("]");
        }

        private void SerializeActions(StringBuilder sb, List<Action> actions)
        {
            sb.Append("\"actions\":[");
            for (int i = 0; i < actions.Count; i++)
            {
                var action = actions[i];
                sb.Append("{");
                sb.Append("\"name\":\"").Append(action.Name).Append("\",");
                sb.Append("\"title\":\"").Append(action.Title).Append("\",");
                sb.Append("\"method\":\"").Append(action.Method).Append("\",");
                sb.Append("\"href\":\"").Append(action.Href).Append("\",");
                sb.Append("\"type\":\"").Append(action.Type).Append("\",");
                sb.Append("\"fields\":").Append(Newtonsoft.Json.JsonConvert.SerializeObject(action.Fields));

                sb.Append("}");
                if (i < actions.Count - 1)
                {
                    sb.Append(",");
                }

            }
            sb.Append("]");
        }

        private void SerializeEntities(StringBuilder sb, List<Entity> entities)
        {
            sb.Append("\"entities\":[");
            for (int i = 0; i < entities.Count; i++)
            {
                var entity = entities[i];
                sb.Append("{");
                if (entity is EmbeddedRepresentation)
                {
                    SerializeEmbededEntity(sb, entity as EmbeddedRepresentation);
                }
                else if (entity is EmbeddedLink)
                {
                    SerializeEmbededLink(sb, entity as EmbeddedLink);
                }
                sb.Append("}");
                if (i < entities.Count - 1)
                {
                    sb.Append(",");
                }
            }
            sb.Append("]");
        }

        private void SerializeEmbededLink(StringBuilder sb, EmbeddedLink entity)
        {
            throw new NotImplementedException();
        }

        private void SerializeEmbededEntity(StringBuilder sb, EmbeddedRepresentation entity)
        {
            SerializeClass(sb, entity.Class);
            sb.Append(",");
            sb.Append("\"rel\"");
            sb.Append(":");

            SerializeRelation(sb, entity.Relation);
            sb.Append(",");
            SerializeProperties(sb, entity.Properties);
            sb.Append(",");
            SerializeLinks(sb, entity.Links);
        }

        private void SerializeProperties(StringBuilder sb, List<Property> properties)
        {
            sb.Append("\"properties\":{");
            for (int i = 0; i < properties.Count; i++)
            {
                var property = properties[i];
                sb.Append("\"");
                sb.Append(property.Name);
                sb.Append("\"");
                sb.Append(":");
                var serializedValue = Newtonsoft.Json.JsonConvert.SerializeObject(property.Value);
                sb.Append(serializedValue);
                if (i < properties.Count - 1)
                {
                    sb.Append(",");
                }
            }
            sb.Append("}");
        }

        private void SerializeClass(StringBuilder sb, List<string> classes)
        {
            sb.Append("\"class\":[");
            for (int i = 0; i < classes.Count; i++)
            {
                sb.Append("\"").Append(classes[i]).Append("\"");
                if (i < classes.Count - 1)
                {
                    sb.Append(",");
                }
            }
            sb.Append("]");
        }
    }
}