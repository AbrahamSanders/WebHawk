using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace UBoat.Utils.DOM
{
    [Serializable]
    public class ElementIdentifier
    {
        #region Static Methods

        public static ElementIdentifier FromHtmlElement(HtmlElement element)
        {
            ElementIdentifier identifier = new ElementIdentifier();
            zBuildElementPaths(element, identifier.Identifiers);
            return identifier;
        }

        public static ElementIdentifier Copy(ElementIdentifier original)
        {
            if (original != null)
            {
                return original.Copy();
            }
            return null;
        }

        private static void zBuildElementPaths(HtmlElement element, List<string> identifiers)
        {
            if (element.Parent != null)
            {
                zBuildElementPaths(element.Parent, identifiers);
            }

            bool hasId = !String.IsNullOrEmpty(element.Id);
            bool isAnchor = hasId || element.Parent == null;

            if (identifiers.Count > 0)
            {
                string indexSelector = zGetElementIndexSelector(element);
                string pathNode = String.Format("/{0}{1}", element.TagName.ToLower(), indexSelector);
                for (int x = 0; x < identifiers.Count; x++)
                {
                    identifiers[x] = String.Format("{0}{1}", identifiers[x], pathNode);
                }
            }
            if (isAnchor)
            {
                string root = hasId ? "//" : "/";
                string tagName = hasId ? "*" : element.TagName.ToLower();
                string selector = hasId ? zGetElementIdSelector(element) : zGetElementIndexSelector(element);
                string pathNode = String.Format("{0}{1}{2}", root, tagName, selector);
                identifiers.Insert(0, pathNode);
            }
        }

        private static string zGetElementIdSelector(HtmlElement element)
        {
            return String.Format("[@id=\"{0}\"]", element.Id);
        }

        private static string zGetElementIndexSelector(HtmlElement element)
        {
            int index = 0;
            HtmlElement parentElement = element.Parent;
            if (parentElement != null)
            {
                List<HtmlElement> siblings = parentElement.Children.Cast<HtmlElement>().Where(e => e.TagName == element.TagName).ToList();
                for (index = 0; index < siblings.Count; index++)
                {
                    if (siblings[index] == element)
                    {
                        break;
                    }
                }
            }
            return String.Format("[{0}]", index + 1); //XPath uses 1 based indices.
        }

        private static string zGetAnchor(string path)
        {
            if (path != null)
            {
                string[] parts = path.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
                return parts.FirstOrDefault();
            }
            return null;
        }

        #endregion

        public List<string> Identifiers { get; private set; }

        [XmlIgnore]
        public string PrimaryIdentifier
        {
            get
            {
                return Identifiers.FirstOrDefault();
            }
            set
            {
                if (Identifiers.Count > 0)
                {
                    Identifiers[0] = value;
                }
                else
                {
                    Identifiers.Add(value);
                }
            }
        }

        public ElementIdentifier()
        {
            Identifiers = new List<string>();
        }

        public ElementIdentifier GetParent()
        {
            ElementIdentifier parent = new ElementIdentifier();
            foreach (string identifier in Identifiers)
            {
                string[] parts = identifier.Split(new char[] { '/' });
                if (parts.Length > 1 && parts[parts.Length - 2] != String.Empty)
                {
                    string parentPath = String.Join("/", parts, 0, parts.Length - 1);
                    parent.Identifiers.Add(parentPath);
                }
            }
            return parent;
        }

        public string GetTagName()
        {
            string documentAnchoredIdentifier = Identifiers.LastOrDefault();
            if (documentAnchoredIdentifier != null)
            {
                string lastElement;
                int lastSeparatorIndex = documentAnchoredIdentifier.LastIndexOf('/');
                if (lastSeparatorIndex == -1)
                {
                    lastElement = documentAnchoredIdentifier;
                }
                else
                {
                    lastElement = documentAnchoredIdentifier.Substring(lastSeparatorIndex + 1);
                }
                int selectorIndex = lastElement.IndexOf('[');
                if (selectorIndex == -1)
                {
                    return lastElement;
                }
                return lastElement.Substring(0, selectorIndex);
            }
            return null;
        }

        public ElementIdentifier RemoveSelector()
        {
            ElementIdentifier selectorRemoved = new ElementIdentifier();
            foreach (string identifier in Identifiers)
            {
                if (!identifier.EndsWith(zGetAnchor(identifier)))
                {
                    int lastSlashIndex = identifier.LastIndexOf('/');
                    int lastBracketIndex = identifier.LastIndexOf('[');
                    selectorRemoved.Identifiers.Add(lastBracketIndex > lastSlashIndex ? identifier.Remove(lastBracketIndex) : identifier);
                }
            }
            return selectorRemoved;
        }

        public ElementIdentifier RelativeTo(ElementIdentifier baseElement)
        {
            if (baseElement != null)
            {
                ElementIdentifier relative = new ElementIdentifier();
                Dictionary<string, string> baseAnchorDictionary = baseElement.ToAnchorDictionary();
                Dictionary<string, string> targetAnchorDictionary = this.ToAnchorDictionary();
                foreach (string baseAnchor in baseAnchorDictionary.Keys)
                {
                    string basePath = baseAnchorDictionary[baseAnchor];
                    string targetPath;
                    if (targetAnchorDictionary.TryGetValue(baseAnchor, out targetPath))
                    {
                        string[] baseParts = basePath.Split('/');
                        string[] targetParts = targetPath.Split('/');
                        string relativePath;
                        if (baseParts.Length == targetParts.Length)
                        {
                            relativePath = ".";
                        }
                        else
                        {
                            relativePath = String.Join("/", targetParts, baseParts.Length, targetParts.Length - baseParts.Length);
                        }
                        relativePath = String.Format("/{0}", relativePath);
                        relative.Identifiers.Add(relativePath);
                        //We only need one path here relative to the base because all paths relative to base paths of matching anchors will be the same.
                        return relative; 
                    }
                }
            }
            return null;
        }

        public ElementIdentifier AbsoluteTo(ElementIdentifier baseElement)
        {
            if (baseElement != null)
            {
                ElementIdentifier absolute = new ElementIdentifier();
                string relativePath = this.PrimaryIdentifier;
                foreach (string identifier in baseElement.Identifiers)
                {
                    absolute.Identifiers.Add(String.Format("{0}{1}", identifier, relativePath));
                }
                return absolute;
            }
            return null;
        }

        public Dictionary<string, string> ToAnchorDictionary()
        {
            return Identifiers.ToDictionary(k => zGetAnchor(k), v => v);
        }

        public ElementIdentifier Copy()
        {
            ElementIdentifier copy = new ElementIdentifier();
            copy.Identifiers.AddRange(this.Identifiers);
            return copy;
        }

        public override string ToString()
        {
            return this.PrimaryIdentifier;
        }
    }
}
