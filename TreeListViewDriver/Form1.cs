using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TreeListViewDriver
{
    public partial class Form1 : Form
    {
        private List<Person> m_PersonList;

        public Form1()
        {
            InitializeComponent();
            treeListView1.CanExpandGetter = zCanExpandGetter;
            treeListView1.ChildrenGetter = zChildrenGetter;
            olvColumnLink.AspectGetter = (obj) => "Hyperlink";

            BrightIdeasSoftware.SimpleDropSink sink = (BrightIdeasSoftware.SimpleDropSink)treeListView1.DropSink;
            sink.CanDropBetween = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            m_PersonList = new List<Person>();
            zRefresh();
        }

        private void zRefresh()
        {
            treeListView1.SetObjects(m_PersonList, true);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Person p = Person.Random();
            m_PersonList.Add(p);

            zRefresh();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (treeListView1.SelectedObject != null)
            {
                Person p = (Person)treeListView1.SelectedObject;
                p.FirstName = Person.GetRandomFirstName();

                zRefresh();
            }
        }

        private bool zCanExpandGetter(object model)
        {
            return ((Person)model).Children != null && ((Person)model).Children.Count > 0;
        }

        private IEnumerable zChildrenGetter(object model)
        {
            return ((Person)model).Children;
        }

        private void treeListView1_HyperlinkClicked(object sender, BrightIdeasSoftware.HyperlinkClickedEventArgs e)
        {
            Person p = (Person)e.Model;
            MessageBox.Show(String.Format("{0} {1}", p.FirstName, p.LastName));
            e.Handled = true;
        }

        private void treeListView1_ModelCanDrop(object sender, BrightIdeasSoftware.ModelDropEventArgs e)
        {
            e.Handled = true;
            if (e.DropTargetLocation == BrightIdeasSoftware.DropTargetLocation.None)
            {
                e.Effect = DragDropEffects.None;
                return;
            }
            foreach (object sourceModel in e.SourceModels)
            {
                if (sourceModel == e.TargetModel
                    || (e.DropTargetLocation == BrightIdeasSoftware.DropTargetLocation.Item && treeListView1.GetParent(sourceModel) == e.TargetModel)
                    || IsAncestor(e.TargetModel, sourceModel))
                {
                    e.Effect = DragDropEffects.None;
                    return;
                }
            }
            e.Effect = DragDropEffects.Move;
        }

        private void treeListView1_ModelDropped(object sender, BrightIdeasSoftware.ModelDropEventArgs e)
        {
            switch (e.DropTargetLocation)
            {
                case BrightIdeasSoftware.DropTargetLocation.AboveItem:
                    zMoveObjects((Person)e.TargetModel, e.SourceModels.Cast<Person>(), 0);
                    break;
                case BrightIdeasSoftware.DropTargetLocation.BelowItem:
                    zMoveObjects((Person)e.TargetModel, e.SourceModels.Cast<Person>(), 1);
                    break;
                case BrightIdeasSoftware.DropTargetLocation.Item:
                    zMoveObjects((Person)e.TargetModel, e.SourceModels.Cast<Person>(), -1);
                    break;
                default:
                    return;
            }

            IList selectedObjects = treeListView1.SelectedObjects;
            zRefresh();
            treeListView1.SelectedObjects = selectedObjects;
        }

        private void zMoveObjects(Person target, IEnumerable<Person> toMove, int siblingOffset)
        {
            foreach (Person p in toMove)
            {
                Person parent = (Person)treeListView1.GetParent(p);
                if (parent == null)
                {
                    m_PersonList.Remove(p);
                }
                else
                {
                    parent.Children.Remove(p);
                }
            }

            if (siblingOffset == -1)
            {
                target.Children.AddRange(toMove);
            }
            else
            {
                Person targetParent = (Person)treeListView1.GetParent(target);
                if (targetParent == null)
                {
                    m_PersonList.InsertRange(m_PersonList.IndexOf(target) + siblingOffset, toMove);
                }
                else
                {
                    targetParent.Children.InsertRange(targetParent.Children.IndexOf(target) + siblingOffset, toMove);
                }
            }
        }

        private bool IsAncestor(object subject, object ancestorCandidate)
        {
            if (subject == null || ancestorCandidate == null)
            {
                return false;
            }

            object subjectParent = treeListView1.GetParent(subject);
            if (subjectParent == ancestorCandidate)
            {
                return true;
            }

            return IsAncestor(subjectParent, ancestorCandidate);
        }
    }

    public class Person
    {
        private static Random m_Random = new Random();

        public static Person Random()
        {
            Person p = new Person();
            p.FirstName = GetRandomFirstName();
            p.LastName = GetRandomLastName();
            p.Age = GetRandomAge(30, 60);
            for (int x = 0; x < m_Random.Next(1, 5); x++)
            {
                p.Children.Add(new Person()
                {
                    FirstName = GetRandomFirstName(),
                    LastName = p.LastName,
                    Age = GetRandomAge(1, 19)
                });
            }
            return p;
        }

        public static string GetRandomFirstName()
        {
            List<string> firstNames = new List<string>()
            {
                "John",
                "James",
                "Abe",
                "Gerald",
                "Ben",
                "Walt",
                "Brent",
                "Vinny",
                "Tyrone",
                "Bill",
                "Jim",
                "Anne",
                "Becky",
                "Lisa",
                "Erin",
                "Laura",
                "Lynn",
                "Alice"
            };
            return firstNames[m_Random.Next(firstNames.Count)];
        }

        public static string GetRandomLastName()
        {
            List<string> lastNames = new List<string>()
            {
                "Richardson",
                "Larson",
                "McPhee",
                "Carlson",
                "Babbage",
                "Billing",
                "Notting",
                "Pedersen",
                "Brandt"
            };
            return lastNames[m_Random.Next(lastNames.Count)];
        }

        public static int GetRandomAge(int low, int high)
        {
            return m_Random.Next(low, high);
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public List<Person> Children { get; set; }

        public Person()
        {
            this.Children = new List<Person>();
        }
    }
}
