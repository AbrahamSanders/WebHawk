using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace UBoat.WebHawk.UI
{
    public class ElementScraper
    {
        private class ElementScrapeInfo
        {
            public HtmlElement Element { get; set; }
            public DateTime LastInput { get; set; }
            public string Input { get; set; }
        }

        private Dictionary<HtmlElement, ElementScrapeInfo> m_Elements;
        private Thread m_WorkerThread;
        private TimeSpan m_ScrapeTime;
        private readonly object m_Lock;
        private bool m_Stop;

        public ElementScraper(TimeSpan scrapeTime)
        {
            m_Lock = new object();
            m_Elements = new Dictionary<HtmlElement, ElementScrapeInfo>();
            m_ScrapeTime = scrapeTime;
            m_Stop = true;
        }

        public void Start()
        {
            if (m_Stop)
            {
                m_Stop = false;
                m_WorkerThread = new Thread(zScrape);
                m_WorkerThread.IsBackground = true;
                m_WorkerThread.Start();
            }
        }

        public void Stop()
        {
            if (!m_Stop)
            {
                lock (m_Lock)
                {
                    m_Elements.Clear();
                    m_Stop = true;
                    m_WorkerThread = null;
                }
            }
        }

        public void ElementInput(HtmlElement element)
        {
            lock (m_Lock)
            {
                ElementScrapeInfo scrapeInfo;
                if (!m_Elements.TryGetValue(element, out scrapeInfo))
                {
                    scrapeInfo = new ElementScrapeInfo()
                    {
                         Element = element
                    };
                    m_Elements.Add(element, scrapeInfo);
                }
                scrapeInfo.LastInput = DateTime.Now;
                scrapeInfo.Input = element.GetAttribute("value");
            }
        }

        public void zScrape()
        {
            List<ElementScrapeInfo> completedScrapes = new List<ElementScrapeInfo>();
            while (!m_Stop)
            {
                lock (m_Lock)
                {
                    foreach (HtmlElement key in m_Elements.Keys.ToArray())
                    {
                        ElementScrapeInfo scrapeInfo = m_Elements[key];
                        if (DateTime.Now.Subtract(scrapeInfo.LastInput) >= m_ScrapeTime)
                        {
                            m_Elements.Remove(key);
                            completedScrapes.Add(scrapeInfo);
                        }
                    }
                }

                foreach (ElementScrapeInfo textBox in completedScrapes)
                {
                    zOnElementScraped(new ElementScraperEventArgs()
                    {
                        Element = textBox.Element,
                        ScrapedText = textBox.Input
                    });
                }
                completedScrapes.Clear();
                Thread.Sleep(100);
            }
        }

        public event EventHandler<ElementScraperEventArgs> ElementScraped;
        protected void zOnElementScraped(ElementScraperEventArgs e)
        {
            EventHandler<ElementScraperEventArgs> evnt = ElementScraped;
            if (evnt != null)
            {
                evnt(this, e);
            }
        }
    }

    public class ElementScraperEventArgs : EventArgs
    {
        public HtmlElement Element { get; set; }
        public string ScrapedText { get; set; }
    }
}
