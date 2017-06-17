using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using UBoat.Utils.Threading;

namespace UBoat.Utils.DOM
{
    /// <summary>
    /// Wraps a WebBrowser control and provides enhanced element querying and polling functionality,
    /// along with abstracting the thread synchronization required for using the WebBrowser control from other threads.
    /// </summary>
    public class WebBrowserHelper
    {
        #region Private Members

        private WebBrowser m_Browser;
        private TimeSpan m_DefaultPollingTimeout;

        #endregion

        #region Public Properties

        public WebBrowser Browser
        {
            get
            {
                return m_Browser;
            }
        }

        #endregion

        #region Constructor

        public WebBrowserHelper(WebBrowser browser) 
            : this(browser, TimeSpan.FromSeconds(5))
        { }
        public WebBrowserHelper(WebBrowser browser, TimeSpan defaultPollingTimeout)
        {
            m_Browser = browser;
            m_DefaultPollingTimeout = defaultPollingTimeout;
        }

        #endregion

        #region Public Methods

        public void PollElement(ElementIdentifier identifier, Action<HtmlElement> callback)
        {
            PollElement(identifier, m_DefaultPollingTimeout, callback);
        }
        public void PollElement(ElementIdentifier identifier, TimeSpan timeout, Action<HtmlElement> callback)
        {
            PollElement(identifier, null, timeout, callback);
        }
        public void PollElement(ElementIdentifier identifier, HtmlElement relativeTo, Action<HtmlElement> callback)
        {
            PollElement(identifier, relativeTo, m_DefaultPollingTimeout, callback);
        }
        public void PollElement(ElementIdentifier identifier, HtmlElement relativeTo, TimeSpan timeout, Action<HtmlElement> callback)
        {
            PollElements(identifier, relativeTo, timeout, (elementList) => callback(elementList.SingleOrDefault()));
        }

        public void PollElements(ElementIdentifier identifier, Action<List<HtmlElement>> callback)
        {
            PollElements(identifier, m_DefaultPollingTimeout, callback);
        }
        public void PollElements(ElementIdentifier identifier, TimeSpan timeout, Action<List<HtmlElement>> callback)
        {
            PollElements(identifier, null, timeout, callback);
        }
        public void PollElements(ElementIdentifier identifier, HtmlElement relativeTo, Action<List<HtmlElement>> callback)
        {
            PollElements(identifier, relativeTo, m_DefaultPollingTimeout, callback);
        }
        public void PollElements(ElementIdentifier identifier, HtmlElement relativeTo, TimeSpan timeout, Action<List<HtmlElement>> callback)
        {
            //Make initial pass at finding element synchronously (in case element is there, don't waste time starting a task)
            List<HtmlElement> results = FindElements(identifier, relativeTo);
            if (results.Count > 0)
            {
                callback(results);
                return;
            }
            
            //If initial pass returns nothing, start polling task
            Task.Factory.StartNew(() =>
            {
                DateTime start = DateTime.Now;
                bool stop = false;
                while (!stop)
                {
                    ThreadingUtils.InvokeControlAction(Browser, ctl =>
                    {
                        List<HtmlElement> pollResults = FindElements(identifier, relativeTo);
                        if (pollResults.Count > 0 || DateTime.Now.Subtract(start) >= timeout)
                        {
                            stop = true;
                            callback(pollResults);
                        }
                    });
                    Thread.Sleep(100);
                }
            });
        }

        public HtmlElement FindElement(ElementIdentifier identifier)
        {
            return FindElement(identifier, null);
        }
        public HtmlElement FindElement(ElementIdentifier identifier, HtmlElement relativeTo)
        {
            return FindElements(identifier, relativeTo).SingleOrDefault();
        }
        
        public List<HtmlElement> FindElements(ElementIdentifier identifier)
        {
            return FindElements(identifier, null);
        }
        public List<HtmlElement> FindElements(ElementIdentifier identifier, HtmlElement relativeTo)
        {
            List<HtmlElement> results = new List<HtmlElement>();
            HtmlElement baseElement = relativeTo;
            if (baseElement == null)
            {
                baseElement = m_Browser.Document != null ? m_Browser.Document.Body : null;
            }

            //Double slashes (//) will result in a blank array entry. zRecursiveFindElements will treat the empty entry as a descendant indicator.
            //The first blank element of the array is skipped, which is why the array index starts at 1.
            foreach (string path in identifier.Identifiers)
            {
                string[] pathArray = path.Split(new char[] { '/' }, StringSplitOptions.None);
                zRecursiveFindElements(pathArray, 1, baseElement, results);
                if (results.Count > 0)
                {
                    break;
                }
            }
            return results;
        }

        #endregion

        #region Private Methods

        private void zRecursiveFindElements(string[] pathArray, int pathIndex, HtmlElement element, List<HtmlElement> results)
        {
            if (element != null)
            {
                if (pathIndex == pathArray.Length)
                {
                    results.Add(element);
                    return;
                }

                string currentPathElement = pathArray[pathIndex];
                bool searchDescendants = false;
                if (currentPathElement == String.Empty)
                {
                    pathIndex++;
                    if (pathIndex == pathArray.Length || pathArray[pathIndex] == String.Empty)
                    {
                        throw new ArgumentException("XPath contains a blank selector.");
                    }
                    currentPathElement = pathArray[pathIndex];
                    searchDescendants = true;
                }
                string[] elementParts = currentPathElement.Split('[');
                string tagName = elementParts[0].ToLower();
                if (tagName == "html" || tagName == "body" || tagName == ".")
                {
                    zRecursiveFindElements(pathArray, pathIndex + 1, element, results);
                    return;
                }
                string selectorPart = elementParts.Length > 1 ? elementParts[1].Remove(elementParts[1].Length - 1, 1) : null;
                
                //If id selector...
                if (selectorPart != null && selectorPart.StartsWith("@id"))
                {
                    Match idMatch = Regex.Match(selectorPart, "@id=\"(.*?)\"", RegexOptions.IgnoreCase);
                    if (idMatch != null && idMatch.Success)
                    {
                        string idPart = idMatch.Groups[1].Value;
                        HtmlElement elementById = element.Document.GetElementById(idPart);
                        if (elementById != null)
                        {
                            if (tagName == "*" || tagName == elementById.TagName.ToLower())
                            {
                                zRecursiveFindElements(pathArray, pathIndex + 1, elementById, results);
                            }
                            return;
                        }
                    }
                    return;
                }
                
                //If index or no selector...
                List<HtmlElement> children;
                if (searchDescendants)
                {
                    if (tagName == "*")
                    {
                        children = element.All.Cast<HtmlElement>().ToList();
                    }
                    else
                    {
                        children = element.GetElementsByTagName(tagName).Cast<HtmlElement>().ToList();
                    }
                }
                else
                {
                    if (tagName == "*")
                    {
                        children = element.Children.Cast<HtmlElement>().ToList();
                    }
                    else
                    {
                        children = element.Children.Cast<HtmlElement>().Where(e => e.TagName.ToLower() == tagName).ToList();
                    }
                }
                if (selectorPart != null)
                {
                    int index = Convert.ToInt32(selectorPart) - 1;
                    for (int i = children.Count - 1; i >= 0; i--)
                    {
                        if (i != index)
                        {
                            children.RemoveAt(i);
                        }
                    }
                }

                if (children.Count > 0)
                {
                    foreach (HtmlElement child in children)
                    {
                        zRecursiveFindElements(pathArray, pathIndex + 1, child, results);
                    }
                }
            }
        }

        #endregion
    }
}
